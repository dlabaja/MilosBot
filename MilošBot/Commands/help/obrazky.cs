using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands.help
{
    public class HelpObrazky : ModuleBase<SocketCommandContext>
    {
        [Command("help-obrazky")]
        [Alias("help-obrázky")]
        [Summary("Vypíše seznam obecných obrázkových příkazů.")]
        public async Task HelpObrazkyAsync()
        {
            Emote agr = Emote.Parse("<:agraelus:766567513181126676>");
            Emote mrk = Emote.Parse("<:mrkmilda:773467539753533450>");
            Emote triget = Emote.Parse("<:triggered:779661928544206848>");
            Emote brain = Emote.Parse("<:bigbrain:798651688352874506>");

            var User1 = Context.User as SocketGuildUser;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Volič");
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Starosta");
            var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");

            if (User1.Roles.Contains(role) || User1.Roles.Contains(role2) || User1.Roles.Contains(role3))
            {
                using (Context.Channel.EnterTypingState())
                {
                    var ovcak = new EmbedBuilder();
                    ovcak.WithColor(Color.Red);
                    ovcak.WithTitle("**Seznam obrázkových příkazů**");
                    ovcak.WithDescription("`amogus`, `darek`, `laska`");
                    ovcak.WithFooter(footer =>
                    {
                        footer
                        .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                        .WithText("Příkaz poslední záchrany od MilošBota");
                    });
                    await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                    ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
                    await cons.SendMessageAsync("help-obrazky: " + Context.Message.Author);
                }
            }
            else
            {
                await ReplyAsync("O co se to jako snažíš? Tento příkaz můžeš použít až od levelu 3!");
            }
        }
    }
}