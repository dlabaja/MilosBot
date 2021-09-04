using Discord;
using Discord.Addons.Interactive;
using Discord.Commands;
using Discord.WebSocket;
using MilošBot.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot
{
    public class Zoford12Module : InteractiveBase
    {
        public static readonly HashSet<ulong> Zoford12Id =new HashSet<ulong>() { 818819044685643826, 732858763186536458, 395315108785553428 , 550000821471805440 };
        ulong id;

        [Command("ChciNaDbl", true)]
        public async Task ChciNaDblAsync()
        {
            if (Context.Guild.Channels.FirstOrDefault(x => x.Name == Context.User.Username) is object)
            {
                await Context.User.TrySendMessageAsync(out var _, "Už probýhá ověření");
                return;
            }
            id =Context.Guild.Id;
            var ch = await Context.Guild.CreateTextChannelAsync(Context.User.Username, ConfigureChannel);

            await ch.AddPermissionOverwriteAsync(Context.User, new OverwritePermissions(viewChannel: PermValue.Allow, readMessageHistory: PermValue.Allow, sendMessages: PermValue.Allow));
            await ch.AddPermissionOverwriteAsync(Context.Client.CurrentUser, new OverwritePermissions(viewChannel: PermValue.Allow, readMessageHistory: PermValue.Allow, sendMessages: PermValue.Allow));
            await ch.SendMessageAsync(@$"Ještě jednou ahoj {Context.User.Mention},
jak již bylo před tím zmíněno tak dostaneš několik otázek na které bueš muset odpovědět. Otázk se ti zobrazí po zadání `.otázky`
Nezapoměn strávně dodržovat velké a malé písmenka, a pokud dáš mezi 2 slova víc jak 1 mezeru tak to taky neuznám.");
        }

        [Command("otázky", true)]
        public async Task OtazkyAsync()
        {
            for (int i = 0; i < Quest.Count; i++)
            {
                var againt = true;
                var ans = await SendQuestionAsync(i, Context.Channel);
                while (againt)
                {
                    var msg = await NextMessageAsync();
                    if (msg is null)
                        continue;
                    if (ans.Equals(msg.Content))
                    {
                        againt = false;
                        //await ReplyAsync("Výborně, jdeme na další otázku.");
                    }
                    else
                    {
                        await ReplyAsync("Tohle není správná odpověď.");
                    }
                }
            }
            if(Context.User is IGuildUser user)
            {
                await ReplyAsync("Nastala vnitřní chyba sistému, zkuste to za chvíli znovu.");
                await Task.Delay(5000);
                if (Zoford12Id.Contains(user.Id))
                    await user.KickAsync();
            }
        }

        async Task<string> SendQuestionAsync(int i, ISocketMessageChannel ch)
        {
            await ch.SendMessageAsync($"Otázka č. {i + 1:00}");
            var q=  Quest[i](ch);
            await q.Item1;
            return q.Item2;
        }

        void ConfigureChannel(TextChannelProperties prop)
        {
            prop.CategoryId = 738310139488108594;
            prop.IsNsfw = false;
            prop.SlowModeInterval = 15;
            prop.Topic = "Speciální došasný kanál na ověření 2.0";
            var deny = PermValue.Deny;
            prop.PermissionOverwrites = new Overwrite[]
            {
                new Overwrite(id, PermissionTarget.Role, new OverwritePermissions(deny, deny, deny, deny, deny, deny, deny, deny, deny, deny, deny, deny, deny, deny, deny, deny, deny, deny, deny, deny, deny, deny)),
            };
        }

        static readonly Random rng = new Random();
        static List<Func<ISocketMessageChannel, (Task, string)>> Quest = new List<Func<ISocketMessageChannel, (Task, string)>>()
        {
            x =>
            {
                int i = rng.Next(100), i2 = rng.Next(100), i3 = rng.Next(100);
                return (x.SendMessageAsync($"Kolik je: {i}+{i2}*{i3}"), (i + i2 * i3).ToString());
            },
            x =>
            {
                var ans = new[] { ("ČŘ", "Praha"), ("Slovenska", "Bratislava"), ("Japonska", "Tokio"), ("Indonésie", "Jakarta"), ("Mexika", "Ciudad de México"), ("Martinik", "Fort-de-France") }.GetRandom();
                return (x.SendMessageAsync($"Hlavní město {ans.Item1} je?"), ans.Item2);
            },
            x => (x.SendMessageAsync($"Které slovo obsahuje gramatickou chybu? syn, plynout, sýr, syrový, sychravý, usychat, sýkora, sýček, sysel, syčet, sypa, pýcha, pytel, pysk, netopýr," +
                $" slepýš, pyl, nachomýtnout se, kopyto, klopýtat, třpytit se, zpytovat, pykat, pýr, pýřit se, čepýřit se,brzy, jazyk, Ruzyně,být, bydlit, obyvatel, lýko, byt, příbytek, nábytek, dobytek," +
                $" obyčej, bystrý, bylina, kobyla, býk, Přibyslav,slyšet, mlýn, blýskat se, polykat, plýtvat, vzlykat, lysý, lýtko, lyže, pelyněk, plyš, nazývat, my, mýt, myslit," +
                $" mýlit se, hmyz, myš, hlemýžď, Lytomišl, mýtit, zamykat, smýkat, dmýchat, chmýří, sytý"), "Lytomišl"),
            x => (x.SendMessageAsync($"Myslím si náhodné číslomezi 0 a 10."), rng.Next(10).ToString()),
            x => (x.SendMessageAsync($"V kolik hodin byla napsaná tahle zpráva?."), $"{DateTime.Now.Hour}:{DateTime.Now.Minute}"),
            x => (x.SendMessageAsync($"Na jaké pozici je Feynmanův bod?"), "762"),
            x => (x.SendMessageAsync($"V jaký datum byla napsaná tahle zpráva?."), $"{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}"),
            x => (x.SendMessageAsync($"Zadejprvní 3 čísla Ludolfova čísla."), "3.14"),
            x => (x.SendMessageAsync($"Jak se jmenuje tenhle server?"), "DBL Gaming"),
            x =>
            {
                var ans = new[] { ("ČŘ", "Praha"), ("Slovenska", "Bratislava"), ("Japonska", "Tokio"), ("Indonésie", "Jakarta"), ("Mexika", "Ciudad de México"), ("Martinik", "Fort-de-France") }.GetRandom();
                return (x.SendMessageAsync($"Hlavní město {ans.Item1} je?"), ans.Item2);
            },
            x => (x.SendMessageAsync($"Nejjižnější město ČR je?"), "Vyšší Brod"),
            x =>
            {
                int i = rng.Next(1, 16);
                return (x.SendMessageAsync($" kolik je: {i}! ?"), factorial(i).ToString());
            },
            x => (x.SendMessageAsync($"Jak se jmenuje tenhle server?"), "dbl gaming"),
            x =>
            {
                var pi = "141592653589793238462643383279502884197169399375105820974944592307816406286208998628034825342117067982148086513282306647";
                int i = rng.Next(5, pi.Length);
                return (x.SendMessageAsync($"Napiš prvních {i} desetiných míst pí?"), pi.Substring(0, i));
            },
            x => (x.SendMessageAsync("Jak se jmenovalo letiště Václava Havla?"), "Ruzyně"),
            x => (x.SendMessageAsync("Co je nejtlustší postava v tf2?"), "Heavy"),
            x => (x.SendMessageAsync("V jakém programovacím jazyku je napsán MineCraft?"), "Java"),
            x => (x.SendMessageAsync("Kolik hlásek má slovní spojení `DBL gaming`?"), "9"),
        };
        static long factorial(long x)
        {
            int result = 1;
            for (int i = 2; i <= x; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
