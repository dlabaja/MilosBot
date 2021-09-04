using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using MilošBot.Commands.Attributes;
using MongoDB.Driver;

namespace MilošBot.Commands
{
    public class heladadadapost : ModuleBase<SocketCommandContext>
    {
        private const int cooldownMin = 10;

        [Command("ztratit")]
        [Alias("stratit", "ztráta", "stráta")]
        [FormatSummary("Převedeš peníze z legílní ruky na černou, cooldown je {0} min.", cooldownMin)]
        public async Task ZtratitAsync()
        {
            var najs = Context.User.Id.ToString();

            var hod = DateTime.UtcNow.AddHours(1);
            DateTime secondsLeft = hod.AddMinutes(cooldownMin);

            //read
            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");
            var coll = db.GetCollection<Rootobject1>("timery");

            var cisla1 = await coll.Find(b => b.uzivatelid == najs).FirstAsync();
            DateTime uzivatel27 = cisla1.timer14;

            ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;
            var ruka = Context.User as SocketGuildUser;

            if (hod >= uzivatel27)
            {
                var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "databáze");
                if (ruka.Roles.Contains(role2))
                {
                    var coll1 = db.GetCollection<Rootobject1>("timery");
                    var filter = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
                    var update = Builders<Rootobject1>.Update.Set("timer14", secondsLeft);
                    coll1.UpdateOne(filter, update);

                    Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");

                    var coll16 = db.GetCollection<Rootobject1>("ekonomika");

                    var cisla16 = await coll16.Find(b => b.uzivatelid == najs).FirstAsync();
                    int uzivatel = cisla16.cum;
                    int uzivatel2 = cisla16.cernaruka;

                    int uzivatel5 = uzivatel / 10;
                    int uzivatel10 = uzivatel2 + uzivatel5;
                    int uzivatel11 = uzivatel - uzivatel5;

                    var coll13 = db.GetCollection<Rootobject1>("ekonomika");
                    var update3 = Builders<Rootobject1>.Update.Set("cernaruka", uzivatel10);
                    var update30 = Builders<Rootobject1>.Update.Set("cum", uzivatel11);

                    coll13.UpdateOne(filter, update3);
                    coll13.UpdateOne(filter, update30);

                    var ovcak = new EmbedBuilder();
                    ovcak.WithColor(Color.Green);
                    ovcak.WithTitle($"Právě se ti povedlo ehmmmmm ztratit {uzivatel5} {agr} STORKSCOINS \n Na legální ruce máš momentálně {uzivatel11} {agr} STORKSCOINS \n A na černé ruce máš momentálně {uzivatel10} {agr} STORKSCOINS");
                    await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                    await cons.SendMessageAsync($"ztratit {ruka}");
                }
                else { await ReplyAsync("nejspíše nejsi registrován do ekonomiky"); }
            }
            else
            {
                await Context.Channel.SendMessageAsync($"příkaz budeš moct použít až {uzivatel27}");
                await cons.SendMessageAsync($"ztratit {uzivatel27} {ruka}");
            }
        }
    }
}