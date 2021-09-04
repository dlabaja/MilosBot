using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MilošBot.Commands

{
    public class kordadsona : ModuleBase<SocketCommandContext>
    {
        [Command("kovidstats")]
        [Alias("covid", "covidstats")]
        [Summary("Ukáže koronavajrus statistiky - nezapomeňte zadat zemi")]
        public async Task HelpEkonomikaAsync(string zeme = "sssr")
        {
            SocketTextChannel covid = Context.Client.GetChannel(778323831499784283) as SocketTextChannel;
            if (Context.Channel.Id != 778323831499784283)
            {
                await ReplyAsync("Nechceš příkaz radši použít v " + covid.Mention + "?");
                return;
            }
            zeme = zeme.ToLower();
            if (zeme == "cr" || zeme == "cz" || zeme == "čr")
            {
                using var clientela = new HttpClient();

                var json = await clientela.GetStringAsync("https://onemocneni-aktualne.mzcr.cz/api/v2/covid-19/zakladni-prehled.json");
                test52 obj = JsonSerializer.Deserialize<test52>(json);

                var ovcak6 = new EmbedBuilder();
                ovcak6.WithColor(Color.Teal);
                ovcak6.WithTitle("**Koronavajrus ratatatá**");
                ovcak6.AddField("**Datum**", obj.data[0].datum.ToString("MM/dd/yyyy"), true);
                ovcak6.AddField("**Testy celkem**", obj.data[0].provedene_testy_celkem, true);
                ovcak6.AddField("**Případy celkem**", obj.data[0].potvrzene_pripady_celkem, true);
                ovcak6.AddField("**Aktivní případy**", obj.data[0].aktivni_pripady, true);
                ovcak6.AddField("**Vyléčení**", obj.data[0].vyleceni, true);
                ovcak6.AddField("**Úmrtí**", obj.data[0].umrti, true);
                ovcak6.AddField("**Hospitalizovaní**", obj.data[0].aktualne_hospitalizovani, true);
                ovcak6.AddField("**Včera testů**", obj.data[0].provedene_testy_vcerejsi_den, true);
                ovcak6.AddField("**Včera případů**", obj.data[0].potvrzene_pripady_vcerejsi_den, true);
                ovcak6.AddField("**Případy dnes**", "Data budou zítra nejpozději kolem půl desáté...");
                ovcak6.WithImageUrl("https://cdn.discordapp.com/attachments/790627506642354256/831475643744649226/koovid.png");
                ovcak6.WithUrl("https://www.youtube.com/channel/UCLJUCkosOJod2VKJpsuZUFg");
                ovcak6.WithThumbnailUrl("https://cdn.pixabay.com/photo/2016/07/06/14/37/czech-republic-1500647_960_720.png");
                ovcak6.WithCurrentTimestamp();

                ovcak6.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Data ze statistického úřadu které ukradl MilošBot");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak6.Build());
            }
            if (zeme == "sk" || zeme == "sr")
            {
                using var clientela = new HttpClient();
                var ovcak6 = new EmbedBuilder();

                ovcak6.WithTitle("**Slovenskej vajrus ratatatatá**");
                ovcak6.WithThumbnailUrl("https://cdn.discordapp.com/attachments/790627506642354256/831541350579175454/Bez_nazvu.png");
                ovcak6.WithUrl("https://covid19-arcgeomkt.hub.arcgis.com/pages/gishub");

                var json = await clientela.GetStringAsync("https://api.apify.com/v2/key-value-stores/GlTLAdXAuOz6bLAIO/records/LATEST?disableRedirect=true");
                test53 obj = JsonSerializer.Deserialize<test53>(json);

                ovcak6.WithColor(Color.Teal);

                ovcak6.AddField("**PCR testy celkem**", obj.testedPCR, true);
                ovcak6.AddField("**Případy celkem**", obj.infected, true);
                ovcak6.AddField("**Úmrtí celkem**", obj.deceased, true);
                ovcak6.AddField("**Včera PCR testů**", obj.newTestedPCR, true);
                ovcak6.AddField("**Včera případů**", obj.newInfectedPCR, true);
                ovcak6.AddField("**Včera úmrtí**", obj.newDeceased, true);
                ovcak6.AddField("**První dávka**", obj.vacinatedFirstDose, true);
                ovcak6.AddField("**Druhá dávka**", obj.vacinatedSecondDose, true);
                ovcak6.AddField("**Datum**", obj.lastUpdatedAtApify.ToString("dd/MM/yyyy"), true);
                ovcak6.AddField("**První dávka včera**", obj.newVacinatedFirstDose, true);
                ovcak6.AddField("**Druhá dávka včera**", obj.newVacinatedSecondDose, true);
                ovcak6.AddField("**Hospitalizovaní**", obj.hospitalized, true);

                ovcak6.AddField("**Případy dnes**", "Data budou zítra kolem nejpozději půl desáté...");
                ovcak6.WithImageUrl("https://cdn.discordapp.com/attachments/790627506642354256/831543668724203570/sputnik.png");
                ovcak6.WithCurrentTimestamp();

                ovcak6.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Data ze statistického úřadu které ukradl MilošBot");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak6.Build());
            }
            if (zeme == "sssr" || zeme != "sk" && zeme != "cr" && zeme != "cz")
                await Context.Channel.SendMessageAsync("[.covid cz/sk]");
        }
    }

    public class test52
    {
        public DateTime modified { get; set; }
        public string source { get; set; }
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public DateTime datum { get; set; }
        public int provedene_testy_celkem { get; set; }
        public int potvrzene_pripady_celkem { get; set; }
        public int aktivni_pripady { get; set; }
        public int vyleceni { get; set; }
        public int umrti { get; set; }
        public int aktualne_hospitalizovani { get; set; }
        public int provedene_testy_vcerejsi_den { get; set; }
        public int potvrzene_pripady_vcerejsi_den { get; set; }
        public int potvrzene_pripady_dnesni_den { get; set; }
        public string provedene_testy_vcerejsi_den_datum { get; set; }
        public string potvrzene_pripady_vcerejsi_den_datum { get; set; }
        public string potvrzene_pripady_dnesni_den_datum { get; set; }
        public int provedene_antigenni_testy_celkem { get; set; }
        public int provedene_antigenni_testy_vcerejsi_den { get; set; }
        public string provedene_antigenni_testy_vcerejsi_den_datum { get; set; }
        public int vykazana_ockovani_celkem { get; set; }
        public int vykazana_ockovani_vcerejsi_den { get; set; }
        public string vykazana_ockovani_vcerejsi_den_datum { get; set; }
        public int potvrzene_pripady_65_celkem { get; set; }
        public int potvrzene_pripady_65_vcerejsi_den { get; set; }
        public string potvrzene_pripady_65_vcerejsi_den_datum { get; set; }
    }

    public class test53
    {
        public int tested { get; set; }
        public int infected { get; set; }
        public int deceased { get; set; }
        public int infectedPCR { get; set; }
        public int testedPCR { get; set; }
        public int newInfectedPCR { get; set; }
        public int newTestedPCR { get; set; }
        public int infectedAG { get; set; }
        public int testedAG { get; set; }
        public int newInfectedAG { get; set; }
        public int newTestedAG { get; set; }
        public int newDeceased { get; set; }
        public int vacinatedFirstDose { get; set; }
        public int newVacinatedFirstDose { get; set; }
        public int vacinatedSecondDose { get; set; }
        public int newVacinatedSecondDose { get; set; }
        public int hospitalized { get; set; }
        public int newHospitalized { get; set; }
        public Regionsdata[] regionsData { get; set; }
        public District[] districts { get; set; }
        public DateTime lastUpdatedAtSource { get; set; }
        public DateTime lastUpdatedAtApify { get; set; }
        public string readMe { get; set; }
    }

    public class Regionsdata
    {
        public string region { get; set; }
        public int newInfected { get; set; }
        public int totalInfected { get; set; }
    }

    public class District
    {
        public string town { get; set; }
        public int newInfected { get; set; }
        public int totalInfected { get; set; }
    }
}