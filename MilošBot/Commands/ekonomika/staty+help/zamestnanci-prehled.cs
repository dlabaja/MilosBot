using Discord;
using Discord.Commands;
using Discord.WebSocket;
using MilošBot.Commands.Attributes;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands.help
{
    public class Zamestnanci : ModuleBase<SocketCommandContext>
    {
        private const int cooldownMin = 1;

        [Command("zam")]
        [Alias("zaměstnanci", "zamestnanci")]
        [FormatSummary("Zobrazí maximální počty zaměstnanů ve firmách, cooldown {0} min.", cooldownMin)]
        public async Task ZamestnanciAsync()
        {
            var najs = Context.User.Id.ToString();

            var hod = DateTime.UtcNow.AddHours(1);
            DateTime secondsLeft = hod.AddMinutes(cooldownMin);

            //read
            var client55 = new MongoClient("MongoDB connection string");
            var db55 = client55.GetDatabase("dbl");
            var coll55 = db55.GetCollection<Rootobject1>("timery");

            var cisla155 = await coll55.Find(b => b.uzivatelid == najs).FirstAsync();
            DateTime uzivatel255 = cisla155.timer6;

            var ruka = Context.User as SocketGuildUser;
            ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;

            if (hod >= uzivatel255)
            {
                var coll1555 = db55.GetCollection<Rootobject1>("timery");
                var filter = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
                var update = Builders<Rootobject1>.Update.Set("timer6", secondsLeft);
                coll1555.UpdateOne(filter, update);

                var ovcak = new EmbedBuilder();
                ovcak.WithColor(Color.Orange);
                ovcak.WithTitle("**POČTY ZAMĚSTNANCŮ**");
                ovcak.WithDescription(@" " +
                    "** živnost **" + " \n   `PRACUJICI MIGRANTI 0/0` " + "`ZAMĚSTNANCI 0/0`" + "  `MISTŘI 0/0`" + " `EXPERTI 0/0`" + "  `Poradci 0/0`" + "  `ŘIDITELÉ ZÁVODŮ VE SVĚTĚ 0/0`\n\n" +
                    "** MALÁ FIRMA **" + " \n  `PRACUJICI MIGRANTI 0/5` " + "`ZAMĚSTNANCI 0/5`" + "  `MISTŘI 0/0`" + " `EXPERTI 0/0`" + "  `Poradci 0/0`" + "  `ŘIDITELÉ ZÁVODŮ VE SVĚTĚ 0/0`\n\n" +
                    "** STŘEDNĚ MALÁ FIRMA **" + " \n  `PRACUJICI MIGRANTI 0/10` " + "`ZAMĚSTNANCI 0/15`" + "  `MISTŘI 0/1`" + " `EXPERTI 0/0`" + "  `Poradci 0/0`" + "  `ŘIDITELÉ ZÁVODŮ VE SVĚTĚ 0/0`\n\n" +
                    "** STŘEDNÍ FIRMA **" + " \n  `PRACUJICI MIGRANTI 0/10` " + "`ZAMĚSTNANCI 0/25`" + "  `MISTŘI 0/5`" + " `EXPERTI 0/0`" + "  `Poradci 0/0`" + "  `ŘIDITELÉ ZÁVODŮ VE SVĚTĚ 0/0`\n\n" +
                    "** VĚTŠÍ FIRMA **" + " \n  `PRACUJICI MIGRANTI 0/10` " + "`ZAMĚSTNANCI 0/100`" + "  `MISTŘI 0/20`" + " `EXPERTI 0/3`" + "  `Poradci 0/0`" + "  `ŘIDITELÉ ZÁVODŮ VE SVĚTĚ 0/0`\n\n" +
                    "** VELKÁ FIRMA **" + " \n  `PRACUJICI MIGRANTI 0/50` " + "`ZAMĚSTNANCI 0/150`" + "  `MISTŘI 0/50`" + " `EXPERTI 0/8`" + "  `Poradci 0/2`" + "  `ŘIDITELÉ ZÁVODŮ VE SVĚTĚ 0/0`\n\n" +
                    "** AKCIOVÁ SPOLEČNOST **" + " \n  `PRACUJICI MIGRANTI 0/200` " + "`ZAMĚSTNANCI 0/500`" + "  `MISTŘI 0/100`" + " `EXPERTI 0/10`" + "  `Poradci 0/5`" + "  `ŘIDITELÉ ZÁVODŮ VE SVĚTĚ 0/1`\n\n" +
                    "** KORPORACE **" + " \n  `PRACUJICI MIGRANTI 0/500` " + "`ZAMĚSTNANCI 0/1200`" + "  `MISTŘI 0/200`" + " `EXPERTI 0/50`" + "  `Poradci 0/25`" + "  `ŘIDITELÉ ZÁVODŮ VE SVĚTĚ 0/5`\n\n" +
                    "** NADNÁRODNÍ SPOLEČNOST **" + " \n  `PRACUJICI MIGRANTI 0/1000` " + "`ZAMĚSTNANCI 0/2000`" + "  `MISTŘI 0/350`" + " `EXPERTI 0/100`" + "  `Poradci 0/50`" + "  `ŘIDITELÉ ZÁVODŮ VE SVĚTĚ 0/15`\n\n");
                ovcak.WithFooter(footer =>
               {
                   footer
                   .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                   .WithText("Příkaz poslední záchrany od MilošBota");
               });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                await cons.SendMessageAsync($"zamestnanci-prehled {ruka}");
            }
            else
            {
                await Context.Channel.SendMessageAsync($"příkaz budeš moct použít až {uzivatel255}");
                await cons.SendMessageAsync($"zam {uzivatel255} {ruka}");
            }
        }
    }
}