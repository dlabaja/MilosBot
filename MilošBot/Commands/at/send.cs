using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Oznam : ModuleBase<SocketCommandContext>
    {
        [Command("send")]
        [RequireUserPermission(GuildPermission.Administrator, ErrorMessage = "O co se to jako snažíš? :what:")]
        public async Task Kickenzou([Remainder] string reason = null)
        {
            if (reason == null)
                reason = "Nezadali jste zprávu!";

            if (reason != null)
            {
                ITextChannel log = Context.Client.GetChannel(743826054535184505) as ITextChannel;
                await log.SendMessageAsync(reason);
            }

            ITextChannel cons = Context.Client.GetChannel(DChannelId.ConsoleLog) as ITextChannel;
            await cons.SendMessageAsync("mluv: " + Context.User.Mention + "\n" + reason);
        }
    }
}