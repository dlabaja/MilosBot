using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Soud : ModuleBase
    {
        [Command("rozhodni")]
        [Alias("soud")]
        [Summary("Rozsoudí mezi tebou a tvým kamarádem kterého musíš zadat")]
        public async Task SoudAsync(IGuildUser user2 = null)
        {
            if (user2 == null) { return; }
            var User1 = Context.User as SocketGuildUser;
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");
            if (User1.Roles.Contains(role2) && (user2 != null))
            {
                if (user2 != null)
                {
                    Random opice = new Random();
                    int coina = opice.Next(2);

                    if (coina == 0)
                    {
                        await Context.Channel.SendMessageAsync($"> **vybral jsem {User1} **");
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync($"> **vybral jsem {user2}**");
                    }
                }
                if (user2 == null)
                {
                    await Context.Message.Channel.SendMessageAsync("A co jim mám jako říct? Musíš si nekoho vybrat!");
                    return;
                }
            }
            else
            {
                await Context.Message.Channel.SendMessageAsync("O co se to jako snažíš? Tato funkce je dostupná až od levelu 20!");
            }

            ITextChannel cons = Context.Client.GetChannelAsync(DChannelId.MilosLog) as ITextChannel;
            await cons.SendMessageAsync("soud: " + Context.User);
        }
    }
}