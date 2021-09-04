using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Feri : ModuleBase<SocketCommandContext>
    {
        List<string> url = new List<string>()
        {
            "https://www.top09.cz/files/photos/large/20170719155638.jpg",
            "https://1gr.cz/fotky/idnes/19/032/cl5/JB79efbf_55.jpg",
            "https://www.forum24.cz/wp-content/uploads/2020/04/Feri-770x460.jpg",
            "https://www.extra.cz/images/thumbs/ec/5a/ec5a576-225125-a-0d0000000-0d0000000-1d0000000-1d0000000-sector_1080x607-crop.png",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/drahos_danelova_12_180127-205707_jgr.jpg?itok=c6xXcGB3",
            "https://img.blesk.cz/img/1/normal620/5024661_dominik-feri-mikulas-ferjencik-pirati-top09-poslanec-v1.jpg?v=1",
            "https://servis.idnes.cz/fbimg.aspx?foto=KRR666c91_DominikFeri.jpg&c=A161108_142736_brno-zpravy_krut",
            "https://static.denikreferendum.cz/pictures/28314/article_body/feri.png?1476345395",
            "https://pbs.twimg.com/media/Ehe6m9BX0AEY2Qr.jpg:large",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRE3YGwAmmHgtwKV5aQdzXk-tiWPgDGdVV-fA&usqp=CAU",
            "https://cdn.forbesmedia.cz/images/eyJ1IjoiXC91cGxvYWRzXC8yMDIxXC8wMVwvZmVyaTMuanBnIiwidyI6MTkyMCwidiI6IjEuMCJ9.jpg",
            "https://lh3.googleusercontent.com/proxy/52c3Mh877is32M-fqL-Askat_JOtfE5pssSi2a6ylzr_V8tOeWJrGMMqwZSKChKYFEbTQaywnHiSIGqhPio05VJWYyEJgIsD",
            "https://www.merchshop.cz/gallery/da7ea83dcab768e779556c80593f09fe/merch_final-1.png",
            "https://img.blesk.cz/img/1/full/5895507_.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSx6ijM6N1wOO7q_7AOapLVg4j6rZvHK8wztA&usqp=CAU",
            "https://upload.wikimedia.org/wikipedia/commons/3/3a/Dominik_Feri_%28cropped%29.jpg",
            "https://cdn.forbesmedia.cz/images/eyJ1IjoiXC91cGxvYWRzXC8yMDIxXC8wMVwvZmVyaV9pbnN0YS5qcGciLCJ3IjoxMjIwLCJ2IjoiMS4wIn0%3D.jpg",
            "https://img.cncenter.cz/img/11/full/5794560_snemovna-jednani-duvera-neduvera-vlada-dominik-feri-v0.jpg?v=0",
            "https://i.ytimg.com/vi/mLj3kqpgHy4/hqdefault.jpg",
            "https://img.cncenter.cz/img/11/full/6513212_dominik-feri-v0.jpg?v=0",
            "https://paralelnilisty.cz/wp-content/uploads/2020/04/Dominika-Feri_2.jpg",
            "https://pbs.twimg.com/media/EOqrwCRWoAEzaHg.jpg",
            "https://pbs.twimg.com/media/DNNh4pyX0AEyDPa.jpg",
            "https://1gr.cz/fotky/bulvar/20/103/cl6/STE86fe6a_39edcollage_2020_10_26T171301.3551.jpg",
        };


        [Command("feri")]
        [Alias("vykřičník", "top09", "instagram", "fery")]
        public async Task Mildosaurus()


        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some Žlutý trojúhelník který řídí náš život **");
                ovcak.WithImageUrl(url[ovce]);

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Choco Afro od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());


                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("feri: " + url[ovce]);
            }
        }
    }
}