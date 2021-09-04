using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace MilošBot.Commands.help
{
    public class helpost : ModuleBase<SocketCommandContext>
    {
        [Command("help-funkce")]
        [Summary("Vypíše seznam \"základních\" příkazů.")]
        public async Task HelpFunkceAsync()
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
                ovcak.WithTitle("**Seznam toho co se nikam nevešlo**");
                ovcak.WithDescription(@"`at`, `bitcoin`, `boo`, `covid <cz>/<sk>`, `cp`, `fanmade`, `hodiny`, `joke`, `korona`, `mince`, `kauricoin`, `ping`, `trailer`" + "\n\n" + mrk +
                                        " **Od levelu 3**\n`help-obrazky`, `pp`, `gay`, `furry`, `weeb`, `iq`, `yt-random`, `yt-search`, `obama <text>`\n\n" + agr +
                                        " **Od levelu 10**\n`wiki <text>`, `el <zpráva>`, `mluv <zpráva>`\n\n" + porn +
                                        " **Od levelu 20**\n`flakanec <uživatel>`, `soud <uživatel>`, `kill <uživatel>`, `killme`\n\n"
                                         );
                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Příkaz poslední záchrany od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
                await cons.SendMessageAsync("help-funkce: " + Context.Message.Author);
            }
        }
    }
}