using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace MilošBot.Commands.funkce
{
    public class BasicReplyModule : ModuleBase
    {

        [Command("JsemSus", true)]
        public async Task JsemSusAsync(IUser? user = null)
        {
            user ??= Context.User;
            await ReplyAsync($"{user.Mention} je  na {new Random().Next(101)}% sus.");
        }

        [Command("bob", true)]
        public async Task BoBAsync(IUser? user = null)
        {
            user ??= Context.User;
            await ReplyAsync($@"
░░░░░▐▀█▀▌░░░░▀█▄░░░
░░░░░▐█▄█▌░░░░░░▀█▄░░
░░░░░░▀▄▀░░░▄▄▄▄▄▀▀░░
░░░░▄▄▄██▀▀▀▀░░░░░░░
░░░█▀▄▄▄█░▀▀░░
░░░▌░▄▄▄▐▌▀▀▀░░ tohle je {user.Mention}
▄░▐░░░▄▄░█░▀▀ ░░ kopírujte a vložte ho na
▀█▌░░░▄░▀█▀░▀ ░░ každý Discord Server,
░░░░░░░▄▄▐▌▄▄░░░ tak, aby mohl
░░░░░░░▀███▀█░▄░░ hrát fortnite
░░░░░░▐▌▀▄▀▄▀▐▄░░ (nespamujte ho)
░░░░░░▐▀░░░░░░▐▌░░
░░░░░░█░░░░░░░░█░░░░░░░
░░░░░░█░░░░░░░░█░░░░░░░
░░░░░░█░░░░░░░░█░░░░░░░
░░░░▄██▄░░░░░▄██▄░░░░
");
        }
    }
}