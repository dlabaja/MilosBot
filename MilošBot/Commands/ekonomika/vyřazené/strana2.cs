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
//    public class helsdadaszthtdpoadsfdst : ModuleBase<SocketCommandContext>
//    {
//        [Command("strana2")]
//        [Alias("s2", "str2")]
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
//            DateTime uzivatel2 = cisla1.timer2;

//            var ruka = Context.User as SocketGuildUser;
//            ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;

//            if (hod >= uzivatel2)
//            {
//                var coll1 = db.GetCollection<Rootobject1>("timery");
//                var filter = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
//                var update = Builders<Rootobject1>.Update.Set("timer2", secondsLeft);
//                coll1.UpdateOne(filter, update);

//                using (Context.Channel.EnterTypingState())
//                {
//                    await Context.Message.DeleteAsync();
//                    await Context.Channel.SendMessageAsync("***STRANA 2***\n" +
//                    "A teď přichází teprve to zajímavé** .legalizovat <číslo>**. Pokud je číslo v kategorii 0-5% tak na to finančák nemá šanci přijít a ty legalizuješ zadaný počet STORKSCOINŮ.\n" +
//                    " Pokud ale je číslo v kategorii 5-10% tak už na to finančák může přijít, ale šance je jen asi 30%. Kategorie 10-15% je sice rychlá, ale taky extrémně nebezpečná s šancí provalení až 65%. Tady už si musí vybrat každý sám, co se mu vyplatí a co už ne… Málem bych zapomněl, vše co je nad 15% tak nepůjde.\n Kdyby se někdy náhodou stalo, že by jsi chtěl, převádět opačným směrem tak to jde přes příkaz **.ztratit**. Jak název napovídá, z tvé lagální ruky se strhne 10% kterých se převede na ruku nelegální.\n" +
//                    " Neboj, ani na hazard jsme nezapomněli, na legálním trhu je to **.vsadit <číslo>**. Číslo musí být větší než jedna, a zároveň menší než 500, protože je to regulováno státem. Šance na výhru je 50%. výhra činí vklad krát 5 (pokud daný sázející vlastní kreditku tak krát 6).\n" +
//                    " Na černém trhu je možnost sázky taky a to formou **.ruskaruleta <číslo>**. Tato sázka je podstatně těžší. Její minimální vklad činí 1 000 STORKSCOINŮ. Trochu ti to popíšu. Šance na výhru je 30%. Pokud je tvoje sázka 1 000-4 000 tak výhra = sázka krát 6 (s padělanou smlouvou 7). Pokud ale vsadíš 4 000-8 000 tak násobič je 4 (potažmo 5). V kategorii 8 000-12 000 je násobič 2 (se smlouvou tři). Sázky větší než 12 000 se podle mě nevyplatí, protože šance na výhru je 1ku3 ale výhra je sázka krát jedna (dva). \n" +
//                    "*O ukládání do banky na straně tři.* **(.strana3)**");
//                }

//                await cons.SendMessageAsync($"strana2 {ruka}");
//            }
//            else
//            {
//                await Context.Channel.SendMessageAsync($"příkaz budeš moct použít až {uzivatel2}");
//                await cons.SendMessageAsync($"strana2 {uzivatel2} {ruka}");
//            }
//        }
//    }
//}

///*
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

//namespace MilošBot.Commands.help
//{
//    public class helsdadasdpoadsfdst : ModuleBase<SocketCommandContext>
//    {
//        [Command("strana2")]
//        [Alias("s2", "str2")]
//        public async Task Mildosaurus()
//        {
//            using (Context.Channel.EnterTypingState())
//            {
//                await Context.Message.DeleteAsync();
//                await Context.Channel.SendMessageAsync("***STRANA 2***\n" +
//                    "A teď přichází teprve to zajímavé** .legalizovat <číslo>**. Pokud je číslo v kategorii 0-5% tak na to finančák nemá šanci přijít a ty legalizuješ zadaný počet STORKSCOINŮ.\n" +
//                    " Pokud ale je číslo v kategorii 5-10% tak už na to finančák může přijít, ale šance je jen asi 30%. Kategorie 10-15% je sice rychlá, ale taky extrémně nebezpečná s šancí provalení až 65%. Tady už si musí vybrat každý sám, co se mu vyplatí a co už ne… Málem bych zapomněl, vše co je nad 15% tak nepůjde.\n Kdyby se někdy náhodou stalo, že by jsi chtěl, převádět opačným směrem tak to jde přes příkaz **.ztratit**. Jak název napovídá, z tvé lagální ruky se strhne 10% kterých se převede na ruku nelegální.\n" +
//                    " Neboj, ani na hazard jsme nezapomněli, na legálním trhu je to **.vsadit <číslo>**. Číslo musí být větší než jedna, a zároveň menší než 500, protože je to regulováno státem. Šance na výhru je 50%. výhra činí vklad krát 5 (pokud daný sázející vlastní kreditku tak krát 6).\n" +
//                    " Na černém trhu je možnost sázky taky a to formou **.ruskaruleta <číslo>**. Tato sázka je podstatně těžší. Její minimální vklad činí 1 000 STORKSCOINŮ. Trochu ti to popíšu. Šance na výhru je 30%. Pokud je tvoje sázka 1 000-4 000 tak výhra = sázka krát 6 (s padělanou smlouvou 7). Pokud ale vsadíš 4 000-8 000 tak násobič je 4 (potažmo 5). V kategorii 8 000-12 000 je násobič 2 (se smlouvou tři). Sázky větší než 12 000 se podle mě nevyplatí, protože šance na výhru je 1ku3 ale výhra je sázka krát jedna (dva). \n" +
//                    "*O ukládání do banky na straně tři.* **(.strana3)**");
//            }
//            //log
//            var ruka = Context.User as SocketGuildUser;
//            ITextChannel cons = Context.Client.GetChannel(814954423972266024) as ITextChannel;
//            await cons.SendMessageAsync("strana2 " + ruka);
//        }
//    }
//}*/