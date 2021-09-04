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
    public class Ulozit : ModuleBase<SocketCommandContext>
    {
        private const int cooldownMin = 10;

        [Command("ulozit")]
        [Alias("ulozto", "vlozit", "uložit")]
        [FormatSummary("Uloží peníze do banky, cooldown je {0} min.", cooldownMin)]
        public async Task UlozitAsync([Summary("volitelný parametr."), Remainder] int i = 0)
        {
            var najs = Context.User.Id.ToString();

            var hod = DateTime.UtcNow.AddHours(1);
            DateTime secondsLeft = hod.AddMinutes(cooldownMin);

            //read
            var client9 = new MongoClient("MongoDB connection string");
            var db = client9.GetDatabase("dbl");
            var coll19 = db.GetCollection<Rootobject1>("timery");

            var cisla1 = await coll19.Find(b => b.uzivatelid == najs).FirstAsync();
            DateTime uzivatel27 = cisla1.timer12;
            ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;
            var ruka = Context.User as SocketGuildUser;

            if (hod >= uzivatel27)
            {
                var coll197 = db.GetCollection<Rootobject1>("ekonomika");
                var cisla17 = await coll197.Find(b => b.uzivatelid == najs).FirstAsync();
                int uzivatel = cisla17.kreditka;
                int uzivatel5 = cisla17.cum;
                int uzivatel10 = cisla17.banka;
                int premium = cisla17.premium;

                if (uzivatel == 0)
                {
                    await Context.Message.Channel.SendMessageAsync("nejspíše nevlastníš kreditku, pro její zakoupení napiš .koupit-kreditku");
                    return;
                }

                var coll119 = db.GetCollection<ModuleBase>("timery");
                var filter9 = Builders<ModuleBase>.Filter.Eq("uzivatelid", najs);
                var update9 = Builders<ModuleBase>.Update.Set("timer12", secondsLeft);
                coll119.UpdateOne(filter9, update9);
                int ctvrtina = uzivatel5 / 2;

                int uzivatel6 = 0; //uzivatel6 zapsat jako cum
                if (i <= ctvrtina && i >= 1) { uzivatel6 = i; }
                if (i >= ctvrtina || i <= 1) { uzivatel6 = uzivatel5 / 2; }

                int uzivatel12 = uzivatel6 / 10;                    //daň
                int uzivatel11 = uzivatel6 + uzivatel10 - uzivatel12; //zapsat do banky
                int uzivatel13 = uzivatel5 - uzivatel6;        //zapsat do cum

                if (premium == 1)
                {
                    uzivatel11 += uzivatel12;
                    var coll1 = db.GetCollection<BsonDocument>("ekonomika");
                    var filter = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
                    var update = Builders<BsonDocument>.Update.Set("banka", uzivatel11);
                    var update1 = Builders<BsonDocument>.Update.Set("cum", uzivatel13);
                    coll1.UpdateOne(filter, update);
                    coll1.UpdateOne(filter, update1);

                    Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");
                    var ovcak = new EmbedBuilder();
                    var ovcak1 = new EmbedBuilder();
                    ovcak1.WithColor(Color.Blue);
                    ovcak.WithColor(Color.Green);
                    ovcak.WithTitle($"Právě jsi si převedl do banky {uzivatel6} {agr} STORKSCOINS \n Na legální ruce máš momentálně {uzivatel13} {agr} STORKSCOINS \n A v bance momentálně máš {uzivatel11} {agr} STORKSCOINS");
                    ovcak1.WithTitle($"10% daň z této transakce tě přišla na 0 {agr} STORKSCOINS");
                    await Context.Channel.SendMessageAsync(embed: ovcak.Build());
                    await Context.Channel.SendMessageAsync(embed: ovcak1.Build());

                    await cons.SendMessageAsync($"ulozit {ruka}");
                }
                if (premium == 0)
                {
                    var coll1 = db.GetCollection<BsonDocument>("ekonomika");
                    var filter = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
                    var update = Builders<BsonDocument>.Update.Set("banka", uzivatel11);
                    var update1 = Builders<BsonDocument>.Update.Set("cum", uzivatel13);
                    coll1.UpdateOne(filter, update);
                    coll1.UpdateOne(filter, update1);

                    Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");
                    var ovcak = new EmbedBuilder();
                    var ovcak1 = new EmbedBuilder();
                    ovcak1.WithColor(Color.Blue);
                    ovcak.WithColor(Color.Green);
                    ovcak.WithTitle($"Právě jsi si převedl do banky {uzivatel6} {agr} STORKSCOINS \n Na legální ruce máš momentálně {uzivatel13} {agr} STORKSCOINS \n A v bance momentálně máš  {uzivatel11} {agr} STORKSCOINS");
                    ovcak1.WithTitle($"10% daň z této transakce tě přišla na {uzivatel12} {agr} STORKSCOINS");
                    await Context.Channel.SendMessageAsync(embed: ovcak.Build());
                    await Context.Channel.SendMessageAsync(embed: ovcak1.Build());
                    //log

                    await cons.SendMessageAsync($"ulozit {ruka}");
                }
            }
            else
            {
                await Context.Channel.SendMessageAsync($"příkaz budeš moct použít až {uzivatel27}");
                await cons.SendMessageAsync($"ulozit {uzivatel27} {ruka}");
            }
        }
    }
}