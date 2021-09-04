using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class iq : ModuleBase<SocketCommandContext>
    {
        [Command("iq")]
        [Summary("Jaké má tvůj kamarád iq?")]
        public async Task Ping([Remainder] string user = null)
        {
            Emote harold = Emote.Parse("<:harold:778284746013671464>");
            Emote tuktuk = Emote.Parse("<:tuktuk:766590238407000084>");
            Emote bigbrain = Emote.Parse("<:bigbrain:798651688352874506>");
            var User1 = Context.User as SocketGuildUser;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Volič");
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Starosta");
            var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");

            if (User1.Roles.Contains(role) || User1.Roles.Contains(role2) || User1.Roles.Contains(role3))
            {
                Emote emoji;
                Random random = new Random();
                int ovce = random.Next(250);

                if (ovce < 90)
                    emoji = harold;
                else if (ovce >= 90 && ovce < 140)
                    emoji = tuktuk;
                else
                    emoji = bigbrain;

                if (user == null)
                {
                    await ReplyAsync("> Tvé iq je " + ovce + " " + emoji);
                }
                else
                {
                    await ReplyAsync("> " + user + " má iq " + ovce + " " + emoji);
                }
            }
            else
            {
                await Context.Message.Channel.SendMessageAsync("O co se to jako snažíš? Tato funkce je dostupná až od levelu 3!");
            }
        }
    }
}