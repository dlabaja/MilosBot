using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class L : ModuleBase<SocketCommandContext>
    {
        [Command("l")]
        [Alias("el")]
        [Summary("Jak moc je tvůj kamarád L?")]
        public async Task Trumpoulina([Remainder] string user = null)
        {
            var User1 = Context.User as SocketGuildUser;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Starosta");
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");
            if (User1.Roles.Contains(role) || User1.Roles.Contains(role2))
            {
                List<string> url = new List<string>()
                {
                 "Putin",
                "Pellegrini",
                "Čaputová",
                "Fico",
                "Schwarzenberg",
                "Ovčáček",
                "Kalousek",
                "Babiš",
                "Sobotka",
                "Drahoš",
                "Tomio",
                "náhodný kolemjdoucí",
                "Kim",
                "Medvídek Pú",
                "Prymula",
                "Blatný",
                "vlastní otec",
                "Biden",
                "Merkelová",
                "Gréta",
                "Volný",
                "Feri",
                "Šťastná",
                "Bůh",
                "Krist",
                "ředitel JZD",
                "policejní prezident",
                "zloděj v TESCU",
                "zloděj v KAUFU",
                "zloděj v Čapáku",
                "bezdomovec",
                "holič",
                "orbán",
                "Hit*er",
                "Obama",
                "migrant lezoucí přes zeď",
                "skladník",
                "naštvaný důchodce",
                };

                if (user == null)
                {
                    await Context.Message.Channel.SendMessageAsync("A co jim mám jako říct? Musíte zadat zprávu!");
                    return;
                }
                else
                {/*/Random some = new Random();
                int someone = some.Next(Context.Guild.Users.Count);
                List<string> haha = new List<string>(Context.Guild.Users.Count);
                await Context.Channel.SendMessageAsync("Vylosovaný je " + haha[someone]);/*/

                    Random rnd = new Random();
                    int ovce = rnd.Next(url.Count());
                    await Context.Channel.SendMessageAsync("> **Ani " + url[ovce] + " není takové L jako " + user + "**");
                    await Context.Message.DeleteAsync();
                }
            }
            else
            {
                await Context.Message.Channel.SendMessageAsync("O co se to jako snažíš? Tato funkce je dostupná až od levelu 10!");
            }
            ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
            await cons.SendMessageAsync("elko: " + Context.User);
        }
    }
}