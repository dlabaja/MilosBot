using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Najdi : ModuleBase<SocketCommandContext>
    {
        //AIzaSyBnWN0zHpEBIEyy10_mpQU2i7QWYXZPZGA

        private string videoid;

        [Command("yt-search")]
        public async Task Run([Remainder] string nazev = null)
        {
            if (nazev == null)
            {
                await ReplyAsync("Nezadal jsi co mám vyhledat");
                return;
            }
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Volič");
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Starosta");
            var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");
            SocketGuildUser user = (SocketGuildUser)Context.User;
            if (user.Roles.Contains(role2) || user.Roles.Contains(role) || user.Roles.Contains(role3))
            {
                ObjectId idcko = ObjectId.Parse("6077d36aaa43c037d8ff47d7");
                var client = new MongoClient("MongoDB connection string");
                var db = client.GetDatabase("dbl");
                var coll = db.GetCollection<YtMongoCooldown>("counting");
                var data = coll.Find(b => b._id == idcko).FirstOrDefaultAsync().Result;

                try
                {
                    if (DateTime.Now.AddSeconds(-30) > data.cooldownsearch || user.GuildPermissions.ManageChannels)
                    {
                        var filter = Builders<YtMongoCooldown>.Filter.Eq("_id", idcko);
                        var update = Builders<YtMongoCooldown>.Update.Set("cooldownsearch", DateTime.Now.AddHours(2));
                        coll.UpdateOne(filter, update);

                        var yt = new YouTubeService(new BaseClientService.Initializer()
                        {
                            ApiKey = "API key",
                            ApplicationName = "Project name"
                        });
                        using (Context.Channel.EnterTypingState())
                        {
                            var searchListRequest = yt.Search.List("snippet,id");
                            searchListRequest.Q = nazev;
                            searchListRequest.MaxResults = 1;
                            searchListRequest.Type = "video";
                            searchListRequest.EventType = SearchResource.ListRequest.EventTypeEnum.None;
                            // Call the search.list method to retrieve results matching the specified query term.
                            var searchListResponse = await searchListRequest.ExecuteAsync();
                            if (searchListResponse.Items.Count == 0)
                            {
                                await ReplyAsync("Nic jsem nenašel :(");
                                return;
                            }
                            foreach (var video in searchListResponse.Items)
                            {
                                videoid = video.Id.VideoId;
                            }
                        }
                        await ReplyAsync("Yay! Našel jsem video! https://www.youtube.com/watch?v=" + videoid);
                    }
                    else
                    {
                        await ReplyAsync("Počkej! Příkaz se může na serveru používat jen jednou za 30s");
                    }
                }
                catch (Exception e)
                {
                    var u = Emote.Parse("<:pepe:773468259575922698>");
                    await ReplyAsync("Něco se pokazilo. Pokud bude chyba přetrvávat, nejspíš byl vyčerpán denní limit který nám nastavil google " + u);
                    Console.WriteLine(e);
                }
            }
            else
            {
                await ReplyAsync("O co se to jako snažíš? Tento příkaz můžeš použít až od role Volič");
            }
        }

        /* Call the search.list method to retrieve results matching the specified query term.
        var searchListRequest = yt.Search.List("contentDetails");
        searchListRequest.MaxResults = 1;
        searchListRequest.Type = "video";
        var e = searchListRequest.Execute();

        foreach (var dat in e.Items)
        {
            if (dat)
        }

        /*var subscriptionListRequest = yt.Subscriptions.List("snippet,contentDetails");
        subscriptionListRequest.ChannelId = "UCq-Fj5jknLsUf-MWSy4_brA";
        var searchListResult = subscriptionListRequest.Execute();
        foreach (var item in searchListResult.Items)
        {
            Console.WriteLine("ID:" + item.Id);
            Console.WriteLine("snippet:" + item.Snippet.Title);
        }*/

        // Call the search.list method to retrieve results matching the specified query term.
        //var searchListResponse = await searchListRequest.ExecuteAsync();

        // Add each result to the appropriate list, and then display the lists of
        // matching videos, channels, and playlists.
        /*foreach (var searchResult in searchListResponse.Items)
        {
            if (searchResult.Id.Kind == "youtube#channel")
            {
                Console.WriteLine("https://www.youtube.com/channel/" + searchResult.Snippet.ChannelId + "\n" + searchResult.Snippet.ChannelTitle);
            }
        }*/
    }
}