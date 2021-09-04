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
    public class helpoasdqst : ModuleBase<SocketCommandContext>
    {
        private const int cooldownMin = 45;

        [Command("vsadit")]
        [Alias("sazka", "sportka")]
        [FormatSummary("Vsadíš peníze z ruky, cooldown je {0} min", cooldownMin)]
        public async Task Kickááenzou([Remainder, Summary("počet peněz na sázku.")] int pocetPenez = 0)
        {
            var najs = Context.User.Id.ToString();

            var hod = DateTime.UtcNow.AddHours(1);
            DateTime secondsLeft = hod.AddMinutes(cooldownMin);

            //read
            var client9 = new MongoClient("MongoDB connection string");
            var db = client9.GetDatabase("dbl");
            var coll19 = db.GetCollection<Rootobject1>("timery");

            var cisla1 = await coll19.Find(b => b.uzivatelid == najs).FirstAsync();
            DateTime uzivatel27 = cisla1.timer11;

            ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;

            if (hod >= uzivatel27)
            {
                if (pocetPenez <= 0 || pocetPenez >= 501)
                {
                    await Context.Channel.SendMessageAsync("Nezadali jste číslo,nebo sázka byla příliš vysoká (max 500)");
                    return;
                }
                var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "databáze");
                var ruka = Context.User as SocketGuildUser;

                if (ruka.Roles.Contains(role2))
                {
                    var coll119 = db.GetCollection<Rootobject1>("timery");
                    var filter9 = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
                    var update9 = Builders<Rootobject1>.Update.Set("timer11", secondsLeft);
                    coll119.UpdateOne(filter9, update9);
                }
                else
                {
                    await Context.Message.Channel.SendMessageAsync("nejspíše nejsi registrován do ekonomiky,použij příkaz .registrovat");
                    return;
                }
                var coll = db.GetCollection<Rootobject1>("ekonomika");

                var cisla = await coll.Find(b => b.uzivatelid == najs).FirstAsync();
                int uzivatel = cisla.cum;
                int uzivatel15 = cisla.kreditka;

                if (uzivatel == 0)
                {
                    await Context.Channel.SendMessageAsync("na ruce nemáš dost peněz");
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

                int uzivatel1 = 0, uzivatel2 = 0;

                Random random = new Random();
                int smrt = random.Next(1, 3);
                if (smrt == 1)
                {
                    int uzivatel14 = 5;
                    int uzivatel16 = uzivatel14 + uzivatel15;
                    uzivatel1 = uzivatel + uzivatel16 * pocetPenez;

                    var ovcak1 = new EmbedBuilder();
                    ovcak1.WithColor(Color.Green);
                    ovcak1.WithTitle($"povedlo se ti {zprava}");
                    await Context.Channel.SendMessageAsync(embed: ovcak1.Build());
                }
                if (smrt == 2)
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
                var update = Builders<BsonDocument>.Update.Set("cum", uzivatel3);
                coll1.UpdateOne(filter, update);

                Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle($"Na ruce máš momentálně  {uzivatel3} {agr} STORKSCOINS");
                ovcak.WithColor(Color.Orange);
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                await cons.SendMessageAsync($"vsadit {ruka}");
            }
            else
            {
                var ruka = Context.User as SocketGuildUser;
                await Context.Channel.SendMessageAsync($"příkaz budeš moct použít až {uzivatel27}");
                await cons.SendMessageAsync($"vsadit {uzivatel27} {ruka}");
            }
        }
    }
}