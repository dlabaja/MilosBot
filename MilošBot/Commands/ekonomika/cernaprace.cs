using Discord;
using Discord.Commands;
using Discord.WebSocket;
using MilošBot.Commands.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class helposahjklkt : ModuleBase<SocketCommandContext>
    {
        private const int cooldownMin = 30;

        [Command("cernaprace")]
        [Alias("černápráce", "černaprace", "černa práce")]
        [FormatSummary("Vydělá peníze na černé ruce, cooldown {0} min.", cooldownMin)]
        public async Task CernaPraceAsync()
        {
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "databáze");
            var ruka = Context.User as SocketGuildUser;

            if (!ruka.Roles.Contains(role2))
            {
                await Context.Message.Channel.SendMessageAsync("nejspíše nejsi registrován do ekonomiky,použij příkaz .registrovat");
                return;
            }

            var najs = Context.User.Id.ToString();

            var hod = DateTime.UtcNow.AddHours(1);
            DateTime secondsLeft = hod.AddMinutes(cooldownMin);

            //read
            var client9 = new MongoClient("MongoDB connection string");
            var db1 = client9.GetDatabase("dbl");
            var coll19 = db1.GetCollection<Rootobject1>("timery");

            var cisla1 = await coll19.Find(b => b.uzivatelid == najs).FirstAsync();
            DateTime uzivatel2 = cisla1.timer8;
            ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;

            if (hod >= uzivatel2)
            {
                var coll119 = db1.GetCollection<Rootobject1>("timery");
                var filter9 = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
                var update9 = Builders<Rootobject1>.Update.Set("timer8", secondsLeft);
                coll119.UpdateOne(filter9, update9);

                Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");

                var coll = db1.GetCollection<Rootobject1>("ekonomika");

                var cisla = await coll.Find(b => b.uzivatelid == najs).FirstAsync();
                int uzivatel6 = cisla.padelanasmlouva;
                int ahoj1 = cisla.cernaruka;

                int uzivatel8 = uzivatel6 + 1;

                Random random = new Random();
                int smrt1 = random.Next(50, 251);
                int smrt = smrt1 * uzivatel8;
                int cislo5 = smrt + ahoj1;

                List<string> url = new List<string>()
                {
                    "krádeží v čapáku",
                    "ukradením zemanovi hůlčičky",
                    "ukradením soukupova ega",
                };
                int ovce = random.Next(url.Count);
                var ovcak = new EmbedBuilder();
                ovcak.WithColor(Color.Green);
                ovcak.WithTitle($"právě jsi si vydělal {url[ovce]} {smrt} {agr} \n na černé ruce momentálně máš  {cislo5} storksCoinu {agr}");
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                //log
                await cons.SendMessageAsync("cernaprace " + ruka);

                //update
                var coll18 = db1.GetCollection<BsonDocument>("ekonomika");
                var filter8 = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
                var update8 = Builders<BsonDocument>.Update.Set("cernaruka", cislo5);

                coll18.UpdateOne(filter8, update8);
            }
            else
            {
                await Context.Channel.SendMessageAsync($"příkaz budeš moct použít až {uzivatel2}");
                await cons.SendMessageAsync($"černá práce {uzivatel2} {ruka}");
            }
        }
    }
}