//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Discord;
//using Discord.Commands;
//using Discord.API;
//using Discord.Rest;
//using Discord.WebSocket;
//using System.Text;
//using System.Timers;
//using MongoDB.Bson;
//using MongoDB.Driver;

//namespace MilošBot.Commands.help
//{
//    public class helsdadaszthtdpoadsofdst : ModuleBase<SocketCommandContext>
//    {
//        [Command("strana3")]
//        [Alias("s3", "str3")]
//        public async Task Mildosaurus()
//        {
//            var najs = Context.User.Id.ToString();

//            var hod = DateTime.UtcNow.AddHours(1);
//            DateTime secondsLeft = hod.AddMinutes(5);

//            //read
//            var client = new MongoClient("MongoDB connection string");
//            var db = client.GetDatabase("dbl");
//            var coll = db.GetCollection<Rootobject1>("timery");

//            var cisla1 = await coll.Find(b => b.uzivatelid == najs).FirstAsync();
//            DateTime uzivatel2 = cisla1.timer3;

//            var ruka = Context.User as SocketGuildUser;
//            ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;

//            if (hod >= uzivatel2)
//            {
//                var coll1 = db.GetCollection<Rootobject1>("timery");
//                var filter = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
//                var update = Builders<Rootobject1>.Update.Set("timer3", secondsLeft);
//                coll1.UpdateOne(filter, update);

//                using (Context.Channel.EnterTypingState())
//                {
//                    await Context.Message.DeleteAsync();
//                    await Context.Channel.SendMessageAsync("***STRANA 3***\n" +
//                        "Banka je asi momentálně nejbezpečnější místo kam uložit peníze. Přes příkaz **.uložit <číslo>** Pokud číslo nezadáš, uložíš do banky polovinu své legální ruky. Můžeš však ale zadat i konkrétní číslo. Pokud toto číslo bude menší jak polovina Miloš uloží na tvůj účet v bance právě toto číslo. Pokud ale číslo bude větší než polovina, Miloš uloží pouze polovinu. Dosti podobně funguje příkaz **.vybrat <číslo>** jen to vezme čtvrtinu z banky a připíše na legální ruku. Číslo které tam můžete zadat funguje úplně stejně jak u předchozího příkazu. ***U obou příkazů je 10% daň!*** \n" +
//                        "Dalším velkým okruhem, je příkaz **.loupež <indikátor> <uživatel>**. Pro kradení z banky ale musíte vlastnit **ČERVENÉ TRENÝRKY** kterými si zakryjete obličej, aby vás nikdo nepoznal. Pokud indikátor je roven „banka‘‘ tak je šance jedna ku deseti že uživateli ukradnete 2-5% z banky. Pokud indikátor je ruka ukradnete 10% z legální ruky s 50% šancí. S indikátorem černá ukradnete s 25% šancí 25% černé ruky.\n" +
//                        " *Na další straně o založení firmy a prvních zaměstnancích…* **(.strana4)**");
//                }

//                await cons.SendMessageAsync($"strana3 {ruka}");
//            }
//            else
//            {
//                await Context.Channel.SendMessageAsync($"příkaz budeš moct použít až {uzivatel2} ");
//                await cons.SendMessageAsync($"strana3 {uzivatel2} {ruka}");
//            }
//        }
//    }
//}