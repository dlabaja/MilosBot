using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.API;
using Discord.Rest;
using Discord.WebSocket;
using System.Text;

namespace MilošBot.Commands
{
    public class Harassimm : ModuleBase<SocketCommandContext>
    {
        /*static*/

        private List<string> url = new List<string>()
        {
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_facebook/public/uploader/2020-03-11t105248z_1_200311-125823_mpa.JPG?itok=7J9cvf2p",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_maly/public/uploader/2018-02-25t171524z_1_180225-181827_jgr.jpg?itok=J8spximl",
            "https://www.investicniweb.cz/sites/default/files/migrated/9818-barack-obama-a-angela-merkelova.jpg",
            "https://www.investicniweb.cz/sites/default/files/migrated/9818-barack-obama-a-angela-merkelova.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSiDrg0Nh0VB6Xrw5uvY4oMDFWg66mN8nPX7g&usqp=CAU",
            "https://img.cncenter.cz/img/3/full/3023386_merkelova-imigranti-v0.jpg?v=0",
            "https://www.tyden.cz/obrazek/201512/566827bcabd8f/crop-912307-angela.jpg",
            "https://i3.cn.cz/15/1594214060_P202007080535201.jpg",
            "https://img.ihned.cz/attachment.php/610/75095610/uBE0MibfpeH98On3sSytAvrVqNJF5j7K/jarvis_5ef9ff4b498e75f6b81d1d0a.jpeg",
            "https://d39-a.sdn.cz/d_39/c_img_gQ_U/q1jBP.jpeg?fl=cro,0,90,1800,1012%7Cres,1200,,1%7Cwebp,75",
            "https://d15-a.sdn.cz/d_15/c_img_F_I/xM3s1J.jpeg?fl=cro,0,3,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://img.ihned.cz/attachment.php/760/75720760/t5K0AM7D48PE6slIBkH2VJrF3gyiSvux/jarvis_5fec73d5498ec7e5fa2b9c62.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQYVHGhKeqL2E3EvBPd4Mgd9GaRi1xg5j9Feg&usqp=CAU",
            "https://infocz-media.s3.amazonaws.com/infocz/production/files/2020/07/15/10/40/19/2c4240c3-2c23-426b-a45d-c4f75ba64015/5047716.jpg",
            "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=merkel-rating-sp-downgrading-jpg-crop_display_636143588076395665.jpg&id=117878",
            "https://d15-a.sdn.cz/d_15/c_img_F_G/weTBZY7.jpeg?fl=cro,0,78,800,450%7Cres,1200,,1%7Cwebp,75",
            "https://cdn.xsd.cz/resize/4976873c084b3e1992dee28f53dc5d22_extract=27,0,1999,1125_resize=680,383_.jpg?hash=de05c4766c415a20ba975c2161ea6b2f",
            "https://www.zdravotnickydenik.cz/wp-content/uploads/2019/04/merkel-bayer.jpg"
        };

        [Command("merklova")]
        [Alias("makrela")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(0, url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some Kancléřka všech makrel**");
                ovcak.WithImageUrl(url[ovce]);
                ovcak.WithColor(Color.Red);
                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Dogeristova láska od MilošBota");
                });
                await Context.Channel.SendMessageAsync("", false, ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(795684253953163274) as ITextChannel;
                await cons.SendMessageAsync("makrela: " + url[ovce]);
            }
        }
    }
}