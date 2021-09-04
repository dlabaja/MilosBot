using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.API;
using Discord.Rest;
using Discord.WebSocket;
using System.Text;
using System.Data.SqlClient;
using System.Net;
using ScottPlot;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MilošBot.Commands
{
    public class helposdsdhjsklkt : ModuleBase<SocketCommandContext>
    {
        [Command("BiTStorK")]
        public async Task Mildosdshuzuuaggdsurus1()
        {
            await Context.Channel.SendFileAsync(@"/home/kubak1500/Desktop/ahojd.jpg");

            var ruka = Context.User as SocketGuildUser;
            ITextChannel cons1 = Context.Client.GetChannel(814954423972266024) as ITextChannel;
            await cons1.SendMessageAsync("Graf bitstork " + ruka);
        }
    }
}