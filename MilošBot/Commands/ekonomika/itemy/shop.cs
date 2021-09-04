using Discord;
using Discord.Addons.Interactive;
using Discord.Commands;
using System.Threading.Tasks;

namespace MilošBot.Commands.help
{
    public class Shop : InteractiveBase
    {
        [Command("shop")]
        [Summary("Zobrazí položky v shopu.")]
        public async Task ShopAsync()
        {
            Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");
            var ovcak1 = new EmbedBuilder();
            ovcak1.WithColor(Color.Blue);
            ovcak1.WithTitle("**SHOP**");
            ovcak1.WithDescription(@"**💳Kreditka💳** " + "\n 2 000" + agr + " [legální ruka]\n **pro koupi piš .1** \numožní ukládání do banky\n\n" +
                "**📜 Padělaná smlouva📜 ** \n 20 000" + agr + " [černá ruka]\n **pro koupi piš .2** \n zvyšuje výdělky na černén trhu\n\n" +
                "**🩳Červené trenky🩳** \n 20 000" + agr + " [banka] \n**pro koupi piš .3** \n bonusový item\n\n" +
                "**📢Přístup do reklam📢** \n 30 000" + agr + " [banka] \n**pro koupi piš .4** \n Přístup do reklam nečekaně\n\n" +
                "**☢️DBL premium☢️** \n 100 000" + agr + " [banka]\n**pro koupi piš .5** \n nemusíš platit daně u příkazů .uložit .vybrat\n");
            ovcak1.WithFooter(footer =>
            {
                footer
                .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                .WithText("Příkaz nákupu od MilošBota");
            });
            await Context.Channel.SendMessageAsync(embed: ovcak1.Build());
        }
    }
}
