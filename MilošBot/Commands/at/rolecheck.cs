/*using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class check : ModuleBase<SocketCommandContext>
    {
        [Command("role")]
        [RequireUserPermission(GuildPermission.Administrator, ErrorMessage = "O co se to jako snažíš? :what:")]
        public async Task Mildosaurus()
        {
            var role8 = Context.Guild.Roles.First(x => x.Id == 738307326364352512);
            var role1 = Context.Guild.Roles.FirstOrDefault(x => x.Id == 798820832901070848);
            var role9 = Context.Guild.Roles.FirstOrDefault(x => x.Id == 805744049877286942);
            foreach (SocketGuildUser user in Context.Guild.Users)
            {
                if (!user.Roles.Contains(role8) && !user.Roles.Contains(role1) && !user.Roles.Contains(role9) && !user.IsBot)
                {
                    await user.AddRoleAsync(role8);
                    Console.WriteLine(user);
                }
            }
        }
    }
}*/