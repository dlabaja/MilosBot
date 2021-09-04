//using Discord;
//using Discord.Commands;
//using Discord.WebSocket;
//using MongoDB.Driver;
//using System;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MilošBot.Commands.help
//{
//    public class helpewrweost : ModuleBase<SocketCommandContext>
//    {
//        [Command("banka")]
//        [Alias("ban", "KB", "sporitelna")]
//        public async Task Mildosdsdsfasasaggdsurus1()
//        {
//            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "databáze");
//            var ruka = Context.User as SocketGuildUser;

//            if (!ruka.Roles.Contains(role2))
//            {
//                await Context.Message.Channel.SendMessageAsync("nejspíše nejsi registrován do ekonomiky,použij příkaz .registrovat");
//                return;
//            }

//            Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");

//            var najs = Context.User.Id.ToString();

//            var client = new MongoClient("MongoDB connection string");
//            var db = client.GetDatabase("dbl");
//            var coll = db.GetCollection<Rootobject1>("ekonomika");

//            var cisla = await coll.Find(b => b.uzivatelid == najs).FirstAsync();
//            int uzivatel1 = cisla.banka;

//            var ovcak = new EmbedBuilder();
//            ovcak.WithColor(Color.Orange);
//            ovcak.WithTitle($"V bance máš momentálně {uzivatel1} {agr} STORKSCOINS");
//            await Context.Channel.SendMessageAsync(embed: ovcak.Build());

//            //log
//            ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;
//            await cons.SendMessageAsync($"banka {ruka}");
//        }
//    }
//}