using Discord;
using Discord.Commands;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MilošBot.Commands

{
    public class korfgdadsona : ModuleBase<SocketCommandContext>
    {
        [Command("bitcoin")]
        [Summary("Ukáže jak moc dropuje")]
        public async Task BitcoinAsync()
        {
            using var clientela = new HttpClient();
            using var clientela1 = new HttpClient();
            var ovcak6 = new EmbedBuilder();

            ovcak6.WithTitle("**Bitcoin vajrus**");
            ovcak6.WithThumbnailUrl("https://cdn.discordapp.com/attachments/790627506642354256/831594391474798622/Bez_nazvusdasdasdas.png");
            ovcak6.WithUrl("https://www.cnbc.com/2021/02/08/tesla-buys-1point5-billion-in-bitcoin.html");

            var json = await clientela.GetStringAsync("https://api.coindesk.com/v1/bpi/currentprice/CZK.json");
            bitcoin1 obj = JsonSerializer.Deserialize<bitcoin1>(json);
            var json1 = await clientela1.GetStringAsync("https://api.coindesk.com/v1/bpi/currentprice.json");
            euro obj1 = JsonSerializer.Deserialize<euro>(json1);

            ovcak6.WithColor(Color.Teal);

            ovcak6.AddField("**BITCOIN hodnota v dolarech**", obj.bpi.USD.rate + " USD", false);
            ovcak6.AddField("**BITCOIN hodnota v korunách**", obj.bpi.CZK.rate + " CZK", true);
            ovcak6.AddField("**BITCOIN hodnota v eurech**", obj1.bpi.EUR.rate + " EUR", false);
            ovcak6.AddField("**BITCOIN hodnota v librách**", obj1.bpi.GBP.rate + " GBR", true);

            ovcak6.WithImageUrl("https://cdn.discordapp.com/attachments/790627506642354256/831831227132280844/Bez_nazvuasdasdasd.png");
            ovcak6.WithCurrentTimestamp();

            ovcak6.WithFooter(footer =>
            {
                footer
                .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                .WithText("Data ze statistického úřadu které ukradl MilošBot");
            });
            await Context.Channel.SendMessageAsync(embed: ovcak6.Build());
        }

        [Command("kaurycoin")]
        [Alias("kauri", "kauricoin")]
        public async Task KauryCoinAsync()
        {
            var ovcak6 = new EmbedBuilder();

            ovcak6.WithTitle("**Kryptošlechta podvod**");
            ovcak6.WithThumbnailUrl("https://cdn.discordapp.com/attachments/790627506642354256/831611782313279588/Bez_nazvuads.png");
            ovcak6.WithUrl("https://www.vscr.cz/veznice-mirov/");

            ovcak6.WithColor(Color.Teal);

            ovcak6.AddField("**kauri coin \nhodnota v dolarech**", "podvod", true);
            ovcak6.AddField("**kauri coin \nhodnota v CZK**", "podvod", true);

            ovcak6.WithImageUrl("https://cdn.discordapp.com/attachments/790627506642354256/831611014810173450/Bez_nazvusdsadasdasd.png");
            ovcak6.WithCurrentTimestamp();

            ovcak6.WithFooter(footer =>
            {
                footer
                .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                .WithText("Data ze statistického úřadu které ukradl MilošBot");
            });
            await Context.Channel.SendMessageAsync(embed: ovcak6.Build());
        }
    }

#pragma warning disable IDE1006 // Naming Styles

    public class euro
    {
        public Time time { get; set; }
        public string disclaimer { get; set; }
        public string chartName { get; set; }
        public Bpi1 bpi { get; set; }
    }

    public class Time1
    {
        public string updated { get; set; }
        public DateTime updatedISO { get; set; }
        public string updateduk { get; set; }
    }

    public class Bpi1
    {
        public USD USD { get; set; }
        public GBP GBP { get; set; }
        public EUR EUR { get; set; }
    }

    public class USD1
    {
        public string code { get; set; }
        public string symbol { get; set; }
        public string rate { get; set; }
        public string description { get; set; }
        public float rate_float { get; set; }
    }

    public class GBP
    {
        public string code { get; set; }
        public string symbol { get; set; }
        public string rate { get; set; }
        public string description { get; set; }
        public float rate_float { get; set; }
    }

    public class EUR
    {
        public string code { get; set; }
        public string symbol { get; set; }
        public string rate { get; set; }
        public string description { get; set; }
        public float rate_float { get; set; }
    }

    //jinej

    public class bitcoin1
    {
        public Time time { get; set; }
        public string disclaimer { get; set; }
        public bitcoin bpi { get; set; }
    }

    public class Time
    {
        public string updated { get; set; }
        public DateTime updatedISO { get; set; }
        public string updateduk { get; set; }
    }

    public class bitcoin
    {
        public USD USD { get; set; }
        public CZK CZK { get; set; }
    }

    public class USD
    {
        public string code { get; set; }
        public string rate { get; set; }
        public string description { get; set; }
        public float rate_float { get; set; }
    }

    public class CZK
    {
        public string code { get; set; }
        public string rate { get; set; }
        public string description { get; set; }
        public float rate_float { get; set; }
    }
}