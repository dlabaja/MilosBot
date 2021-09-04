using Discord.Commands;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Trailer : ModuleBase<SocketCommandContext>
    {
        [Command("trajler")]
        [Alias("trailer", "info")]
        [Summary("DBL GAMING\n**hudba**")]
        public async Task Coin()
        {
            await ReplyAsync("> https://www.youtube.com/watch?v=QFpbqT5vWCI");
        }
    }
}