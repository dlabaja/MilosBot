using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.API;
using Discord.Rest;
using Discord.WebSocket;
using System.Text;
using System.Data.SqlClient;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MilošBot.Commands.help
{
    public class helpjkltdjklost : ModuleBase<SocketCommandContext>
    {
        [Command("koupit-NSDM")]
        public async Task Kickáásdsdsdsaswewdsaenzou([Remainder] int i = 0)
        {
            if (i >= 1)
            {
                var najs = Context.User.Id.ToString();

                //read
                var client9 = new MongoClient("MongoDB connection string");
                var db = client9.GetDatabase("dbl");

                var coll5515 = db.GetCollection<Rootobject1>("cislo");
                var idcko1 = new ObjectId("603d510a6b05e30f18f4647b");
                var cisla11 = coll5515.Find(b => b._id == idcko1).FirstAsync().Result;
                int cisl = cisla11.uzivat;

                var coll191 = db.GetCollection<Rootobject1>("test");
                var cisla12 = coll191.Find(b => b.uzi == cisl - 2).FirstAsync().Result;
                int kurz = cisla12.ahoj;

                var coll19 = db.GetCollection<Rootobject1>("kryptomena1");
                var cisla1 = coll19.Find(b => b.uzivatelid == najs).FirstAsync().Result;
                int nsdm = cisla1.kryptomena1;

                var coll1911 = db.GetCollection<Rootobject1>("ekonomika");
                var cisla121 = coll1911.Find(b => b.uzivatelid == najs).FirstAsync().Result;
                int banka = cisla121.banka;

                if (kurz * i <= banka)
                {
                    int vysledek = kurz * i;
                    int banka1 = banka - vysledek;
                    int nsdm1 = nsdm + i;
                    var hod = DateTime.UtcNow.AddHours(1);
                    DateTime secondsLeft = hod.AddDays(3);

                    var coll12 = db.GetCollection<Rootobject1>("kryptomena1");
                    var filter9 = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
                    var update9 = Builders<Rootobject1>.Update.Set("timer4", secondsLeft);
                    var update91 = Builders<Rootobject1>.Update.Set("kryptomena1", nsdm1);
                    coll12.UpdateOne(filter9, update9);
                    coll12.UpdateOne(filter9, update91);

                    var coll121 = db.GetCollection<Rootobject1>("ekonomika");
                    var filter91 = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
                    var update941 = Builders<Rootobject1>.Update.Set("banka", banka1);
                    coll121.UpdateOne(filter91, update941);

                    await Context.Channel.SendMessageAsync("právě si jsi koupil " + i + " investičních mincí kryptoměny NSDM v kurzu 1:" + kurz + " za " + vysledek + " STORKSCOINU");

                    //log
                    var ruka = Context.User as SocketGuildUser;
                    ITextChannel cons1 = Context.Client.GetChannel(814954423972266024) as ITextChannel;
                    await cons1.SendMessageAsync("koupit NSDM " + ruka);
                }
                else { await Context.Channel.SendMessageAsync("V bance nemáš dost peněz F"); }
            }
        }
    }
}