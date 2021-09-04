using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Weeb : ModuleBase<SocketCommandContext>
    {
        [Command("weeb")]
        [Summary("Koupelny ptáček approves")]
        public async Task WeebAsync([Remainder] string user = null)
        {
            Emote hype = Emote.Parse("<:hype:828343646654038018>");
            Emote happy = Emote.Parse("<:happy:802228598681370624>");
            Emote cmolik = Emote.Parse("<:cmolik:823833616735666186>");
            Emote cum = Emote.Parse("<:cum:806068570604961812>");
            Emote uwu = Emote.Parse("<:UwU:818579834237485076>");
            var User1 = Context.User as SocketGuildUser;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Volič");
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Starosta");
            var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");

            if (User1.Roles.Contains(role) || User1.Roles.Contains(role2) || User1.Roles.Contains(role3))
            {
                Emote emoji;
                Random random = new Random();
                int ovce = random.Next(101);

                if (ovce > 90)
                    emoji = uwu;
                else if (ovce > 75 && ovce < 90)
                    emoji = cum;
                else if (ovce > 45 && ovce < 75)
                    emoji = happy;
                else if (ovce > 20 && ovce < 45)
                    emoji = cmolik;
                else
                    emoji = hype;

                if (user == null)
                {
                    await ReplyAsync("> Jsi z " + ovce + "% weeb " + emoji);
                }
                else
                {
                    await ReplyAsync("> " + user + " je z " + ovce + "% weeb " + emoji);
                }
            }
            else
            {
                await Context.Message.Channel.SendMessageAsync("O co se to jako snažíš? Tato funkce je dostupná až od levelu 3!");
            }
        }
    }
}