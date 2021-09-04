using Discord.Commands;
using Discord.WebSocket;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Obama : ModuleBase<SocketCommandContext>
    {
        public static List<DateTimeOffset> Timer = new List<DateTimeOffset>();
        public static List<ulong> User = new List<ulong>();

        [Command("obama")]
        [Summary("Ó mocný Obamo, promluv")]
        public async Task ObamaAsync([Remainder] string text = null)
        {
            var User1 = Context.User as SocketGuildUser;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Volič");
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Starosta");
            var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");

            if (User1.Roles.Contains(role) || User1.Roles.Contains(role2) || User1.Roles.Contains(role3))
            {
                if (User.Contains(Context.User.Id))
                {
                    //If they have used this command before, take the time the user last did something, add 5 seconds, and see if it's greater than this very moment.
                    if (Timer[User.IndexOf(Context.User.Id)].AddSeconds(15) >= DateTimeOffset.Now)
                    {
                        //If enough time hasn't passed, reply letting them know how much longer they need to wait, and end the code.
                        int secondsLeft = (int)(Timer[User.IndexOf(Context.User.Id)].AddSeconds(15) - DateTimeOffset.Now).TotalSeconds;
                        await ReplyAsync($"Zadrž, přece mě nechceš usmažit! Počkej ještě {secondsLeft} sekund");
                        return;
                    }
                    else
                    {
                        //If enough time has passed, set the time for the user to right now.
                        Timer[User.IndexOf(Context.User.Id)] = DateTimeOffset.Now;
                    }
                }
                else
                {
                    //If they've never used this command before, add their username and when they just used this command.
                    User.Add(Context.User.Id);
                    Timer.Add(DateTimeOffset.Now);
                }
                var pismenka = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                if (text == null || text.Length > 240 || text.IndexOfAny(pismenka.ToCharArray()) == -1)
                {
                    await Context.Channel.SendFileAsync(Data.Pictrazky("missingText.mp4"));
                    return;
                }

                try
                {
                    var zprava = await Context.Channel.SendMessageAsync("Zpracovávám požadavek, dej mi chvilku (trvá mi to lul)");
                    using (Context.Channel.EnterTypingState())
                    {
                        //var driver = new ChromeDriver(Data.Pictrazky(""));
                        //if (Program.umisteni)
                        ChromeDriver driver = new ChromeDriver();

                        driver.Navigate().GoToUrl("http://talkobamato.me/");
                        IWebElement e;

                        e = driver.FindElement(By.Name("input_text"));
                        e.Clear();
                        e.SendKeys(text);

                        e = driver.FindElement(By.Id("talk_button"));
                        e.Click();

                        var i = 0;
                        label1:
                        try
                        {
                            Console.WriteLine("V obamově loopu" + i);
                            driver.FindElement(By.TagName("source")).GetAttribute("src");
                        }
                        catch
                        {
                            Thread.Sleep(1000);
                            i++;
                            if (i > 20)
                            {
                                await zprava.ModifyAsync(x => x.Content = "Požadavek trval moc dlouho... zkus to znovu.");
                                Console.WriteLine("konec obamy");
                                return;
                            }
                            goto label1;
                        }

                        var ms = new MemoryStream();

                        await zprava.ModifyAsync(x => x.Content = driver.FindElement(By.TagName("source")).GetAttribute("src"));
                        driver.Close();
                    }
                }
                catch (Exception e) { Console.WriteLine(e); }
            }
        }
    }
}
