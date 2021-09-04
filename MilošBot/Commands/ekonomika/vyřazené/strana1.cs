//using Discord;
//using Discord.Commands;
//using Discord.WebSocket;
//using MongoDB.Driver;
//using System;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MilošBot.Commands.help
//{
//    public class helsdadaszthatdpoadsfdst : ModuleBase<SocketCommandContext>
//    {
//        [Command("strana1")]
//        [Alias("s1", "str1")]
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
//            DateTime uzivatel2 = cisla1.timer1;

//            var ruka = Context.User as SocketGuildUser;
//            ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;

//            if (hod >= uzivatel2)
//            {
//                var coll1 = db.GetCollection<Rootobject1>("timery");
//                var filter = Builders<Rootobject1>.Filter.Eq("uzivatelid", najs);
//                var update = Builders<Rootobject1>.Update.Set("timer1", secondsLeft);
//                coll1.UpdateOne(filter, update);

//                using (Context.Channel.EnterTypingState())
//                {
//                    await Context.Message.DeleteAsync();
//                    await Context.Channel.SendMessageAsync("***STRANA 1***\n" +
//                        "Pokud ti nestačí **.help-dbl** tak tady je delší průvodce. Na začátek bych ti chtěl popřát, ať se ti v ekonomice daří a ať se ti hlavně líbí. " +
//                        "\n Prvním příkazem, kterým začneš, je **.registrovat**.Tento příkaz tě registruje do databáze. Proč to máme přes příkaz? Protože  kdybychom se to snažili dělat automaticky, tak nám to spamuje konzoli chybami. Teď je asi důležité si něco povědět o naší měně. Jako měnu používáme ŠTORKSCOINY. Ptáte se, jak to vzniklo? Úplně v počátku byl čáp (anglicky stork). Takže zjednodušeně platíme čápy :XD:." +
//                        "\n Tvůj první příkaz jak vydělávat je **.pracovat**. Za odvedenou práci dostaneš 1-100 STOKSCOINŮ. Zdá se ti to málo? Ano je to málo. Proto jako první co doporučuji udělat je koupit si kreditku. Myslíš si, že než na ní vyděláš tak budeš muset dlouho čekat? Pokud půjdeš opatrnou cestou, a to jen přes .pracovat tak ano, ale není to jediný příkaz na vydělávání ze začátku. Do této doby jsem se vůbec nezmínil o tom, že v této ekonomice je i černý trh. Nevěříte? **.Černá práce** je obdoba příkazu .pracovat jen na jiném trhu. " +
//                        "\n Je všeobecně známo že na černém trhu se točí mnohonásobně více peněz. Jinak tomu není ani u černé práce kdy z jednoho jobu vyděláte 50-250 STORKSCOINŮ. Teď ale pozor! Příkazem .ruce se vypíše tvá balance. Zjišťuješ, že mince má dvě strany a jinak tomu není ani u naší ekonomiky. Přece by bylo podezřelé kdyby se ti velké peníze z černého trhu válely po ubytovně, a tak si je radši schováváš v lese pod kamenem. První co tě napadá je jistě zdali si tyto peníze můžeš převést na legální ruku? Ano jde to, ale není to tak jednoduché. Na finančním úřadě pravidelně kontrolují daňová přiznání, tím pádem to nesmíš legalizovat moc rychle, aby tě FBI nezačala sledovat a nenašla tvoji skrýš pod kamenem v lese. " + "Neboj, nechci tě trápit matematikou, tak jsem si pro tebe připravil příkaz **.legalizovat-výpočet**. Tento příkaz ti spočítá 5, 10, 15% STORKSCOINŮ na tvé černé ruce. \n *Pokračování na druhé straně.* **(.strana2)**");
//                }
//                //log

//                await cons.SendMessageAsync($"strana3 {ruka}");
//            }
//            else
//            {
//                await Context.Channel.SendMessageAsync($"příkaz budeš moct použít až {uzivatel2}");
//                await cons.SendMessageAsync($"strana3 {uzivatel2} {ruka}");
//            }
//        }
//    }
//}

///*using System;
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
//    public class helpoadsfdst : ModuleBase<SocketCommandContext>
//    {
//        [Command("strana1")]
//        [Alias("s1", "str1")]
//        public async Task Mildosaurus()  //dopnit antispam
//        {
//            using (Context.Channel.EnterTypingState())
//            {
//                await Context.Message.DeleteAsync();
//                await Context.Channel.SendMessageAsync("***STRANA 1***\n" +
//                    "Pokud ti nestačí **.help-dbl** tak tady je delší průvodce. Na začátek bych ti chtěl popřát, ať se ti v ekonomice daří a ať se ti hlavně líbí. " +
//                    "\n Prvním příkazem, kterým začneš, je **.registrovat**.Tento příkaz tě registruje do databáze. Proč to máme přes příkaz? Protože  kdybychom se to snažili dělat automaticky, tak nám to spamuje konzoli chybami. Teď je asi důležité si něco povědět o naší měně. Jako měnu používáme ŠTORKSCOINY. Ptáte se, jak to vzniklo? Úplně v počátku byl čáp (anglicky stork). Takže zjednodušeně platíme čápy :XD:." +
//                    "\n Tvůj první příkaz jak vydělávat je **.pracovat**. Za odvedenou práci dostaneš 1-100 STOKSCOINŮ. Zdá se ti to málo? Ano je to málo. Proto jako první co doporučuji udělat je koupit si kreditku. Myslíš si, že než na ní vyděláš tak budeš muset dlouho čekat? Pokud půjdeš opatrnou cestou, a to jen přes .pracovat tak ano, ale není to jediný příkaz na vydělávání ze začátku. Do této doby jsem se vůbec nezmínil o tom, že v této ekonomice je i černý trh. Nevěříte? **.Černá práce** je obdoba příkazu .pracovat jen na jiném trhu. " +
//                    "\n Je všeobecně známo že na černém trhu se točí mnohonásobně více peněz. Jinak tomu není ani u černé práce kdy z jednoho jobu vyděláte 50-250 STORKSCOINŮ. Teď ale pozor! Příkazem .ruce se vypíše tvá balance. Zjišťuješ, že mince má dvě strany a jinak tomu není ani u naší ekonomiky. Přece by bylo podezřelé kdyby se ti velké peníze z černého trhu válely po ubytovně, a tak si je radši schováváš v lese pod kamenem. První co tě napadá je jistě zdali si tyto peníze můžeš převést na legální ruku? Ano jde to, ale není to tak jednoduché. Na finančním úřadě pravidelně kontrolují daňová přiznání, tím pádem to nesmíš legalizovat moc rychle, aby tě FBI nezačala sledovat a nenašla tvoji skrýš pod kamenem v lese. " + "Neboj, nechci tě trápit matematikou, tak jsem si pro tebe připravil příkaz **.legalizovat-výpočet**. Tento příkaz ti spočítá 5, 10, 15% STORKSCOINŮ na tvé černé ruce. \n *Pokračování na druhé straně.* **(.strana2)**");
//            }
//            //log
//            var ruka = Context.User as SocketGuildUser;
//            ITextChannel cons = Context.Client.GetChannel(814954423972266024) as ITextChannel;
//            await cons.SendMessageAsync("strana1 " + ruka);
//        }
//    }
//}*/