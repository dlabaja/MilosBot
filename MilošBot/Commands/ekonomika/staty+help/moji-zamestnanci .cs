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
    public class helpsadvdfOaJMdvfpol : ModuleBase<SocketCommandContext>
    {
        private const int cooldownMin = 1;

        [Command("moji-zam")]
        [Alias("zamestnanci-moji", "moji-zamestnanci", "zam-moji")]
        [FormatSummary("Zobrazí  počty zaměstnanů v mojí firmě, cooldown {0} min.", cooldownMin)]
        public async Task MojiZamestnanciAsync()
        {
            var najs = Context.User.Id.ToString();

            var hod = DateTime.UtcNow.AddHours(1);
            DateTime secondsLeft = hod.AddMinutes(cooldownMin);

            var client55 = new MongoClient("MongoDB connection string");
            var db55 = client55.GetDatabase("dbl");
            var coll55 = db55.GetCollection<Rootobject1>("timery");

            var cisla155 = await coll55.Find(b => b.uzivatelid == najs).FirstAsync();
            DateTime uzivatel255 = cisla155.timer5;

            var ruka = Context.User as SocketGuildUser;
            ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;

            if (hod >= uzivatel255)
            {
                var coll1555 = db55.GetCollection<Rootobject1>("timery");
                var filter = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
                var update = Builders<Rootobject1>.Update.Set("timer5", secondsLeft);
                coll1555.UpdateOne(filter, update);

                Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");

                var client = new MongoClient("MongoDB connection string");
                var db = client.GetDatabase("dbl");
                var coll = db.GetCollection<Rootobject1>("ekonomika");

                await cons.SendMessageAsync($"moji zam {ruka}");

                var cisla = await coll.Find(b => b.uzivatelid == najs).FirstAsync();
                int uzivatel1 = cisla.zivnost;
                int uzivatel21 = cisla.malafirma;
                int uzivatel211 = cisla.strednemalafirma;
                int uzivatel221 = cisla.strednifirma;
                int uzivatel13 = cisla.vetsifirma;
                int uzivatel173 = cisla.velkafirma;
                int uzivatel183 = cisla.akciovaspolecnost;
                int uzivatel193 = cisla.korporace;
                int uzivatel143 = cisla.nadnarodnispolecnost;
                int uzivatel3 = cisla.pracujicimigranti;
                int uzivatel4 = cisla.zamestnanci;
                int uzivatel41 = cisla.mistri;
                int uzivatel42 = cisla.experti;
                int uzivatel43 = cisla.poradci;
                int uzivatel44 = cisla.riditelezavoduvesvete;

                int soucet111 = uzivatel3 + uzivatel4 + uzivatel41 + uzivatel42 + uzivatel43 + uzivatel44;

                int soucet = uzivatel221 + uzivatel211 + uzivatel21 + uzivatel193 + uzivatel183 + uzivatel173 + uzivatel143 + uzivatel13 + uzivatel1;
                if (soucet == 0)
                {
                    await Context.Channel.SendMessageAsync("Dokud nebudeš vlastnit alespoň živnost, tak ti tvoji zaměstnanci mohou být jedno :D");
                    return;
                }

                var arr = new[]
                {
                    "",
                    "** živnost **[{0}] \n   `PRACUJICI MIGRANTI {1}/0` `ZAMĚSTNANCI {2}/0` `MISTŘI {3}/0` `EXPERTI {4}/0` `Poradci {5}/0` `ŘIDITELÉ ZÁVODŮ VE SVĚTĚ {6}/0`\n\n" ,
                    "** MALÁ FIRMA **[{0}] \n  `PRACUJICI MIGRANTI {1}/5` `ZAMĚSTNANCI {2}/5` `MISTŘI {3}/0` `EXPERTI  {4}/0`" + "  `Poradci {5}/0`" + "  `ŘIDITELÉ ZÁVODŮ VE SVĚTĚ {6}/0`\n\n" ,
                    "** STŘEDNĚ MALÁ FIRMA **[{0}] \n  `PRACUJICI MIGRANTI {1}/10` " + "`ZAMĚSTNANCI {2}/15`" + "  `MISTŘI {3}/1`" + " `EXPERTI  {4}/0`" + "  `Poradci {5}/0`" + "  `ŘIDITELÉ ZÁVODŮ VE SVĚTĚ {6}/0`\n\n" ,
                    "** STŘEDNÍ FIRMA **[{0}] \n  `PRACUJICI MIGRANTI {1}/10` " + "`ZAMĚSTNANCI {2}/25`" + "  `MISTŘI {3}/5`" + " `EXPERTI  {4}/0`" + "  `Poradci {5}/0`" + "  `ŘIDITELÉ ZÁVODŮ VE SVĚTĚ {6}/0`\n\n" ,
                    "** VĚTŠÍ FIRMA **[{0}] \n  `PRACUJICI MIGRANTI {1}/10` " + "`ZAMĚSTNANCI {2}/100`" + "  `MISTŘI {3}/20`" + " `EXPERTI  {4}/3`" + "  `Poradci {5}/0`" + "  `ŘIDITELÉ ZÁVODŮ VE SVĚTĚ {6}/0`\n\n" ,
                    "** VELKÁ FIRMA **[{0}] \n  `PRACUJICI MIGRANTI {1}/50` " + "`ZAMĚSTNANCI {2}/150`" + "  `MISTŘI {3}/50`" + " `EXPERTI  {4}/8`" + "  `Poradci {5}/2`" + "  `ŘIDITELÉ ZÁVODŮ VE SVĚTĚ {6}/0`\n\n" ,
                    "** AKCIOVÁ SPOLEČNOST **[{0}] \n  `PRACUJICI MIGRANTI {1}/200` " + "`ZAMĚSTNANCI {2}/500`" + "  `MISTŘI  {4}/100`" + " `EXPERTI  {4}/10`" + "  `Poradci {5}/5`" + "  `ŘIDITELÉ ZÁVODŮ VE SVĚTĚ {6}/1`\n\n" ,
                    "** KORPORACE **[{0}] \n  `PRACUJICI MIGRANTI {1}/500` " + "`ZAMĚSTNANCI {2}/1200`" + "  `MISTŘI {3}/200`" + " `EXPERTI  {4}/50`" + "  `Poradci {5}/25`" + "  `ŘIDITELÉ ZÁVODŮ VE SVĚTĚ {6}/5`\n\n" ,
                    "** NADNÁRODNÍ SPOLEČNOST **[{0}] \n  `PRACUJICI MIGRANTI {1}/1000` " + "`ZAMĚSTNANCI {2}/2000`" + "  `MISTŘI {3}/350`" + " `EXPERTI {4}/100`" + "  `Poradci {5}/50`" + "  `ŘIDITELÉ ZÁVODŮ VE SVĚTĚ {6}/15`\n\n"
                };
                var ovcak12 = new EmbedBuilder();
                ovcak12.WithColor(Color.Orange);
                ovcak12.WithTitle("**POČTY TVOJICH ZAMĚSTNANCŮ**");
                for (int i = soucet; i < arr.Length; i++)
                {
                    Console.WriteLine(i);
                    var firma = i == soucet ? "vlastniš" : "nevlastníš";
                    ovcak12.Description += string.Format(arr[i], firma, uzivatel3, uzivatel4, uzivatel41, uzivatel42, uzivatel43, uzivatel44);
                }
                ovcak12.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Počty zaměstnanců od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak12.Build());
                return;
            }
            else
            {
                await Context.Channel.SendMessageAsync($"příkaz budeš moct použít až {uzivatel255}");
                await cons.SendMessageAsync($"moji-zam {uzivatel255} {ruka}");
            }
        }
    }
}