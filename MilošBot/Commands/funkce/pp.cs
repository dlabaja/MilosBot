using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands

{
    public class pp : ModuleBase<SocketCommandContext>
    {
        [Command("pp")]
        [Summary(":lennyface:")]
        public async Task Ping([Remainder] string user = null)
        {
            var User1 = Context.User as SocketGuildUser;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Volič");
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Starosta");
            var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");

            if (user == null)
            {
                user = Context.User.Username;
            }

            if (User1.Roles.Contains(role) || User1.Roles.Contains(role2) || User1.Roles.Contains(role3))
            {
                List<string> url = new List<string>()
                {
                    "",
                    "=",
                    "==",
                    "===",
                    "====",
                    "=====",
                    "======",
                    "=======",
                    "========",
                    "=========",
                    "==========",
                    "===========",
                    "============",
                    "=============",
                    "=============="
                };
                Random random = new Random();
                int ovce = random.Next(url.Count);

                await ReplyAsync(user + " ppík: **8" + url[ovce] + "D**");
                if (ovce <= 2)
                {
                    await ReplyAsync("Menší jak Ovčáčkovo");
                    return;
                }
                if (ovce == 3)
                {
                    await ReplyAsync("Jako Ovčáček");
                    return;
                }
                if (ovce >= 4 && ovce <= 7)
                {
                    await ReplyAsync("Větší jak Ovčáčkovo");
                    return;
                }
                if (ovce >= 8)
                {
                    await ReplyAsync("Mnohem větší jak Ovčáčkovo");
                    return;
                }
            }
            else { await ReplyAsync("Tento příkaz je až od levelu 3!"); }
        }
    }
}