using Discord;
using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using MilošBot.Commands.Attributes;
using MilošBot.Extensions;
using MilošBot.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands.at
{
    public class ModerationModule : ModuleBase<SocketCommandContext>
    {
        const string defaultReason = "Dostal jsi trest protože ses neuměl chovat.";
        readonly MuteServise _muteServise;
        readonly ILogger _logger;

        public ModerationModule(MuteServise muteServise, ILogger<ModerationModule> logger)
        {
            _muteServise = muteServise;
            _logger = logger;
        }

        [Command("Add")]
        [RequireUserPermission(GuildPermission.ManageRoles, ErrorMessage = "Nemáš oprávnění měnit role.")]
        public async Task AddRolesAsync(IGuildUser user, params IRole[] roles)
        {
            if (Context.User is SocketGuildUser guildUser)
            {
                var max = Math.Min(guildUser.Hierarchy == int.MaxValue ? int.MaxValue : guildUser.Roles.Max(x => x.Position),
                    Context.Guild.Users.First(x => x.Id == Context.Client.CurrentUser.Id).Roles.Max(x => x.Position));
                var cant = roles.Where(x => x.Position >= max);
                var can = roles.Where(x => x.Position < max);
                await user.AddRolesAsync(can);
                await ReplyAsync(cant.Any()
                    ? $"Na přidání některých rolí nemám já nebo ty dostatečné oprávnění: {string.Join(", ", cant.Select(x => $"`{x.Name}`"))}"
                    : "Všechny role přidány"
                    );

                var eb = new EmbedBuilder()
                {
                    Description = @$"Proběhl pokus o přidání rolí uživateli {user.Mention},
úspěšně přidáno: {string.Join(", ", can.Select(x => $"`{x.Name}`"))}
neúspěšně přidáno: {string.Join(", ", cant.Select(x => $"`{x.Name}`"))}"
                }.WithAuthor(guildUser);
                _logger.LogEmbed(LogLevel.Information, eb);
            }
        }

        [Command("Remove")]
        [RequireUserPermission(GuildPermission.ManageRoles, ErrorMessage = "Nemáš oprávnění měnit role.")]
        public async Task RemoveRolesAsync(IGuildUser user, params IRole[] roles)
        {
            if (Context.User is SocketGuildUser guildUser)
            {
                var max = Math.Min(guildUser.Hierarchy == int.MaxValue ? int.MaxValue : guildUser.Roles.Max(x => x.Position),
                    Context.Guild.Users.First(x => x.Id == Context.Client.CurrentUser.Id).Roles.Max(x => x.Position));
                var cant = roles.Where(x => x.Position >= max);
                var can = roles.Where(x => x.Position < max);
                await user.RemoveRolesAsync(can);
                await ReplyAsync(cant.Any()
                    ? $"Na odstranení některých rolí nemám já nebo ty dostatečné oprávnění: {string.Join(", ", cant.Select(x => $"`{x.Name}`"))}"
                    : "Všechny role odebrány"
                    );
                var eb = new EmbedBuilder()
                {
                    Description = @$"Proběhl pokus o oddělání rolí uživateli {user.Mention},
úspěšně odděláno: {string.Join(", ", can.Select(x => $"`{x.Name}`"))}
neúspěšně odděláno: {string.Join(", ", cant.Select(x => $"`{x.Name}`"))}"
                }.WithAuthor(guildUser);
                _logger.LogEmbed(LogLevel.Information, eb);
            }
        }

        [Command("Ban")]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage = "O co se to jako snažíš? :what:")]
        public async Task BanAsync([NotAuthor, CheckUserHierarchy] IGuildUser? user = null, string reason = defaultReason)
        {
            if (user is null)
            {
                await ReplyAsync("Zadejte uživatele k zabanování.");
                return;
            }
            var eb = new EmbedBuilder()
            {
                Title = "Miloš někoho vykopnul!",
                Description = $"**{user.Mention} se neuměl chovat, tak dostal ban.**\nDůvod: {reason}",
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Powered by MilošBot",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());

            eb = new EmbedBuilder()
            {
                Description = $"{user.Mention}({user}) dostal ban.\nDůvod: {reason}"
            }.WithAuthor(Context.User);
            _logger.LogEmbed(LogLevel.Information, eb);
            await Context.Guild.AddBanAsync(user, 0, reason);
        }

        [Command("Unban")]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage = "O co se to jako snažíš? :what:")]
        public async Task UnbanAsync(string? user)
        {
            var bans = await Context.Guild.GetBansAsync();
            RestBan? ban;
            if (ulong.TryParse(user, out var id))
            {
                ban = bans.FirstOrDefault(x => x.User.Id == id);
            }
            else
            {
                bans = bans.Where(x => x.User.Username.Equals(user, StringComparison.InvariantCultureIgnoreCase) || x.ToString().Equals(user, StringComparison.InvariantCultureIgnoreCase)).ToArray();
                if (bans.Count > 1)
                {
                    var eb = new EmbedBuilder()
                    {
                        Title = "Seznam potensionálních lidí k unbanování."
                    };
                    foreach (var item in bans)
                    {
                        eb.Description += $"{item.User}\n";
                    }
                    await ReplyAsync(embed: eb.Build());
                    return;
                }
                else
                {
                    ban = bans.FirstOrDefault();
                }
            }
            if (ban is object)
            {
                await Context.Guild.RemoveBanAsync(ban.User);
                await ReplyAsync($"Uživatel {ban.User.Mention} byl právě odbanován.");
                var eb = new EmbedBuilder()
                {
                    Description = $"{ban} dostal unban."
                }.WithAuthor(Context.User);
                _logger.LogEmbed(LogLevel.Information, eb);
            }
            else
            {
                await ReplyAsync("Nenašel se žádný uživatel k odbanování");
            }
        }

        [Command("Kick")]
        [RequireUserPermission(GuildPermission.KickMembers, ErrorMessage = "O co se to jako snažíš? :what:")]
        public async Task KincAsync([NotAuthor, CheckUserHierarchy] IGuildUser? user = null, string reason = defaultReason)
        {
            if (user is null)
            {
                await ReplyAsync("Zadejte uživatele k vyhození.");
                return;
            }
            var eb = new EmbedBuilder()
            {
                Title = "Miloš někoho vykopnul!",
                Description = $"**<:aaatycuraku: 766567796783316992 > {user.Mention} se neuměl chovat, tak ho Miloš vykopl svou hůlčičkou\nDůvod: **{reason}**",
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Powered by MilošBot",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());
            eb = new EmbedBuilder()
            {
                Description = $"{user.Mention}({user}) byl vyhozen."
            }.WithAuthor(Context.User);
            _logger.LogEmbed(LogLevel.Information, eb);
            await user.KickAsync();
        }

        [Command("Mute")]
        [RequireUserPermission(GuildPermission.ManageRoles, ErrorMessage = "O co se to jako snažíš? :what:")]
        public async Task MuteAsync([NotAuthor, CheckUserHierarchy] IGuildUser? user = null, string reason = defaultReason)
        {
            if (user is null)
            {
                await ReplyAsync("Zadejte uživatele k mutnutí.");
                return;
            }
            if (await _muteServise.MuteUserAsync(user))
            {
                var eb = new EmbedBuilder()
                {
                    Description = $"{user.Mention}({user}) dostal mute."
                }.WithAuthor(Context.User);
                _logger.LogEmbed(LogLevel.Information, eb);
                await ReplyAsync($"Uživatel {user.Mention} dostal mute");
            }
            else
            {
                await ReplyAsync("Nepodařilo se dát Mute.");
            }
        }

        [Command("TempMute")]
        [RequireUserPermission(GuildPermission.ManageRoles, ErrorMessage = "O co se to jako snažíš? :what:")]
        public async Task TempMuteAsync([CheckUserHierarchy] IGuildUser? user = null, TimeSpan? time = null, string reason = defaultReason)
        {
            if (user is null)
            {
                await ReplyAsync("Zadejte uživatele k dočasnému mutnutí.");
                return;
            }
            var muteTime = time ?? new TimeSpan(0, 10, 0);
            if (await _muteServise.TempMuteUserAsync(user, muteTime))
            {
                var eb = new EmbedBuilder()
                {
                    Description = $"{user.Mention}({user}) dostal tempMute na {muteTime}."
                }.WithAuthor(Context.User);
                _logger.LogEmbed(LogLevel.Information, eb);
            }
            else
            {
                await ReplyAsync("Nepodařilo se dát TempMute.");
            }
        }

        [Command("Unmute")]
        [RequireUserPermission(GuildPermission.ManageRoles, ErrorMessage = "O co se to jako snažíš? :what:")]
        public async Task UnmuteAsync(IGuildUser? user = null)
        {
            if (user is null)
            {
                await ReplyAsync("Zadejte uživatele neexistuje");
                return;
            }
            if (await _muteServise.UnmuteUserAsync(user))
            {
                var eb = new EmbedBuilder()
                {
                    Description = $"Uživatel {user.Mention} dostal Unmute."
                }.WithAuthor(Context.User);
                _logger.LogEmbed(LogLevel.Information, eb);
                await ReplyAsync($"Uživatel {user.Mention} už nemá mute.");
            }
            else
            {
                await ReplyAsync("Nepodařilo se dát Unmute, zadaný uživatel možná nemá mute.");
            }
        }

        [Command("clean")]
        [RequireUserPermission(ChannelPermission.ManageMessages, ErrorMessage = "Nemáš oprávnění mazat zprávy")]
        public async Task CleanAsync(ushort count = 0)
        {
            var messages = await Context.Channel.GetMessagesAsync(count + 1).FlattenAsync();
            if (Context.Channel is SocketTextChannel channel)
            {
                await channel.DeleteMessagesAsync(messages.Select(x => x.Id));
                var eb = new EmbedBuilder()
                {
                    Description = $"Mazání {count}+1 zpráv v {Context.Channel.Name}"
                }.WithAuthor(Context.User);
                _logger.LogEmbed(LogLevel.Information, eb);
            }
            else
            {
                await ReplyAsync("Něco se nepovedddlo při mazání zpráv.");
            }
        }

        [Command("EditMsg")]
        [RequireUserPermission(ChannelPermission.ManageMessages, ErrorMessage = "Nemáš oprávnění editovat milošovi zprávy")]
        public async Task EditMsg(ulong messageId, string content)
        {
            var msg = await Context.Channel.GetMessageAsync(messageId);
            if (msg is IUserMessage umsg && umsg.Author.Id == Context.Client.CurrentUser.Id)
                await umsg.ModifyAsync(x => x.Content = content);
        }
    }
}
