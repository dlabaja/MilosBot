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
using System.Data.SqlClient;
using System.Net;
using ScottPlot;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading;

namespace MilošBot.Commands
{
    public class helposddsahjklkt : ModuleBase<SocketCommandContext>
    {
        [Command("bitcoin7")]
        public async Task Mildosdshuzuuaggdsurus1()
        {
            var client55 = new MongoClient("MongoDB connection string");
            var db = client55.GetDatabase("dbl");
            var coll55 = db.GetCollection<Rootobject1>("cislo");

            var idcko = new ObjectId("6033734fcc238b307841f0ff");
            var cisla = coll55.Find(b => b._id == idcko).FirstAsync().Result;
            int i = cisla.uzivat;

            var coll = db.GetCollection<Rootobject1>("kryptomena1");

            var cisla8 = coll.Find(b => b.uzi == i).FirstAsync().Result;
            DateTime uzivatel = cisla8.timer1;

            var hod = DateTime.UtcNow.AddHours(1);
            Console.WriteLine(i);

            var coll1 = db.GetCollection<BsonDocument>("cislo");
            int ii = i++;
            DateTime secondsLeft = uzivatel.AddHours(8);

            var client558 = new MongoClient("MongoDB connection string");
            var db8 = client558.GetDatabase("dbl");
            var coll6 = db8.GetCollection<BsonDocument>("kryptomena1");
            var pridani = new BsonDocument
            {
                {"uzi",ii},
                {"timer1",secondsLeft},
            };
            await coll6.InsertOneAsync(pridani);

            //update
            var coll14 = db.GetCollection<BsonDocument>("cislo");
            var filter = Builders<BsonDocument>.Filter.Eq("idcko", "6033734fcc238b307841f0ff");
            var update = Builders<BsonDocument>.Update.Set("uzivat", ii);
            coll1.UpdateOne(filter, update);*/

/*
var coll = db55.GetCollection<BsonDocument>("kryptomena1");
DateTime secondsLeft = hod.AddMinutes(2);
var pridani = new BsonDocument
{
    {"uzi",i},
    {"timer1",hod},
};
await coll.InsertOneAsync(pridani);
}
}
}*/