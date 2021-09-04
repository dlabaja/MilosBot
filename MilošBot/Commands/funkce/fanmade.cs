using Discord;
using Discord.Commands;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MilošBot.Commands
{
    public class Fanmady : ModuleBase<SocketCommandContext>
    {
        [Command("fanmade")]
        [Alias("fans", "made", "dbl")]
        public async Task Mildosaurus()
        {
            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");
            var coll = db.GetCollection<fanmadeUrl>("fanmade");
            var idcko = new ObjectId("605f6cc123e0effc68568a49");
            var cisla = coll.Find(b => b._id == idcko).FirstAsync().Result;

            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(cisla.url.Length);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some fanmade from dbl gaming**");
                ovcak.WithImageUrl(cisla.url[ovce]);

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Chcete být taky v tomto příkazu? Napište nám do #📣feedback :)");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("fanmade: " + cisla.url[ovce]);
            }
        }

        [Command("fadd")]
        [RequireUserPermission(GuildPermission.ManageRoles, ErrorMessage = "O co se to jako snažíš? :what:")]
        public async Task AddFanmade(string odkaz = null)
        {
            if (odkaz == null)
            {
                return;
            }
            var url = new Uri(odkaz);
            var filter = Builders<fanmadeUrl>.Filter.Eq("_id", new ObjectId("605f6cc123e0effc68568a49"));

            var update = Builders<fanmadeUrl>.Update
                    .Push("url", odkaz);

            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");
            var coll = db.GetCollection<fanmadeUrl>("fanmade");

            await coll.FindOneAndUpdateAsync(filter, update);
            await Context.Message.DeleteAsync();
        }
    }

    public class fanmadeUrl
    {
        public ObjectId _id { get; set; }
        public string[] url { get; set; }
    }
}