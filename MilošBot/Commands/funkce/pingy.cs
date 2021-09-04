using Discord;
using Discord.Commands;
using Discord.Rest;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace MilošBot.Commands
{
    public class Pingy : ModuleBase<SocketCommandContext>
    {
        private RestUserMessage zprava;
        private Timer aTimer = new Timer(1000);

        private Emoji[] reakce = new Emoji[] {
            new Emoji("1️⃣"),
            new Emoji("2️⃣"),
            new Emoji("3️⃣"),
            new Emoji("4️⃣"),
            new Emoji("5️⃣")};

        //new Emoji("4️⃣")

        [Command("pingy")]
        [Summary("Otevři si DM a nastav si pingy co chceš u nás dostávat. Nastavování upozornění nikdy nebylo jednodušší")]
        public async Task PingyAsync()
        {
            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");
            var coll = db.GetCollection<MongoPingy>("pingy");
            var collec = db.GetCollection<BsonDocument>("pingy");

            var data = coll.Find(b => b.idcko == Context.User.Id.ToString()).FirstOrDefaultAsync().Result;
            if (data == null)
            {
                var pridani = new BsonDocument { { "nick", Context.User.ToString() }, { "idcko", Context.User.Id.ToString() }, { "oznameni", true }, { "promo", true }, { "freehry", false }, { "politika", false }, { "pocasi", false } };
                collec.InsertOne(pridani);
            }

            var pingy = coll.Find(b => b.idcko == Context.User.Id.ToString()).FirstAsync().Result;
            var ovcak = new EmbedBuilder();
            ovcak.WithTitle("Vaše **dbl gaming** pingy na jednom místě");
            ovcak.WithDescription(":one: Oznámení‎‎‏‏‎ ‎‏‏‎ ‎" + TrueFalse(pingy.oznameni) + "\n:two: Promo                          ‎‏‏‎‎‏‏‎‎‏‏‎" + TrueFalse(pingy.promo) + "\n:three: Free hry‏‏‎ ‎‏‏‎ ‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‎" + TrueFalse(pingy.freehry) + "\n:four: Politika‏‏‎ ‎‏‏‎ ‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎  ‎‎‎‎  ‎‎‎‎‎‎‎‎" + TrueFalse(pingy.politika) + "\n:five: Počasí ‎‏‏‎ ‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎  ‎‎ ‎‎‎‎ ‎‎‎‎ ‎‎‎‎‎‎‎‎" + TrueFalse(pingy.pocasi));
            ovcak.WithFooter(footer =>
            {
                footer
                .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                .WithText("Nastavení pingů od MilošBota");
            });

            try
            {
                zprava = (RestUserMessage)await UserExtensions.SendMessageAsync(Context.User, embed: ovcak.Build());
            }
            catch (Discord.Net.HttpException)
            {
                await ReplyAsync("Nemůžu ti poslat zprávu, otevři si DM");
                return;
            }
            await ReplyAsync("Poslal jsem ti zprávu do DM, " + pingy.nick);

            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //aTimer.Start();
            await zprava.AddReactionsAsync(reakce);
            await Task.Delay(20000);
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            foreach (var reaktion in reakce)
            {
                /*var lidi = zprava.GetReactionUsersAsync(reaktion, zprava.Reactions.Count).FlattenAsync().Result;
                Console.WriteLine("e");
                foreach (var user in lidi)
                {
                    Console.WriteLine(user);
                    /*if ()
                    {
                        Console.WriteLine("" + user + reakce);
                        aTimer.Stop();
                    }
                }*/
            }
        }

        public Emote TrueFalse(bool b)
        {
            if (b)
                return Emote.Parse("<:check:830732009557983264>");
            else
                return Emote.Parse("<:cross_mark_red:830720259656908800>");
        }
    }

    public class MongoPingy
    {
        public ObjectId _id { get; set; }
        public string nick { get; set; }
        public string idcko { get; set; }
        public bool oznameni { get; set; }
        public bool freehry { get; set; }
        public bool politika { get; set; }
        public bool promo { get; set; }
        public bool pocasi { get; set; }
    }
}