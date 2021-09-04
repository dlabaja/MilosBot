using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class furajhry : ModuleBase<SocketCommandContext>
    {
        [Command("mir")]
        [Summary("Tajný příkaz pro buchtu")]
        public async Task Ping([Remainder] string user = null)
        {
            Emote qwer = Emote.Parse("<:cum:806068570604961812>");
            Emote qwer1 = Emote.Parse("<:omegalul:787672799572394034>");
            var User1 = Context.User as SocketGuildUser;
            string slovo = Context.User.Id.ToString();
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Volič");
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Starosta");
            var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");

            if (User1.Roles.Contains(role) || User1.Roles.Contains(role2) || User1.Roles.Contains(role3))
            {
                Random random = new Random();
                int ovce = random.Next(1, 3);
                if (slovo == "815656020713537556" && ovce == 1) { await Context.Channel.SendMessageAsync("NE! " + qwer1); }
                else { await Context.Channel.SendMessageAsync("Velice rád 🤩 " + qwer); }
            }
        }
    }
}