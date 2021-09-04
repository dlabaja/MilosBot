using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class overit : ModuleBase<SocketCommandContext>
    {
        [Command("overit")]
        [Alias("ověřit", "overeni", "ověření")]
        [RequireUserPermission(GuildPermission.ManageRoles, ErrorMessage = "O co se to jako snažíš? :what:")]
        public async Task Verify(SocketGuildUser user = null)
        {
            if (user == null)
            {
                user = (SocketGuildUser)Context.User;
            }

            var role = Context.Guild.Roles.FirstOrDefault(x => x.Id == 798822764872990740);//level
            var role1 = Context.Guild.Roles.FirstOrDefault(x => x.Id == 798825895866793984);//pingrole
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Id == 798823309596819488);//speciální
            var role9 = Context.Guild.Roles.FirstOrDefault(x => x.Id == 798822477169819689);//tomiorole
            var role10 = Context.Guild.Roles.FirstOrDefault(x => x.Id == 798822174005657601);//ekonomika
            var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Id == 798820832901070848);//věk
            var role4 = Context.Guild.Roles.FirstOrDefault(x => x.Id == 727125331512918128);//imigrant
            var role5 = Context.Guild.Roles.FirstOrDefault(x => x.Id == 786631302514343997);//ping
            var role6 = Context.Guild.Roles.FirstOrDefault(x => x.Id == 811279796587331605);//promoping
            var role7 = Context.Guild.Roles.FirstOrDefault(x => x.Id == 735827797792129134);//dj
            var role8 = Context.Guild.Roles.FirstOrDefault(x => x.Id == 738307326364352512);//nereg
            var role85 = Context.Guild.Roles.FirstOrDefault(x => x.Id == 782183833960316929);//lovec

            if (user.Roles.Contains(role8))
            {
                await user.RemoveRoleAsync(role8);
                await user.AddRolesAsync(new[] { role, role1, role2, role3, role4, role5, role6, role7, role85, role9, role10 });
                await Context.Channel.DeleteMessageAsync(Context.Message);
                return;
            }
            else
            {
                await ReplyAsync("O co se to jako snažíš? Už jsi asi registrován");
                return;
            }
        }
    }
}