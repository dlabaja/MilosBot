using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Ozrala : ModuleBase<SocketCommandContext>
    {
        List<string> url = new List<string>()
        {
            "https://www.top09.cz/files/photos/large/20150723140007.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/e/ed/Miroslav_Kalousek_Praha_2018.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_E_I/NZVpSt.jpeg?fl=cro,0,23,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://pbs.twimg.com/profile_images/796289819571843072/yg0FHZZD_400x400.jpg",
            "https://img.blesk.cz/img/1/full/5638848_hejtmanka-jermanova-kalousek-stredocesky-kraj-v0.jpg?v=0",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_fotogalerie_large/public/uploader/miroslav-kalousek-to_191204-130350_rez.jpg?itok=dKAw07SQ",
            "https://cdn.xsd.cz/resize/a795dd2372723129b9a66555c6095e67_extract=71,0,1848,1041_resize=680,383_.jpg?hash=f87b009081291ce847d54fd8d84d480a",
            "https://g.cz/sites/default/files/resize/styles/clanek_-_velke_foto_586x330/public/field/image/2015/kalouseksluk-586x401.jpg?itok=NZrdkrQn",
            "https://cdn.administrace.tv/2020/05/28/small_169/b97bc1602a23cc49de27ad5283ecefe9.jpg",
            "https://1gr.cz/fotky/idnes/20/072/r7/PEC84b354_kalousek3.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_facebook/public/uploader/kalousek_201103-231146_bar.jpg?itok=9SQrDlnK",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/crop_880x495/public/images/2468939-kalousek.png?itok=zCHq6G2G",
            "https://g.denik.cz/1/51/praha-rozhovor-kalousek-101-08_denik-320-16x9.jpg",
            "https://cdn.xsd.cz/resize/4424f8cbbbd839f997afcb856530bf37_extract=39,0,1960,1102_resize=680,383_.jpg?hash=154192c9c5fad27e0f98a8afbf1baf2c",
            "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=IMG_5165_637316998789327616.jpg&id=151942",
            "https://g.denik.cz/1/cb/praha-rozhovor-kalousek-101-09_galerie-980.jpg",
            "https://www.top09.cz/files/photos/large/20170530102352.jpg",
            "https://img.cncenter.cz/img/11/normal690/3739937_miroslav-kalousek-top-09-v0.jpg?v=0",
            "https://img.cncenter.cz/img/3/full/1313256-img-kalousek-v2.jpg?v=2",
            "https://d15-a.sdn.cz/d_15/c_img_QP_J/6oaoL.jpeg?fl=cro,0,46,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://www.barrandov.tv/obrazek/202011/5fa2a59b43033/crop-373220-miroslav-kalousek-sulova-katerina-ctk_960x540.jpeg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRG2QemKPzciVDa_MVuwYXRY2rifPDJ4WCpkw&usqp=CAU",
            "https://img.blesk.cz/img/1/normal620/6643508_kalousek-pivo-koronavirus-zakaz-v2.jpg?v=2",
            "https://1gr.cz/fotky/idnes/20/033/cl5/KOP82440b_kalousek.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/dsc_9004_170510-143532_fij.jpg?itok=hl4YZH0g",
            "https://i.ytimg.com/vi/TZ-F7FMTul4/maxresdefault.jpg",
            "https://img.cncenter.cz/img/11/full/5969867_miroslav-kalousek-v0.jpg?v=0",
            "https://1.bp.blogspot.com/-trpYJpajOYY/UfujNi6CrLI/AAAAAAAAQt8/103h4eGtewI/s1600/Kalousek+Chlast%C3%A1m+v%C3%ADc.jpg&gt;",
            "https://g.denik.cz/1/03/0004586355-kalousek-nebude-v-pristich-volbach-kandidovat-do-snemovny_denik-320-16x9.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRsSlsdaJdMBSuJ5xGvWRCgLTCcbZ8AUrz7pg&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTzWx-XDNAcjLr8mwv8xmdbqoevv4BZEi_oQg&usqp=CAU",
            "https://i.ytimg.com/vi/My2Jd5b_Qkk/maxresdefault.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_E_J/zIAfde.jpeg?fl=cro,0,0,800,450%7Cres,1200,,1%7Cwebp,75",
            "https://echo24.cz/img/5fa2a179ffd8cd3c48363ccd/1180/614?_sig=bCTNQFlVsjsnmhRdpSq-X6gfPzHSEodj43oVhOaG_to",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQOm5HT8LbOBemf88-ixbU7f7U9xCCdtQc-Kg&usqp=CAU",
            "https://www.bleskove.cz/img/articles/c/5572.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR_0fcLJzI1hAv0zxKjPyrFLaDwqamiFxvXZQ&usqp=CAU"
        };

        [Command("kalousek")]
        [Alias("kalous", "mirek", "mira", "míra", "miroslav", "qwer8", "qwer", "osel")]
        public async Task soukupisko()
        {
            Random random = new Random();
            int ovce = random.Next(url.Count);
            var ovcak = new EmbedBuilder();
            ovcak.WithTitle("**Here, take Some Ožrala**");
            ovcak.WithImageUrl(url[ovce]);
            Console.WriteLine(ovce);
            ovcak.WithColor(Color.Red);
            ovcak.WithFooter(footer =>
            {
                footer
                .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                .WithText("Zloděj Zlodějský od MilošBota");
            });
            await Context.Channel.SendMessageAsync(embed: ovcak.Build());

            ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("kalous: " + url[ovce]);
        }
    }
}
