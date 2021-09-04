using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class killloš : ModuleBase<SocketCommandContext>
    {
        [Command("killmilos")]
        [RequireUserPermission(GuildPermission.Administrator, ErrorMessage = "O co se to jako snažíš? :what:")]
        public async Task Andrejsaurus()
        {
            await ReplyAsync("Miloš se vypíná");
            await Context.Message.DeleteAsync();
            Environment.Exit(1);
        }
    }
}