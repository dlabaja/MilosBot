using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Soukup : ModuleBase<SocketCommandContext>
    {
        List<string> url = new List<string>()
        {
            "https://1gr.cz/fotky/idnes/19/012/cl5/REJ78bcae_soukup.jpg",
            "https://static.novydenik.com/2018/10/crop-226557-1-kjs-28032018_960x540.jpg",
            "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=CaptureSoukupejsijednicka_636745916447045353.JPG&id=136405",
            "https://i.iinfo.cz/images/571/jaromir-soukup-1.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/crop-194963-duel_960_180816-185308_tak.jpg?itok=Y49ADQQR",
            "https://img.blesk.cz/img/1/full/6132326_jaromir-soukup-televize-barrandov-moderator-v0.jpg?v=0",
            "https://1gr.cz/fotky/bulvar/18/061/cl6/REN73c457_jaromir_soukup.jpg",
            "https://www.barrandov.tv/obrazek/201808/5b7d0e91277d1/crop-239804-jaromir-soukup-live_1920x920.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_F_I/caFuC7.jpeg?fl=cro,0,1,1276,717%7Cres,1200,,1%7Cwebp,75",
            "https://img.cncenter.cz/img/3/article/5468416_soukup-barrandov-list-politika-televize-v0.jpg?v=0",
            "https://img.cncenter.cz/img/3/article/5468416_soukup-barrandov-list-politika-televize-v0.jpg?v=0",
            "https://sedmicka.tyden.cz/obrazek/201910/5da0762935138/crop-1943196-00-sedm2044_888x600.jpg",
            "https://img.blesk.cz/img/1/full/6132341_jaromir-soukup-televize-barrandov-moderator-v0.jpg?v=0",
            "https://cdn.xsd.cz/resize/7dce3aaae75731c499d8de181be207e0_extract=0,0,1280,720_resize=680,383_.jpg?hash=208b2bb9c0a55bf6be48ff4a49bcb50a",
            "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=Vystrizek_636757906874292689.JPG&id=136650",
            "https://img.cncenter.cz/img/11/full/5664925_tmbk-tomas-prinek-jaromir-soukup-v0.jpg?v=0",
            "https://img.ihned.cz/attachment.php/700/70586700/Wxg3stdpGLU4J1hHAwMiK5BcSTNrQjal/jaromir-soukup-duel-jaromira-soukupa-tv-barrandov-2018.jpg",
            "https://img.cncenter.cz/img/3/article/5091212_rx282018-v0.jpg?v=0",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQJoyKHw0r5zQPVwXgISg1MnriWUTivafmJA&usqp=CAU",
            "https://www.kinobox.cz/data/clanky/640x400x1/jaromir-soukup-se-konecne-dockal-bude-cesky-premier.jpg",
            "https://www.borovan.cz/wp-content/uploads/jarom%C3%ADr-soukup-foto-empresa-2-760x455.jpg",
            "https://cdn.forbesmedia.cz/images/eyJ1IjoiXC91cGxvYWRzXC8yMDIwXC8wNFwvamFyb21pcl9zb3VrdXAuanBnIiwidyI6MTIzMCwidiI6IjEuMCJ9.jpg",
            "https://img.cncenter.cz/img/11/normal690/5467597_soukup-v0.jpg?v=0",
            "https://www.forum24.cz/wp-content/uploads/2018/03/kauzy-soukup-850x480.png",
            "https://img.ihned.cz/attachment.php/20/71955020/5Hpe97Uv82cL6uizAnxCtlIjDk31mTbG/jaromir-soukup-medea-tv-barrandov.jpg",
            "https://sedmicka.tyden.cz/obrazek/201711/5a0d5e0c9fb3b/crop-1333145--mg-8312_800x540.jpg",
            "https://www.extra.cz/images/thumbs/82/05/8205b79-262062-soukup02-001-0d0000000-0d0174825-1d0000000-1d0000000-sector_740x416-crop.jpg",
            "https://cdn.xsd.cz/resize/2d43967b094639d6bb9a586839751d9a_extract=204,99,1815,1021_resize=680,383_.jpg?hash=8b461cf12f4b80bf204a9610e7da39ce",
            "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=Vystrizek_636801043498929982.JPG&id=138195",
            "https://www.radiotv.cz/wp-content/uploads/2018/04/barrandov-tyden-podle-jaromira-soukupa.jpg",
            "https://www.mediaguru.cz/media/12915/arena-jaromira-soukupa.jpg?anchor=center&mode=crop&width=1200&height=630&rnd=132350395440000000",
            "https://img.cncenter.cz/img/11/normal690/5201738_jaromir-soukup-moderator-milos-zeman-hrad-barrandov-v0.jpg?v=0",
            "https://1gr.cz/fotky/lidovky/19/023/lnc460/ZDP798c9f_333.png",
            "https://www.extra.cz/images/thumbs/af/1d/af1d73d-262125-soukupb5h-0d1460000-0d0000000-0d6280000-1d0000000-sector_360x340-crop.jpg",
            "https://pbs.twimg.com/profile_images/1215309447393873920/JWbtiq-6.jpg"
        };

        [Command("soukup")]
        [Alias("jarda", "jaromir", "jaromír")]
        public async Task soukupisko()
        {
            Random random = new Random();
            int ovce = random.Next(url.Count);
            var ovcak = new EmbedBuilder();
            ovcak.WithTitle("**Here, take Some Egomaniak**");
            ovcak.WithImageUrl(url[ovce]);
            Console.WriteLine(ovce);
            ovcak.WithColor(Color.Red);
            ovcak.WithFooter(footer =>
            {
                footer
                .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                .WithText("Prezident zadlužené důchodcovské televize od MilošBota");
            });
            await Context.Channel.SendMessageAsync(embed: ovcak.Build());

            ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("soukup: " + url[ovce]);
        }
    }
}
