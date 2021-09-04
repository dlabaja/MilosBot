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

namespace MilošBot.Commands.help
{
    public class hejkyxyxklpost : ModuleBase<SocketCommandContext>
    {
        private const int cooldownMin = 30;

        [Command("práce")]
        [Alias("pracovat", "prace", "pracant")]
        [FormatSummary("Vydělá peníze na normální ruce, cooldown {0} min.", cooldownMin)]
        public async Task PracovatAsync()
        {
            var najs = Context.User.Id.ToString();
            var hod = DateTime.UtcNow.AddHours(1);
            DateTime secondsLeft = hod.AddMinutes(cooldownMin);

            var client9 = new MongoClient("MongoDB connection string");
            var db = client9.GetDatabase("dbl");
            var coll19 = db.GetCollection<Rootobject1>("timery");

            var cisla1 = await coll19.Find(b => b.uzivatelid == najs).FirstAsync();
            DateTime uzivatel27 = cisla1.timer9;
            ITextChannel cons1 = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;
            var ruka = Context.User as SocketGuildUser;

            if (hod >= uzivatel27)
            {
                var coll119 = db.GetCollection<Rootobject1>("timery");
                var filter9 = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
                var update9 = Builders<Rootobject1>.Update.Set("timer9", secondsLeft);
                coll119.UpdateOne(filter9, update9);

                var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "databáze");

                if (!ruka.Roles.Contains(role2))
                {
                    await Context.Message.Channel.SendMessageAsync("nejspíše nejsi registrován do ekonomiky, použij příkaz .registrovat");
                    return;
                }

                await cons1.SendMessageAsync($"prace {ruka}");

                var coll = db.GetCollection<Rootobject1>("ekonomika");

                var cisla = await coll.Find(b => b.uzivatelid == najs).FirstAsync();
                int uzivatel6 = cisla.kreditka;
                int uzivatel = cisla.cum;

                Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");

                int uzivatel7 = 1;
                int uzivatel8 = uzivatel6 + uzivatel7;

                Random random = new Random();
                int smrt1 = random.Next(1, 101);
                int smrt = smrt1 * uzivatel8;
                int cislo5 = (int)(smrt + uzivatel);

                var coll1 = db.GetCollection<BsonDocument>("ekonomika");
                var filter = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
                var update = Builders<BsonDocument>.Update.Set("cum", cislo5);
                coll1.UpdateOne(filter, update);

                List<string> url = new List<string>()
            {
                "krádeží v čapáku",
                "ukradením zemanovi hůlčičky",
                "ukradením soukupova ega",
            };
                int ovce = random.Next(0, url.Count);
                var ovcak = new EmbedBuilder();
                ovcak.WithColor(Color.Green);
                ovcak.WithTitle($"právě jsi si vydělal {url[ovce]} {smrt} {agr} \n na ruce momentálně máš {cislo5} storksCoinu {agr}");
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());
            }
            else
            {
                await Context.Channel.SendMessageAsync($"příkaz budeš moct použít až {uzivatel27}");
                await cons1.SendMessageAsync($"pracovat {uzivatel27} {ruka}");
            }
        }
    }
}