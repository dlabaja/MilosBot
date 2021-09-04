using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Prekladac : ModuleBase<SocketCommandContext>
    {
        [Command("gay")]
        [Summary("Jak moc je tvůj kamarád gay?")]
        public async Task Ping([Remainder] string user = null)
        {
            Emote tomio = Emote.Parse("<:hotGayPornosTomio:719272936757919847>");
            Emote qwer = Emote.Parse("<:gayqwer:814392134878101524>");
            var User1 = Context.User as SocketGuildUser;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Volič");
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Starosta");
            var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");

            if (User1.Roles.Contains(role) || User1.Roles.Contains(role2) || User1.Roles.Contains(role3))
            {
                Random random = new Random();
                int ovce = random.Next(101);

                if (user == null)
                {
                    await ReplyAsync("> " + tomio + " Jsi z " + ovce + "% gej lul " + qwer);
                }
                else
                {
                    await ReplyAsync("> " + tomio + " " + user + " je z " + ovce + "% gej lul " + qwer);
                }
            }
            else
            {
                await ReplyAsync("O co se to jako snažíš? Tento příkaz je až od levelu 3!");
            }
        }
    }
}