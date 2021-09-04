using Discord;
using Discord.Commands;
using Discord.WebSocket;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Korona : ModuleBase<SocketCommandContext>
    {
        [Command("korona")]
        [Alias("chcikovid")]
        [Summary("Snaž se nenakazit")]
        public async Task KoronaAsync([Remainder] string user = null)
        {
            var User1 = Context.User as SocketGuildUser;
            var users = Context.Guild.Users;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Volič");
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Starosta");
            var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");

            if (User1.Roles.Contains(role) || User1.Roles.Contains(role2) || User1.Roles.Contains(role3))
            {
                foreach (IGuildUser userino in users)
                {
                    if (userino.Mention == user)
                    {
                        user = userino.Username;
                    }
                }
                Random random = new Random();
                float ovce = random.Next(1, 1001);
                float deleno = random.Next(11, 51);
                float dod = ovce / deleno;
                float nedod = dod + deleno;

                var ovcak = new EmbedBuilder();
                ovcak.WithColor(Color.Magenta);
                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Statistická chyba je 1-99%");
                });

                if (user == null)
                    ovcak.WithTitle($"Pokud budeš dodržovat opatření, tak dle aktuální předpovědi chytneš koronu, podle miloše z {dod}% \n pokud je ale dodržovat *nebudeš*, tak z **{nedod}%**");
                else
                    ovcak.WithTitle($"Pokud bude {user} dodržovat opatření, tak dle aktuální předpovědi chytne koronu, podle miloše z {dod}% \n pokud je ale dodržovat *nebude*, tak z **{nedod}%**");

                await Context.Channel.SendMessageAsync(embed: ovcak.Build());
                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
                await cons.SendMessageAsync($"korona {dod} a {nedod}");
            }
        }
    }
}