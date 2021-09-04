using Discord;
using Discord.Commands;
using MilošBot.Commands.Attributes;
using MilošBot.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    [Group("MilosBot")]
    public class MilosBotModule : ModuleBase<SocketCommandContext>
    {
        private readonly UpTimeService _upTime;

        public MilosBotModule(UpTimeService upTimeService)
        {
            _upTime = upTimeService;
        }

        [Command("Status")]
        public async Task BotStatusAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "Jak jsem na tom?",
                Fields = new System.Collections.Generic.List<EmbedFieldBuilder>()
                {
                    new EmbedFieldBuilder() { Name = "Start time", Value = _upTime.StartTime, IsInline = true },
                    new EmbedFieldBuilder() { Name = "Up time", Value = _upTime.UpTime.ToString("dd\\d\\ hh\\:mm"), IsInline = true },
                    new EmbedFieldBuilder() { Name = "Latency", Value = Context.Client.Latency, IsInline = true },
                }
            };
            await ReplyAsync(embed: eb.Build());
        }

        [Command("Nick", true)]
        [RequiredRole(803893381863571497, ErrorMessage = "Potřebuješ politika aby jsi to mohl použít.")]
        [GuildCommandCooldown(0, 30, 0)]
        public async Task MildaNickAsync(string newNick)
        {
            var user = Context.Guild.Users.First(x => x.Id == Context.Client.CurrentUser.Id);
            await user.ModifyAsync(x => x.Nickname = newNick);
        }

        [Command("Status")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task MildaNickAsync(string? name = null, string? activityType = null, string? activityProperties = null, string? details = null)
        {
            if (name is null)
            {
                await ReplyAsync("Zapoměl jsi zaat status.");
                return;
            }
            if (!Enum.TryParse<ActivityType>(activityType, true, out var type))
                type = ActivityType.Playing;
            if (!Enum.TryParse<ActivityProperties>(activityProperties, true, out var properties))
                properties = ActivityProperties.None;
            await Context.Client.SetActivityAsync(new Game(name, type, properties, details));
        }
    }
}