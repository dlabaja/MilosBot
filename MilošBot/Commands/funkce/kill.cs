using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class kill : ModuleBase<SocketCommandContext>
    {
        [Command("kill")]
        [Summary("Zabij svého kamaráda... ale pozor, může se to jednoduše obrátit i proti tobě!")]
        public async Task Trumpoulina([Remainder] string user = null)
        {
            Emote sad = Emote.Parse("<:smutnej:722776040170061844>");
            var users = Context.Guild.Users;
            var User1 = Context.User as SocketGuildUser;
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");

            foreach (IGuildUser userino in users)
            {
                if (userino.Mention == user)
                {
                    user = userino.Username;
                }
            }

            if (User1.Roles.Contains(role2))
            {
                if (user == null || user == User1.Username)
                {
                    await ReplyAsync("Toto je kill, ne sebevražda");
                    return;
                }
                else
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

                    List<string> url1 = new List<string>()
                    {
                        "umlátil kamenem",
                        "zastřelil",
                        "ubil hůlčičkou",
                        "utýral k smrti",
                        "rozkrájel",
                        "přejel limuzínou",
                        "poslal čápy na",
                        "snědl",
                        "prodal hladovým afričanům",
                        "poslal na sibiř",
                        "poslal do Jáchymova do uranových dolů",
                        "nakazil koronavirem",
                        "byl při loupení v čapáku uškrcen samotným",
                        "se ušňupal kokainu, který měl od",
                        "posadil na vlak do osvětimi",
                    };

                    List<string> url2 = new List<string>()
                    {
                        "umlátil kamenem",
                        "zastřelil",
                        "ubil hůlčičkou",
                        "utýral k smrti",
                        "rozkrájel",
                        "přejel limuzínou",
                        "poslal čápy na",
                        "snědl",
                        "prodal hladovým afričanům",
                        "poslal na sibiř",
                        "poslal do Jáchymova do uranových dolů",
                        "nakazil koronavirem",
                        "posadil na vlak do Osvětimi",
                    };

                    List<string> url3 = new List<string>()
            {
                "Putina",
                "Pellegriniho",
                "Čaputovou",
                "Fica",
                "Schwarzenberga",
                "Ovčáčka",
                "Kalouska",
                "Babiše",
                "Sobotku",
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
                "Obamu",
                "migranta lezoucího přes zeď",
                "skladníka",
                "naštvaného důchodce",
            };
                    var ovcak = new EmbedBuilder();
                    if (user == null)
                    {
                        await Context.Message.Channel.SendMessageAsync("A co jim mám jako říct? Musíte zadat zprávu!");
                        return;
                    }
                    else
                    {
                        Random random = new Random();
                        int smrt = random.Next(1, 5);
                        if (smrt == 1)
                        {                         //dlabaja je zadavajici prikaz a do pingu pinguje  @zarvok
                            int ovce3 = random.Next(url3.Count());
                            int ovce1 = random.Next(url2.Count());
                            //zarvok umlatil kamenem putina
                            await Context.Channel.SendMessageAsync("> " + user + " " + url2[ovce1] + " " + url3[ovce3] + " " + sad);
                            await Context.Message.DeleteAsync();
                        }

                        if (smrt == 2)
                        {
                            int ovce = random.Next(url.Count());
                            int ovce1 = random.Next(url1.Count());
                            //putin umlatil kamenem zarvoka
                            await Context.Channel.SendMessageAsync("> " + url[ovce] + " " + url1[ovce1] + " " + user + " " + sad);
                            await Context.Message.DeleteAsync();
                        }
                        if (smrt == 3)
                        {
                            int ovce1 = random.Next(url1.Count());
                            //zarvok umlatil kamenem dlabaju
                            await Context.Channel.SendMessageAsync("> " + user + " " + url1[ovce1] + " " + User1.Username + " " + sad);
                            await Context.Message.DeleteAsync();
                        }
                        if (smrt == 4)
                        {
                            int ovce1 = random.Next(url1.Count());
                            //dlabaja umlatil kamenem zarvoka
                            await Context.Channel.SendMessageAsync("> " + User1.Username + " " + url1[ovce1] + " " + user + " " + sad);
                            await Context.Message.DeleteAsync();
                        }
                    }
                }
            }
            else
            {
                await Context.Message.Channel.SendMessageAsync("O co se to jako snažíš? Tato funkce je dostupná až od levelu 20!");
            }
            ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
            await cons.SendMessageAsync("kill: " + Context.User);
        }
    }
}