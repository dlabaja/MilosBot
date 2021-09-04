using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class alžbeta : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://upload.wikimedia.org/wikipedia/commons/b/b6/Queen_Elizabeth_II_in_March_2015.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/images/03612168.jpeg?itok=6I0-9mET",
            "https://img.kurzy.cz/zpravy/obrazky/22/521722-britska-kralovna-alzbeta-ii-se-chysta-do-duchodu-planuje-vzdat-se-koruny/kralovna_big_w420h315.jpg",
            "https://imagebox.cz.osobnosti.cz/foto/alzbeta-II/alzbeta-II.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_fotogalerie_large/public/uploader/2018-06-08t142702z_5_180620-193913_haf.jpg?itok=vFZXpmgV",
            "https://d15-a.sdn.cz/d_15/c_img_E_J/UzxH59.jpeg?fl=cro,0,60,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://zajezdy.radynacestu.cz/img/w-900,h-750,wm-a/2015-11-03/mc-download-queen-large.jpg",
            "https://img.cncenter.cz/img/3/article/2273629_alzbeta-ii-v0.jpg?v=0",
            "https://1gr.cz/fotky/idnes/15/091/cl6/ZAR5dc426_FFS01_BRITAIN_ROYALS_0904_11.JPG",
            "https://d15-a.sdn.cz/d_15/c_img_F_P/AjLYmw.jpeg?fl=cro,0,1,1276,717%7Cres,1200,,1%7Cwebp,75",
            "https://eurozpravy.cz/pictures/photo/2012/06/03/13387491592_660x371.jpg",
            "https://zajezdy.radynacestu.cz/img/w-900,h-750,wm-a/2015-11-03/queen.jpg",
            "https://c1.primacdn.cz/sites/default/files/styles/landscape_extra_large/public/3/33/4753959-snimek_obrazovky_2019-04-22_v_11.29.50.png?itok=ca38LzVo&c=def_cloudinary",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSFE82Wfp8tVNp9STf2mljm6T_HyXMeFD43ug&usqp=CAU",
            "https://cdn.xsd.cz/resize/99a0b08268bc3be5bf577e3a7e61822c_resize=680,383_.jpg?hash=80d2e19b31a0092189f7be9952fc44cd",
            "https://1gr.cz/fotky/lidovky/15/063/lnc460/ELE5c20e4_p201506230786101.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSSfdNRG7M1b-fpJ5afdAaLHvDi_qklmuJHkg&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAuXrKKpFdYd4gHLZtS_YxK62GgRXib89Zog&usqp=CAU",
            "https://img.cncenter.cz/img/3/article/5438318_kralovna-alzbeta-ii-v3.jpg?v=3",
            "https://img.blesk.cz/img/1/normal620/4931545_velka-britanie-kralovna-alzbeta-ii-narozeniny-oslava-koncert-v2.jpg?v=2",
            "https://img.cncenter.cz/img/11/normal690/6095775_kralovna-alzbeta-vanoce-projev-v1.jpg?v=1",
            "https://img.cncenter.cz/img/18/new_article/6651034-img-kralovna-alzbeta-ii-kralovska-rodina-moda-trendy-v0.jpg?v=0",
            "https://www.bety.cz/image.ashx?id=46229&f=191104204142-kralovna.jpg&w=640&h=480",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_16x9/public/2440898-p202004050421601.jpeg?itok=r63Y6P_-",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTLuhQRVRx6KR9cioRWBjvm_sEMV77c1OBM0g&usqp=CAU",
            "https://www.extra.cz/images/thumbs/1f/2d/1f2d139-12453-profimedia-0161031778-0d0000000-0d1275000-1d0000000-0d5575000-sector_740x416-crop.jpg",
            "https://g.cz/sites/default/files/styles/gflex_landscape_large/public/g/images/kra2.jpg?itok=dkEIA1Dm",
            "https://www.tyden.cz/obrazek/201704/58ed1c2e4894a/crop-1185705-kralovna-alzbeta-ii-(2).jpg",
            "https://img.cncenter.cz/img/18/full/2290749_.jpg",
            "https://img.ihned.cz/attachment.php/300/73556300/IAVFbTOltHm3M1r2yLqn8Skpo7ga5xc6/jarvis_5cf56402498e11e9e019a43b.jpg",
            "https://img.cncenter.cz/img/3/full/2273629-img-alzbeta-ii-v0.jpg?v=0",
            "https://infocz-media.s3.amazonaws.com/infocz/production/files/2020/07/15/09/29/14/53288627-af57-4bcc-a7f6-8a8d053d46b3/4932815.jpg",
            "https://cdn.xsd.cz/resize/260137a3190c377ea0f2184e8a0faed0_resize=640,492_.jpg?hash=f084d82b787792bd872ad0a0b92d56ff",
            "https://d15-a.sdn.cz/d_15/c_img_H_E/ipreJ0.jpeg?fl=cro,0,52,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://img.cncenter.cz/img/3/full/3847609-img-alzbeta-filip-britanie-v0.jpg?v=0",
            "https://img.cncenter.cz/img/18/new_article/1176032-img-alzbeta-ii-kralovna-v5.jpg?v=5",
            "https://i1.wp.com/iluxus.cz/wp-content/uploads/queen-elizabeth-ii-468x430.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/2020-10-15t114008z_2_201015-201111_onz.JPG?itok=yefteQrm",
            "https://d15-a.sdn.cz/d_15/c_img_E_J/BofBNj3.jpeg?fl=cro,0,32,1250,703%7Cres,1200,,1%7Cwebp,75",
            "https://media.extralife.cz/test/lifee/201911queen-670x377.png",
            "https://media.super.cz/images/top_foto1/0000001709990563/_SlJ-Yj_OcnhtJFmslT_Ng/52af1f19231eb28d90ca0100-97968.jpg?20150217154412&size=539",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR3QGwM_4O9Geh3s--7n9LmFI_ZLY4nIhwGbw&usqp=CAU",
            "https://img.cncenter.cz/img/11/normal690/2833739_v0.jpg?v=0",
            "https://lh3.googleusercontent.com/proxy/qs81cRnbL-kB3Wgrlux-WEuqEYMv1BcWyqu2yJhm_Ayivg5B4Sg-B8O2ZDW97jqC0Zqg8TI8rbLChCyq0hmejeqLP1w_ofvnNbUEYY6Q0qUcngPdd48WHfQlUguyrazqBKpMkgGasolRrmPhIsP_1ZL9wHoNxV2RrqZVgqOsa9xX5sFGJuEWSXkJA_O0tzKDM_ZfDV5l4glwpqcy",
            "https://media.extralife.cz/test/lifee/201911flickr-1-670x377.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/images/02640859.jpeg?itok=Q7YYcueP",
            "https://www.ctidoma.cz/sites/default/files/styles/image_detail/public/imgs/10/800px-alzbeta_ii._na_slovensku_2008.jpg",
        };

        [Command("alzbeta")]
        [Alias("VB")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some nejlepší vládce světa **");
                ovcak.WithImageUrl(url[ovce]);

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Na stáří nezáleží, ona je toho živoucí důkaz... MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("alzbeta: " + url[ovce]);
            }
        }
    }
}