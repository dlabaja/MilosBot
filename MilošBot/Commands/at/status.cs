using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.API;
using Discord.Rest;
using Discord.WebSocket;
using System.Text;

namespace MilošBot.Commands
{
    public class status : ModuleBase<SocketCommandContext>
    {
        private DiscordSocketClient client;

        [Command("status")]
        [RequireUserPermission(GuildPermission.ManageRoles, ErrorMessage = "O co se to jako snažíš? :what:")]
        public async Task Andrejsaurus()
        {
            client = new DiscordSocketClient();
            var casik = DateTime.Parse("Jul 15, 2021") - DateTime.Now;
            await client.SetActivityAsync(new Game("cestu kolem hradu co skončí za " + casik.Days + " dní", ActivityType.Playing, ActivityProperties.None));
        }
    }
}