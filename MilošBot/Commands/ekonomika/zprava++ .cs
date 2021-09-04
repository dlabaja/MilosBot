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
    public class heladadasdapost : ModuleBase<SocketCommandContext>
    {
        [Command("pridat")]
        public async Task Ping([Remainder] string user = null)
        {
            if (user == null) { await ReplyAsync("> zadej co chces přidat"); }
            else
            {
                var ruka = Context.User as SocketGuildUser;
                var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "premiér");
                var role4 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Hlavní poradce premiéra");

                if (ruka.Roles.Contains(role2) || ruka.Roles.Contains(role4))
                {
                    var clientik = new MongoClient("MongoDB connection string");
                    var datab = clientik.GetDatabase("dbl");
                    var collec = datab.GetCollection<Rootobject1>("cislo");
                    var idckoo = new ObjectId("604515595de3962730795c2a");
                    var cislaa = await collec.Find(b => b._id == idckoo).FirstAsync();
                    DateTime porovnani = cislaa.timer5;
                    int zpravy = cislaa.uzivat;

                    var hod = DateTime.UtcNow.AddHours(1);
                    DateTime secondsLeft = hod.AddSeconds(5);
                    if (hod >= porovnani)
                    {
                        int zpravy2 = zpravy + 1;
                        var coll18 = datab.GetCollection<Rootobject1>("cislo");
                        var filter = Builders<Rootobject1>.Filter.Eq("ahoj", 1);
                        var update = Builders<Rootobject1>.Update.Set("timer5", secondsLeft);
                        var update1 = Builders<Rootobject1>.Update.Set("uzivat", zpravy2);
                        coll18.UpdateOne(filter, update1);
                        coll18.UpdateOne(filter, update);

                        var coll = datab.GetCollection<BsonDocument>("zpravy");

                        var pridani = new BsonDocument
                        {
                            {"poradi",zpravy2},
                            {"zprava",user}
                        };
                        await coll.InsertOneAsync(pridani);
                        await ReplyAsync($"> Děkuji, do databáze jsem připsal [{user}]. Již máme {zpravy2} možností.");
                    }
                    else { await ReplyAsync("> počkej pět vteřin"); }
                }
                else { await ReplyAsync("> napiš svůj návrk Your Generic Scunt#7070"); }
            }
        }
    }
}