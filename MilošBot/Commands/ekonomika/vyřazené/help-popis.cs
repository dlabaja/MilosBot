//using Discord;
//using Discord.Commands;
//using Discord.WebSocket;
//using System.Threading.Tasks;

//namespace MilošBot.Commands.help
//{
//    public class hexcyxcyxclpoadst : ModuleBase<SocketCommandContext>
//    {
//        [Command("help-popis")]
//        [Alias("help-p", "pomoc-p", "pomoc-popis")]
//        public async Task Mildosaurus()
//        {
//            using (Context.Channel.EnterTypingState())
//            {
//                var ovcak = new EmbedBuilder();
//                ovcak.WithColor(Color.Orange);
//                ovcak.WithTitle("**orientační seznam slohového popisu**");
//                ovcak.WithDescription(@" " +
//                     "** \n`strana1`\n o registraci a prvních příkazech" +
//                     " \n`strana2`\n o převodu peněz a hazardu" +
//                     " \n`strana3`\n o krádežích" +
//                     " \n`strana4`\n o základech firmy" +
//                     " \n`strana5`\n o firmě po pokročilé**");
//                ovcak.WithFooter(footer =>
//                {
//                    footer
//                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
//                    .WithText("Příkaz poslední záchrany od MilošBota");
//                });
//                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

//                var ruka = Context.User as SocketGuildUser;
//                ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;
//                await cons.SendMessageAsync($"help-popis {ruka}");
//            }
//        }
//    }
//}