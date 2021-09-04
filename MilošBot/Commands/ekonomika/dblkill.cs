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
    public class DblKill : ModuleBase<SocketCommandContext>
    {
        [Command("dblkill")]
        public async Task DblKillAsync([Remainder] string user = null)
        {
            SocketGuildUser zidle = null;
            Emote sad = Emote.Parse("<:smutnej:722776040170061844>");
            var users = Context.Guild.Users;
            var User1 = Context.User as SocketGuildUser;
            foreach (SocketGuildUser userino in users)
            {
                Console.WriteLine(userino + user);
                if (userino.Mention == user)
                {
                    user = userino.Username;
                    zidle = userino;
                    break;
                }
            }
            var najs = Context.User.Id.ToString();
            var clientik = new MongoClient("MongoDB connection string");
            var datab = clientik.GetDatabase("dbl");
            var collec = datab.GetCollection<Rootobject1>("timery");
            var idckoo = new ObjectId("604515595de3962730795c2a");
            var cislaa = collec.Find(b => b.uzivatelid == najs).FirstAsync().Result;
            DateTime porovnani = cislaa.timer16;

            var hod = DateTime.UtcNow.AddHours(1);
            DateTime secondsLeft = hod.AddHours(8);
            if (zidle != null)
            {
                if (hod >= porovnani)
                {
                    var filter = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
                    var update = Builders<Rootobject1>.Update.Set("timer15", secondsLeft);
                    collec.UpdateOne(filter, update);

                    var idd = zidle.Id.ToString();
                    var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "databáze");
                    if (zidle.Roles.Contains(role2))
                    {
                        Random random1 = new Random();
                        int smrt11 = random1.Next(1, 4);
                        if (smrt11 == 1)
                        {
                        }
                        else { await Context.Message.Channel.SendMessageAsync("Nepovedlo se ti to, za osm hodin to můžeš zkusit znova"); }
                    }
                    else { await Context.Message.Channel.SendMessageAsync("Wtf tebou vybraný uživatel nehraje ekonomiku?! Upaluj mu to hned říct ať máš koho okrádat 🤦 "); }
                }
                else { await Context.Message.Channel.SendMessageAsync("příkaz budeš znova moci použít až " + porovnani); }
            }
            else { await Context.Message.Channel.SendMessageAsync("pingni uživatele ?!"); }
        }
    }
}