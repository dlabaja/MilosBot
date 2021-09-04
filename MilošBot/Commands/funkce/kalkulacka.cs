using Discord;
using Discord.Addons.Interactive;
using Discord.Rest;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace MilošBot.Commands
{
    public class SampleModule : InteractiveBase
    {
        public static RestUserMessage kalkul;

        public Int16 tim = 0;
        private static Timer aTimer;
        public IMessage response;
        public Int16 operace;

        public DiscordSocketClient client;
        public IUser clovek;
        public float a;
        public float b;
        public bool pass = false;
        public float vysledek;

        // [Command("math", RunMode = RunMode.Async)]

        public async Task Test_NextMessageAsync()
        {
            var User1 = Context.User as SocketGuildUser;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Volič");
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Starosta");
            var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");
            if (Context.Channel.Id == 803526206166401064)
            {
                if (User1.Roles.Contains(role) || User1.Roles.Contains(role2) || User1.Roles.Contains(role3))
                {
                    /* var clovek = Context.Message.Author;

                     var ovcak = new EmbedBuilder();
                     ovcak.WithTitle("");

                     ovcak.WithFooter(footer =>
                     {
                         footer
                         .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                         .WithText("Milošova Kalkulačka");
                     });*/
                    var origo = await Context.Channel.SendMessageAsync("**Zadejte pod tento příkaz číslo**");

                    response = await NextMessageAsync();
                    Emoji plus = new Emoji("➕");
                    Emoji minus = new Emoji("➖");
                    Emoji krat = new Emoji("✖️");
                    Emoji deleno = new Emoji("➗");

                    if (response != null)
                    {
                        Console.WriteLine(response.ToString());
                        if (float.TryParse(response.Content, out a))
                        {
                            await origo.DeleteAsync();
                            /* var emb = new EmbedBuilder();
                             ovcak.WithTitle(a.ToString());

                             ovcak.WithFooter(footer =>
                             {
                                 footer
                                 .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                                 .WithText("Milošova Kalkulačka");
                             });*/
                            var kalk = await Context.Channel.SendMessageAsync("**" + a + "**");
                            kalkul = kalk;
                            await response.DeleteAsync();
                            await kalk.AddReactionAsync(plus);
                            await kalk.AddReactionAsync(minus);
                            await kalk.AddReactionAsync(krat);
                            await kalk.AddReactionAsync(deleno);

                            aTimer = new Timer(1000); // Set up the timer for 1 seconds
                            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                            aTimer.Start();
                        }
                        else if (!float.TryParse(response.Content, out a))
                        {
                            await Context.Channel.SendMessageAsync("To co jste zadali není číslo!");
                        }
                    }
                    else
                        await ReplyAsync("Nestihl jsi odpovědět :(");
                }
                else
                {
                    await ReplyAsync("O co se to jako snažíš? Tento příkaz je dostupný od levelu 3!");
                    return;
                }
            }
            else
            {
                await ReplyAsync("Jsi ve špatném kanálu - běž radši do #📐kalkulačka");
            }
        }

        //Po prvním napsání čísla

        public async void OnTimedEvent(object source, ElapsedEventArgs e)
        {
        label1:

            if (pass == true)
            {
                aTimer = new Timer(1000); // Set up the timer for 1 seconds
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                pass = false;
                aTimer.Start();
            }

            var clovek = Context.Message.Author;
            RestUserMessage kalk;

            Emoji plus = new Emoji("➕");
            Emoji minus = new Emoji("➖");
            Emoji krat = new Emoji("✖️");
            Emoji deleno = new Emoji("➗");

            var reactedUsers = kalkul.GetReactionUsersAsync(plus, 2);
            var reactedminus = kalkul.GetReactionUsersAsync(minus, 2);
            var reactedkrat = kalkul.GetReactionUsersAsync(krat, 2);
            var reacteddeleno = kalkul.GetReactionUsersAsync(deleno, 2);

            await foreach (IReadOnlyCollection<IUser> clo in reactedUsers)
            {
                foreach (var item in clo)
                {
                    if (item.Id == clovek.Id)
                    {
                        aTimer.Stop();
                        operace = 1;
                        response = await NextMessageAsync();
                    }
                    else
                    {
                        tim++;
                    }
                }
            }
            await foreach (IReadOnlyCollection<IUser> clo in reactedminus)
            {
                foreach (var item in clo)
                {
                    if (item.Id == clovek.Id)
                    {
                        aTimer.Stop();
                        operace = 2;
                        response = await NextMessageAsync();
                    }
                    else
                    {
                        tim++;
                    }
                }
            }
            await foreach (IReadOnlyCollection<IUser> clo in reactedkrat)
            {
                foreach (var item in clo)
                {
                    if (item.Id == clovek.Id)
                    {
                        aTimer.Stop();
                        operace = 3;
                        response = await NextMessageAsync();
                    }
                    else
                    {
                        tim++;
                    }
                }
            }
            await foreach (IReadOnlyCollection<IUser> clo in reacteddeleno)
            {
                foreach (var item in clo)
                {
                    if (item.Id == clovek.Id)
                    {
                        aTimer.Stop();
                        operace = 4;
                        response = await NextMessageAsync();
                    }
                    else
                    {
                        tim++;
                    }
                }
            }

            if (tim <= 70)
            {
                if (response != null)
                {
                    if (operace == 1)
                    {
                        //Plus
                        if (float.TryParse(response.Content, out b))
                        {
                            using (Context.Channel.EnterTypingState())
                            {
                                await kalkul.DeleteAsync();

                                vysledek = a + b;
                                /* var ovcak = new EmbedBuilder();
                                 ovcak.WithTitle(vysledek.ToString());

                                 ovcak.WithFooter(footer =>
                                 {
                                     footer
                                     .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                                     .WithText("Milošova Kalkulačka");
                                 });*/
                            }
                            Console.WriteLine("haha");
                            kalkul = await Context.Channel.SendMessageAsync("**" + vysledek + "**");
                            Console.WriteLine("lul");
                            //await response.DeleteAsync();
                            Console.WriteLine("emoty");
                            kalk = kalkul;
                            await kalk.AddReactionAsync(plus);
                            await kalk.AddReactionAsync(minus);
                            await kalk.AddReactionAsync(krat);
                            await kalk.AddReactionAsync(deleno);
                            kalk = null;
                            Console.WriteLine("passed");
                            tim = 0;
                            a = vysledek;

                            Console.WriteLine(a);
                            pass = true;
                            operace = 0;
                            goto label1;
                        }
                        else if (!float.TryParse(response.Content, out a))
                        {
                            await Context.Channel.SendMessageAsync("To co jste zadali není číslo!");
                        }
                        else
                            await ReplyAsync("Nestihl jsi odpovědět :(");
                    }

                    if (operace == 2)
                    {
                        //Minus
                        if (float.TryParse(response.Content, out b))
                        {
                            using (Context.Channel.EnterTypingState())
                            {
                                await kalkul.DeleteAsync();

                                vysledek = a - b;
                                /* var ovcak = new EmbedBuilder();
                                 ovcak.WithTitle(vysledek.ToString());

                                 ovcak.WithFooter(footer =>
                                 {
                                     footer
                                     .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                                     .WithText("Milošova Kalkulačka");
                                 });*/
                            }
                            Console.WriteLine("haha");
                            kalkul = await Context.Channel.SendMessageAsync("**" + vysledek + "**");
                            Console.WriteLine("lul");
                            //await response.DeleteAsync();
                            Console.WriteLine("emoty");
                            kalk = kalkul;
                            await kalk.AddReactionAsync(plus);
                            await kalk.AddReactionAsync(minus);
                            await kalk.AddReactionAsync(krat);
                            await kalk.AddReactionAsync(deleno);
                            kalk = null;
                            Console.WriteLine("passed");
                            tim = 0;
                            a = vysledek;

                            Console.WriteLine(a);
                            pass = true;
                            operace = 0;
                            goto label1;
                        }
                        else if (!float.TryParse(response.Content, out a))
                        {
                            await Context.Channel.SendMessageAsync("To co jste zadali není číslo!");
                        }
                        else
                            await ReplyAsync("Nestihl jsi odpovědět :(");
                    }
                    if (operace == 3)
                    {
                        //Minus
                        if (float.TryParse(response.Content, out b))
                        {
                            using (Context.Channel.EnterTypingState())
                            {
                                await kalkul.DeleteAsync();

                                vysledek = a * b;
                                /* var ovcak = new EmbedBuilder();
                                 ovcak.WithTitle(vysledek.ToString());

                                 ovcak.WithFooter(footer =>
                                 {
                                     footer
                                     .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                                     .WithText("Milošova Kalkulačka");
                                 });*/
                            }
                            Console.WriteLine("haha");
                            kalkul = await Context.Channel.SendMessageAsync("**" + vysledek + "**");
                            Console.WriteLine("lul");
                            //await response.DeleteAsync();
                            Console.WriteLine("emoty");
                            kalk = kalkul;
                            await kalk.AddReactionAsync(plus);
                            await kalk.AddReactionAsync(minus);
                            await kalk.AddReactionAsync(krat);
                            await kalk.AddReactionAsync(deleno);
                            kalk = null;
                            Console.WriteLine("passed");
                            tim = 0;
                            a = vysledek;

                            Console.WriteLine(a);
                            pass = true;
                            operace = 0;
                            goto label1;
                        }
                        else if (!float.TryParse(response.Content, out a))
                        {
                            await Context.Channel.SendMessageAsync("To co jste zadali není číslo!");
                        }
                        else
                            await ReplyAsync("Nestihl jsi odpovědět :(");
                    }
                    if (operace == 4)
                    {
                        //Minus
                        if (float.TryParse(response.Content, out b))
                        {
                            Console.WriteLine("hýr");
                            using (Context.Channel.EnterTypingState())
                            {
                                await kalkul.DeleteAsync();

                                vysledek = a / b;
                                /* var ovcak = new EmbedBuilder();
                                 ovcak.WithTitle(vysledek.ToString());

                                 ovcak.WithFooter(footer =>
                                 {
                                     footer
                                     .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                                     .WithText("Milošova Kalkulačka");
                                 });*/
                            }
                            Console.WriteLine("haha");
                            kalkul = await Context.Channel.SendMessageAsync("**" + vysledek + "**");
                            Console.WriteLine("lul");
                            //await response.DeleteAsync();
                            Console.WriteLine("emoty");
                            kalk = kalkul;
                            await kalk.AddReactionAsync(plus);
                            await kalk.AddReactionAsync(minus);
                            await kalk.AddReactionAsync(krat);
                            await kalk.AddReactionAsync(deleno);
                            kalk = null;
                            Console.WriteLine("passed");
                            tim = 0;
                            a = vysledek;

                            Console.WriteLine(a);
                            pass = true;
                            operace = 0;
                            goto label1;
                        }
                        else if (!float.TryParse(response.Content, out a))
                        {
                            await Context.Channel.SendMessageAsync("To co jste zadali není číslo!");
                        }
                        else
                            await ReplyAsync("Nestihl jsi odpovědět :(");
                    }

                    /*catch (WebException ex)
                    {
                        if (ex.Status == WebExceptionStatus.ProtocolError)
                        {
                            HttpWebResponse response = ex.Response as HttpWebResponse;
                            if (response != null)
                            {
                                if ((int)response.StatusCode == 404) // Not Found
                                {
                                    pass = true;
                                    tim = 0;
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("error");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    goto label1;
                                }
                            }
                        }
                    }*/
                }
            }
            else if (tim >= 71)
            {
                await ReplyAsync("Konec kalkulačky");
                aTimer.Stop();
                return;
            }
            else
            {
                tim++;
                Console.WriteLine("haha");
            }
        }
    }
}