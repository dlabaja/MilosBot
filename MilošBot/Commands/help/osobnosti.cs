using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace MilošBot.Commands.help
{
    public class helposob : ModuleBase<SocketCommandContext>
    {
        [Command("help-osobnosti")]
        [Summary("Vypíše seznam politických obrázkových příkazů.")]
        public async Task HelpOsobnostiAsync()
        {
            Emote agr = Emote.Parse("<:agraelus:766567513181126676>");
            Emote mrk = Emote.Parse("<:mrkmilda:773467539753533450>");
            Emote triget = Emote.Parse("<:triggered:779661928544206848>");
            Emote brain = Emote.Parse("<:bigbrain:798651688352874506>");
            Emote milda = Emote.Parse("<:mildahornik:721018998308732980>");
            Emote trenky = Emote.Parse("<:trenky:815306768329867264>");
            using (Context.Channel.EnterTypingState())
            {
                var ovcak = new EmbedBuilder();
                ovcak.WithColor(Color.Red);
                ovcak.WithTitle("**Seznam toho co se nikam nevešlo**");
                ovcak.WithDescription(@" " +
                     agr + "** Zajímaví lidé**\n`harold`, `furrik`, `jolanda`, `mildahornik`, `soudružky`\n\n " +
                     mrk + "** Podnikatelé**\n`gates`, `jobs`, `musk`, `zuckerberg`\n\n" +
                     trenky + "** Kuchaři**\n`babica`, `láďa`, `pohlreich`\n\n" +
                    triget + " **Místa**\n`cernobyl`, `dukovany`, `orloj`\n\n" +
                     milda + "** Herní postavy**\n`puro`, `colin`, `freeman`\n\n" +
                     brain + "** To ostatní**\n`kremilek`, `krtek`, `krtekceskej`, `rakosnicek`\n\n"

                    );

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Příkaz poslední záchrany od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
                await cons.SendMessageAsync("help-osobnosti: " + Context.Message.Author);
            }
        }
    }
}