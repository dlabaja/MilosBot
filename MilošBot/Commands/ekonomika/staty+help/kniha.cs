using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace MilošBot.Commands.help
{
    public class Kniha : ModuleBase<SocketCommandContext>
    {
        private IUserMessage _msg;
        private IUser _usr;

        [Command("kniha")]
        [Summary("Zobrazí rozepsanou nápovšdu k ekonomice.")]
        public async Task KnihaAsync()
        {
            var dmChannel = await Context.User.GetOrCreateDMChannelAsync();

            _usr = Context.User;
            _msg = await dmChannel.SendMessageAsync(embed: new EmbedBuilder() { Title = "Kniha" }
            .WithDescription("vyber si stranu\n1 - vydělávání\n2 - hazard a převody\n3 - O ukládání do banky\n4 -  Založení firmy a první zaměstnanci")
            .Build());
            await _msg.AddReactionsAsync(new[] { new Emoji("1️⃣"), new Emoji("2️⃣"), new Emoji("3️⃣"), new Emoji("4️⃣") });
            await Task.Delay(1000);
            Context.Client.ReactionAdded += Client_ReactionAdded;
            endTime = DateTime.Now.AddMinutes(1);
            while (DateTime.Now < endTime)
                await Task.Delay(1000);
            Context.Client.ReactionAdded -= Client_ReactionAdded;
            await _msg.RemoveAllReactionsAsync();
        }

        private DateTime endTime;

        private Task Client_ReactionAdded(Cacheable<IUserMessage, ulong> arg1, Discord.WebSocket.ISocketMessageChannel arg2, Discord.WebSocket.SocketReaction arg3)
        {
            if (arg3.MessageId == _msg.Id && arg3.UserId == _usr.Id)
            {
                endTime = DateTime.Now.AddMinutes(4);
                if (arg3.Emote.Name == new Emoji("1️⃣").Name)
                {
                    _msg.RemoveReactionAsync(new Emoji("1️⃣"), arg3.User.Value);
                    _msg.ModifyAsync(mp => mp.Content = "***STRANA 1***\n" +
                        "Pokud ti nestačí **.help-dbl** tak tady je delší průvodce. Na začátek bych ti chtěl popřát, ať se ti v ekonomice daří a ať se ti hlavně líbí. " +
                        "\n Prvním příkazem, kterým začneš, je **.registrovat**.Tento příkaz tě registruje do databáze. Proč to máme přes příkaz? Protože  kdybychom se to snažili dělat automaticky, tak nám to spamuje konzoli chybami. Teď je asi důležité si něco povědět o naší měně. Jako měnu používáme ŠTORKSCOINY. Ptáte se, jak to vzniklo? Úplně v počátku byl čáp (anglicky stork). Takže zjednodušeně platíme čápy :XD:." +
                        "\n Tvůj první příkaz jak vydělávat je **.pracovat**. Za odvedenou práci dostaneš 1-100 STOKSCOINŮ. Zdá se ti to málo? Ano je to málo. Proto jako první co doporučuji udělat je koupit si kreditku. Myslíš si, že než na ní vyděláš tak budeš muset dlouho čekat? Pokud půjdeš opatrnou cestou, a to jen přes .pracovat tak ano, ale není to jediný příkaz na vydělávání ze začátku. Do této doby jsem se vůbec nezmínil o tom, že v této ekonomice je i černý trh. Nevěříte? **.Černá práce** je obdoba příkazu .pracovat jen na jiném trhu. " +
                        "\n Je všeobecně známo že na černém trhu se točí mnohonásobně více peněz. Jinak tomu není ani u černé práce kdy z jednoho jobu vyděláte 50-250 STORKSCOINŮ. Teď ale pozor! Příkazem .ruce se vypíše tvá balance. Zjišťuješ, že mince má dvě strany a jinak tomu není ani u naší ekonomiky. Přece by bylo podezřelé kdyby se ti velké peníze z černého trhu válely po ubytovně, a tak si je radši schováváš v lese pod kamenem. První co tě napadá je jistě zdali si tyto peníze můžeš převést na legální ruku? Ano jde to, ale není to tak jednoduché. Na finančním úřadě pravidelně kontrolují daňová přiznání, tím pádem to nesmíš legalizovat moc rychle, aby tě FBI nezačala sledovat a nenašla tvoji skrýš pod kamenem v lese. " + "Neboj, nechci tě trápit matematikou, tak jsem si pro tebe připravil příkaz **.legalizovat-výpočet**. Tento příkaz ti spočítá 5, 10, 15% STORKSCOINŮ na tvé černé ruce. \n *Pokračování na druhé straně.* **(strana2)**");
                }
                if (arg3.Emote.Name == new Emoji("2️⃣").Name)
                {
                    _msg.RemoveReactionAsync(new Emoji("2️⃣"), arg3.User.Value);
                    _msg.ModifyAsync(mp => mp.Content = "***STRANA 2***\n" +
                    "A teď přichází teprve to zajímavé** .legalizovat <číslo>**. Pokud je číslo v kategorii 0-5% tak na to finančák nemá šanci přijít a ty legalizuješ zadaný počet STORKSCOINŮ.\n" +
                    " Pokud ale je číslo v kategorii 5-10% tak už na to finančák může přijít, ale šance je jen asi 30%. Kategorie 10-15% je sice rychlá, ale taky extrémně nebezpečná s šancí provalení až 65%. Tady už si musí vybrat každý sám, co se mu vyplatí a co už ne… Málem bych zapomněl, vše co je nad 15% tak nepůjde.\n Kdyby se někdy náhodou stalo, že by jsi chtěl, převádět opačným směrem tak to jde přes příkaz **.ztratit**. Jak název napovídá, z tvé lagální ruky se strhne 10% kterých se převede na ruku nelegální.\n" +
                    " Neboj, ani na hazard jsme nezapomněli, na legálním trhu je to **.vsadit <číslo>**. Číslo musí být větší než jedna, a zároveň menší než 500, protože je to regulováno státem. Šance na výhru je 50%. výhra činí vklad krát 5 (pokud daný sázející vlastní kreditku tak krát 6).\n" +
                    " Na černém trhu je možnost sázky taky a to formou **.ruskaruleta <číslo>**. Tato sázka je podstatně těžší. Její minimální vklad činí 1 000 STORKSCOINŮ. Trochu ti to popíšu. Šance na výhru je 30%. Pokud je tvoje sázka 1 000-4 000 tak výhra = sázka krát 6 (s padělanou smlouvou 7). Pokud ale vsadíš 4 000-8 000 tak násobič je 4 (potažmo 5). V kategorii 8 000-12 000 je násobič 2 (se smlouvou tři). Sázky větší než 12 000 se podle mě nevyplatí, protože šance na výhru je 1ku3 ale výhra je sázka krát jedna (dva).");
                }
                if (arg3.Emote.Name == new Emoji("3️⃣").Name)
                {
                    _msg.RemoveReactionAsync(new Emoji("3️⃣"), arg3.User.Value);
                    _msg.ModifyAsync(mp => mp.Content = "***STRANA 3***\n" +
                        "Banka je asi momentálně nejbezpečnější místo kam uložit peníze. Přes příkaz **.uložit <číslo>** Pokud číslo nezadáš, uložíš do banky polovinu své legální ruky. Můžeš však ale zadat i konkrétní číslo. Pokud toto číslo bude menší jak polovina Miloš uloží na tvůj účet v bance právě toto číslo. Pokud ale číslo bude větší než polovina, Miloš uloží pouze polovinu. Dosti podobně funguje příkaz **.vybrat <číslo>** jen to vezme čtvrtinu z banky a připíše na legální ruku. Číslo které tam můžete zadat funguje úplně stejně jak u předchozího příkazu. ***U obou příkazů je 10% daň!*** \n" +
                        "Dalším velkým okruhem, je příkaz **.loupež <indikátor> <uživatel>**. Pro kradení z banky ale musíte vlastnit **ČERVENÉ TRENÝRKY** kterými si zakryjete obličej, aby vás nikdo nepoznal. Pokud indikátor je roven „banka‘‘ tak je šance jedna ku deseti že uživateli ukradnete 2-5% z banky. Pokud indikátor je ruka ukradnete 10% z legální ruky s 50% šancí. S indikátorem černá ukradnete s 25% šancí 25% černé ruky.");
                }
                if (arg3.Emote.Name == new Emoji("4️⃣").Name)
                {
                    _msg.RemoveReactionAsync(new Emoji("4️⃣"), arg3.User.Value);
                    _msg.ModifyAsync(mp => mp.Content = "dodělává se");
                }
            }
            return Task.CompletedTask;
        }
    }
}
