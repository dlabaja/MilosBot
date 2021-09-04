using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class aleuzrbgvchenka : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
           "https://euractiv.cz/wp-content/uploads/sites/7/2019/07/janbranc_com-7104-787x450.jpg",
            "https://foto.pribram.cz/clanky/foto/15613.jpg",
            "https://img.cncenter.cz/img/11/full/5254680_adam-vojtech-v0.jpg?v=0",
            "https://www.muzivcesku.cz/wp-content/uploads/2020/04/32786645-5e44-4439-951f-c9b0b010e1f0-2.jpeg",
            "https://img.cncenter.cz/img/11/full/5254680_adam-vojtech-v0.jpg?v=0",
            "https://1gr.cz/fotky/idnes/20/093/cl5/SUB864e19_profimedia_0452374044.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_facebook/public/uploader/adam_vojtech_2_180822-105015_mda.jpg?itok=xiX-bSQb",
            "https://img.blesk.cz/img/1/normal620/6593239_koronavirus-ministr-zdravotnictvi-adam-vojtech-epicentrum-v4.jpg?v=4",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTjU1MBNwNHfHvaZ8QGl46zsLhBGi2v6ZscVg&usqp=CAU",
            "https://i.ytimg.com/vi/5I5lzAHiDR4/maxresdefault.jpg",
            "https://img.blesk.cz/img/1/normal620/6573203_vojtech-ministr-v2.jpg?v=2",
            "https://zivotvcesku.cz/wp-content/uploads/optimg/2020/09/28d68606276dcbc4d691949107bf524855c79a13-w680-h382.jpg",
            "https://g.denik.cz/1/07/ctk-rada-statu-resi-omezeni-akci-ochrane-ridicu-ci-cene-rousek_denik-320-16x9.jpg",
            "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=IMG_0054_636771242760546684.jpg&id=137051",
            "https://www.drbna.cz/files/drbna/images/page/2020/09/21/size1-16006694802129-207-ministr-zdravotnictvi-adam-vojtech-oznamil-rezignaci.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS7n2kMm3cY1GQibDKPLvF_PAZ_BD9YdeDK9A&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS7n2kMm3cY1GQibDKPLvF_PAZ_BD9YdeDK9A&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQRGLXfFB3ilBIfCekEXzfT1xI-t73AFqCVLQ&usqp=CAU",
            "https://zivotvcesku.cz/wp-content/uploads/optimg/2020/04/54ce255fa7830953c5e8ce6af7d3bf7fc9422bfa-w680-h382.jpg",
            "https://img.cz.prg.cmestatic.com/media/images/original/Mar2020/2364496.jpg?d41d",
            "https://zivotvcesku.cz/wp-content/uploads/optimg/2020/09/5c3a70022b48a13d10d32b7c5ec21cad466c8016-w680-h382.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_QP_T/64qOc.jpeg?fl=cro,0,6,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://cdn.administrace.tv/2020/08/20/small_169/7030849f2f20ec4d4f846c853e84cd73.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHQGlfuTOdHlwf2xtAfFYwA3ekugs1YZQIZA&usqp=CAU",
            "https://1gr.cz/fotky/idnes/20/041/cl8h/LUH826af3_02.jpg",
            "https://www.vlada.cz/assets/clenove-vlady/Vojtech_188.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRS3UAmgzNc2bvIsPxB2bOCLv_YL0ZkyRPjIQ&usqp=CAU",
            "https://img.kurzy.cz/zpravy/obrazky/20/541920-zabiji-zpev-koronavirus-aneb-ministr-zdravotnictvi-vojtech-coby-ucastnik-superstar-v-roce-2005/Vojtech_Adam_Superstar_2005.png",
            "https://musicserver.cz/img/170332ts.jpg",
        };

        [Command("vojtech")]
        [Alias("adam")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here take some Andrejova bílá ovce**");
                ovcak.WithImageUrl(url[ovce]);

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Bývalého ministra a nadějného zpěváka přináší Milošbot");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("vojtech: " + url[ovce]);
            }
        }
    }
}