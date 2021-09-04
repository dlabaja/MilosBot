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
    public class Dividenty : ModuleBase<SocketCommandContext>
    {
        public const int CooldownHod = 8;
        private const int penizeMig = 100;
        private const int penizeZam = 200;
        private const int penizeMistr = 400;
        private const int penizeExp = 800;
        private const int penizePor = 2_000;
        private const int penizeRedZav = 5_000;

        [Command("dividenty")]
        [FormatSummary("Získáš dividenty od státu, cooldonw {0} hod.", CooldownHod)]
        [FormatRemarks("Migrant - {0}\nZamestnanec - {1}\nMistr - {2}\nExpert - {3}\nPoradce - {4}\nŘeditel závodů - {5}",
            penizeMig, penizeZam, penizeMistr, penizeExp, penizePor, penizeRedZav)]
        public async Task DividentyAsync()
        {
            var najs = Context.User.Id.ToString();

            var hod = DateTime.UtcNow.AddHours(1);
            DateTime secondsLeft = hod.AddHours(CooldownHod);

            //read
            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");
            var coll11 = db.GetCollection<Rootobject1>("timery");

            var cisla1 = coll11.Find(b => b.uzivatelid == najs).FirstAsync().Result;
            DateTime uzivatel2 = cisla1.timer15;

            if (hod >= uzivatel2)
            {
                var coll18 = db.GetCollection<Rootobject1>("timery");
                var filter = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
                var update = Builders<Rootobject1>.Update.Set("timer15", secondsLeft);
                coll18.UpdateOne(filter, update);

                var ruka = Context.User as SocketGuildUser;

                var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "malafirma");
                var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "zivnost");
                var role4 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "strednemalafirma");
                var role5 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "strednifirma");
                var role6 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "vetsifirma");
                var role7 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "velkafirma");
                var role8 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "akciovaspolecnost");
                var role9 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "korporace");
                var role10 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "nadnarodnispolecnost");

                if (ruka.Roles.Contains(role2) || ruka.Roles.Contains(role4) || ruka.Roles.Contains(role5) || ruka.Roles.Contains(role6) || ruka.Roles.Contains(role7) || ruka.Roles.Contains(role8) || ruka.Roles.Contains(role9) || ruka.Roles.Contains(role10))
                {
                    Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");

                    var coll1 = db.GetCollection<Rootobject1>("ekonomika");

                    var cisla = coll1.Find(b => b.uzivatelid == najs).FirstAsync().Result;
                    int uzivatel52 = cisla.zamestnanci;
                    int uzivatel5 = cisla.pracujicimigranti;
                    int uzivatel57 = cisla.mistri;
                    int uzivatel55 = cisla.experti;
                    int uzivatel571 = cisla.poradci;
                    int uzivatel56 = cisla.riditelezavoduvesvete;
                    int uzivatel = cisla.banka;

                    int xuzivatel52 = uzivatel52 * penizeZam;
                    int xuzivatel5 = uzivatel5 * penizeMig;
                    int xuzivatel57 = uzivatel57 * penizeMistr;
                    int xuzivatel55 = uzivatel55 * penizeExp;
                    int xuzivatel571 = uzivatel571 * penizePor;
                    int xuzivatel56 = uzivatel56 * penizeRedZav;
                    int xuzivatel = xuzivatel52 + xuzivatel5 + xuzivatel57 + xuzivatel55 + xuzivatel571 + xuzivatel56;
                    int banka5 = xuzivatel + uzivatel;

                    //log
                    ITextChannel cons = Context.Client.GetChannel(814954423972266024) as ITextChannel;
                    await cons.SendMessageAsync("odmeny " + xuzivatel + " " + ruka);

                    var coll189 = db.GetCollection<Rootobject1>("ekonomika");
                    var update9 = Builders<Rootobject1>.Update.Set("banka", banka5);
                    coll189.UpdateOne(filter, update9);
                    await Context.Channel.SendMessageAsync("vybral jsi si na odměnách za zaměstnance od státu " + xuzivatel);
                }
                else
                {
                    await Context.Channel.SendMessageAsync("Odměny můžeš vybírat až budeš mít nějaké zaměstnance");
                }
            }
            else
            {
                var ruka = Context.User as SocketGuildUser;
                await Context.Channel.SendMessageAsync("příkaz budeš moct použít až " + uzivatel2);
                ITextChannel cons = Context.Client.GetChannel(814954423972266024) as ITextChannel;
                await cons.SendMessageAsync("dividenty " + uzivatel2 + " " + ruka);
            }
        }
    }
}