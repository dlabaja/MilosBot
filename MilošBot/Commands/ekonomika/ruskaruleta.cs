using Discord;
using Discord.Commands;
using Discord.WebSocket;
using MilošBot.Commands.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands.help
{
    public class RuskarRuleta : ModuleBase<SocketCommandContext>
    {
        private const int cooldownMin = 45;

        [Command("ruskaruleta")]
        [Alias("Ruska", "ruleta", "černý.hazard")]
        [FormatSummary("Vsadíš peníze z černé ruky, cooldown je {0} min.", cooldownMin)]
        public async Task RuskarRuletaAsync([Remainder, Summary("počet peněz na sázku.")] int pocetPenez = 0)
        {
            var ruka = Context.User as SocketGuildUser;
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "databáze");

            if (!ruka.Roles.Contains(role2))
            {
                await Context.Message.Channel.SendMessageAsync("nejspíše nejsi registrován do ekonomiky,použij příkaz .registrovat");
                return;
            }
            var najs = Context.User.Id.ToString();

            var hod = DateTime.UtcNow.AddHours(1);
            DateTime secondsLeft = hod.AddMinutes(cooldownMin);

            //read
            var client9 = new MongoClient("MongoDB connection string");
            var db = client9.GetDatabase("dbl");
            var coll19 = db.GetCollection<Rootobject1>("timery");

            var cisla1 = coll19.Find(b => b.uzivatelid == najs).FirstAsync().Result;
            DateTime uzivatel27 = cisla1.timer10;
            ITextChannel cons1 = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;

            if (hod >= uzivatel27)
            {
                if (pocetPenez < 1000)
                {
                    await Context.Channel.SendMessageAsync("Nezadali jste číslo,nebo jste zadali příliš malou sázku(minimální sázka je 1 000)!");
                    return;
                }

                var coll119 = db.GetCollection<Rootobject1>("timery");
                var filter9 = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
                var update9 = Builders<Rootobject1>.Update.Set("timer10", secondsLeft);
                coll119.UpdateOne(filter9, update9);

                int pokus = 1;
                if (pocetPenez <= 4000) { pokus = 6; }
                if (pocetPenez <= 8000 && pocetPenez > 4000) { pokus = 4; }
                if (pocetPenez <= 12000 && pocetPenez > 8000) { pokus = 2; }

                Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");

                var coll = db.GetCollection<Rootobject1>("ekonomika");

                var cisla = await coll.Find(b => b.uzivatelid == najs).FirstAsync();
                int uzivatel = cisla.cernaruka;
                int uzivatel15 = cisla.padelanasmlouva;

                if (uzivatel < pocetPenez)
                {
                    await Context.Channel.SendMessageAsync("na černé ruce nemáš dost peněz");
                    return;
                }
                var collec5 = db.GetCollection<Rootobject1>("cislo");
                var idckoo = new ObjectId("604515595de3962730795c2a");
                var cislaa = await collec5.Find(b => b._id == idckoo).FirstAsync();
                int zpravy = cislaa.uzivat;

                Random random1 = new Random();
                int smrt11 = random1.Next(1, zpravy + 1);

                var coll194 = db.GetCollection<Rootobject1>("zpravy");

                var cisla14 = await coll194.Find(b => b.poradi == smrt11).FirstAsync();
                string zprava = cisla14.zprava;

                int uzivatel1 = 0, uzivatel2 = 0, uzivatel16 = 0;

                int smrt = random1.Next(3);
                if (smrt == 0)
                {
                    uzivatel16 = pokus + uzivatel15;
                    uzivatel1 = uzivatel + uzivatel16 * pocetPenez;

                    var ovcak1 = new EmbedBuilder();
                    ovcak1.WithColor(Color.Green);
                    ovcak1.WithTitle($"povedlo se ti {zprava}");
                    await Context.Channel.SendMessageAsync(embed: ovcak1.Build());
                }
                else
                {
                    uzivatel2 = uzivatel - pocetPenez;
                    var ovcak11 = new EmbedBuilder();
                    ovcak11.WithColor(Color.Red);
                    ovcak11.WithTitle($"nepovedlo se ti {zprava}");
                    await Context.Channel.SendMessageAsync(embed: ovcak11.Build());
                }

                int uzivatel3 = uzivatel1 + uzivatel2;

                var coll1 = db.GetCollection<BsonDocument>("ekonomika");
                var filter = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
                var update = Builders<BsonDocument>.Update.Set("cernaruka", uzivatel3);
                coll1.UpdateOne(filter, update);

                var ovcak = new EmbedBuilder();
                ovcak.WithColor(Color.Orange);
                ovcak.WithTitle($"Na černé ruce máš momentálně {uzivatel3} {agr} STORKSCOINS");
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                //log
                await cons1.SendMessageAsync($"ruskaruleta {ruka}");
            }
            else
            {
                await Context.Channel.SendMessageAsync($"příkaz budeš moct použít až {uzivatel27}");
                await cons1.SendMessageAsync($"ruskaruleta {uzivatel27} { ruka}");
            }
        }
    }
}