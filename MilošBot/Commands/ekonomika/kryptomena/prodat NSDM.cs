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
using System.Net;
using ScottPlot;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MilošBot.Commands
{
    public class helposdeshjklkt : ModuleBase<SocketCommandContext>
    {
        [Command("Prodat-NSDM")]
        public async Task Kickáásdsdsdsaswewdsaenzou([Remainder] string reason = null)
        {
            int i = 0;
            bool result = int.TryParse(reason, out i);

            if (i >= 1)
            {
                var najs = Context.User.Id.ToString();

                var porovnani = DateTime.UtcNow.AddHours(1);

                var client55 = new MongoClient("MongoDB connection string");
                var db = client55.GetDatabase("dbl");
                var coll55 = db.GetCollection<Rootobject1>("kryptomena1");

                var cisla12 = coll55.Find(b => b.uzivatelid == najs).FirstAsync().Result;
                DateTime hod1 = cisla12.timer4;
                int NSDM = cisla12.kryptomena1;

                if (porovnani >= hod1)
                {
                    var coll1911 = db.GetCollection<Rootobject1>("ekonomika");
                    var cisla121 = coll1911.Find(b => b.uzivatelid == najs).FirstAsync().Result;
                    int banka = cisla121.banka;

                    var coll5515 = db.GetCollection<Rootobject1>("cislo");
                    var idcko1 = new ObjectId("603d510a6b05e30f18f4647b");
                    var cisla11 = coll5515.Find(b => b._id == idcko1).FirstAsync().Result;
                    int cisl = cisla11.uzivat;

                    var coll191 = db.GetCollection<Rootobject1>("test");
                    var cisla1214 = coll191.Find(b => b.uzi == cisl - 2).FirstAsync().Result;
                    int kurz = cisla1214.ahoj;

                    // i>=NSDM
                    int banka2 = NSDM * kurz + banka;
                    int NSDM2 = 0;

                    // i<NSDM
                    int banka1 = i * kurz + banka;
                    int NSDM1 = NSDM - i;

                    //log
                    var ruka = Context.User as SocketGuildUser;
                    ITextChannel cons1 = Context.Client.GetChannel(814954423972266024) as ITextChannel;
                    await cons1.SendMessageAsync("Prodat NSDM " + ruka);
                    if (NSDM == 0)
                    {
                        await Context.Channel.SendMessageAsync("nevlastníš žádnou kryptoměnu NSDM");
                        return;
                    }
                    if (NSDM <= i)
                    {
                        var coll12 = db.GetCollection<Rootobject1>("kryptomena1");
                        var filter9 = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
                        var update91 = Builders<Rootobject1>.Update.Set("kryptomena1", NSDM2);
                        coll12.UpdateOne(filter9, update91);

                        var coll121 = db.GetCollection<Rootobject1>("ekonomika");
                        var filter91 = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
                        var update941 = Builders<Rootobject1>.Update.Set("banka", banka2);
                        coll121.UpdateOne(filter91, update941);
                        int banka21 = NSDM * kurz;
                        await Context.Channel.SendMessageAsync("prodal jsi všechnu svou kryptoměnu NSDM v kurzu 1:" + kurz + " za " + banka21);
                    }
                    if (NSDM > i)
                    {
                        var coll12 = db.GetCollection<Rootobject1>("kryptomena1");
                        var filter9 = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
                        var update91 = Builders<Rootobject1>.Update.Set("kryptomena1", NSDM1);
                        coll12.UpdateOne(filter9, update91);

                        var coll121 = db.GetCollection<Rootobject1>("ekonomika");
                        var filter91 = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
                        var update941 = Builders<Rootobject1>.Update.Set("banka", banka1);
                        coll121.UpdateOne(filter91, update941);
                        int banka12 = i * kurz;
                        await Context.Channel.SendMessageAsync("prodal jsi " + i + " své kryptoměny NSDM v kurzu 1:" + kurz + " za " + banka12);
                    }
                }
                else { await Context.Channel.SendMessageAsync("neuběhli tři dny, příkaz budeš moci použít až " + hod1); }
            }
        }
    }
}