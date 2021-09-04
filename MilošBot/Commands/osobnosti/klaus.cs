using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class starsi : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://upload.wikimedia.org/wikipedia/commons/f/f2/V%C3%A1clav_Klaus_Praha_2015_%282%29_%28cropped%29.JPG",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_16x9/public/2197493-kj.jpg?itok=Au68_b1B",
            "https://cdn.xsd.cz/resize/8c16eba3a0a03fea95937c7e86feadff_extract=318,0,823,463_resize=680,383_.jpg?hash=40ed357c92aec13d27f3b2c351e58968",
            "https://www.hrad.cz/file/edee/2015/07/zivotopis-20150703-100608.jpg",
            "https://g.denik.cz/50/ff/vaclav-klaus-rnkt-02-ara_galerie-980.jpg",
            "https://1gr.cz/fotky/idnes/20/021/r7/JB81313c_kla.jpg",
            "https://www.barrandov.tv/obrazek/202004/5e8c91faf175f/crop-335652-p201909280431201_960x540.jpeg",
            "https://media.klaus.cz/size/550x/4091.jpg",
            "https://img.cncenter.cz/img/11/normal690/6625696_vaclav-klaus-prezident-v0.jpg?v=0",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/crop_880x495/public/images/2435428-klaus2_0.jpg?itok=2USqs30-",
            "https://img.ihned.cz/attachment.php/280/44853280/4tpGBcOvhemMC6aIuKljN8QPEqdLiR5k/klaus_Volf_k.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a7/Vaclav_Klaus_headshot.jpg/1200px-Vaclav_Klaus_headshot.jpg",
            "https://www.extra.cz/images/thumbs/16/03/1603366-212607-16508264-1602894989727434-385818-0d1640000-0d0000000-0d7280000-1d0000000-sector_360x340-crop.jpg",
            "https://g.denik.cz/50/81/vaclav-klaus-rnkt-06-ara_galerie-980.jpg",
            "https://cdn.administrace.tv/2020/10/09/small_169/ad983cfce298fec2cd7c620bcc8ca502.jpg",
            "https://pbs.twimg.com/profile_images/1133832453/vaclavklaus_400x400.png",
            "https://d15-a.sdn.cz/d_15/c_img_H_E/i8JdRI.jpeg?fl=cro,0,78,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://img.cncenter.cz/img/18/full/6156843_.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTGT9ilsfTvGjLcPiRJQP7wtigI01NmB6-mPw&usqp=CAU",
            "https://img.cncenter.cz/img/3/full/5092560-img-klaus-vaclav-prezident-v0.jpg?v=0",
            "https://img.blesk.cz/img/1/normal620/6667389_17-listopad-narodni-trida-pieta-vaclav-klaus-rouska-rousky-v0.jpg?v=0",
            "https://upload.wikimedia.org/wikipedia/commons/a/a5/Vaclav-Klaus-01.jpg",
            "https://img.cncenter.cz/img/11/normal690/6033344_vaclav-klaus-prezident-v0.jpg?v=0",
            "https://echo24.cz/img/5e6ffcadffd8fa2b28812aea/1180/614?_sig=TMJRuS2A6jDMBYH_z-EunODuJoRY8DJrrJjQSf5DCZ0",
            "https://lh3.googleusercontent.com/proxy/mzAJFD0cpDcIdZba36p_DayEnQpHF00LQttdfP69_z5_UmN6TRjtsXeQeM99N8ECl6HzirdxC0GykXiq-q0t6-R-OZCevCIHst_B39wxYWjbh6fw2Mkcdk9f0-Cymy_ZyJ-jZW3muD87C8NE9aVkwD0f6db2LBGbHdaG_FIcRxxFJ5w2rjsjA76vd8nUW6SeNm4JxK1YxIGdvF_CbiOUfH7KadLyrg",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/scale_1180/public/1971271-klaus.jpg?itok=r1UHqrl-",
            "https://1gr.cz/fotky/idnes/20/071/r7/MBB848da9_klaus.jpg",
            "https://www.cbdb.cz/authors/102.jpg",
            "https://img.cncenter.cz/img/3/article/5600783_vaclav-klaus-jan-klaus-vaclav-klaus-ml-oslava-narozeniny-v0.jpg?v=0",
            "https://d15-a.sdn.cz/d_15/c_img_E_I/EmaBL1Y.jpeg?fl=cro,0,20,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQJoD4tFQapcndF4kLUENN01gw2oFCSYe9OCg&usqp=CAU",
            "https://d15-a.sdn.cz/d_15/c_img_F_E/i6mBqHi.jpeg?fl=cro,0,55,800,450%7Cres,1200,,1%7Cwebp,75",
            "https://upload.wikimedia.org/wikipedia/commons/1/13/President_V%C3%A1clav_Klaus.JPG",
            "https://1gr.cz/fotky/idnes/12/113/cl6/JB4760b9_ruzi.jpg",
            "https://cdncz1.img.sputniknews.com/img/171/17/1711738_841:355:3235:2046_638x450_80_0_0_03f20b44d395068ac5a7465b59d517e3.jpg",
            "https://img.cncenter.cz/img/3/article/6667496_vaclav-klaus-narodni-trida-rouska-v1.jpg?v=1",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7e/Sv%C4%9Bt_knihy_2009_-_V%C3%A1clav_Klaus_2.jpg/220px-Sv%C4%9Bt_knihy_2009_-_V%C3%A1clav_Klaus_2.jpg",
        };

        [Command("klaus")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some Klaus s normálním obličejem**");
                ovcak.WithImageUrl(url[ovce]);
                ovcak.WithColor(Color.Red);
                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Odpůrce roušek od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("klaus: " + url[ovce]);
            }
        }
    }
}