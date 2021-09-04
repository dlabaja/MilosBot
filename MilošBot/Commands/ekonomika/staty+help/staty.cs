using Discord;
using Discord.Commands;
using Discord.WebSocket;
using MilošBot.Commands.Attributes;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class helpjhsadpol : ModuleBase<SocketCommandContext>
    {
        private const int cooldownMin = 1;

        [Command("staty")]
        [Alias("stats")]
        [FormatSummary("Zobrazí ekonomické staty uživatele, cooldown {0} min.", cooldownMin)]
        public async Task StatyAsnyc([Summary("nepovinný parametr."), Remainder] IUser user = null)
        {
            var client1 = new MongoClient("MongoDB connection string");
            var db1 = client1.GetDatabase("dbl");
            var coll1 = db1.GetCollection<Rootobject1>("timery");

            var najs = Context.User.Id.ToString();
            var cisla1 = await coll1.Find(b => b.uzivatelid == najs).FirstAsync();
            DateTime uzivatel12 = cisla1.timer4;

            var hod = DateTime.UtcNow.AddHours(1);
            DateTime secondsLeft = hod.AddMinutes(cooldownMin);

            var ruka = Context.User as SocketGuildUser;
            ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;

            if (hod >= uzivatel12)
            {
                var coll11 = db1.GetCollection<Rootobject1>("timery");
                var filter = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
                var update = Builders<Rootobject1>.Update.Set("timer4", secondsLeft);
                coll11.UpdateOne(filter, update);
                SocketGuildUser zidle = user as SocketGuildUser;
                var users = Context.Guild.Users;
                var User1 = Context.User as SocketGuildUser;

                if (zidle != null)
                {
                    var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "databáze");
                    if (zidle.Roles.Contains(role2))
                    {
                        najs = zidle.Id.ToString();
                    }
                    else { await Context.Message.Channel.SendMessageAsync("Wtf tebou vybraný uživatel nehraje ekonomiku?! Upaluj mu to hned říct ať máš koho okrádat 🤦 "); return; }
                }

                Console.WriteLine(najs);
                var coll = db1.GetCollection<Rootobject1>("ekonomika");
                Console.WriteLine(najs);
                var cisla = await coll.Find(b => b.uzivatelid == najs).FirstAsync();

                Console.WriteLine(najs);
                int uzivatel1 = cisla.cum;
                int uzivatel2 = cisla.cernaruka;
                int uzivatel3 = cisla.banka;
                Console.WriteLine(najs);
                int uzivatel4 = cisla.kreditka;
                int uzivatel5 = cisla.padelanasmlouva;
                int uzivatel6 = cisla.cervenetrenyrky;
                int uzivatel7 = cisla.premium;
                Console.WriteLine(najs);
                var coll7 = db1.GetCollection<Rootobject1>("itemy");
                var cisla7 = await coll7.Find(b => b.uzivatelid == najs).FirstAsync();
                int uzivatel55 = cisla7.item2;
                Console.WriteLine(najs);

                var coll2 = db1.GetCollection<Rootobject1>("kryptomena1");
                var cisla2 = await coll2.Find(b => b.uzivatelid == najs).FirstAsync();
                int uzivatel14 = cisla2.kryptomena1;
                int uzivatel13 = cisla2.kryptomena2;
                Console.WriteLine(najs);

                string ahojky1 = "nevlastníš", ahojky2 = "nevlastníš", ahojky3 = "nevlastníš", ahojky4 = "nevlastníš", ahojky5 = "nevlastníš";

                if (uzivatel4 == 1) { ahojky1 = "vlastníš"; }
                if (uzivatel5 == 1) { ahojky2 = "vlastníš"; }
                if (uzivatel6 == 1) { ahojky3 = "vlastníš"; }
                if (uzivatel7 == 1) { ahojky4 = "vlastníš"; }
                if (uzivatel55 == 1) { ahojky5 = "vlastníš"; }

                Console.WriteLine(najs);
                var ovcak = new EmbedBuilder();
                ovcak.WithColor(Color.Orange);
                ovcak.WithTitle("**STATY**");
                ovcak.AddField("**ruka**", uzivatel1, true);
                ovcak.AddField("** cernaruka**", uzivatel2, true);
                ovcak.AddField("** banka**", uzivatel3, true);
                ovcak.AddField("** NSDM**", uzivatel4, true);
                ovcak.AddField("** BiTStorK**", uzivatel13, true);
                ovcak.AddField("** kreditka**", ahojky1, true);
                ovcak.AddField("** padelanasmlouva**", ahojky2, true);
                ovcak.AddField("** cervenetrenyrky**", ahojky3, true);
                ovcak.AddField("** přístup do reklam**", ahojky5, true);
                ovcak.AddField("** premium**", ahojky4, true);

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Data ze statistického úřadu které ukradl MilošBot");
                });

                await Context.Channel.SendMessageAsync(embed: ovcak.Build());
                await cons.SendMessageAsync($"staty {ruka}");
            }
            else
            {
                await Context.Channel.SendMessageAsync($"příkaz budeš moct použít až {uzivatel12}");
                await cons.SendMessageAsync($"staty {uzivatel12} {ruka}");
            }
        }
    }
}