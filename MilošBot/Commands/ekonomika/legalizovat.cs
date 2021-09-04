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
    public class Legalizovat : ModuleBase<SocketCommandContext>
    {
        private const int cooldownHod = 1;

        [Command("legalizovat")]
        [Alias("legálně", "legalne")]
        [FormatSummary("Legalizuje peníze z černé ruky n a ruku, cooldown je {0} hod.", cooldownHod)]
        public async Task LegalizovatAsync([Remainder, Summary("Počet peněz k legalizování.")] int pocet = 0)
        {
            var najs = Context.User.Id.ToString();
            var hod = DateTime.UtcNow.AddHours(1);
            DateTime secondsLeft = hod.AddHours(cooldownHod);

            var client9 = new MongoClient("MongoDB connection string");
            var db1 = client9.GetDatabase("dbl");
            var coll19 = db1.GetCollection<Rootobject1>("timery");

            var cisla1 = await coll19.Find(b => b.uzivatelid == najs).FirstAsync();
            DateTime uzivatel27 = cisla1.timer2;
            ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;
            var ruka = Context.User as SocketGuildUser;

            if (pocet <= 0)
            {
                await Context.Channel.SendMessageAsync("Nezadali jste číslo!");
                return;
            }

            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "databáze");
            if (!ruka.Roles.Contains(role2))
            {
                await Context.Message.Channel.SendMessageAsync("nejspíše nejsi registrován do ekonomiky,použij příkaz .registrovat");
                return;
            }

            if (hod >= uzivatel27)
            {
                var coll119 = db1.GetCollection<Rootobject1>("timery");
                var filter9 = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
                var update9 = Builders<Rootobject1>.Update.Set("timer2", secondsLeft);
                coll119.UpdateOne(filter9, update9);

                await cons.SendMessageAsync($"legalizovat {ruka}");

                Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");

                var db = client9.GetDatabase("dbl");
                var coll = db.GetCollection<Rootobject1>("ekonomika");

                var cisla = await coll.Find(b => b.uzivatelid == najs).FirstAsync();
                int uzivatel2 = cisla.cum;
                int uzivatel = cisla.cernaruka;

                int mez1 = uzivatel / 20;
                int mez3 = uzivatel / 10;
                int mez5 = uzivatel / 100 * 15;

                Random random = new Random();

                if (pocet >= 1 && pocet <= mez1)
                {
                    int uzivatel5 = uzivatel - pocet;    //uzivatel5 zapsat na cernouruku
                    int uzivatel6 = uzivatel2 + pocet;   //uzivatel6 zapsat na cum

                    var coll1 = db.GetCollection<BsonDocument>("ekonomika");
                    var filter = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
                    var update = Builders<BsonDocument>.Update.Set("cum", uzivatel6);
                    var update1 = Builders<BsonDocument>.Update.Set("cernaruka", uzivatel5);

                    coll1.UpdateOne(filter, update);
                    coll1.UpdateOne(filter, update1);

                    var ovcak = new EmbedBuilder();
                    var ovcak1 = new EmbedBuilder();
                    ovcak.WithColor(Color.Orange);
                    ovcak1.WithColor(Color.Green);
                    ovcak.WithTitle($"Na ruce máš momentálně {uzivatel6} {agr} STORKSCOINS \n Na černé ruce máš momentálně {uzivatel5} {agr} STORKSCOINS");
                    ovcak1.WithTitle($"Právě se ti povedlo legalizovat kus tvojí černé ruky (0-5%) což činí {pocet} {agr} STORKSCOINS");
                    await Context.Channel.SendMessageAsync(embed: ovcak1.Build());
                    await Context.Channel.SendMessageAsync(embed: ovcak.Build());
                }
                if (pocet > mez1 && pocet <= mez3)
                {
                    int smrt1 = random.Next(3);
                    if (smrt1 == 1)
                    {
                        await Context.Channel.SendMessageAsync("boužel se ti nepovedlo legalizovat kus svého jmění");
                        return;
                    }
                    else
                    {
                        int uzivatel5 = uzivatel - pocet;    //uzivatel5 zapsat na cernouruku
                        int uzivatel6 = uzivatel2 + pocet;   //uzivatel6 zapsat na cum

                        var coll1 = db.GetCollection<BsonDocument>("ekonomika");
                        var filter = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
                        var update = Builders<BsonDocument>.Update.Set("cum", uzivatel6);
                        var update1 = Builders<BsonDocument>.Update.Set("cernaruka", uzivatel5);

                        coll1.UpdateOne(filter, update);
                        coll1.UpdateOne(filter, update1);

                        var ovcak = new EmbedBuilder();
                        var ovcak1 = new EmbedBuilder();
                        ovcak.WithColor(Color.Orange);
                        ovcak1.WithColor(Color.Green);
                        ovcak.WithTitle($"Na ruce máš momentálně {uzivatel6} {agr} STORKSCOINS \n Na černé ruce máš momentálně {uzivatel5} {agr} STORKSCOINS");
                        ovcak1.WithTitle($"Právě se ti povedlo legalizovat kus tvojí černé ruky (5-10%) což činí {pocet} {agr} STORKSCOINS");
                        await Context.Channel.SendMessageAsync(embed: ovcak1.Build());
                        await Context.Channel.SendMessageAsync(embed: ovcak.Build());
                    }
                }

                if (pocet > mez3 && pocet <= mez5)
                {
                    int smrt11 = random.Next(3);
                    if (smrt11 == 1)
                    {
                        int uzivatel5 = uzivatel - pocet;    //uzivatel5 zapsat na cernouruku
                        int uzivatel6 = uzivatel2 + pocet;  //uzivatel6 zapsat na cum

                        var coll1 = db.GetCollection<BsonDocument>("ekonomika");
                        var filter = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
                        var update = Builders<BsonDocument>.Update.Set("cum", uzivatel6);
                        var update1 = Builders<BsonDocument>.Update.Set("cernaruka", uzivatel5);

                        coll1.UpdateOne(filter, update);
                        coll1.UpdateOne(filter, update1);

                        var ovcak = new EmbedBuilder();
                        var ovcak1 = new EmbedBuilder();

                        ovcak.WithColor(Color.Orange);
                        ovcak.WithTitle($"Na ruce máš momentálně {uzivatel6} {agr} STORKSCOINS \n Na černé ruce máš momentálně {uzivatel5} {agr} STORKSCOINS");
                        ovcak1.WithColor(Color.Green);
                        ovcak1.WithTitle($"Právě se ti povedlo legalizovat kus tvojí černé ruky (10-15%) což činí {pocet} {agr} STORKSCOINS");

                        await Context.Channel.SendMessageAsync(embed: ovcak1.Build());
                        await Context.Channel.SendMessageAsync(embed: ovcak.Build());
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("boužel se ti nepovedlo legalizovat kus svéhosvé jmění");
                        return;
                    }
                }
                if (pocet > mez5)
                {
                    await Context.Channel.SendMessageAsync($"maximálně můžeš 15% {agr} STORKSCOINů");
                }
            }
            else
            {
                await Context.Channel.SendMessageAsync($"příkaz budeš moct použít až {uzivatel27}");

                await cons.SendMessageAsync($"legalizovat {uzivatel27} {ruka}");
            }
        }
    }
}