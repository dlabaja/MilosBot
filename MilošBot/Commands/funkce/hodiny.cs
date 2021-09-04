using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Hodiny : ModuleBase<SocketCommandContext>
    {
        [Command("hodiny")]
        [Summary("Kolik je hodin?")]
        public async Task Trumpoulina()
        {
            List<string> url = new List<string>()
            {
                "qwer je gay",
                "na becherovku",
                "na chlastání s Putinem",
                "na pivo s Prymulou",
                "na zabíjení novinářů",
                "na hraní Zeminátora",
                "na hraní s Ovčáčkem",
                "na hraní Pussy Walk",
                "na pád ze schodů",
                "na mlácení migrantů hůlčičkou",
                "na porážku Drahoše",
                "na projížďku po vodním kanále"
            };

            Random rnd = new Random();
            int ovce = rnd.Next(url.Count());
            await Context.Channel.SendMessageAsync(DateTime.UtcNow.AddHours(1) + "\n**Čas " + url[ovce] + "**");
        }
    }
}