using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class number
    {
        public int bany;
    }

    public class Pong : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        [Summary("Pong")]
        public async Task Ping(SocketGuildUser gUser)
        {
            //save the image file
            //return cestá;
        }
    }
}