using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class flak : ModuleBase<SocketCommandContext>
    {
        [Command("flakanec")]
        [Alias("flak", "flákanec")]
        [Summary("Doplň živatele kterému chceš dát flákanec")]
        public async Task Trumpoulina(IGuildUser user = null)
        {
            Emote sad = Emote.Parse("<:smutnej:722776040170061844>");
            var User1 = Context.User as SocketGuildUser;
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");
            if (User1.Roles.Contains(role2))
            {
                if (user == null) { return; }
                else
                {
                    List<string> url = new List<string>()
            {
               "Putina",
                "Pellegriniho",
                "Čaputovou",
                "Fica",
                "Schwarzenberga",
                "Ovčáčka",
                "Kalouska",
                "Babiše",
                "Sobotky",
                "Drahoše",
                "Tomia",
                "náhodného kolemjdoucího",
                "Kima",
                "Medvídka Pú",
                "Prymulu",
                "Blatného",
                "vlastního otce",
                "Bidena",
                "Merkelovou",
                "Grétu",
                "Volného",
                "Feriho",
                "Boha",
                "Krista",
                "ředitele JZD",
                "policejního prezidenta",
                "zloděje v TESCU",
                "zloděje v KAUFU",
                "zloděje v Čapáku",
                "bezdomovce",
                "holiče",
                "orbána",
                "Hit*era",
                "Obamy",
                "migranta lezoucího přes zeď",
                "skladníka",
                "naštvaného důchodce",
            };

                    if (user == null)
                    {
                        await Context.Message.Channel.SendMessageAsync("A co jim mám jako říct? Musíte zadat zprávu!");
                        return;
                    }
                    else
                    {/*/Random some = new Random();
                int someone = some.Next(0, Context.Guild.Users.Count);
                List<string> haha = new List<string>(Context.Guild.Users.Count);
                await Context.Channel.SendMessageAsync("Vylosovaný je " + haha[someone]);/*/

                        Random rnd = new Random();
                        int ovce = rnd.Next(url.Count());
                        await Context.Channel.SendMessageAsync("> Od **" + url[ovce] + " jsi dostal flákanec**, " + user.Mention + "**! Au **" + sad);
                        await Context.Message.DeleteAsync();
                    }
                }
            }
            else
            {
                await Context.Message.Channel.SendMessageAsync("O co se to jako snažíš? Tato funkce je dostupná až od levelu 20!");
            }
            ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
            await cons.SendMessageAsync("flakanec: " + Context.User);
        }
    }
}
