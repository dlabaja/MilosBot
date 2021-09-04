//using Discord;
//using Discord.Commands;
//using Discord.WebSocket;
//using MongoDB.Driver;
//using System;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MilošBot.Commands.help
//{
//    public class helpoasdst : ModuleBase<SocketCommandContext>
//    {
//        [Command("ruka")]
//        [Alias("ruce", "balance")]
//        public async Task Mildosdsasasaggdsurus1()
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
//            int uzivatel1 = cisla.cum;
//            int uzivatel11 = cisla.cernaruka;

//            //odpoved
//            var ovcak = new EmbedBuilder();
//            ovcak.WithTitle($"Na ruce máš momentálně {uzivatel1} {agr} STORKSCOINS \n Na černé ruce máš momentálně {uzivatel11} {agr} STORKSCOINS");
//            await Context.Channel.SendMessageAsync(embed: ovcak.Build());

//            ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;
//            await cons.SendMessageAsync($"ruce {ruka}");
//        }
//    }
//}