using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Cum : ModuleBase<SocketCommandContext>
    {
        [Command("cum")]
        [RequireNsfw(ErrorMessage = "O co se to jako snažíš? Tenhle příkaz můžeš použít pouze v NSFW")]
        [Summary("NSFW")]
        public async Task CumAsync([Remainder] string user = null)
        {
            Emote sad = Emote.Parse("<:smutnej:722776040170061844>");
            var users = Context.Guild.Users;
            var User1 = Context.User as SocketGuildUser;

            foreach (IGuildUser userino in users)
            {
                if (userino.Mention == user)
                {
                    user = userino.Username;
                }
            }

            if (user == null || user == User1.Username)
            {
                await ReplyAsync("Nebylo možné provést tuto operaci, protože jsi zadal sám sebe, nebo nikoho, a i malé dítě ví že sám se sebou to není ono");
                return;
            }
            else
            {
                Random random = new Random();
                int smrt = random.Next(1, 4);
                if (smrt == 1)
                {
                    await Context.Channel.SendMessageAsync("> " + user + " cumnul na " + User1 + sad);
                    await Context.Message.DeleteAsync();
                }

                if (smrt == 2)
                {
                    await Context.Channel.SendMessageAsync("> " + User1 + " si udělal dobře nad " + user + sad);
                    await Context.Message.DeleteAsync();
                }
            }

            ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
            await cons.SendMessageAsync("cum: " + Context.User);
            return;
        }
    }
}