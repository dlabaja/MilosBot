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
    public class helpajkaltdjklost : ModuleBase<SocketCommandContext>
    {
        [Command("zitra-NSDM")]
        public async Task Mildosdsassdasasaggdsurus1()
        {
            var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");
            var User1 = Context.User as SocketGuildUser;

            if (User1.Roles.Contains(role3))
            {
                //log
                var ruka = Context.User as SocketGuildUser;
                ITextChannel cons1 = Context.Client.GetChannel(814954423972266024) as ITextChannel;
                await cons1.SendMessageAsync("politici kurz " + ruka);
                //read
                var client9 = new MongoClient("MongoDB connection string");
                var db = client9.GetDatabase("dbl");

                var coll5515 = db.GetCollection<Rootobject1>("cislo");
                var idcko1 = new ObjectId("603d510a6b05e30f18f4647b");
                var cisla11 = coll5515.Find(b => b._id == idcko1).FirstAsync().Result;
                int cisl = cisla11.uzivat;

                var coll191 = db.GetCollection<Rootobject1>("test");
                var cisla12 = coll191.Find(b => b.uzi == cisl - 1).FirstAsync().Result;
                int kurz = cisla12.ahoj;

                string msg = "Zítřejší kurz bude " + kurz + " za jednu minci";
                await Discord.UserExtensions.SendMessageAsync(User1, msg);
                await Context.Channel.SendMessageAsync("máš jej v PM, tak ho hlavně nikomu neříkej :DD");
            }
        }
    }
}