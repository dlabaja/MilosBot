using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class havel : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://upload.wikimedia.org/wikipedia/commons/1/11/V%C3%A1clav_Havel_cut_out.jpg",
            "https://www.hrad.cz/file/edee/2015/07/vaclav-havel.jpg",
            "https://www.stoplusjednicka.cz/sites/default/files/obrazky/2019/10/016b.jpgv",
            "https://upload.wikimedia.org/wikipedia/commons/a/a4/Vaclav_Havel.jpg",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_horizontal/public/2202296-fo00005265.jpeg?itok=2f1kLJ5o",
            "https://www.vize.cz/wp-content/uploads/2016/02/vaclav-havel-portrait.jpg",
            "https://cdn-vsh.prague.eu/object/2121/a.jpg",
            "https://www.marianne.cz/sites/default/files/public/styles/article_teaser_large_desktop/public/2020-10/gettyimages-530865510.jpg?itok=A1keicDy",
            "https://www.vaclavhavel.cz/img/product/00091b.jpg",
            "https://www.piratibrandys.cz/wp-content/uploads/2019/08/havel-e1566208374676-1200x804.jpg",
            "https://img.cncenter.cz/img/3/article/4588608_havel-v0.jpg?v=0",
            "https://obalky.kosmas.cz/ReviewCovers/452510_base.jpg",
            "https://www.rexter.cz/obrazek/5c1a7c7b1fb11/havel-vaclav_590x396.jpg",
            "https://refstatic.sk/article/vaclav-havel-uhlavni-nepritel-komunismu-bojovnik-za-lidska-prava-ale-take-kontroverzni-osobnost-ceskoslovenske-politiky~71fdfd22383de0623ce9.jpg?is=919x570c&ic=0x27x1024x635&c=2w&s=d1295e942070d9c5d0d5b25bd24266c42d1a28354491ea3f1ceb33d72301ff2f",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/crop_880x495/public/images/2409167-fo0013378802.jpg?itok=KUcoNsgd",
            "http://www.literatiznasictvrti.cz/archiv/ad_cz/havel.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/19910320_havel_007_r_190123-192934_haf.jpg?itok=2Twsu9gk",
            "https://www.extra.cz/images/thumbs/f8/40/f840f0b-171716-havel-2-0d0000000-0d0570571-1d0000000-0d9009009-sector_740x416-crop.jpg",
            "https://www.ctidoma.cz/sites/default/files/styles/image_detail/public/imgs/23/vaclav_havelll.jpg",
            "https://img.ihned.cz/attachment.php/850/35639850/iostv348CGIO6PQdfgpqrxyz0STwARVn/havel_web2.png",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSM_KnwlwMMpXCFflK6yfa27UOG8_SzeBKjAQ&usqp=CAU",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/navrh_bez_nazvu1_200805-162817_kro.png?itok=fa7g_uwP",
            "https://g.denik.cz/32/61/valasske-mezirici-vaclav-havel-vystava_denik-320-16x9.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSPIwTx25KPlpFv18Qq9ar0yF2-XZLAK_K46Q&usqp=CAU",
            "https://d15-a.sdn.cz/d_15/c_img_E_G/8yVOIO.jpeg",
            "https://cdn.xsd.cz/original/5edf5042d9ce38febfd9cb124c5c6abe.jpg",
            "https://1gr.cz/fotky/idnes/11/122/cl5/JB3fdd9e_nef.jpg",
            "https://img.radio.cz/HxNmJfpGgx_KIJrutWi1ccxBmxc=/fit-in/800x800/1324218740__pictures/ctk1112/havelbg.jpg",
            "https://www.vaclavhavel.cz/img/gallery/01552/012b.jpg",
            "https://cdn.xsd.cz/resize/2d786a6eda7e3c11893cfbf50631b6b9_extract=121,0,1750,985_resize=680,383_.jpg?hash=c4a4ef66c73bd96489e4aaa6cef675e7",
            "http://www.vhlf.org/wp-content/uploads/2014/11/0012.jpg",
            "https://imagebox.cz.osobnosti.cz/foto/vaclav-havel/vaclav-havel.jpg",
            "https://www.vaclavhavel.cz/elearning/img/timeline/00013b.jpg",
            "https://lh3.googleusercontent.com/proxy/XLW_DPFXeQY-5lQcnDiHj6xaoozHuVVHDNT9IKr3x_G01mmS99NgEY0GmBwDP4gQNTrIPU3JjirzDRXxMBvhR6IzSn5RPaqNQENBF3L0_5fIq927pnGIYeP8MHYKRgktJHhjj0HProZ6YlIc2EY9Ka1LGkhasa-jGeNXXQLzDBpAkMcX7iUlPxVPm77T",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRo4RV2BM8mESUcUQ6Wi6ZmGazrMO0g4tqZjQ&usqp=CAU",
            "https://encyklopedie.praha2.cz/sites/default/files/styles/max_size/public/galerie/2019/01/04/havel_vaclav2.jpg?itok=ABJE1os-",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/images/02270238.jpeg?itok=Pq_3gHAF",
        };

        [Command("havel")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(0, url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some Havel**");
                ovcak.WithImageUrl(url[ovce]);
                ovcak.WithColor(Color.Red);
                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Prezident rozdělitel od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("Havel: " + url[ovce]);
            }
        }
    }
}