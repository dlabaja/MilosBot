using Discord;
using Discord.Addons.Interactive;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MilošBot.Commands.at;
using MilošBot.Commands.Attributes;
using MilošBot.Logging;
using MilošBot.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Program
    {
        private static async Task Main() => await new Program().RunBotAsync();

        public static bool umisteni = Environment.OSVersion.Platform == PlatformID.Unix; //false jsem já, true je ubuntu
        public ulong LogId => umisteni ? DChannelId.MilosLog : 843905808244801576ul;
        private readonly Random random = new Random();

        private DiscordSocketClient _client;
        private ForbidenWordService _forbidenWordS;
        private CommandService _commands;
        private IServiceProvider _services;
        private MuteServise muteServise;

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_client)
                .AddSingleton(_commands)
                .AddSingleton<InteractiveService>()
                .AddSingleton<Random>()
                .AddLogging(c => c.ClearProviders().AddSimpleConsole().AddProvider(new DiscordProvider(_client, LogId)));
            services.AddTransient(x => new MongoClient("MongoDB connection string"))
                .AddTransient<IMongoClient>(x => x.GetRequiredService<MongoClient>())
                .AddSingleton<UpTimeService>()
                .AddSingleton<ForbidenWordService>()
                .AddSingleton<MuteServise>();
        }

        public async Task RunBotAsync()
        {
            Console.Title = "Milošovo hackovací středisko";
            _client = new DiscordSocketClient();
            _commands = new CommandService(new CommandServiceConfig() { DefaultRunMode = RunMode.Async });
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _services = serviceCollection.BuildServiceProvider();
            _forbidenWordS = _services.GetRequiredService<ForbidenWordService>();
            muteServise = _services.GetRequiredService<MuteServise>();

            string token;
            if (umisteni)
            {
                Console.WriteLine("TrueMiloš - bez debugu");
                token = "TOKEN";
            }
            else
            {
                Console.WriteLine("Debug verze bota");
                token = "TOKEN2";
            }

            Console.WriteLine("Ubuntu umisteni: " + umisteni);

            _client.Log += Client_Log;

            await RegisterCommandsAsync();
            await _client.LoginAsync(TokenType.Bot, token);
            _client.UserJoined += AnnounceJoinedUser;
            _client.UserLeft += AnnounceLeftUser;
            _client.ReactionAdded += ReactionAdded;

            var casik = new DateTime(2021, 7, 15) - DateTime.Now;
            await _client.SetActivityAsync(new Game($"Přípravu na paralymPIJádu", ActivityType.Playing, ActivityProperties.None));
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        private Task Client_Log(LogMessage arg)
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + ": " + arg);
            return Task.CompletedTask;
        }

        public async Task AnnounceJoinedUser(SocketGuildUser gUser)
        {
            if (Zoford12Module.Zoford12Id.Contains(gUser.Id))
            {
                gUser.AddRoleAsync(860123585401192459);
                return;
            }
            ITextChannel log = _client.GetChannel(DChannelId.ConsoleLog) as ITextChannel;
            Console.WriteLine(DateTime.Now.ToShortTimeString());
            Console.WriteLine(gUser.CreatedAt.AddDays(7));
            Console.WriteLine(gUser.CreatedAt);
            if (DateTimeOffset.Compare(DateTime.Now.AddMilliseconds(1), gUser.CreatedAt.AddDays(7)) < 0)
            {
                await log.SendMessageAsync(gUser + " se sem pokoušel dostat, ale má moc mladý účet.");
                try
                {
                    await gUser.SendMessageAsync("Pro pobyt na tomto serveru je tvůj účet moc mladý. Vrať se později.");
                }
                catch
                {
                    return;
                }
                await gUser.KickAsync();
                return;
            }

            var role8 = gUser.Guild.Roles.FirstOrDefault(x => x.Id == 738307326364352512);
            await gUser.AddRoleAsync(role8);
            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");
            var coll = db.GetCollection<RootobjectI>("uzivatele");
            var collec = db.GetCollection<BsonDocument>("uzivatele");
            var collic2 = db.GetCollection<BsonDocument>("pingy");
            uvitani:
            var data = coll.Find(b => b.idcko == gUser.Id.ToString()).FirstOrDefaultAsync().Result;
            Console.WriteLine("jsj");
            if (data == null)
            {
                Console.WriteLine("jj");
                string avatar = gUser.GetAvatarUrl() ?? gUser.GetDefaultAvatarUrl();
                var tagkod = gUser.DiscriminatorValue * random.Next(2, 11) + random.Next(1, 100);
                Console.WriteLine("jjpo");
                var pridani = new BsonDocument { { "nick", gUser.ToString() }, { "mute", false }, { "avatar", avatar }, { "joined", DateTime.Now }, { "tagkod", tagkod }, { "idcko", gUser.Id.ToString() }, };
                collec.InsertOne(pridani);
                var pridania = new BsonDocument { { "nick", gUser.ToString() }, { "idcko", gUser.Id.ToString() }, { "oznameni", true }, { "promo", true }, { "freehry", false }, { "politika", false } };
                collic2.InsertOne(pridania);
                Console.WriteLine("jjposa");
                goto uvitani;
            }
            if (await muteServise.CheckMuteAsync(gUser))
            {
                IGuild server = _client.GetGuild(719247194145816686);
                try
                {
                    await gUser.SendMessageAsync("Ale ale ale, obcházení mutu? Za to dostaneš BAN.");
                }
                catch (Discord.Net.HttpException)
                {
                }
                var premier = server.Roles.FirstOrDefault(x => x.Id == 719259714701230140);//premier wow
                await log.SendMessageAsync($"{premier.Mention} {gUser} se sem pokoušel dostat, dostal ale ban za porušování mute :yay:");
                await gUser.BanAsync(reason: "Obcházení mutu");
                return;
            }
            await ObrazekAsync(gUser);
            try
            {
                await gUser.SendMessageAsync("🇨🇿 Super, vítej u našeho ověření. Jediné co stačí udělat je opsat tento kód\n🇬🇧󠁧󠁢󠁥󠁮󠁧󠁿 Great, welcome to our verification system. Only thing you have to do is write this code");
                KodObrazek(gUser);
                await log.SendMessageAsync(gUser + " " + gUser.Mention + " " + gUser.GetAvatarUrl() + " " + DateTime.Now);
            }
            catch (Discord.Net.HttpException)
            {
                return;
            }
        }

        public async Task AnnounceLeftUser(SocketGuildUser gUser)
        {
            Emote _16 = Emote.Parse("<:smutnej:722776040170061844>");
            var channel = _client.GetChannel(DChannelId.Vitej) as SocketTextChannel;
            await channel.SendMessageAsync($"{gUser.Username} se na nás vy*ral " + _16);
        }

        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        private readonly List<string> vysralReakce = new List<string>() { "<:aaatycuraku:766567796783316992>", "<:soukupfuck:721356646147817562>", "<:gottfuck:719278717242966086>" };
        private readonly Emoji jop = new Emoji("\u2705");
        private readonly Emote cauLidi = Emote.Parse("<:ahoj:815313636192288818>");

        private readonly ulong[] randomReactionChannelIgnore = new ulong[] { DChannelId.MilosLog, DChannelId.Suggest, DChannelId.ConsoleLog, DChannelId.MilosOsobnosti, 800713025840742415 };

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            if (message is null)
            {
                return;
            }
            IGuild server = _client.GetGuild(719247194145816686);
            var context = new SocketCommandContext(_client, message);
            var user = context.User as SocketGuildUser;
            ITextChannel log = context.Client.GetChannel(DChannelId.ConsoleLog) as ITextChannel;
            ITextChannel logfeed = context.Client.GetChannel(DChannelId.Suggest) as ITextChannel;

            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");
            var collic = db.GetCollection<RootobjectI>("uzivatele");
            var collek = db.GetCollection<BsonDocument>("uzivatele");

            if (message.Author.IsBot)
            {
                //vysral reakce
                if (message.Channel.Id == DChannelId.Vitej && message.Content.Contains("vy*ral"))
                {
                    int randomReakce = random.Next(vysralReakce.Count);
                    Emote emote = Emote.Parse(vysralReakce[randomReakce]);
                    await message.AddReactionAsync(emote);
                }
            }
            else
            {
                //commandy
                int argPos = 0;
                if (message.HasStringPrefix(".", ref argPos) && message.Channel.Id != DChannelId.Counting)
                {
                    var result = await _commands.ExecuteAsync(context, argPos, _services);
                    if (!result.IsSuccess)
                    {
                        Console.WriteLine(result.ErrorReason);
                        ITextChannel cons = context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
                        await cons.SendMessageAsync($"{result.ErrorReason }\n{message.Author} - {message.Content}");
                    }
                    if (result.Error.Equals(CommandError.UnmetPrecondition)) await message.Channel.SendMessageAsync(result.ErrorReason);
                }

                //Po ověření
                if (context.Channel.GetType() == typeof(SocketDMChannel))
                {
                    await log.SendMessageAsync(message.ToString() + " - " + message.Author);
                    foreach (SocketGuildUser uzivatele in server.GetUsersAsync().Result)
                    {
                        if (message.Author.ToString() == uzivatele.ToString() && uzivatele.Roles.Contains(server.GetRole(738307326364352512)))
                        {
                            var data = collic.Find(b => b.idcko == uzivatele.Id.ToString()).First();
                            if (message.Content.Contains(data.tagkod.ToString()))
                            {
                                try
                                { await uzivatele.SendMessageAsync(@"🇨🇿 Vítej na **dbl gaming**
Za celý AT doufám že se ti tu bude líbit, všechny příkazy a informace jsou připnuté
Pokud něco z nějakého důvodu nefunguje, napiš nějakému premiérovi :)

🇬🇧󠁧󠁢󠁥󠁮󠁧󠁿 Welcome to **dbl gaming**
We hope you enjoy your stay here, commands and informations are pinned in the specific channel
If something doesn't work for some reason, contact anyone with role @premier :)"); }
                                catch (Discord.Net.HttpException) { }
                                var role = server.Roles.FirstOrDefault(x => x.Id == 798822764872990740);//level
                                var role1 = server.Roles.FirstOrDefault(x => x.Id == 798825895866793984);//pingrole
                                var role2 = server.Roles.FirstOrDefault(x => x.Id == 798823309596819488);//speciální
                                var role9 = server.Roles.FirstOrDefault(x => x.Id == 798822477169819689);//tomiorole
                                var role10 = server.Roles.FirstOrDefault(x => x.Id == 798822174005657601);//ekonomika
                                var role3 = server.Roles.FirstOrDefault(x => x.Id == 798820832901070848);//věk
                                var role4 = server.Roles.FirstOrDefault(x => x.Id == 727125331512918128);//imigrant
                                var role5 = server.Roles.FirstOrDefault(x => x.Id == 786631302514343997);//ping
                                var role6 = server.Roles.FirstOrDefault(x => x.Id == 811279796587331605);//promoping
                                var role7 = server.Roles.FirstOrDefault(x => x.Id == 735827797792129134);//dj
                                var role8 = server.Roles.FirstOrDefault(x => x.Id == 738307326364352512);//nereg
                                var role85 = server.Roles.FirstOrDefault(x => x.Id == 782183833960316929);//lovec

                                await uzivatele.RemoveRoleAsync(role8);
                                await uzivatele.AddRolesAsync(new[] { role, role1, role2, role3, role4, role5, role6, role7, role85, role9, role10 });
                            }
                            try
                            {
                                await message.DeleteAsync();
                            }
                            catch { }
                        }
                    }
                }

                //ověření filtr
                if (message.Channel.Id == 738307611673362502 && !message.Content.Equals(".resend") && user.Roles.Contains(server.GetRole(738307326364352512)))
                {
                    await log.SendMessageAsync(message.ToString() + " - " + message.Author);
                    var data = collic.Find(b => b.idcko == user.Id.ToString()).First();
                    if (message.Content.Contains(data.tagkod.ToString()))
                    {
                        try { await user.SendMessageAsync(@"🇨🇿 Vítej na **dbl gaming**
Za celý AT doufám že se ti tu bude líbit, všechny příkazy a informace jsou připnuté
Pokud něco z nějakého důvodu nefunguje, napiš nějakému premiérovi :)

🇬🇧 Welcome on **dbl gaming**
We hope you enjoy your stay here, commands and informations are pinned in a specific channel
If something doesn't work for some reason, contact anyone with role @premier :)"); }
                        catch (Discord.Net.HttpException)
                        { }

                        var role = context.Guild.Roles.FirstOrDefault(x => x.Id == 798822764872990740);//level
                        var role1 = context.Guild.Roles.FirstOrDefault(x => x.Id == 798825895866793984);//pingrole
                        var role2 = context.Guild.Roles.FirstOrDefault(x => x.Id == 798823309596819488);//speciální
                        var role9 = context.Guild.Roles.FirstOrDefault(x => x.Id == 798822477169819689);//tomiorole
                        var role10 = context.Guild.Roles.FirstOrDefault(x => x.Id == 798822174005657601);//ekonomika
                        var role3 = context.Guild.Roles.FirstOrDefault(x => x.Id == 798820832901070848);//věk
                        var role4 = context.Guild.Roles.FirstOrDefault(x => x.Id == 727125331512918128);//imigrant
                        var role5 = context.Guild.Roles.FirstOrDefault(x => x.Id == 786631302514343997);//ping
                        var role6 = context.Guild.Roles.FirstOrDefault(x => x.Id == 811279796587331605);//promoping
                        var role7 = context.Guild.Roles.FirstOrDefault(x => x.Id == 735827797792129134);//dj
                        var role8 = context.Guild.Roles.FirstOrDefault(x => x.Id == 738307326364352512);//nereg
                        var role85 = context.Guild.Roles.FirstOrDefault(x => x.Id == 782183833960316929);//lovec

                        if (user.Roles.Contains(role8))
                        {
                            await user.RemoveRoleAsync(role8);
                            await user.AddRolesAsync(new[] { role, role1, role2, role3, role4, role5, role6, role7, role85, role9, role10 });
                            await context.Channel.DeleteMessageAsync(context.Message);
                            return;
                        }
                    }
                    else
                    {
                        try
                        {
                            await user.SendMessageAsync("🇨🇿 Ověření se nezdařilo\n🇬🇧󠁧󠁢󠁥󠁮󠁧󠁿 Verification failed\n\nZkuste znovu opsat tento kód: " + data.tagkod);
                        }
                        catch (Discord.Net.HttpException)
                        {
                            return;
                        }
                    }
                    try
                    {
                        await message.DeleteAsync();
                    }
                    catch { }
                }

                //gm
                if (message.Content.Equals("gm", StringComparison.OrdinalIgnoreCase))
                {
                    await message.AddReactionAsync(cauLidi);
                    await context.Channel.SendMessageAsync("Dobré ráno soudruhu " + context.User.Username);
                }

                //gn
                if (message.Content.Equals("gn", StringComparison.OrdinalIgnoreCase))
                {
                    await message.AddReactionAsync(cauLidi);
                    await context.Channel.SendMessageAsync("Kráné sny ti vinšuji soudruhu " + context.User.Username);
                }

                var att = typeof(ForbiddenWordModule).GetCustomAttribute<RequiredRoleAttribute>();
                //invite filter
                if (_forbidenWordS.TryGet(message.Content, out var fw) && message.Channel.Id != DChannelId.Reklama && message.Channel.Id != DChannelId.Spoluprace && !(user.GuildPermissions.Administrator || user.Roles.Any(x => att.RoleIds.Contains(x.Id))))
                {
                    var embed = new EmbedBuilder()
                        .WithTitle(context.User + "** použil zakázaná slovíčka, Miloš je ale naštěstí odrazil svým Ovčáčkem**")
                        .WithDescription("\n**" + message.Content + "\n**" + context.Channel.Name)
                        .WithFooter(footer =>
                        {
                            footer
                            .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                            .WithText("Kázeňské přestupky řešené MilošBotem");
                        });
                    await log.SendMessageAsync(embed: embed.Build());
                    await context.User.SendMessageAsync(" Ty ty ty to se nedělá! >:(​ ");
                    await context.User.SendMessageAsync("https://cdn.discordapp.com/attachments/725236966286950430/790874454417866772/dssdsd.png");
                    await message.DeleteAsync();
                    await context.Channel.SendMessageAsync("> " + context.User + "** použil zakázaná slovíčka, Miloš je ale naštěstí odrazil svým Ovčáčkem**");
                    const string reason = "Zakázaný odkaz.";
                    switch (fw.Severity)
                    {
                        case ForbiddenWordSeverity.Kick:
                            await user.KickAsync(reason);
                            break;

                        case ForbiddenWordSeverity.TempMute:
                            await muteServise.TempMuteUserAsync(user, fw.Delay ?? new TimeSpan(0, 5, 0));
                            break;

                        case ForbiddenWordSeverity.Mute:
                            await muteServise.MuteUserAsync(user);
                            break;

                        case ForbiddenWordSeverity.Ban:
                            await user.BanAsync(reason: reason);
                            break;

                        default:
                            break;
                    }
                }

                //slovni fotbal
                if (message.Channel.Id == DChannelId.Fotbal || message.Channel.Id == 787627654882525204)
                {
                    var messages = context.Channel.GetMessagesAsync(2).Flatten();
                    await foreach (Discord.Rest.RestUserMessage zprava in messages)
                    {
                        if (zprava.Author != message.Author && zprava.Content.ToLower().Last() == message.Content.ToLower().First() && char.IsLetter(message.Content.Last()) && message.Content != zprava.Content)
                        {
                            await message.AddReactionAsync(jop);
                            return;
                        }
                    }
                    await message.DeleteAsync();
                }

                //counting
                if (message.Channel.Id == DChannelId.Counting || message.Channel.Id == 785862164434518067)
                {
                    var coll = db.GetCollection<prom>("counting");
                    var idcko = new ObjectId("6033734fcc238b307841f0ff");
                    var cisla = coll.Find(b => b._id == idcko).FirstAsync().Result;
                    bool isgut = false;//true je jiný

                    if (message.Content.Contains(cisla.pocitani.ToString()) || message.Attachments.Count > 0 || message.Content.Contains("http://") || message.Content.Contains("https://"))
                    {
                        var messages = context.Channel.GetMessagesAsync(2).Flatten();

                        await foreach (Discord.Rest.RestUserMessage zprava in messages)
                        {
                            Console.WriteLine(zprava);
                            if (zprava.Author != context.Message.Author)
                            {
                                var necisla = ulong.Parse(cisla.pocitani.ToString());
                                var filter = Builders<prom>.Filter.Eq("_id", idcko);
                                var update = Builders<prom>.Update.Set("pocitani", necisla + 1);
                                var nove = coll.UpdateOne(filter, update);
                                isgut = true;
                                await message.AddReactionAsync(jop);
                            }
                            else
                            {
                                isgut = false;
                                // Console.WriteLine(zprava.Author + " " + context.Message.Author);
                            }
                        }
                        if (isgut == false)
                        {
                            await message.DeleteAsync();
                        }
                    }
                    else
                    {
                        await message.DeleteAsync();
                    }
                }
            }

            //politici
            if (message.Channel.Id == DChannelId.PoliticiIn)
            {
                ITextChannel pol = context.Client.GetChannel(DChannelId.PoliticiOut) as ITextChannel;
                await pol.SendMessageAsync(message.Content.ToString());
            }

            //everyone & here
            if (context.Guild == server)
            {
                var rolepo = context.Guild.Roles.FirstOrDefault(x => x.Id == 803891419160510484);
                if (message.Content.Contains(rolepo.Mention) && !user.Roles.Equals("premiér"))
                {
                    await user.AddRoleAsync(rolepo);
                    await log.SendMessageAsync("everyone: " + user);
                }
                var rolehere = context.Guild.Roles.FirstOrDefault(x => x.Id == 810105483365056522);
                if (message.Content.Contains(rolehere.Mention) && !user.Roles.Equals("premiér"))
                {
                    await user.AddRoleAsync(rolehere);
                    await log.SendMessageAsync("here: " + user);
                }
            }

            //feedback
            if (message.Channel.Id == 762353445151440936)
            {
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Feedback od **" + context.User);
                ovcak.WithDescription(message.ToString());

                await logfeed.SendMessageAsync(embed: ovcak.Build());
                if (context.Message.Attachments.Count >= 1)
                {
                    var url = context.Message.Attachments.First().Url;

                    string cesta = umisteni == false ?
                        @"C:\Users\uzivatel 1\Pictures\discord_temp\" + context.Message.Attachments.First().Filename :
                        @"/home/kubak1500/Desktop/" + context.Message.Attachments.First().Filename;

                    using (var clientela = new WebClient())
                    {
                        clientela.DownloadFile(new Uri(url), cesta);
                    }
                    await logfeed.SendFileAsync(cesta);
                    File.Delete(cesta);
                }
                await context.Channel.DeleteMessageAsync(context.Message.Id);

                try
                {
                    await context.User.SendMessageAsync($"Děkujeme za feedback! Až ho schválíme, dáme ti vědět {context.User.Mention} :)");
                }
                catch
                {
                    return;
                }
            }

            //reakce & spam filter
            else
            {
                if (!randomReactionChannelIgnore.Contains(message.Channel.Id) && context.Channel.GetType() != typeof(SocketDMChannel) && random.Next(20) == 0)
                {
                    try
                    {
                        var randomEmoteIndex = random.Next(server.Emotes.Count);
                        await message.AddReactionAsync(server.Emotes.ElementAt(randomEmoteIndex));
                    }
                    catch { }
                }

                var collec = db.GetCollection<Rootobject1>("statistiky");
                var idckoo = new ObjectId("603d418f3327a936bcba734e");
                var cislaa = collec.Find(b => b._id == idckoo).FirstAsync().Result;
                DateTime porovnani = cislaa.timer2;
                int zpravy = cislaa.zpravy;

                var filtered = Builders<Rootobject1>.Filter.Eq("_id", idckoo);
                var updated = Builders<Rootobject1>.Update.Set("zpravy", zpravy + 1);
                var nove = collec.UpdateOne(filtered, updated);

                var hod1 = DateTime.UtcNow.AddHours(1);
                DateTime secondsLeft = porovnani.AddDays(1);
                DateTime hod = porovnani.AddDays(1);

                if (porovnani <= hod1)
                {
                    string nula = "aaaaa";
                    int nula1 = 0;

                    var filter9 = Builders<Rootobject1>.Filter.Eq("uzivatelid", nula);
                    var update9 = Builders<Rootobject1>.Update.Set("timer2", secondsLeft);
                    collec.UpdateOne(filter9, update9);

                    var coll5515 = db.GetCollection<Rootobject1>("cislo");

                    var idcko1 = new ObjectId("603d510a6b05e30f18f4647b");
                    var cisla1 = coll5515.Find(b => b._id == idcko1).FirstAsync().Result;
                    int i = cisla1.uzivat;

                    int ii = i + 1;
                    Console.WriteLine(ii);
                    var coll551 = db.GetCollection<Rootobject1>("cislo");
                    var filter99 = Builders<Rootobject1>.Filter.Eq("ahoj", nula1);
                    var update99 = Builders<Rootobject1>.Update.Set("uzivat", ii);
                    coll551.UpdateOne(filter99, update99);

                    var coll1 = db.GetCollection<Rootobject1>("test");
                    var cisla7 = coll1.Find(b => b.uzi == i).FirstAsync().Result;
                    int rozdil = cisla7.rozdil;

                    int kurz = zpravy - rozdil;

                    var coll11 = db.GetCollection<BsonDocument>("test");
                    var pridani1 = new BsonDocument
                    {
                        { "uzi", ii },
                        { "timer1", hod },
                        { "ahoj", kurz },
                        { "rozdil", zpravy }
                    };
                    await coll11.InsertOneAsync(pridani1);

                    var gUser = context.User as SocketGuildUser;
                    SocketGuild dbl = gUser.Guild;
                    int users = dbl.Users.Count;

                    var coll117 = db.GetCollection<BsonDocument>("test1");
                    var pridani17 = new BsonDocument
                    {
                        { "uzi", ii },
                        { "timer1", hod },
                        { "ahoj", users },
                    };
                    await coll117.InsertOneAsync(pridani17);

                    //var kurz = new kurzupdate();
                    //await kurz.updatekurz();

                    var coll19 = db.GetCollection<Rootobject1>("test1");

                    var ccoll5515 = db.GetCollection<Rootobject1>("cislo");

                    var cidcko1 = new ObjectId("603d510a6b05e30f18f4647b");
                    var cisla11 = ccoll5515.Find(b => b._id == cidcko1).FirstAsync().Result;
                    int ci = cisla11.uzivat;

                    List<double> amplitudes = new List<double>();
                    List<string> frequencies = new List<string>();
                    for (int x = 2; x < 18; x++)
                    {
                        var ccisla1 = await coll19.Find(b => b.uzi == ci - x).FirstOrDefaultAsync();
                        if (ccisla1 is null)
                            Console.WriteLine("null");
                        DateTime datum1 = ccisla1.timer1;
                        amplitudes.Add(ccisla1.ahoj);
                        frequencies.Add(datum1.ToString("MM/dd HH"));
                    }
                    var plt = new Plot(1000, 400);
                    amplitudes.Reverse();
                    frequencies.Reverse();
                    double[] positions = DataGen.Consecutive(frequencies.Count);
                    plt.AddScatter(positions, amplitudes.ToArray());

                    string[] plabels = frequencies.Select(x => x.ToString()).ToArray();
                    plt.XTicks(positions, plabels);

                    plt.Title("kurz virtuální kryptoměny BiTStorK");
                    plt.YLabel("kurz");
                    plt.XLabel("čas (měsíc den hodina)");

                    var pcoll19 = db.GetCollection<Rootobject1>("test");

                    List<double> pamplitudes = new List<double>();
                    List<string> pfrequencies = new List<string>();
                    for (int x = 2; x < 18; x++)
                    {
                        var pcisla1 = await pcoll19.Find(b => b.uzi == ci - x).FirstAsync();
                        if (pcisla1 is null)
                            Console.WriteLine("null");
                        DateTime datum1 = pcisla1.timer1;
                        Console.WriteLine("null");
                        pamplitudes.Add(pcisla1.ahoj);
                        pfrequencies.Add(datum1.ToString("MM/dd HH"));
                    }
                    var pplt = new Plot(1000, 400);
                    pamplitudes.Reverse();
                    pfrequencies.Reverse();
                    double[] ppositions = DataGen.Consecutive(pfrequencies.Count);
                    pplt.AddScatter(ppositions, pamplitudes.ToArray());

                    string[] pplabels = pfrequencies.Select(x => x.ToString()).ToArray();
                    pplt.XTicks(ppositions, pplabels);

                    pplt.Title("kurz virtuální kryptoměny NSDM");
                    pplt.YLabel("kurz");
                    pplt.XLabel("čas (měsíc den hodina)");

                    pplt.SaveFig(@"C:home/kubak1500/Desktop/nsdm.jpg");
                    plt.SaveFig(@"C:home/kubak1500/Desktop/ahojd.jpg");

                    ITextChannel kanak = context.Client.GetChannel(DChannelId.Kurz) as ITextChannel;
                    await kanak.SendFileAsync(@"C:home/kubak1500/Desktop/ahojd.jpg");
                    await kanak.SendFileAsync(@"C:home/kubak1500/Desktop/nsdm.jpg");

                    //home/kubak1500/Desktop/nsdm.jpg
                }
            }
        }

        private async Task ObrazekAsync(SocketGuildUser gUser)
        {
            var met = new GeneratorUvitacihoObrazku();
            var avatar = gUser.GetAvatarUrl() ?? gUser.GetDefaultAvatarUrl();
            string cesta = Data.Pictrazky("obrazek.png");

            var ms = new MemoryStream();
            using (var clientela = new HttpClient())
            {
                var data = await clientela.GetStreamAsync(avatar);
                await data.CopyToAsync(ms);
            }

            string firstText = $"Čest práci  {gUser.Username}! Vítej na dbl gaming,";
            string secondText = $"serveru, který má díky tobě už {gUser.Guild.Users.Count} členů";
            var profilovka = System.Drawing.Image.FromStream(ms);
            var firstLocation = new PointF(550f, 390f);
            var secondLocation = new PointF(550f, 440f);
            var bitmap = (Bitmap)System.Drawing.Image.FromFile(cesta);//load the image file
            met.ResizeImage(profilovka, 300, 300);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                var fontSize = gUser.Username.ToString().Length >= 20 ? 20 : 30;
                using var arialFont = new Font("Calibri", fontSize);
                var format = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                };
                graphics.DrawString(firstText, arialFont, Brushes.White, firstLocation, format);
            }
            using (var graphics = Graphics.FromImage(bitmap))
            {
                using var arialFont = new Font("Calibri", 25);
                var format = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                };
                var resized = met.ResizeImage(profilovka, 248, 248);
                graphics.DrawString(secondText, arialFont, Brushes.White, secondLocation, format);
                graphics.DrawImage(met.CropImage(resized), 417, 49);
            }
            ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            ms.Position = 0;
            ITextChannel vitej = _client.GetChannel(DChannelId.Vitej) as ITextChannel;
            await vitej.SendFileAsync(ms, "vitej.png");
        }

        private async void KodObrazek(IUser user)
        {
            var cesta = Data.Pictrazky("kod.jpg");
            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");
            var coll = db.GetCollection<RootobjectI>("uzivatele");
            var data = coll.Find(b => b.idcko == user.Id.ToString()).FirstOrDefaultAsync().Result;

            var bitmap1 = (Bitmap)System.Drawing.Image.FromFile(cesta);
            Console.WriteLine(data.tagkod);
            using (var graphics = Graphics.FromImage(bitmap1))
            {
                using var arialFont = new Font("Comic Sans MS", 100);
                var format = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                };
                graphics.DrawString(data.tagkod.ToString(), arialFont, Brushes.Black, 357, 130, format);
            }
            var ms = new MemoryStream();
            bitmap1.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Position = 0;
            try
            {
                await user.SendFileAsync(ms, "kal.jpg");
            }
            catch { }
        }

        private async void Volej(ulong userid, bool b, ulong r, string e, ulong zpr)
        {
            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");
            var coll = db.GetCollection<MongoPingy>("pingy");
            IGuild server = _client.GetGuild(719247194145816686);
            var role8 = server.Roles.FirstOrDefault(x => x.Id == r);
            foreach (var user in await server.GetUsersAsync())
            {
                if (user.Id == userid && !user.IsBot)
                {
                    MongoPingy pingy;
                    IMessage zpra;
                    var filter = Builders<MongoPingy>.Filter.Eq("idcko", user.Id);
                    pingy = coll.Find(b => b.idcko == user.Id.ToString()).FirstAsync().Result;
                    var met = new Pingy();

                    var messages = await user.GetOrCreateDMChannelAsync();
                    var zpravy = messages.GetMessagesAsync(3).Flatten();

                    await foreach (Discord.Rest.RestUserMessage zprava in zpravy)
                    {
                        if (zprava.Id == zpr)
                        {
                            zpra = zprava;
                            goto label1;
                        }
                    }
                    return;
                    label1:
                    UpdateDefinition<MongoPingy> update;
                    try
                    {
                        if (b == true)
                        {
                            await user.RemoveRoleAsync(role8);
                            await user.SendMessageAsync("Role odebrána");
                            update = Builders<MongoPingy>.Update.Set(e, false);
                        }
                        else
                        {
                            await user.AddRoleAsync(role8);
                            await user.SendMessageAsync("Role přidána");
                            update = Builders<MongoPingy>.Update.Set(e, true);
                        }
                        coll.UpdateOne(filter, update);
                        await zpra.DeleteAsync();
                        pingy = coll.Find(b => b.idcko == user.Id.ToString()).FirstAsync().Result;
                        var ovcak = new EmbedBuilder();
                        ovcak.WithTitle("Vaše **dbl gaming** pingy na jednom místě");
                        ovcak.WithDescription(":one: Oznámení‎‎‏‏‎ ‎‏‏‎ ‎" + met.TrueFalse(pingy.oznameni)
                            + "\n:two: Promo                          ‎‏‏‎‎‏‏‎‎‏‏‎"
                            + met.TrueFalse(pingy.promo) + "\n:three: Free hry‏‏‎ ‎‏‏‎ ‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‎"
                            + met.TrueFalse(pingy.freehry) + "\n:four: Politika‏‏‎ ‎‏‏‎ ‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎  ‎‎‎‎  ‎‎‎‎‎‎‎‎"
                            + met.TrueFalse(pingy.politika) + "\n:five: Počasí ‎‏‏‎ ‏‏‎ ‎‏‏‎ ‎‏‏‎ ‎‏‏‎  ‎‎ ‎‎‎‎ ‎‎‎‎ ‎‎‎‎‎‎‎‎"
                            + met.TrueFalse(pingy.pocasi));
                        ovcak.WithFooter(footer =>
                        {
                            footer
                            .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                            .WithText("Nastavení pingů od MilošBota");
                        });
                        var sendMeg = await user.SendMessageAsync(embed: ovcak.Build());
                        await sendMeg.AddReactionsAsync(reakce);
                        break;
                    }
                    catch (Discord.Net.HttpException)
                    {
                        return;
                    }
                }
            }
        }

        private Emoji[] reakce = new Emoji[] {
            new Emoji("1️⃣"),
            new Emoji("2️⃣"),
            new Emoji("3️⃣"),
            new Emoji("4️⃣"),
            new Emoji("5️⃣")};

        private async Task ReactionAdded(Cacheable<IUserMessage, ulong> arg1, IChannel arg2, SocketReaction arg3)
        {
            if (arg3.Channel.GetType() == typeof(SocketDMChannel))
            {
                foreach (var reaction in reakce)
                {
                    if (arg3.Emote.Equals(reaction) && !arg3.User.Value.IsBot)
                    {
                        var client = new MongoClient("MongoDB connection string");
                        var db = client.GetDatabase("dbl");
                        var coll = db.GetCollection<MongoPingy>("pingy");
                        var pingy = coll.Find(b => b.idcko == arg3.UserId.ToString()).FirstAsync().Result;
                        ITextChannel log = _client.GetChannel(DChannelId.ConsoleLog) as ITextChannel;

                        if (arg3.Emote.ToString().Contains("1"))
                        {
                            Volej(arg3.UserId, pingy.oznameni, 786631302514343997, "oznameni", arg3.MessageId);
                        }
                        if (arg3.Emote.ToString().Contains("2"))
                        {
                            Volej(arg3.UserId, pingy.promo, 811279796587331605, "promo", arg3.MessageId);
                        }
                        if (arg3.Emote.ToString().Contains("3"))
                        {
                            Volej(arg3.UserId, pingy.freehry, 789825600340623381, "freehry", arg3.MessageId);
                        }
                        if (arg3.Emote.ToString().Contains("4"))
                        {
                            Volej(arg3.UserId, pingy.politika, 825056360436858880, "politika", arg3.MessageId);
                        }
                        if (arg3.Emote.ToString().Contains("5"))
                        {
                            Volej(arg3.UserId, pingy.pocasi, 851038798578057247, "pocasi", arg3.MessageId);
                        }
                        await log.SendMessageAsync("Ping role - " + arg3.User);
                    }
                }
            }
        }
    }

#pragma warning disable IDE1006 // Naming Styles

    public class prom
    {
        public ObjectId _id { get; set; }
        public ulong pocitani { get; set; }
    }

    public class Rootobject
    {
        public ObjectId _id { get; set; }
        public int zpravy { get; set; }
        public DateTime timer2 { get; set; }
        public string uzivatelid { get; set; }
    }

#pragma warning restore IDE1006 // Naming Styles
}