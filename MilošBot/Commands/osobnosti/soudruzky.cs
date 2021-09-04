using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class soudruzky : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://media.discordapp.net/attachments/798653980858646549/798654652140224582/alberta.png",
            "https://cdn.discordapp.com/attachments/798653980858646549/798654863318712401/alice.jpg",
            "https://cdn.discordapp.com/attachments/798653980858646549/798655028838793256/anabela.png",
            "https://cdn.discordapp.com/attachments/798653980858646549/798655296011894814/blazenka.png",
            "https://cdn.discordapp.com/attachments/798653980858646549/798655894509322330/elenka.jpg",
            "https://cdn.discordapp.com/attachments/798653980858646549/798655976215543908/elvira.jpg",
            "https://cdn.discordapp.com/attachments/798653980858646549/798656149742288926/eva.jpg",
            "https://cdn.discordapp.com/attachments/798653980858646549/798656294747766835/ilonka.png",
            "https://cdn.discordapp.com/attachments/798653980858646549/798656416314294302/majka.jpg",
            "https://cdn.discordapp.com/attachments/798653980858646549/798656533872640020/vilma.jpg",
            "https://cdn.discordapp.com/attachments/798653980858646549/798656615883603999/svetlana.jpg",
            "https://cdn.discordapp.com/attachments/798653980858646549/798656751712469022/rozalie.png",
            "https://cdn.discordapp.com/attachments/798653980858646549/798656926120149042/cestmira.jpg",
            "https://cdn.discordapp.com/attachments/798653980858646549/798657092163731527/marta.jpg",
            "https://cdn.discordapp.com/attachments/798653980858646549/798657278098014308/beta.jpg",
            "https://cdn.discordapp.com/attachments/798653980858646549/798657502509924384/jirinka.jpg",
            "https://cdn.discordapp.com/attachments/798653980858646549/798657601536655369/veroslava.jpg",
            "https://cdn.discordapp.com/attachments/798653980858646549/798657890486976534/ruzenka.png",
            "https://cdn.discordapp.com/attachments/798653980858646549/798658016835534849/jarmilka.jpg",
            "https://cdn.discordapp.com/attachments/798653980858646549/798658258956714024/alzbetka.png",
            "https://cdn.discordapp.com/attachments/798653980858646549/798658406684557312/cecilie.jpg",
            "https://cdn.discordapp.com/attachments/798653980858646549/798658653896835072/bohumira.png",
            "https://cdn.discordapp.com/attachments/798653980858646549/798658811287175198/dobroslavka.png",
            "https://cdn.discordapp.com/attachments/798653980858646549/798658916434968586/gilberta.jpg",
            "https://cdn.discordapp.com/attachments/798653980858646549/798659136672890920/karolina.jpg",
            "https://cdn.discordapp.com/attachments/798653980858646549/798659430701858916/bozena.png",
            "https://cdn.discordapp.com/attachments/798653980858646549/798659971163226152/citoslava.jpg",
            "https://cdn.discordapp.com/attachments/798653980858646549/798660147898744893/stanislava.jpg",
            "https://cdn.discordapp.com/attachments/798653980858646549/798660948188725248/matylda.png",
            "https://cdn.discordapp.com/attachments/798653980858646549/798661795774332948/milena.jpg",
        };

        [Command("soudruzky")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some soudružky z NDR **");
                ovcak.WithImageUrl(url[ovce]);

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Soudružky, jejichž server went brrrr, poskytl @CharieCat...  od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("soudruzky: " + url[ovce]);
            }
        }
    }
}