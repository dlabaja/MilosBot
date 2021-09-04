using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class joke2 : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "**1. **Víte jaký je rozdíl mezi černým, brutálním a morbidním humorem? Černý: Deset cikánů v jedné popelnici. Brutální: Jeden cikán v deseti popelnicích. Morbidní: Deset popelnic v jednom cikánovi.",
            "**2. **Který tým nejvíce září v Ukrajinské hokejové lize? Černobyl.",
            "**3. **Černý humor je jako dítě z Afgánistánu. Nemá hlavu, ani patu.",
            "**4. **Chlap v lese brutálně znásilní holku. Když se zvedá a zapíná si poklopec, s radostí prohlásí: Až se to narodí, říkej tomu třeba Franta. Ona na to: Hmm, až se to projeví, říkej tomu třeba chřipka debile.",
            "**5. **Šly děti po minovém poli a rozhazovaly rukama... některé i 30 metrů!",
            "**6. **Pletou dvě nastávající maminky malé svetříky pro své ratolesti a jedna říká: Doufám že to bude chlapeček, mám jenom modrou přízi. Druhá říká:Doufám že to bude kripl, zkurvila jsem rukáv.",
            "**7. **Leží nahá žena v posteli. Přijde domů manžel a ptá se: Proč tady ležíš nahá? Manželka odpoví: Nemám co na sebe! Muž otevře skříň a počítá: Jedny šaty-druhé-třetí-ahoj Karle-čtvrté...",
            "**8. **Syn s otcem jdou do ZOO. Tati, proč ta gorila na nás tak divně čumí? Ticho synu, jsme teprve u pokladny.",
            "**9. **Manželka: Víš co bych si přála na narozeniny ? Manžel: Tak povídej Manželka: No,já bych chtěla něco, co udělá z 0 na 100 za 3 vteřiny... Manžel trochu zapřemýšlí a řekne... Tak to ti koupím váhu!",
            "**10. **Vejde tlustá paní do obchodu a říká prodavači: Ráda bych viděla nějaké plavky, co by mi byly. Prodavač: Tak to já taky!",
            "**11. **Jdou ženy na prvního máje v průvodu a každá nese jedno z písmen, která tvoří nápis: VŠE CO MÁME, PRO MÍR DÁME! Ta, co nese třetí M říká té, co nese Í: A ne, aby ses nám zase ztratila jako minule!",
            "**12. **Prsa jsou jasným důkazem, že se muži dokážou soustředit na dvě věci najednou.",
            "**13. **Nejkrásnější jméno v ČR je podle statistik Lenka. Obsahuje vše, co mají muži rádi. DovoLenka, miLenka, páLenka...",
            "**14. **Můj penis byl v Guinnesově knize rekordů! Pak si mě ale prodavačka v knihkupectví všimla a vyhodila mě...",
            "**15. **Důvod proč ženy nikdy nebudou žádat chlapa o ruku je ten, že když si žena klekne tak si chlap začne rozepínat kalhoty.",
            "**16. **Baví se dva muži: Koupil jsem ženě kuchařku, ale nechce podle ní vařit. Já jsem na tom stejně - koupil jsem tchýni kufr!",
            "**17. **Zákazník: Mám nainstalovaný Windows Vista. Hotline: OK. Zákazník: Počítač mi nefunguje. Hotline: Ano, to jste už říkal...",
            "**18. **Víte, jaké adresy jsou nejvíce zadávány v prohlížeči MS Internet Explorer? Google & Mozilla*",
            "**19. **Víte co dělá windows na měsíci? Padá 6 krát pomalejc.",
            "**20. **Na uživatele vyskočí klasická hláška: Zadejte vaše heslo. Uživatel: penis. PC: Vaše heslo je příliš krátké!",
            "**21. **Víte, co je to slepičí bujon? Ženská inteligence v kostce!",
            "**22. **Zastaví policajt auto: „Pane řidiči, překročil jste rychlost 50 Km za hodinu.“ A řidič na to: „Co kecáte, dyť jedu teprve čtvrt hodiny!“ A policajt se postaví do pozoru: „Tak tedy pardon, pokračujte.“ ",
            "**23. **Otecko, preco mamicka tak kluckuje? Mlc a podavaj granaty.",
            "**24. **Víte, proč maj’ slepý děti nejradši makovaný rohlíky? – Protože na každým z nich je jiná pohádka.",
            "**25. **Nedavaj nadobu s benzinom blizko ohna, pouca otec syna. Moze byt z toho velke nestastie. -Ale otec, vari ty veris na povery?",
            "**26. **Zkouší si děda v obchodě nové boty a když si je nazouvá nejvehementněji, uprdne se. Omlouvám se, skutečně je mi to trapné. To nic dědo, až vám řeknu, kolik stojí, tak se poserete.",
            "**27. **„Haló, to je policejní stanice? Měl bych dotaz. Neutekl dneska z blázince nějakej chovanec? No proč se ptám? Protože mi dneska v noci někdo unesl moji ženu!“",
            "**28. **proč blondýnky přikládají ucho ke zdi? protože poslouchají house",
            "**29. **Q: Proč mají krysy čtyři nohy? A: Aby byly u popelnic dřív než důchodci.",
            "**30. **Aky je rozdiel medzi muzskymi a zenskymi nohavicami? -? – Do muzskych sa ide nohami a do zenskych rukami!",
            "**31. **Smuteční průvod jde ulicí. Najednou se k truchlícímu muži, který jde za rakví, přitočí kolemjdoucí a ptá se: „Manželka?“ „Ne, tchýně,“ odpoví muž. „Taky dobrý,“ řekne kolemjdoucí.",
            "**32. **Jak se mate? zertuje Klaus Dobre, Dobre. zertuji obcane.",
            "**33. **Ptá se policajt náčelníka. Pane veliteli, umí krokodýlové létat? Samozřejmě, že neumí. A skutečně neumí lítat? Skutečně neumí. Ale generál povídal, že umí lítat. No, trošku umí lítat.",
            "**34. **Co si říká slepec, když myje struhadlo? Takovou kravinu jsem ještě nečetl.",
            "**35. **Státní zástupce rozhořčeně odsuzuje trestný čin. Delikvent chvíli poslouchá a pak rozhodí rukama a povídá: „Co se rozčilujete, pane doktore, kdybych já nekradl, tak jsou vám ty vaše študie houby platný a jste nezaměstnaný!“",
            "**36. **„Maminko, uz vim proc je tatinek tak tlusty!““A procpak Pepicku?“ pta se maminka.“No vcera jsem pribehl k tatinkovi do kancelare a pani sekretarka ho zrovna nafukovala!“",
            "**37. **Soudce u rozvodového řízení: „Tak vy jste hodila po manželovi tři talíře. Proč?“ „Protože jsem se tím prvním ani druhým nestrefila.“",
            "**38. **V kazdej organizacii je vzdy aspon jedna osoba, ktora vie o co ide. Tuto treba zastrelit.",
            "**39. **U hořícího domu povídá jeden druhému: „Cítím tady karamel!“ A druhý na to: „Vím, můj děda měl cukrovku…“",
            "**40. **Je to černý a je to mezi nohama. Co to je? Černoch pod stolem.",
            "**41. **Lord se oženil. Ráno po svatební noci říká své ženě: „Lady, doufám, že jste otěhotněla. Nerad bych ty směšné pohyby opakoval.“",
            "**42. **Víte, jak dostanete somálce do prázdné flašky? Hodíte tam zrnko rýže. A jak ho dostanete ven? Nedostanete. Už je najezený.",
            "**43. **Víte co se stane, když se dvě úplně stejné blondýny rozeběhnou k sobě?….. Rozbije se zrcadlo.",
            "**44. **Lord popíjí svou oblíbenou whisky a když dopije vyhodí láhev z okna. Pod oknem se ozve výkřik. Tu se lord otočí na svého sluhu, povytáhne jedno obočí a otáže se: „Jean, v té láhvi byli lidé?“",
            "**45. **Ma vplyv panske spodne pradlo na znizenu potenciu? Nie, ale ako vyhovorka je to dobre.",
            "**46. **To vám takhle dojde chlap z pozdě večer z hospody, bez oka, ruka pryč a manželka ho hnedle vyslíchá, co se mu to stalo? Ale, odpovídá muž, vsadil jsem se s chlapama o oko, že mi neutrhnou ruku…",
            "**47. **Na autobusove zastavce si rano mlada slecna zapali cigaretu. Starsi pani rozhorcene poznamena: – Radsi bych spachala neveru nez zapalit si na ulici. – Ja taky, ale ted musim jit do prace.",
            "**48. **Co je to apatie? Poměr k poměru po poměru.",
            "**49. **Janko lubis ma? -Ano Marienka, ale ked Pan Boh ta ma radsej nech si ta berie on.",
            "**50. **Pepicek se pta babicky: babi, ty tvoje bryle zvetsuji? Ano. Tak si je prosimte nasad, a ukroj mi kousek dortu.",
            "**51. **Je to cerny a klepe to na dvere, co je to? Krasna ruzova budoucnost.",
            "**52. **Jaká je nejvzrušující otázka pro nekrofilického-zoofila? Odpověď: Kde je zakopaný pes?",
            "**53. **Policajt sedí doma a najednou někdo klepe na dveře. „Kdo je tam?“ ptá se policajt. „Já,“ ozve se zpoza dveří. „Já?“",
            "**54. **Je blondýnka v pizzerii, číšník ji přinese pizzu a ptá se jí:“Chcete ji rozkrojit na 6 nebo na 12 dílku?“ – Blondynka odpovi: „Na 6 já bych 12 nesnědla.“",
            "**55. **Kaboom**"
        };

        [Command("joke")]
        [Alias("humor", "vtip")]
        [Summary("Fany ftips")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                await Context.Channel.SendMessageAsync(url[ovce]);

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
                await cons.SendMessageAsync("joke: " + url[ovce]);
            }
        }
    }
}