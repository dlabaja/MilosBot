using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using MilošBot.Commands;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MilošBot.Services
{
    class MutedUser
    {
        public ulong Id { get; set; }
        public ulong[] RolesId { get; set; } = default!;
        public DateTime? EndMute { get; set; }
    }

    public class MuteServise
    {
        const ulong MuteRoleId = 805744049877286942;
        readonly IServiceProvider _services;
        readonly DiscordSocketClient _discordSocketClient;
        IMongoCollection<MutedUser> Table => _services.GetRequiredService<IMongoClient>().GetDatabase("dbl").GetCollection<MutedUser>("Mute");
        Dictionary<ulong, CancellationTokenSource> TempMutedTasks = new Dictionary<ulong, CancellationTokenSource>();
        public MuteServise(IServiceProvider services, DiscordSocketClient discordSocketClient)
        {
            _services = services;
            _discordSocketClient = discordSocketClient;
            discordSocketClient.Ready += DiscordSocketClient_Ready;
        }

        private Task DiscordSocketClient_Ready()
        {
            TempMutedTasks = new Dictionary<ulong, CancellationTokenSource>();
            var collection = Table.FindAsync(x => true).GetAwaiter().GetResult().ToListAsync().GetAwaiter().GetResult();
            foreach (var item in collection)
            {
                if (item.EndMute is object)
                {
                    var time = item.EndMute.Value - DateTime.Now;
                    if (time < TimeSpan.Zero)
                    {
                        CreateUnmuteTask(item.Id, TimeSpan.Zero, default).ConfigureAwait(false);
                    }
                    else
                    {
                        var cts = new CancellationTokenSource();
                        CreateUnmuteTask(item.Id, time, cts.Token).ConfigureAwait(false);
                        TempMutedTasks.Add(item.Id, cts);
                    }
                }
            }
            return Task.CompletedTask;
        }

        public async Task CreateUnmuteTask(ulong userId, TimeSpan time, CancellationToken token)
        {
            await Task.Delay(time, token);
            var user = _discordSocketClient.Guilds.First(x => x.Id == 719247194145816686).GetUser(userId);
            await UnmuteUserAsync(user);
        }

        public async Task<bool> CheckMuteAsync(IGuildUser user)
        {
            var collection = await (await Table.FindAsync(x => true)).ToListAsync();
            var mutedUser = collection.FirstOrDefault(x => x.Id == user.Id);
            if (mutedUser is null)
            {
                return false;
            }
            if (!mutedUser.EndMute.HasValue)
            {
                await MuteUserAsync(user);
                return true;
            }
            var time = mutedUser.EndMute.Value - DateTime.Now;
            if (time < TimeSpan.Zero)
            {
                return !await UnmuteUserAsync(user);
            }
            else
            {
                var cts = new CancellationTokenSource();
                CreateUnmuteTask(user.Id, time, cts.Token);
                TempMutedTasks.Add(user.Id, cts);
            }
            return true;
        }

        public async Task<bool> MuteUserAsync(IGuildUser user)
        {
            var collection = await (await Table.FindAsync(x => true)).ToListAsync();
            var mutedUser = collection.FirstOrDefault(x => x.Id == user.Id);
            if (mutedUser is object)
            {
                return false;
            }
            var sockedUser = user as SocketGuildUser;
            mutedUser = new MutedUser()
            {
                Id = user.Id,
                RolesId = sockedUser.Roles.Where(x => !x.IsEveryone).Select(x => x.Id).ToArray()
            };
            await user.RemoveRolesAsync(mutedUser.RolesId);
            await user.AddRoleAsync(MuteRoleId);
            await Table.InsertOneAsync(mutedUser);
            return true;
        }

        public async Task<bool> UnmuteUserAsync(IGuildUser user)
        {
            var collection = await (await Table.FindAsync(x=>true)).ToListAsync();
            var mutedUser = collection.FirstOrDefault(x => x.Id == user.Id);
            if (mutedUser is null)
            {
                return false;
            }
            if (TempMutedTasks.ContainsKey(user.Id))
            {
                TempMutedTasks[user.Id].Cancel();
                TempMutedTasks.Remove(user.Id);
            }
            await Table.DeleteOneAsync(x => x.Id == user.Id);
            await user.RemoveRoleAsync(MuteRoleId);
            await user.AddRolesAsync(mutedUser.RolesId);
            return true;
        }

        public async Task<bool> TempMuteUserAsync(IGuildUser user, TimeSpan time)
        {
            var collection = await (await Table.FindAsync(x => true)).ToListAsync();
            var mutedUser = collection.FirstOrDefault(x => x.Id == user.Id);
            if (mutedUser is object)
            {
                return false;
            }
            var sockedUser = user as SocketGuildUser;
            mutedUser = new MutedUser()
            {
                Id = user.Id,
                RolesId = sockedUser.Roles.Where(x => !x.IsEveryone).Select(x => x.Id).ToArray(),
                EndMute = DateTime.Now + time
            };
            await Table.InsertOneAsync(mutedUser);
            await user.AddRoleAsync(MuteRoleId);
            await user.RemoveRolesAsync(mutedUser.RolesId);
            var cts = new CancellationTokenSource(time);
            CreateUnmuteTask(user.Id, time, cts.Token);
            TempMutedTasks.TryAdd(user.Id, cts);
            return true;
        }
    }
}
