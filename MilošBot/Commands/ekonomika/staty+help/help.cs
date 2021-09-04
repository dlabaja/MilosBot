using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace MilošBot.Commands.help
{
    public class helpoadst : ModuleBase<SocketCommandContext>
    {
        [Command("help-dblekonomika")]
        [Alias("help-dbl", "pomoc-dbl", "pomoc-dblekonomika")]
        [Summary("Zobrazí 1. nápovědu k ekonomice.")]
        public async Task HelpEkonomikaAsync()
        {
            using (Context.Channel.EnterTypingState())
            {
                var ovcak = new EmbedBuilder();
                ovcak.WithColor(Color.Orange);
                ovcak.WithTitle("**předběžný orientační seznam ekonomiky**");
                ovcak.WithDescription(@" " +
                     "** \n`kniha`\n slohová práce o ekonomice" +
                     " \n`registrovat`\n registruje do ekonomiky" +
                     " \n`pracovat`\n základní příkaz na vydělávání" +
                     " \n`ruce`\n zobrazí aktuální měmí na obou rukách" +
                     " \n`banka`\n výpis z banky" +
                     " \n`staty`\n tvoje staty" +
                     " \n`cernaprace`\n základní příkaz na vydělávání " +
                     " \n`vsadit`\n sázka (maximalni sazka 500)" +
                     " \n`ruskaruleta`\n sázka s minimálním vkladem 1 000 (udelat méně efektivní pri vysokých sázkách) " +
                     " \n`koupit-kreditku`\n zvyšuje .pracovat a .vsadit + odemyká ukládání do banky" +
                     " \n`padelanasmlouva`\n zvyšuje .cernaprace + ruskaruleta" +
                     " \n`pristipdoreklam`\n nečekaně přístup do reklam" +
                     " \n`BDLpremium`\n neplatíš daně z .uložit a .ztratit" +
                     " \n`ulozit`\n uloží 1/2 peněz z ruky do banky (10% daň)" +
                     " \n`vybrat`\n vybere 1/4 peněz z banky do ruky (10% daň)" +
                     " \n`legalizovat-vypocet`\n doporučuji použít před .legalizovat" +
                     " \n`legalizovat`\n legalizuje zadanou částku(0-5% bez rizika 5-10% s 33% rizika a 10-15% s 66% rizika " +
                     " \n`ztratit`\n presun opačným směrem**");
                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Příkaz poslední záchrany od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                var ruka = Context.User as SocketGuildUser;
                ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;
                await cons.SendMessageAsync($"help-ekonomika {ruka}");
            }
        }

        [Command("help-dblekonomika2")]
        [Alias("help-dbl2", "pomoc-dbl2", "pomoc-dblekonomika2")]
        [Summary("Zobrazí 2. nápovědu k ekonomice.")]
        public async Task Milaadosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                var ovcak = new EmbedBuilder();
                ovcak.WithColor(Color.Orange);
                ovcak.WithTitle("**předběžný orientační seznam ekonomiky**");
                ovcak.WithDescription(@" " +
                     " \n`zalozit - zivnost`\n založí živnost" +
                     " \n`najmout-migranta`\n najme migranta" +
                     " \n`najmout-zamestnance`\n najme zaměstnance" +
                     " \n`najmout-mistra`\n najme mistra" +
                     " \n`najmout-experta`\n najme experta" +
                     " \n`najmout-poradce`\n najme poradce" +
                     " \n`najmout-riditelezavoduvesvete`\n najme zřiditele závodů ve světě" +
                     " \n`zam`\n přehled firem" +
                     " \n`moji-zam`\n přehled zaměstnanců" +
                     " \n`dividenty`\n odměny za firmy (1x za " + Dividenty.CooldownHod + "h)");

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Příkaz poslední záchrany od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                var ruka = Context.User as SocketGuildUser;
                ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;
                await cons.SendMessageAsync($"help-ekonomika {ruka}");
            }
        }
    }
}
