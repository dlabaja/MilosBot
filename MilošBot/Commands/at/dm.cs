using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class dmko : ModuleBase<SocketCommandContext>
    {
        [Command("dm")]
        [RequireUserPermission(GuildPermission.ManageRoles, ErrorMessage = "O co se to jako snažíš? :what:")]
        public async Task Verify(IGuildUser user = null, [Remainder]string msg = null)
        {
            if (user == null || msg == null)
            {
                return;
            }
            await UserExtensions.SendMessageAsync(user, msg);

            ITextChannel log = Context.Client.GetChannel(DChannelId.ConsoleLog) as ITextChannel;
            await log.SendMessageAsync(Context.User + " poslal dm " + user + "\n" + msg);

            await Context.Message.DeleteAsync();
        }
    }
}