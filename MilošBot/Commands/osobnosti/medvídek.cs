using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class méďa : ModuleBase<SocketCommandContext>
    {
        List<string> url = new List<string>()
        {
            "https://cdn.discordapp.com/attachments/719289692474048675/803872261878710302/unknown.png",
            "https://cdn.discordapp.com/attachments/723512415198642177/803872557484343387/unknown.png",
            "https://cdn.discordapp.com/attachments/723512415198642177/803872712052703272/unknown.png",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cd/Xi_Jinping_and_Barack_Obama_toast_at_White_House_state_dinner_September_2015.jpg/220px-Xi_Jinping_and_Barack_Obama_toast_at_White_House_state_dinner_September_2015.jpg",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_horizontal/public/2371160-2019-10-12t144130z_347067577_rc1549d71b10_rtrmadp_3_nepal-china.jpg?itok=aMAol3E4",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_fotogalerie_large/public/uploader/2019-06-05t115853z_1_190605-153603_ako.JPG?itok=C1hadHCA",
            "https://cdncz1.img.sputniknews.com/img/1025/99/10259936_80:-1:2984:2048_638x450_80_0_0_533f4e9d8b16ad8110ecfe3b6df7974f.jpg",
            "https://www.euro.cz/wp-content/uploads/2018/03/c48dc3adnskc3bd-prezident-si-c5a5in-pching-1.jpg",
            "https://1gr.cz/fotky/idnes/10/102/cl5/JB3691e8_002.JPG",
            "https://1gr.cz/fotky/idnes/10/102/cl5/JB3691e8_002.JPG",
            "https://img.blesk.cz/img/1/full/3557677_.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_E_D/qaiBrkG.jpeg?fl=cro,0,32,800,450%7Cres,1200,,1%7Cwebp,75",
            "https://img.cncenter.cz/img/11/full/5678775_.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_rubrikovy_nahled/public/uploader/profimedia-035321579_171017-192846_mls.jpg?itok=pKAapESU",
            "https://img.ihned.cz/attachment.php/440/68586440/FRc0fNVlMyAEJI37PbjK9nSBursWizDe/jarvis_595920be498e6104b93f7da9.jpeg",
            "https://img.cncenter.cz/img/11/full/5252643_milos-zeman-si-tin-pching-dmitrij-medvedev-v0.jpg?v=0",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/pjimage_1_171017-192846_mls.jpg?itok=oFps98S6",
            "https://d15-a.sdn.cz/d_15/c_img_F_I/tWP3e1.jpeg?fl=cro,0,0,800,450%7Cres,1200,,1%7Cwebp,75",
            "https://cdncz1.img.sputniknews.com/img/1015/86/10158617_84:0:2988:2048_638x450_80_0_0_db551b329021309f30d3878b244f69fd.jpg",
            "https://www.euro.cz/wp-content/uploads/2016/03/c48dc3adnskc3bd-prezident-si-c5a5in-pching-po-pc599c3adletu-do-prahy.jpg",
        };


        [Command("Pching")]
        [Alias("čína", "lidovárepublika", "si ťin-Pching", "méďa", "meda", "méda", "pú", "pů")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some Méďa PÚ **");
                ovcak.WithImageUrl(url[ovce]);

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Prezident, který do ČR jezdí rád, ale české pohádky zkazí a Česko obviňuje z původu covidu od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());


                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("méďa: " + url[ovce]);
            }
        }
    }
}