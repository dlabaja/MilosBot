using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Tomio : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://tomio.cz/wp-content/uploads/2020/02/Tomio_Okamura_8-1-e1588927265909.jpg",
            "https://pbs.twimg.com/profile_images/808994525385519104/2MBupdXy_400x400.jpg",
            "https://www.romea.cz/aaa/img.php?src=/img_upload/03ec66ac77713bab242255f6194ad3ff/okamura-big.jpg&w=630",
            "https://tomio.cz/wp-content/uploads/2020/07/669538_article_photo_tomio-okamura.jpg",
            "https://img.cncenter.cz/img/3/article/3754577_rx442017-v0.jpg?v=0",
            "https://img.ihned.cz/attachment.php/130/70906130/bP1248DvoGsKfLudeV09zExgjF3p7Rl5/jarvis_5a999420498e813322fb2cf1.jpeg",
            "https://1gr.cz/fotky/lidovky/17/111/lnc460/ANI321e56_lg_tomio1.JPG",
            "https://www.nbns.cz/files/images/recnici/tomio_okamura.jpg",
            "https://pbs.twimg.com/profile_images/922414959174279173/UXyF2USI_400x400.jpg",
            "https://1gr.cz/fotky/idnes/12/113/cl6/KOP47781c_p201211260516401.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/b/bd/Sv%C4%9Bt_knihy_2011_-_Tomio_Okamura.jpg",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_16x9/public/images/1208408-331480.jpg?itok=56BE4JVo",
            "https://cdn.xsd.cz/resize/f8a0533ecc1934f3800855c7c74ced30_resize=1024,1342_.jpg?hash=4642f120638d834ad8f465aa113f4d7d",
            "https://www.extra.cz/images/thumbs/8a/56/8a563d6-175219-oka-2-0d0000000-0d0000000-1d0000000-0d8413174-sector_740x416-crop.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFz6dfkqOD-8vb3S9kFUDPdtAdwtpYJoP30g&usqp=CAU",
            "https://pbs.twimg.com/profile_images/685595149242609664/BU3gxo38_400x400.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTFjPU87HRGOcjiDJu40Nrx3gtdf5_KIUuwUQ&usqp=CAU",
            "https://infocz-media.s3.amazonaws.com/infocz/production/files/2020/07/15/21/44/47/c35f6b73-0dc9-420e-abf6-d3e296ec5784/5603975.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/sn_12_190710-075516_mda.jpg?itok=GIj3-EPb",
            "https://cdn.albatrosmedia.cz/Images/Product/27739997/?ts=636575456798130000",
            "https://cdn.xsd.cz/resize/016cf5c012fb352596b474a12fd8f524_extract=48,0,1024,576_resize=680,383_.jpg?hash=e192b16413c43f226246f991c53e1aaa",
            "https://d15-a.sdn.cz/d_15/c_img_E_D/0ltBrV3.jpeg?fl=cro,0,0,800,450%7Cres,1200,,1%7Cwebp,75",
            "https://www.barrandov.tv/obrazek/202009/5f4e278fdd259/crop-362554-tomio_958x539.jpg",
            "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=10012020_Upice_Okamura_autorzuzanakoulova-6_637144281263889243.JPG&id=147184",
        };

        [Command("tomio")]
        [Alias("okamura")]
        public async Task SexMan()
        {
            Random random = new Random();
            int ovce = random.Next(url.Count);
            var ovcak = new EmbedBuilder();
            ovcak.WithTitle("**Here, take Some Svalouš co skočil z okna**");
            ovcak.WithImageUrl(url[ovce]);
            Console.WriteLine(ovce);
            ovcak.WithColor(Color.Red);
            ovcak.WithFooter(footer =>
            {
                footer
                .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                .WithText("Migrant zakazující migraci od MilošBota");
            });
            await Context.Channel.SendMessageAsync(embed: ovcak.Build());

            ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("tomio: " + url[ovce]);
        }
    }
}