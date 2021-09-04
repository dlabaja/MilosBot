using Discord;
using Discord.Commands;
using Discord.WebSocket;
using MilošBot.Commands.Attributes;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Mluveni : ModuleBase<SocketCommandContext>
    {
        [Command("mluv")]
        [Alias("m")]
        [Summary("Nech miloše promluvit")]
        public async Task Kickenzou([Remainder] string reason = null)
        {
            var User = Context.User as SocketGuildUser;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Starosta");
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");

            if (User.Roles.Contains(role) || User.Roles.Contains(role2))
            {
                if (reason == null)
                {
                    string msg = "Chybí ti text zprávy!";
                    await UserExtensions.SendMessageAsync(Context.User, msg);
                }
                if (reason != null)
                {
                    await Context.Channel.SendMessageAsync(reason);
                    await Context.Channel.DeleteMessageAsync(Context.Message);
                }
            }
            else
            {
                await Context.Message.Channel.SendMessageAsync("O co se to jako snažíš? Tato funkce je dostupná až od levelu 10!");
            }
            ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
            await cons.SendMessageAsync("mluv: " + Context.User + Context.Channel.Name + "\n" + reason);
        }

        [Command("mluv")]
        [Alias("m")]
        [Summary("Nech miloše promluvit")]
        public async Task Kickenzou(ITextChannel textChannel,[Remainder] string? text = null)
        {
            var User = Context.User as SocketGuildUser;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Starosta");
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");

            if (User.Roles.Contains(role) || User.Roles.Contains(role2))
            {
                if (text == null)
                {
                    string msg = "Chybí ti text zprávy!";
                    await UserExtensions.SendMessageAsync(Context.User, msg);
                }
                else
                {
                    await textChannel.SendMessageAsync(text);
                    await Context.Channel.DeleteMessageAsync(Context.Message);
                }
            }
            else
            {
                await Context.Message.Channel.SendMessageAsync("O co se to jako snažíš? Tato funkce je dostupná až od levelu 10!");
            }
            ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
            await cons.SendMessageAsync("mluv: " + Context.User + Context.Channel.Name + "\n" + text);
        }
    }
}
