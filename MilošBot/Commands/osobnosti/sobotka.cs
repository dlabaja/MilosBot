using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Sobotka : ModuleBase<SocketCommandContext>
    {
        List<string> url = new List<string>()
        {
            "https://upload.wikimedia.org/wikipedia/commons/9/9f/B_Sobotka_2015_Praha.JPG",
            "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=Bohous-v-metru_636573146357808475.jpg&id=131297",
            "https://d15-a.sdn.cz/d_15/c_img_E_D/XtFBqnC.jpeg?fl=cro,0,24,800,450%7Cres,1200,,1%7Cwebp,75",
            "https://g.denik.cz/1/ed/praha-rozhovor-sobotka-1_denik-630-16x9.jpg",
            "https://g.denik.cz/1/0d/0004797494-sobotka-vypo_denik-630-16x9.jpg",
            "https://1gr.cz/fotky/lidovky/16/022/lnc460/ELE614a7c_56QsCgA8SIYdbeAFsVtAMwpLohwCFWrUEGrK.jpg",
            "https://img.ihned.cz/attachment.php/840/68338840/7cU8H3B6VSsKLnQOg9why1MEDtmPbCav/sobotka_olga.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_F_E/Ha3BqDw.jpeg",
            "https://img.blesk.cz/img/1/normal620/3485212_bohuslav-sobotka-v10.jpg?v=10",
            "https://img.ihned.cz/attachment.php/340/71076340/Mo4LWeCE0UFAbtxIVN659kiyvDOR2dwr/CR_SNEMOVNA_STRANY_INTERNET_KOMUNIKACE_SOBOTKA_244.jpg",
            "https://img.cncenter.cz/img/3/article/3496584_bohuslav-sobotka-v0.jpg?v=0",
            "https://img.cncenter.cz/img/18/new_article/1434235-img-bohuslav-sobotka-v0.jpg?v=0",
            "https://upload.wikimedia.org/wikipedia/commons/f/f4/Bohuslav_Sobotka_2014-03-05.jpg",
            "https://cdn.xsd.cz/resize/31eeda1a652e3c5e810998869242110c_resize=680,383_.jpg?hash=0c9e7c21ee8479c8cf10f9d1e75b3031",
            "https://img.cncenter.cz/img/11/normal690/3041612_bohuslav-sobotka-v1.jpg?v=1",
            "https://infocz-media.s3.amazonaws.com/infocz/production/files/2020/07/15/17/26/20/f1d8b053-a84f-4321-aeb9-d71c47a11e50/3501586.jpg",
            "https://www.vlada.cz/assets/clenove-vlady/premier/Bohuslav_Sobotka_188.jpg",
            "https://pbs.twimg.com/profile_images/378800000059045294/8bbb095bab71a283f7ba4c968a409d07_400x400.jpeg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTZIEnUiEEOYxgwyzqI3c_fZ4Czgj2pVzxDvw&usqp=CAU",
            "https://img.cncenter.cz/img/18/new_article/3435796-img-bohuslav-sobotka-v5.jpg?v=5",
            "https://cdn.xsd.cz/resize/e69d1e36fe773bd79bb5355e943ac22c_resize=680,383_.jpg?hash=1b6ecb9d4cd78afe20c61e498232f5d0",
            "https://img.cncenter.cz/img/3/article/3496128_sobotka-v0.jpg?v=0",
            "https://www.tyden.cz/obrazek/201310/524e949818832/crop-501559-sobotka_520x250.jpg",
            "https://1gr.cz/fotky/lidovky/12/053/lnc460/PTA434b05_ovm_01_3_.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_E_I/z9pBFDk.jpeg?fl=cro,0,16,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://img.blesk.cz/img/1/full/1844055_bohuslav-sobotka-cssd-svatba-hluboka-olga-sobotkova-manzelka-v0.jpg?v=0",
            "https://1gr.cz/fotky/idnes/18/073/cl5/ZUC74ee09_134648_3678571.jpg",
            "https://infocz-media.s3.amazonaws.com/infocz/production/files/2020/07/15/19/47/34/6c216062-4323-4858-aecd-126bffc49a41/3502730.jpg",
            "https://www.extra.cz/images/thumbs/8e/fd/8efd5bf-125882-sobotka-0d0220000-0d0142349-0d9820000-0d9750890-sector_740x416-crop.jpg",
            "https://img.aktualne.centrum.cz/628/36/6283631-blog-bohuslav-sobotka.jpg",
            "https://servis.idnes.cz/fbimg.aspx?foto=JB6b1555_55.jpg&c=A190325_103728_domaci_jadv",
            "https://www.boskovice.cz/assets/Image.ashx?id_org=832&id_obrazky=121937&datum=7%2F28%2F2015+9%3A15%3A53+PM"
        };

        [Command("sobotka")]
        [Alias("bouhouš", "bohous", "bohuslav")]
        public async Task soukupisko()
        {
            Random random = new Random();
            int ovce = random.Next(url.Count);
            var ovcak = new EmbedBuilder();
            ovcak.WithTitle("**Here, take Some Plešingr**");
            ovcak.WithImageUrl(url[ovce]);
            Console.WriteLine(ovce);
            ovcak.WithColor(Color.Red);
            ovcak.WithFooter(footer =>
            {
                footer
                .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                .WithText("Člověk na kterého ukázal i Miloš od Milošbota");
            });
            await Context.Channel.SendMessageAsync(embed: ovcak.Build());

            ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("sobotka: " + url[ovce]);
        }
    }
}
