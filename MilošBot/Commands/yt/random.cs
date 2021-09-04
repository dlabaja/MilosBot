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
    public class Search : ModuleBase<SocketCommandContext>
    {
        //AIzaSyBnWN0zHpEBIEyy10_mpQU2i7QWYXZPZGA
        public static char GetLetter()
        {
            string chars = "abcdefghijklmnopqrstuvwxyz";
            Random rand = new Random();
            int num = rand.Next(0, chars.Length);
            return chars[num];
        }

        private string videoid;
        private int i = 0;
        private ulong e = 1000;
        private ulong u;
        private DateTime cas;

        [Command("yt-random")]
        public async Task Run()
        {
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
                    if (DateTime.Now.AddSeconds(-30) > data.cooldown)
                    {
                        var filter = Builders<YtMongoCooldown>.Filter.Eq("_id", idcko);
                        var update = Builders<YtMongoCooldown>.Update.Set("cooldown", DateTime.Now.AddHours(2));
                        coll.UpdateOne(filter, update);

                        var yt = new YouTubeService(new BaseClientService.Initializer()
                        {
                            ApiKey = "API key",
                            ApplicationName = "Project name"
                        });
                        using (Context.Channel.EnterTypingState())
                        {
                            var searchListRequest = yt.Search.List("snippet,id");
                            searchListRequest.Q = GetLetter().ToString() + GetLetter().ToString();// Replace with your search term.
                            searchListRequest.MaxResults = 50;
                            searchListRequest.Order = SearchResource.ListRequest.OrderEnum.ViewCount;
                            searchListRequest.Type = "video";
                            //searchListRequest.Location = "22.7063353,79.6198206";
                            //searchListRequest.LocationRadius = "999km";
                            searchListRequest.VideoDuration = SearchResource.ListRequest.VideoDurationEnum.Short__;
                            searchListRequest.PublishedAfter = DateTime.Now.AddHours(-15);
                            searchListRequest.EventType = SearchResource.ListRequest.EventTypeEnum.None;
                            // Call the search.list method to retrieve results matching the specified query term.
                            var searchListResponse = await searchListRequest.ExecuteAsync();
                            i = 0;
                            e = 1000;
                            Console.WriteLine(searchListResponse.Items.Count - 10);
                            foreach (var video in searchListResponse.Items)
                            {
                                if (i > searchListResponse.Items.Count - 10)
                                {
                                    var subscriptionListRequest = yt.Channels.List("contentDetails,statistics,snippet");
                                    subscriptionListRequest.Id = video.Snippet.ChannelId;
                                    subscriptionListRequest.MaxResults = 1;
                                    var searchListResult = subscriptionListRequest.Execute();
                                    foreach (var kanal in searchListResult.Items)
                                    {
                                        if (kanal.Statistics.SubscriberCount < e)
                                        {
                                            Console.WriteLine(i);
                                            e = (ulong)kanal.Statistics.SubscriberCount;
                                            videoid = video.Id.VideoId;
                                            cas = (DateTime)video.Snippet.PublishedAt;
                                        }
                                    }
                                }
                                i++;
                            }

                            if (videoid == null)
                            {
                                Console.WriteLine("null vyjímka");
                            }

                            var vid = yt.Videos.List("statistics");
                            vid.Id = videoid;
                            vid.MaxResults = 1;
                            var hledej = await vid.ExecuteAsync();
                            foreach (var video in hledej.Items)
                            {
                                u = (ulong)video.Statistics.ViewCount;
                                break;
                            }
                        }
                        await ReplyAsync("https://www.youtube.com/watch?v=" + videoid + "\n**Odběratelé:** " + e + ", **Zhlédnutí:** " + u + ", **Vydáno:** " + cas);
                        i = 0;
                        e = 1000;
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

    public class YtMongoCooldown
    {
        public ObjectId _id { get; set; }
        public DateTime cooldown { get; set; }
        public DateTime cooldownsearch { get; set; }
    }
}