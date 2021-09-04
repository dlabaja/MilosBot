using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace MilošBot.Commands.help
{
    public class helpostds : ModuleBase<SocketCommandContext>
    {
        [Command("credits")]
        [Summary("Vypíše seznam těch co se podílely na tvorbě bota.")]
        public async Task CreditsAsync()
        {
            Emote agr = Emote.Parse("<:agraelus:766567513181126676>");
            Emote mrk = Emote.Parse("<:mrkmilda:773467539753533450>");
            Emote porn = Emote.Parse("<:heheboy:766567729531584542>");
            Emote triget = Emote.Parse("<:triggered:779661928544206848>");
            Emote tomio = Emote.Parse("<:hotGayPornosTomio:719272936757919847>");
            Emote lul = Emote.Parse("<:omegalul:787672799572394034>");

            using (Context.Channel.EnterTypingState())
            {
                var ovcak = new EmbedBuilder();
                ovcak.WithColor(Color.Red);
                ovcak.WithTitle("**Ti co se na tvorbě podíleli**");
                ovcak.WithDescription(@"**Ten dlabaja** - nápad, základ bota a první kód, většina funkcí
**qwer8** - spousta politických příkazů, ekonomika, příkazy stahující data z webů
**kubak1500** - hosting na Ubuntu
**AoshiW** - úprava kódu, spousta rad a tipů
**CharlieCat** - trocha té slovenské politiky
");
                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Děkujeme Vám všem - bez vás by Miloš nebyl tam kde je");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
                await cons.SendMessageAsync("credits: " + Context.Message.Author);
            }
        }
    }
}