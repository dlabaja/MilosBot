using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Answer : ModuleBase<SocketCommandContext>
    {
        [Command("answer")]
        [Alias("answ")]
        [RequireUserPermission(GuildPermission.ManageRoles, ErrorMessage = "O co se to jako snažíš? :what:")]
        public async Task Andrejsaurus(IGuildUser user = null, [Remainder] string zpr = null)
        {
            if (user == null)
            {
                await ReplyAsync("Chybí uživatel");
                return;
            }
            if (zpr == null)
            {
                await ReplyAsync("Chybí zpráva");
                return;
            }
            string msg = "**Feedback je vyřešen!**\n" + zpr + "\n*Za AT vyřešil " + Context.User.Username + "*";
            await UserExtensions.SendMessageAsync(user, msg);
            await Context.Message.DeleteAsync();

            ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
            await cons.SendMessageAsync("feedback: " + zpr);
        }
    }
}