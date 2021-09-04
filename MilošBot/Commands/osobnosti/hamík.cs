using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class hamounzČssd : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://www.vlada.cz/assets/clenove-vlady/Hamacek_188.jpg",
            "https://img.ihned.cz/attachment.php/320/74774320/EnaIuzOmd4SWtcKi6pMlyBC1D0HPNqe8/jarvis_5e7d0e75498e40c80ad6f099.jpeg",
            "https://upload.wikimedia.org/wikipedia/commons/6/6a/Hamacek_Danko_%28cropped%29.jpg",
            "https://img.cncenter.cz/img/11/normal690/6586098_jan-hamacek-v1.jpg?v=1",
            "https://d15-a.sdn.cz/d_15/c_img_F_J/EAO0zw.jpeg?fl=cro,0,128,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://www.forum24.cz/wp-content/uploads/2020/03/koronavl%C3%A1da-770x460.jpg",
            "https://img.cncenter.cz/img/3/article/6244538_andrej-babis-jan-hamacek-rouska-rousky-cesko-koronavirus-v0.jpg?v=0",
            "https://img.ihned.cz/attachment.php/150/73523150/vR49BEKuMCbJzfhGLtkj81elgrmcFsi0/P201905260838801.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/hamzem_200512-181711_cen.jpg?itok=D6xjVmWP",
            "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=rouskari_637200486335550721.jpg&id=148827",
            "https://cdn.xsd.cz/resize/6fc4b10e7fa6374188096e6e3507948b_resize=680,383_.jpg?hash=4c57eecb9aa105deb5d2e7cac6ed835f",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTFKqmwrGa-ZjWb1IsCULSFF4wPsPXEvGsMHg&usqp=CAU",
            "https://cdn.xsd.cz/resize/6652fccd6c8f3244b6bde90223953668_extract=127,0,1620,912_resize=680,383_.jpg?hash=d835f04e1793a71b6886eaf9215c7f83",
            "https://www.forum24.cz/wp-content/uploads/2020/03/bbb-42-770x460.jpg",
            "https://nevimnews.cz/wp-content/uploads/2020/09/kadernik.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/images/657bd39893a8e6c050695adf9c573952.jpg?itok=fk2DhcQa",
            "https://infocz-media.s3.amazonaws.com/infocz/production/files/2020/07/16/03/21/27/ab1873cf-ec22-4bde-b6b0-043c96c1943c/5480508.jpg",
            "https://zivotvcesku.cz/wp-content/uploads/optimg/2020/09/9d5756ce6738c068bbc9288a69e3cc9bbd7bbac7-w680-h382.jpg",
        };

        [Command("hamáček")]
        [Alias("ham", "svetr", "hamanda", "hamík", "hamacek")]
        public async Task Bidik()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                var ovcak = new EmbedBuilder();
                ovcak.WithColor(Color.Red);
                ovcak.WithTitle("Here, take Some Rudý Svetr");
                ovcak.WithImageUrl(url[ovce]);
                Console.WriteLine(ovce);
                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Pokud má svetr červené barvy, situace se dá ještě zachránit. Ale pokud má vyhrnuté rukávy, tak je to už boužel bez šance... od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("hamáček: " + url[ovce]);
            }
        }
    }
}