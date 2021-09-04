using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace MilošBot.Commands.help
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        [Alias("pomoc", "pomoč", "pomočit")]
        [Summary("Základní příkaz pro pomoc.")]
        public async Task HelpAsync()
        {
            using (Context.Channel.EnterTypingState())
            {
                var ovcak = new EmbedBuilder();
                ovcak.WithColor(Color.Red);
                ovcak.WithTitle("**Nevíš si rady? Miloš ti hodí záchranný člun!**");
                ovcak.WithDescription("**Můj prefix je [*.*]**\n\n`.pravidla`\n`.invite`\n`.pingy`\n`.hcmd <prikaz>`,\n`.help-obrazky`\n`.help-politici`\n`.help-osobnosti`\n`.help-funkce`\n`.credits`");
                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Kdo za tím vším stojí? Koukni do .credits");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
                await cons.SendMessageAsync("help: " + Context.Message.Author);
            }
        }
    }
}
