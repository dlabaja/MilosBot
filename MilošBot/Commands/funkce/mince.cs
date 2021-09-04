using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Mince : ModuleBase<SocketCommandContext>
    {
        [Command("mince")]
        [Summary("Panna nebo orel... wait, tenhle příkaz ještě někdo používá?")]
        public async Task Coin()
        {
            var random = new Random();
            int coina = random.Next(2);

            if (coina == 0)
            {
                await ReplyAsync($"Panna");
            }
            else
            {
                await ReplyAsync($"Orel");
            }
        }
    }
}