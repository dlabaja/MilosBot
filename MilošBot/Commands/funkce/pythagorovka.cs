using Discord;
using Discord.Addons.Interactive;
using Discord.Commands;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Pythagorovka : InteractiveBase
    {
        public float a = 0;
        public float b = 0;
        public float c = 0;
        public float A = 0;
        public float B = 0;
        public float C = 0;
        public float va = 0;
        public float vb = 0;
        public float vc = 0;
        public float o = 0;
        public float S = 0;
        public float s = 0;
        public float mezi = 0;
        public IMessage response;

        [Command("troj", RunMode = RunMode.Async)]

        //a = strana
        //A = úhel
        //v = výška

        public async Task Coin()
        {
            var ovcak = new EmbedBuilder();
            ovcak.WithTitle("**Milošův trojúhelník**");
            ovcak.WithDescription("*Legenda*\n**a, b, c** = strana\n**A, B, C** = úhel\n**va, vb, vc** = výška");

            await Context.Channel.SendMessageAsync("", false, ovcak.Build());

            await ReplyAsync("Zadejte první údaj");
            response = await NextMessageAsync();
            //první
            if (response.Content.Contains("a=") || response.Content.Contains("b=") || response.Content.Contains("c=") || response.Content.Contains("A=") || response.Content.Contains("B=") || response.Content.Contains("C=") || response.Content.Contains("va=") || response.Content.Contains("vb=") || response.Content.Contains("vc="))
            {
                if (response.Content.Contains("a="))
                {
                    string resp1 = response.ToString().Replace("a=", null);
                    Console.WriteLine(resp1);
                    float.TryParse(resp1, out a);
                }

                if (response.Content.Contains("b="))
                {
                    string resp1 = response.ToString().Replace("b=", null);
                    float.TryParse(resp1, out b);
                }

                if (response.Content.Contains("c="))
                {
                    string resp1 = response.ToString().Replace("c=", null);
                    float.TryParse(resp1, out c);
                }

                if (response.Content.Contains("A="))
                {
                    string resp1 = response.ToString().Replace("A=", null);
                    float.TryParse(resp1, out A);
                }

                if (response.Content.Contains("B="))
                {
                    string resp1 = response.ToString().Replace("B=", null);
                    float.TryParse(resp1, out B);
                }

                if (response.Content.Contains("C="))
                {
                    string resp1 = response.ToString().Replace("C=", null);
                    float.TryParse(resp1, out C);
                }

                if (response.Content.Contains("va="))
                {
                    string resp1 = response.ToString().Replace("va=", null);
                    float.TryParse(resp1, out va);
                }

                if (response.Content.Contains("vb="))
                {
                    string resp1 = response.ToString().Replace("vb=", null);
                    float.TryParse(resp1, out vb);
                }

                if (response.Content.Contains("vc="))
                {
                    string resp1 = response.ToString().Replace("vc=", null);
                    float.TryParse(resp1, out vc);
                }
            }
            else
            {
                await ReplyAsync("Číslo je ve špatném formátu, nedovedu to spočítat :(");
                return;
            }

            await ReplyAsync("Zadejte druhý údaj");
            response = await NextMessageAsync();

            if (response.Content.Contains("a=") || response.Content.Contains("b=") || response.Content.Contains("c=") || response.Content.Contains("A=") || response.Content.Contains("B=") || response.Content.Contains("C=") || response.Content.Contains("va=") || response.Content.Contains("vb=") || response.Content.Contains("vc="))
            {
                if (response.Content.Contains("a="))
                {
                    string resp1 = response.ToString().Replace("a=", null);
                    float.TryParse(resp1, out a);
                }

                if (response.Content.Contains("b="))
                {
                    string resp1 = response.ToString().Replace("b=", null);
                    float.TryParse(resp1, out b);
                }

                if (response.Content.Contains("c="))
                {
                    string resp1 = response.ToString().Replace("c=", null);
                    float.TryParse(resp1, out c);
                }

                if (response.Content.Contains("A="))
                {
                    string resp1 = response.ToString().Replace("A=", null);
                    float.TryParse(resp1, out A);
                }

                if (response.Content.Contains("B="))
                {
                    string resp1 = response.ToString().Replace("B=", null);
                    float.TryParse(resp1, out B);
                }

                if (response.Content.Contains("C="))
                {
                    string resp1 = response.ToString().Replace("C=", null);
                    float.TryParse(resp1, out C);
                }

                if (response.Content.Contains("va="))
                {
                    string resp1 = response.ToString().Replace("va=", null);
                    float.TryParse(resp1, out va);
                }

                if (response.Content.Contains("vb="))
                {
                    string resp1 = response.ToString().Replace("vb=", null);
                    float.TryParse(resp1, out vb);
                }

                if (response.Content.Contains("vc="))
                {
                    string resp1 = response.ToString().Replace("vc=", null);
                    float.TryParse(resp1, out vc);
                }
            }
            else
            {
                await ReplyAsync("Číslo je ve špatném formátu, nedovedu to spočítat :(");
                return;
            }

            await ReplyAsync("Zadejte třetí údaj");
            response = await NextMessageAsync();

            if (response.Content.Contains("a=") || response.Content.Contains("b=") || response.Content.Contains("c=") || response.Content.Contains("A=") || response.Content.Contains("B=") || response.Content.Contains("C=") || response.Content.Contains("va=") || response.Content.Contains("vb=") || response.Content.Contains("vc="))
            {
                if (response.Content.Contains("a="))
                {
                    string resp1 = response.ToString().Replace("a=", null);
                    float.TryParse(resp1, out a);
                }

                if (response.Content.Contains("b="))
                {
                    string resp1 = response.ToString().Replace("b=", null);
                    float.TryParse(resp1, out b);
                }

                if (response.Content.Contains("c="))
                {
                    string resp1 = response.ToString().Replace("c=", null);
                    float.TryParse(resp1, out c);
                }

                if (response.Content.Contains("A="))
                {
                    string resp1 = response.ToString().Replace("A=", null);
                    float.TryParse(resp1, out A);
                }

                if (response.Content.Contains("B="))
                {
                    string resp1 = response.ToString().Replace("B=", null);
                    float.TryParse(resp1, out B);
                }

                if (response.Content.Contains("C="))
                {
                    string resp1 = response.ToString().Replace("C=", null);
                    float.TryParse(resp1, out C);
                }

                if (response.Content.Contains("va="))
                {
                    string resp1 = response.ToString().Replace("va=", null);
                    float.TryParse(resp1, out va);
                }

                if (response.Content.Contains("vb="))
                {
                    string resp1 = response.ToString().Replace("vb=", null);
                    float.TryParse(resp1, out vb);
                }

                if (response.Content.Contains("vc="))
                {
                    string resp1 = response.ToString().Replace("vc=", null);
                    float.TryParse(resp1, out vc);
                }
            }
            else
            {
                await ReplyAsync("Číslo je ve špatném formátu, nedovedu to spočítat :(");
                return;
            }

            if (a != 0 && b != 0 && c != 0)
            {
                o = a + b + c;
                s = o / 2;
                mezi = s * (s - a) * (s - b) * (s - c);
                S = (float)Math.Sqrt(mezi);
                va = (2 * S) / a;
                vb = (2 * S) / b;
                vc = (2 * S) / c;

                float meziuhel1a = (b * b + c * c - a * a) / (2 * b * c);

                A = (float)Math.Acos(meziuhel1a);
                A = (float)(A * (180 / Math.PI));
                A = (float)Math.Round(A, 4);

                float meziuhel2b = (a * a + c * c - b * b) / (2 * a * c);

                B = (float)Math.Acos(meziuhel2b);
                B = (float)(B * (180 / Math.PI));
                B = (float)Math.Round(B, 4);

                C = 180 - A - B;

                var theString = A.ToString();
                var aStringBuilder = new StringBuilder(theString);
                var theStringb = B.ToString();
                var bStringBuilder = new StringBuilder(theStringb);
                var theStringc = C.ToString();
                var cStringBuilder = new StringBuilder(theStringc);

                //A
                if (A.ToString().Length == 7)
                {
                    aStringBuilder.Remove(2, 5);

                    theString = aStringBuilder.ToString();
                }
                if (A.ToString().Length == 8)
                {
                    aStringBuilder.Remove(3, 5);

                    theString = aStringBuilder.ToString();
                }
                if (A.ToString().Length == 6)
                {
                    aStringBuilder.Remove(1, 5);

                    theString = aStringBuilder.ToString();
                }

                //B
                if (B.ToString().Length == 7)
                {
                    bStringBuilder.Remove(2, 5);

                    theStringb = bStringBuilder.ToString();
                }
                if (B.ToString().Length == 8)
                {
                    bStringBuilder.Remove(3, 5);

                    theStringb = bStringBuilder.ToString();
                }
                if (B.ToString().Length == 6)
                {
                    bStringBuilder.Remove(1, 5);

                    theStringb = bStringBuilder.ToString();
                }

                //C
                if (C.ToString().Length == 7)
                {
                    cStringBuilder.Remove(2, 5);

                    theStringc = cStringBuilder.ToString();
                }
                if (C.ToString().Length == 8)
                {
                    cStringBuilder.Remove(3, 5);

                    theStringc = cStringBuilder.ToString();
                }
                if (C.ToString().Length == 6)
                {
                    cStringBuilder.Remove(1, 5);

                    theStringc = cStringBuilder.ToString();
                }

                var end = new EmbedBuilder();
                end.WithTitle("**Trojúhelník je spočítaný**");
                end.WithDescription("**Strana a:** " + a + "\n**Strana b: **" + b + "\n**Strana c: **" + c + "\n**Obvod:    **" + o + "\n**Obsah:    **" + S + "\n**Výška a:  **" + va + "\n**Výška b:  **" + vb + "\n**Výška c:  **" + vc + "\n**Úhel α:   **" + aStringBuilder + "\n**Úhel β:   **" + bStringBuilder + "\n**Úhel γ:   **" + C);
                end.WithColor(Color.Red);
                end.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("MilošBot - Vaše kalkulačka k testům z matiky");
                });
                await Context.Channel.SendMessageAsync("", false, end.Build());
            }

            /**/

            //pythagorovka
            /*if (a > b && a > c)
            {
                obsah = (v * a) / 2;
                Console.WriteLine("Přepona je " + a + "(a)");
                double veta = (b * b) + (c * c);
                if (veta == a * a)
                {
                    Console.WriteLine("Trojúhelník je pravoúhlý");
                }
                else
                {
                    Console.WriteLine("Trojúhelník není pravoúhlý");
                }
            }
            if (b > a && b > c)
            {
                obsah = (v * a) / 2;
                Console.WriteLine("Přepona je " + b + "(b)");
                double veta = a * a + c * c;
                if (veta == b * b)
                {
                    Console.WriteLine("Trojúhelník je pravoúhlý");
                }
                else
                {
                    Console.WriteLine("Trojúhelník není pravoúhlý");
                }
            }
            if (c > b && c > a)
            {
                double obsah1 = v * a;
                obsah = obsah1 / 2;
                Console.WriteLine("Přepona je " + c + "(c)");
                double veta = b * b + a * a;
                if (veta == c * c)
                {
                    Console.WriteLine("Trojúhelník je pravoúhlý");
                }
                else
                {
                    Console.WriteLine("Trojúhelník není pravoúhlý");
                }
            }
            else
            {
                obsah = (v * a) / 2;
                Console.WriteLine("Trojúhelník je rovnoběžný");
            }
        }
        await ReplyAsync("Možná je to tou becherovkou, ale v tom co jste zadali nevidím číslo");
    }
    else
    {
        await ReplyAsync("Možná je to tou becherovkou, ale v tom co jste zadali nevidím číslo");
    }

    /*
        Promenne trojuh = new Promenne();
        Console.WriteLine("Zadejte stranu a");
        a = double.Parse(Console.ReadLine()); ;
        Console.WriteLine("Zadejte stranu b");
        b = double.Parse(Console.ReadLine()); ;
        Console.WriteLine("Zadejte stranu c");
        c = double.Parse(Console.ReadLine()); ;
        obvod = a + b + c;

        p = (a + b + c) / 2;
        double mezi = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        v = (2 / a) * mezi;
        v = Math.Round(v, 3);

        if (a > b && a > c)
        {
            obsah = (v * a) / 2;
            Console.WriteLine("Přepona je " + a + "(a)");
            double veta = (b * b) + (c * c);
            if (veta == a * a)
            {
                Console.WriteLine("Trojúhelník je pravoúhlý");
            }
            else
            {
                Console.WriteLine("Trojúhelník není pravoúhlý");
            }
        }
        if (b > a && b > c)
        {
            obsah = (v * a) / 2;
            Console.WriteLine("Přepona je " + b + "(b)");
            double veta = a * a + c * c;
            if (veta == b * b)
            {
                Console.WriteLine("Trojúhelník je pravoúhlý");
            }
            else
            {
                Console.WriteLine("Trojúhelník není pravoúhlý");
            }
        }
        if (c > b && c > a)
        {
            double obsah1 = v * a;
            obsah = obsah1 / 2;
            Console.WriteLine("Přepona je " + c + "(c)");
            double veta = b * b + a * a;
            if (veta == c * c)
            {
                Console.WriteLine("Trojúhelník je pravoúhlý");
            }
            else
            {
                Console.WriteLine("Trojúhelník není pravoúhlý");
            }
        }
        else
        {
            obsah = (v * a) / 2;
            Console.WriteLine("Trojúhelník je rovnoběžný");
        }

        double vk = obsah / p;
        double nasobek = a * b * c;
        double nas2 = 4 * p * vk;
        double ok = nasobek / nas2;

        Console.WriteLine("Obvod je " + obvod + " cm");
        Console.WriteLine("Obsah je " + obsah + " cm2");
        Console.WriteLine("Výška od přepony je " + v + " cm\nPoloměr kružnice vepsané je " + vk + " cm");
        Console.WriteLine("Poloměr opsané kružnice je " + ok + "cm");
        goto start1;*/
        }
    }
}