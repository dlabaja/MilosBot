using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Vykourit : ModuleBase<SocketCommandContext>
    {
        [Command("vykourit")]
        [RequireNsfw(ErrorMessage = "O co se to jako snažíš? Tenhle příkaz můžeš použít pouze v NSFW")]
        [Summary("NSFW")]
        public async Task VykouritykouritAsync([Remainder] string user = null)
        {
            Emote sad = Emote.Parse("<:agraelus:766567513181126676>");
            var users = Context.Guild.Users;

            foreach (IGuildUser userino in users)
            {
                if (userino.Mention == user)
                {
                    user = userino.Username;
                }
            }

            if (user == null || user == Context.User.Username)
            {
                await ReplyAsync("Nebylo možné provést tuto operaci, protože.... xd");
                return;
            }
            else
            {
                Random random = new Random();
                int smrt = random.Next(1, 4);
                if (smrt == 1)
                {
                    await Context.Channel.SendMessageAsync("> " + user + " vykouřil " + Context.User.Username + sad);
                    await Context.Message.DeleteAsync();
                }

                if (smrt == 2)
                {
                    await Context.Channel.SendMessageAsync("> " + Context.User.Username + " vykouřil " + user + sad);
                    await Context.Message.DeleteAsync();
                }
            }
        }
    }
}