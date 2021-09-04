using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class furjhry : ModuleBase<SocketCommandContext>
    {
        [Command("furry")]
        [Summary("Jak moc je tvůj kamarád furry?")]
        public async Task Ping([Remainder] string user = null)
        {
            Emote tomio = Emote.Parse("<:hotGayPornosTomio:719272936757919847>");
            Emote qwer = Emote.Parse("<:furik:775744281380913192>");
            var User1 = Context.User as SocketGuildUser;
            var users = Context.Guild.Users;
            var slovo = Context.User.Id;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Volič");
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Starosta");
            var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");
            foreach (IGuildUser userino in users)
            {
                if (userino.Mention == user)
                {
                    user = userino.Username;
                }
            }

            if (User1.Roles.Contains(role) || User1.Roles.Contains(role2) || User1.Roles.Contains(role3))
            {
                Random random = new Random();
                int ovce = random.Next(0, 101);

                if (slovo == 709434611851198526 && user == null)
                {
                    if (ovce >= 51)
                    {
                        ovce = ovce - 50;
                        await ReplyAsync("> " + tomio + " Jsi z " + ovce + "% furry lul " + qwer);
                        return;
                    }
                    await ReplyAsync("> " + tomio + " Jsi z " + ovce + "% furry lul " + qwer);
                    return;
                }
                if (slovo == 528526689236418561 && user == null)
                {
                    if (ovce <= 49)
                    {
                        ovce = ovce + 50;
                        await ReplyAsync("> " + tomio + " Jsi z " + ovce + "% furry lul " + qwer);
                        return;
                    }
                    await ReplyAsync("> " + tomio + " Jsi z " + ovce + "% furry lul " + qwer);
                    return;
                }
                if (ovce <= 50 && user == "Your Generic Scunt" || user == "Zarvok" || user == "Ten dlabaja" || user == "kubak1500")
                {
                    ovce = ovce + 50;
                    await ReplyAsync("> " + tomio + " " + user + " je z " + ovce + "% furry lul " + qwer);
                    return;
                }
                if (user == "qwer8" && ovce >= 51)
                {
                    ovce = ovce - 50;
                    await ReplyAsync("> " + tomio + " " + user + " je z " + ovce + "% furry lul " + qwer);
                    return;
                }
                if (user == null)
                {
                    await ReplyAsync("> " + tomio + " Jsi z " + ovce + "% furry lul " + qwer);
                }
                else
                {
                    await ReplyAsync("> " + tomio + " " + user + " je z " + ovce + "% furry lul " + qwer);
                }
            }
        }
    }
}