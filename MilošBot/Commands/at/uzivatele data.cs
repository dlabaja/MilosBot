using Discord;
using Discord.Commands;
using Discord.WebSocket;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class flaka : ModuleBase<SocketCommandContext>
    {
        [Command("databaze")]
        [RequireUserPermission(Discord.GuildPermission.Administrator)]
        public async Task Trumpoulina()
        {
            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");
            var coll = db.GetCollection<RootobjectI>("uzivatele");
            var collic = db.GetCollection<MongoPingy>("pingy");
            var collic2 = db.GetCollection<BsonDocument>("pingy");
            var collec = db.GetCollection<BsonDocument>("uzivatele");

            Random random = new Random();
            foreach (SocketGuildUser user in Context.Guild.Users)
            {
                if (user.IsBot == false)
                {
                    var data = coll.Find(b => b.idcko == user.Id.ToString()).FirstOrDefaultAsync().Result;
                    if (data == null)
                    {
                        string avatar = user.GetAvatarUrl();
                        if (avatar == null)
                        {
                            avatar = user.GetDefaultAvatarUrl();
                        }
                        var tagkod = user.DiscriminatorValue * random.Next(2, 11) + random.Next(1, 100);

                        var pridani = new BsonDocument { { "nick", user.ToString() }, { "mute", false }, { "avatar", avatar }, { "joined", DateTime.Now }, { "tagkod", tagkod }, { "idcko", user.Id.ToString() }, };
                        collec.InsertOne(pridani);
                        Console.WriteLine(user);
                    }

                    var dataa = collic.Find(b => b.idcko == user.Id.ToString()).FirstOrDefaultAsync().Result;
                    if (dataa == null)
                    {
                        Console.WriteLine("pingy: " + user);
                        var pridania = new BsonDocument { { "nick", user.ToString() }, { "idcko", user.Id.ToString() }, { "oznameni", true }, { "promo", true }, { "freehry", false }, { "politika", false }, { "pocasi", false } };
                        collic2.InsertOne(pridania);
                    }
                    else
                    {
                        /*Console.WriteLine("pocasi " + user);
                        var filterDefinition = Builders<MongoPingy>.Filter.Empty;
                        var updateDefinition = Builders<MongoPingy>.Update
                            .Set("pocasi", false);
                        collic.UpdateMany(filterDefinition, updateDefinition, new UpdateOptions { IsUpsert = true });*/
                    }
                }
            }
            var _client = new DiscordSocketClient();
            IGuild server = _client.GetGuild(719247194145816686);
            foreach (SocketGuildUser user in Context.Guild.Users)
            {
                if (user.IsBot == false)
                {
                    label1:
                    Console.WriteLine(user);
                    filter = Builders<MongoPingy>.Filter.Eq("idcko", user.Id);
                    var pingy = collic.Find(b => b.idcko == user.Id.ToString()).FirstOrDefaultAsync().Result;
                    if (pingy == null)
                    {
                        var pridania = new BsonDocument { { "nick", user.ToString() }, { "idcko", user.Id.ToString() }, { "oznameni", true }, { "promo", true }, { "freehry", false }, { "politika", false } };
                        collic2.InsertOne(pridania);
                        goto label1;
                    }
                    update = Builders<MongoPingy>.Update.Set("oznameni", RolePingySet(786631302514343997, user, pingy.oznameni));
                    collic.UpdateOne(filter, update);
                    update = Builders<MongoPingy>.Update.Set("promo", RolePingySet(811279796587331605, user, pingy.promo));
                    collic.UpdateOne(filter, update);
                    update = Builders<MongoPingy>.Update.Set("freehry", RolePingySet(789825600340623381, user, pingy.freehry));
                    collic.UpdateOne(filter, update); ;
                    update = Builders<MongoPingy>.Update.Set("politika", RolePingySet(825056360436858880, user, pingy.politika));
                    collic.UpdateOne(filter, update);
                    Console.WriteLine("" + user + pingy.oznameni + pingy.promo + pingy.freehry + pingy.politika);
                }
            }
            Console.WriteLine("hotovo");
        }

        private FilterDefinition<MongoPingy> filter;
        private UpdateDefinition<MongoPingy> update;

        private bool RolePingySet(ulong roleid, SocketGuildUser user, bool b)
        {
            var rolepo = Context.Guild.Roles.FirstOrDefault(x => x.Id == roleid);
            if (user.Roles.Contains(rolepo))
            {
                b = true;
                return b;
            }
            else
            {
                b = false;
                return b;
            }
        }
    }

    public class RootobjectI
    {
        public ObjectId _id { get; set; }
        public bool mute { get; set; }
        public string nick { get; set; }
        public string avatar { get; set; }
        public DateTime joined { get; set; }
        public int tagkod { get; set; }
        public string idcko { get; set; }
    }
}