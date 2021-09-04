using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Boiii : ModuleBase<SocketCommandContext>
    {
        [Command("boi")]
        [Alias("booi", "boo", "baf")]
        [Summary("b a f")]
        public async Task BoiAsync()
        {
            var ovcak = new EmbedBuilder();
            ovcak.WithColor(Color.Red);
            ovcak.WithTitle("**bububububu**");
            ovcak.WithDescription(
               "  ╱▔▔▔▔▔▔╲┈╭━━━╮\n" +
               " ▕┈╭━╮╭━╮┈▏┃BOO…┃\n" +
               " ▕┈┃╭╯╰╮┃┈▏╰┳━━╯ \n" +
               " ▕┈╰╯╭╮╰╯┈▏┈┃ \n" +
               " ▕┈┈┈┃┃┈┈┈▏━╯ \n" +
               " ▕┈┈┈╰╯┈┈┈▏ \n" +
               " ▕╱╲╱╲╱╲╱╲▏");

            await Context.Message.DeleteAsync();
            await Context.Channel.SendMessageAsync(embed: ovcak.Build());

            ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
            await cons.SendMessageAsync("boiiiiii: " + Context.User);
        }
    }
}