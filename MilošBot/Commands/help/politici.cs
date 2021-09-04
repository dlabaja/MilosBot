using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace MilošBot.Commands.help
{
    public class helppol : ModuleBase<SocketCommandContext>
    {
        [Command("help-politici")]
        [Summary("Vypíše seznam politických obrázkovích příkazů.")]
        public async Task HelpPoliticiAsync()
        {
            Emote har = Emote.Parse("<:harabin:802935062512402482>");
            Emote haro = Emote.Parse("<:harold:778284746013671464>");
            Emote bab = Emote.Parse("<:happyandrej:719271346626101341>");
            Emote trum = Emote.Parse("<:trumpik:803297658768326686>");
            Emote orl = Emote.Parse("<:orloj:803878290905104420>");

            using (Context.Channel.EnterTypingState())
            {
                var ovcak = new EmbedBuilder();
                ovcak.WithColor(Color.Red);
                ovcak.WithTitle("**Seznam politických příkazů**");
                ovcak.WithDescription(@"" + bab + " **Česko**\n`alena`, `andrej`, `blatny`, `feri`, `hamacek`, `havel`, `kalousek`, `klaus`, `klausmladsi`, `masaryk`, `ovcacek`, `paroubek`, `pirati`, `plaga`, `prymula`, `schwarzenberg`, `sobotka`, `soukup`, `tomio`, `vojtech`, `zeman`\n\n" +
                                              har + " **Slovensko**\n`danko`, `fico`, `harabin`, `pellegrini`\n\n" +
                                              trum + " **Ze světa**\n`alzbeta`, `biden`, `kim`, `lenin`, `méďa`, `barack`, `putin`, `stalin`, `trump`\n\n");

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Příkaz poslední záchrany od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
                await cons.SendMessageAsync("help-politici: " + Context.Message.Author);
            }
        }
    }
}