/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.API;
using Discord.Rest;
using Discord.WebSocket;
using System.Text;
using System.Timers;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MilošBot.Commands.help
{
    public class htdpoadsofdst : ModuleBase
    {
        [Command("testtop")]
        [Alias("s3", "str3")]
        public async Task Mildosaurus()
        {
            var najs = Context.User.Id.ToString();

            var hod = DateTime.UtcNow.AddHours(1);
            DateTime secondsLeft = hod.AddMinutes(5);

            //read
            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");
            var coll = db.GetCollection<Rootobject1>("timery");

            var cisla1 = await coll.Find(b => b.uzivatelid == najs).FirstAsync();
            DateTime uzivatel2 = cisla1.timer3;

            var ruka = Context.User as SocketGuildUser;

            //if (hod >= uzivatel2)
            // {
            var coll1 = db.GetCollection<Rootobject1>("timery");
            var filter = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
            var update = Builders<Rootobject1>.Update.Set("timer3", secondsLeft);
            coll1.UpdateOne(filter, update);

            var collec = db.GetCollection<Rootobject1>("cislo");
            var idckoo = new ObjectId("6045f2e774137e2c24f83dd8");
            var cislaa = await collec.Find(b => b._id == idckoo).FirstAsync();
            int ii = cislaa.uzivat;
            Console.WriteLine("ahoj");

            int[] test = new int[ii];
            Console.WriteLine("ahoj");
            for (int i = 0; i < ii; i++)
            {
                var coll7 = db.GetCollection<Rootobject1>("ekonomika");

                var cisla17 = await coll7.Find(b => b.poradi == i).FirstAsync();
                int poradi = cisla17.banka;
                Console.WriteLine("ahoj");
                test[i] = poradi;
            }
            for (int i = 0; i < test.Length; i++)
                Console.Write("{0} ", test[i]);
        }
    }
}*/