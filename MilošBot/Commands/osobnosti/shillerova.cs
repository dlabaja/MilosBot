using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class alenka : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://img.cncenter.cz/img/11/full/5934755_alena-schillerova-ministryne-ministerstvo-financi-cr-v0.jpg?v=0",
            "https://upload.wikimedia.org/wikipedia/commons/e/e1/Alena_Schillerov%C3%A1_2.jpg",
            "https://www.forum24.cz/wp-content/uploads/2019/06/48394633_565696747236942_7010865392901947392_o.jpg",
            "https://eurozpravy.cz/pictures/photo/2020/03/03/c-eurozpravycz-incorp-images-vlada-2020-krepelka-20200301-13a4928-1e4bae2953_660x371.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_G_I/FqkIQc.jpeg?fl=cro,0,113,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://www.zlin.eu/clanky/aktuality/5108/js1-6880.jpg",
            "https://www.extra.cz/images/thumbs/e9/19/e919922-234244-profimedia-0452298635-2048x0-shrink.jpg",
            "https://cdn.administrace.tv/2020/12/04/small_169/8737d92ea9ba86aa14180455fbd79e47.png",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQyoubtnPOr-oq754RrRzRCo4_ikl3Ico8lgw&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQjNMgDf11O2yzY1UojbN4DJE3PbkO2ELIM_A&usqp=CAU",
            "https://cdn.xsd.cz/resize/2fb07ca1915032cb8e396b2d7a097dda_resize=680,383_.jpg?hash=0f2999a5bc5a010d26c3444c7f5695c6",
            "https://cdn.xsd.cz/resize/2fb07ca1915032cb8e396b2d7a097dda_resize=680,383_.jpg?hash=0f2999a5bc5a010d26c3444c7f5695c6",
            "https://www.mujrozhlas.cz/sites/default/files/styles/detail/public/rapi/88c7c65064630e700ee1a591149ce29a.jpg?h=4362216e&itok=ikl1o3F6",
            "https://iuhli.cz/wp-content/uploads/2019/03/alena-schillerova-foto-fb-alena-schillerova_compressed.jpg",
            "https://www.forum24.cz/wp-content/uploads/2019/11/Schillerov%C3%A1-kuk.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSkKbjH1h5rVjkjg0HrTVDnoc2I6ZWXrv9xaw&usqp=CAU",
            "https://m.actve.net/frekvence1/2019/06/p201906100624401-610x440.jpeg",
            "https://servis.idnes.cz/fbimg.aspx?foto=JB824a15_sva.jpg&c=A200319_145257_vztahy-sex_rik&premium",
            "https://img.cncenter.cz/img/3/article/6356486_alena-schillerova-plakat-jan-ignac-riha-dph-malacova-venezuela-v0.jpg?v=0",
            "https://d15-a.sdn.cz/d_15/c_img_gV_N/b4HFSz.jpeg?fl=cro,0,150,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRhaGSV4EusKvUXqiqFjs4cEXHvZ9GXI07xZg&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT6ibNC2hA-v4_uqOXqJZfuvXHtRe45e2RGgg&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSGnTRxZgITWWQzyTc8t2o-JW6HCdS2voREqw&usqp=CAU",
            "https://img.blesk.cz/img/1/normal620/6361502_schillerova-uces-anglictina-rouska-v2.jpg?v=2",
            "https://d15-a.sdn.cz/d_15/c_img_QM_Q/L2MxP.jpeg?fl=cro,0,52,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTW1akAPnFrzZZHfkEFrk4hwZhycpadnXry_A&usqp=CAU",
        };

        [Command("alena")]
        [Alias("money", "kasa", "miliarda", "ucetni", "shillerova", "schillerová")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some Miliarda sem, Miliarda tam... **");
                ovcak.WithImageUrl(url[ovce]);

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Důležitá je čeština, angličtinu nikdo podle Aleny nepoužívá a tak ani nemá důvod se jí učit... od Milošbota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("alena: " + url[ovce]);
            }
        }
    }
}