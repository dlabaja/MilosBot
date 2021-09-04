using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class sebevrah : ModuleBase<SocketCommandContext>
    {
        [Command("sebevražda")]
        [Alias("killme", "sebe", "sebevrah")]
        [Summary("KYS")]
        public async Task Trumpoulina()
        {
            Emote sad = Emote.Parse("<:smutnej:722776040170061844>");
            var users = Context.Guild.Users;
            var User1 = Context.User as SocketGuildUser;
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");

            if (User1.Roles.Contains(role2))
            {
                List<string> url1 = new List<string>()
                    {
                        "se umlátil kamenem",
                        "se zastřelil",
                        "se ubil hůlčičkou",
                        "se rozkrájel",
                        "skočil pod vlak",
                        "vylezl na chladící věž Temelína a skočil dovnitř",
                        "zapomněl uhnout dlabajovi v tanku",
                        "jel do afriky jako žvanec pro místní",
                        "naštívil Sibiř, ale zapoměl si čepici a ponožky",
                        "skočil z pátého patra",
                        "se ufetoval k smrti",
                        "se oběsil na klice",
                        "skočil z (M)ostu",
                    };
                List<string> url2 = new List<string>()
                    {
                        "umlátit kamenem",
                        "zastřelit ",
                        "ubít hůlčičkou",
                        "rozkrájet",
                        "skočit pod vlak",
                        "vylézt na chladící věž Temelína a skočit dovnitř",

                        "jet do afriky jako žvanec pro místní",
                        "umrznout na Sibiři",
                        "skočit z pátého patra",
                        "ufetovat k smrti",
                        "oběsit na klice",
                        "skočit z (M)ostu",
                    };
                var ovcak = new EmbedBuilder();
                Random random = new Random();
                int smrt = random.Next(2);
                if (smrt == 0)
                {
                    int ovce1 = random.Next(url1.Count());
                    //dlabaja se umlátil kamenem :sad:
                    await Context.Channel.SendMessageAsync("> " + User1.Username + " " + url1[ovce1] + " " + sad);
                }
                else
                {
                    int ovce1 = random.Next(url2.Count());
                    //dlabaja se pokusil skocit pod vlak ale naštěstí se mu to nepovedlo  :sad:
                    await Context.Channel.SendMessageAsync("> " + User1.Username + " se pokusil " + url2[ovce1] + ", ale naštěstí se mu to nepovedlo ");
                }
            }
            else
            {
                await Context.Message.Channel.SendMessageAsync("O co se to jako snažíš? Tato funkce je dostupná až od levelu 20!");
                goto label2;
            }
            label2:
            if (User1.Roles.Contains(role2))
            {
                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
                await cons.SendMessageAsync("sebevrah: " + Context.User);
                return;
            }
            else
            {
                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
                await cons.SendMessageAsync("Nebylo možné provést tuto operaci, protože nemáš dostatečný level");
                return;
            }
        }
    }
}