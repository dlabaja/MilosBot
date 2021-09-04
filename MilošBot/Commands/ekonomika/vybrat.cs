using Discord;
using Discord.Commands;
using Discord.WebSocket;
using MilošBot.Commands.Attributes;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands.help
{
    public class helpokljklst : ModuleBase<SocketCommandContext>
    {
        private const int cooldownMin = 10;

        [Command("vybrat")]
        [Alias("bankomat", "PIN")]
        [FormatSummary("Vybere peníze z banky, cooldown je {0} min.", cooldownMin)]
        public async Task Kickáásdssssdwewdsaenzou([Remainder] int i = 0)
        {
            var najs = Context.User.Id.ToString();

            var hod = DateTime.UtcNow.AddHours(1);
            DateTime secondsLeft = hod.AddMinutes(cooldownMin);

            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");
            var coll = db.GetCollection<Rootobject1>("timery");

            var cisla1 = await coll.Find(b => b.uzivatelid == najs).FirstAsync();
            DateTime uzivatel2 = cisla1.timer13;
            ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;

            if (hod >= uzivatel2)
            {
                var coll12 = db.GetCollection<Rootobject1>("ekonomika");

                var cisla11 = await coll12.Find(b => b.uzivatelid == najs).FirstAsync();
                int uzivatel = cisla11.kreditka;

                Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");

                if (uzivatel == 0)
                {
                    await Context.Message.Channel.SendMessageAsync("nejspíše nevlastníš kreditku, pro její zakoupení napiš .koupit-kreditku");
                    return;
                }
                var coll1 = db.GetCollection<Rootobject1>("timery");
                var filter = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
                var update = Builders<Rootobject1>.Update.Set("timer13", secondsLeft);
                coll1.UpdateOne(filter, update);

                int uzivatel10 = cisla11.cum;
                int uzivatel5 = cisla11.banka;
                int premium = cisla11.premium;

                int uzivatel6 = 0;
                int ctvrtina = uzivatel5 / 4;
                if (i <= ctvrtina && i >= 1)
                {
                    uzivatel6 = i;
                }
                else if (i >= ctvrtina || i <= 1)
                {
                    uzivatel6 = uzivatel5 / 4;
                }

                int uzivatel12 = uzivatel6 / 10;                    //daň
                int uzivatel11 = uzivatel6 + uzivatel10 - uzivatel12; //zapsat do cum
                int uzivatel13 = uzivatel5 - uzivatel6;             //zapsat do banky

                if (premium == 1)
                {
                    uzivatel11 = uzivatel11 + uzivatel12;
                    uzivatel12 = 0;
                    var coll18 = db.GetCollection<Rootobject1>("ekonomika");
                    var update8 = Builders<Rootobject1>.Update.Set("banka", uzivatel13);
                    var update88 = Builders<Rootobject1>.Update.Set("cum", uzivatel11);
                    coll18.UpdateOne(filter, update8);
                    coll18.UpdateOne(filter, update88);

                    var ovcak = new EmbedBuilder();
                    var ovcak1 = new EmbedBuilder();
                    ovcak1.WithColor(Color.Blue);
                    ovcak.WithColor(Color.Green);
                    ovcak.WithTitle($"Právě jsi si převedl z banky {uzivatel6} {agr} STORKSCOINS \n Na legální ruce máš momentálně {uzivatel11} {agr} STORKSCOINS \n A v bance momentálně máš {uzivatel13} {agr} STORKSCOINS");
                    ovcak1.WithTitle($"10% daň z této transakce tě přišla na {uzivatel12} {agr} STORKSCOINS");
                    await Context.Channel.SendMessageAsync(embed: ovcak.Build());
                    await Context.Channel.SendMessageAsync(embed: ovcak1.Build());
                }
                if (premium == 0)
                {
                    var coll18 = db.GetCollection<Rootobject1>("ekonomika");
                    var update8 = Builders<Rootobject1>.Update.Set("banka", uzivatel13);
                    var update88 = Builders<Rootobject1>.Update.Set("cum", uzivatel11);
                    coll18.UpdateOne(filter, update8);
                    coll18.UpdateOne(filter, update88);

                    var ovcak = new EmbedBuilder();
                    var ovcak1 = new EmbedBuilder();
                    ovcak1.WithColor(Color.Blue);
                    ovcak.WithColor(Color.Green);
                    ovcak.WithTitle($"Právě jsi si převedl z banky {uzivatel6} {agr} STORKSCOINS \n Na legální ruce máš momentálně {uzivatel11} {agr} STORKSCOINS \n A v bance momentálně máš {uzivatel13} {agr} STORKSCOINS");
                    ovcak1.WithTitle($"10% daň z této transakce tě přišla na {uzivatel12} {agr} STORKSCOINS");
                    await Context.Channel.SendMessageAsync(embed: ovcak.Build());
                    await Context.Channel.SendMessageAsync(embed: ovcak1.Build());
                }
                var ruka = Context.User as SocketGuildUser;
                await cons.SendMessageAsync($"vybrat {ruka}");
            }
            else
            {
                var ruka = Context.User as SocketGuildUser;
                await Context.Channel.SendMessageAsync($"příkaz budeš moct použít až {uzivatel2}");

                await cons.SendMessageAsync($"vybrat {i} {ruka}");
            }
        }
    }
}