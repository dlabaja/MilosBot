using Discord.Commands;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class CP : ModuleBase<SocketCommandContext>
    {
        [Command("cp")]
        public async Task Cp()
        {
            await ReplyAsync("https://creativeportal.eu/");
        }
    }
}