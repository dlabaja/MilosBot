using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class bláto : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://cdn.discordapp.com/attachments/723512415198642177/806984998926286876/unknown.png",
            "https://www.vecernikpv.cz/images/2020/11_listopad/45_blatny.jpg",
            "https://cdn.xsd.cz/resize/8866fe5217033cb89f0eea0a1ddc32f7_resize=853,1280_.jpg?hash=f21c290f29b02a70a20dff3db5151567",
            "https://d15-a.sdn.cz/d_15/c_img_gU_P/Q7l9O.jpeg?fl=cro,0,49,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_horizontal/public/images/2519152-p202011200742501.jpeg?itok=R-h6PL9y",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/p202010300466301_201030-135231_kro.jpeg?itok=LZY-BFOH",
            "https://www.mzcr.cz/wp-content/uploads/2020/11/Jan_Blatny_Interview24.png",
            "https://pbs.twimg.com/media/ElV-kTaXYAAimfU.jpg",
            "https://brnenska.drbna.cz/files/drbna/images/page/2020/10/26/size4-16037035984522-60-novym-ministrem-zdravotnictvi-by-mel-byt-spickovy-brnensky-detsky-lekar-jan-blatny.jpg",
            "https://1gr.cz/fotky/lidovky/20/103/lnc460/VAG86edbe_143906_9429902.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/7/77/Jan_Blatn%C3%BD_%E2%80%93_signature_2020.svg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcHDpb0Ci4S9FHftJfnaaaP0p1TLOgFTruQA&usqp=CAU",
            "https://neovlivni.cz/wp-content/uploads/2020/11/ministr_zdravotnictvi_jan_blatny1.jpg",
            "https://img.blesk.cz/img/1/normal620/6660386_blatny-ministr-blesk-v2.jpg?v=2",
            "https://i3.cn.cz/15/1609060145_P202012270167201.jpg",
            "https://img.blesk.cz/img/1/normal620/6741267_ockovani-vakcina-koronavirus-fakultni-nemocnice-brno-jan-blatny-v0.jpg?v=0",
            "https://www.prahadnes.info/portal/0_foto_nahled.php?file=/home/www/infodnes.cz/www/infodnes.cz/data1/im_zpravy_clanky/30402/1-blatny-jan-00_vlada_cz.jpg&x=600&y=500&konst=x",
            "https://img.cncenter.cz/img/3/article/6634035_robert-plaga-jan-blatny-snemovna-ano-v0.jpg?v=0",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQyYjIA2GXGh_50iAv-8HiHbZhi3gFoBU_6lA&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSuNi_WtEvcCsBdMYlRn_YhK3BrXiwfWEjug&usqp=CAU",
            "https://im.tiscali.cz/press/2020/10/27/1229661-profimedia-0565600414-base_16x9.jpg.1152?1603786513.0",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRnOCsh6Yjg3xqkwGiX69yYxj2TLc5apewxhQ&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQAbX_26gf7wH4RkCsG5IB-g4lJ46QdoTOpZw&usqp=CAU",
        };

        [Command("blatny")]
        [Alias("janblatny", "ministr", "pandemie", "treti")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some neschopný ministr, na kterého dle predikce ukáže Miloš hůlčičkou **");
                ovcak.WithImageUrl(url[ovce]);

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("bláto od Milošbota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("blatný: " + url[ovce]);
            }
        }
    }
}