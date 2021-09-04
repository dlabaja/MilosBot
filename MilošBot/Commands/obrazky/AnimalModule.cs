using Discord;
using Discord.Commands;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MilošBot.Commands.obrazky
{
    public class AnimalModule : ModuleBase<SocketCommandContext>
    {
        [Command("shiba")]
        [Summary("Pošle obrázek Shiba Inu.")]
        public async Task ShibaAsync()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://shibe.online/api/shibes");
            if (!response.IsSuccessStatusCode)
            {
                await ReplyAsync("Neco se pokazilo a tak ti némůžeme poskytnout obrázek Shibi :(.");
            }
            var urls = JsonSerializer.Deserialize<string[]>(await response.Content.ReadAsStringAsync());
            var eb = new EmbedBuilder()
            {
                Title = "Zde je obrázek pejska",
                ImageUrl = urls[0]
            }.WithFooter("Zvířata z Milošovy zoo.");
            await ReplyAsync(embed: eb.Build());
        }
    }
}
