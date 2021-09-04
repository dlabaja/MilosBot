using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class stalin : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://upload.wikimedia.org/wikipedia/commons/thumb/9/97/Stalin_Potsdam_1945_%28cropped%29.jpg/225px-Stalin_Potsdam_1945_%28cropped%29.jpg",
            "https://www.pametnaroda.cz/sites/default/files/Stalin-Vlasta.jpg",
            "https://1gr.cz/fotky/idnes/13/031/cl5/JB49a98e_stalin.jpg",
            "https://www.pametnaroda.cz/sites/default/files/styles/930x520/public/Stalin-Gottwald.png?itok=Zor6gidb",
            "https://www.novinykraje.cz/vysocina/wp-content/uploads/sites/11/2019/09/Stalin.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/c/c4/Stalin_1945.jpg",
            "http://www.totalita.cz/images/o_stalinj.jpg",
            "http://www.nasevojsko.eu/fotky4869/fotos/_vyr_5540J-V-Stalin_portret.jpg",
            "https://www.valka.cz/attachments/3140/Stalin.jpg",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_16x9/public/images/1390451-117341.jpg?itok=kGGkKNk1",
            "https://www.patria.cz/fotobank/465eaec0-2f15-4ecf-9864-ee2fb30ea006",
            "https://www.stoplusjednicka.cz/sites/default/files/styles/full/public/obrazky/stalin-99.jpg?itok=5dKRpaub",
            "https://img.cncenter.cz/img/3/article/6733733_josif-vissarionovic-stalin-v0.jpg?v=0",
            "http://www.historieblog.cz/wp-content/uploads/2015/03/Sn%C3%ADmek-obrazovky-2015-03-13-v-9.33.10.png",
            "https://lh3.googleusercontent.com/proxy/uC2q_KZ9EuLXcw-Dy6grl3q0tZQamZeCWHXuRZRTysHQVHA2lPAoIXo0tbk18zTMQFgKPg8sH9ygcl1PzUMPZsMSrfbsEpqNPQ4qiS_U86c",
            "https://img.cncenter.cz/img/3/article/3544878_stalin-v0.jpg?v=0",
            "https://cdn.i0.cz/src/public-data/f7/3d/752592cd3a1c865ccef1d8270e09_base_optimal.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ7e7TuWjrCROarVxe59_bIEQf_xPFCIv6-6Q&usqp=CAU",
            "https://www.valka.cz/attachments/3140/Stalin-and-Churchill_jalta.jpg",
            "https://cdncz1.img.sputniknews.com/img/369/61/3696188_113:234:2685:2048_638x450_80_0_0_55b7471f384880580d5a93c4a0881fd3.jpg",
            "https://1gr.cz/fotky/lidovky/19/041/lnc460/GAA2e6cb3_stalin.jpg",
            "https://1gr.cz/fotky/idnes/18/102/cl6/VOV76bbbf_LeninStalin.jpg",
            "https://www.biography.com/.image/t_share/MTY2NjgyOTkyNTMyNTMwMjMx/gettyimages-2637237.jpg",
            "https://pbs.twimg.com/profile_images/1171149799464329218/X92jwZl6_400x400.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTdLgqBtpx9LOvWHwC__S8oWLKKwTx64HXuTg&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRUtXboJfPCChHc0QVPUyd8uZT6v5s1LGxLbw&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSYDeDN9La7HREsFndQwCFqjL205oOQ6zywLQ&usqp=CAU",
            "https://cdn.britannica.com/54/60154-050-B02509B6/Joseph-Stalin-1950.jpg",
            "https://cdn.hswstatic.com/gif/stalin-1.jpg",
            "https://g.denik.cz/1/33/ctk_stalin_soviet_portret_denik-320-16x9.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRo9wriqS4kX5KMgB6upsCR9C7F1pTyAsOCvg&usqp=CAU",
            "https://g.denik.cz/127/30/leninstalincrop.jpg",
            "https://images-na.ssl-images-amazon.com/images/I/81eRo6Xo4ZL.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSDNfWvQUaBpm6DPr-12NV1J9B_2fdaAnRe0Q&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTptuX9xgKvUBZz2DWYYXNh4hAHl5WRr52T8Q&usqp=CAU",
            "https://static.timesofisrael.com/www/uploads/2016/09/Stalin_in_July_1941-1024x640.jpg",
            "https://u-blogidnes.1gr.cz/blogidnes/article/0/65/655420/655420_article_photo_sX5JZKI0_900x.jpeg?r=27bqů",
        };

        [Command("stalin")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some Stalin**");
                ovcak.WithImageUrl(url[ovce]);
                ovcak.WithColor(Color.Red);
                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Jeden repost - 18 milionů furríků do gulagu... od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("stalin: " + url[ovce]);
            }
        }
    }
}