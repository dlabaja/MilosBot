using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Schwarz : ModuleBase<SocketCommandContext>
    {
        List<string> url = new List<string>()
        {
            "https://upload.wikimedia.org/wikipedia/commons/b/b3/Karel_Schwarzenberg_2019.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/e/e1/Karl_VI_zu_Schwarzenberg.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_E_I/nbQB6qM.jpeg?fl=cro,0,19,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://www.pametnaroda.cz/sites/default/files/witness/3142/photo/11439-photo.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_F_E/0LlBqJK.jpeg?fl=cro,0,34,800,450%7Cres,1200,,1%7Cwebp,75",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e8/Karel_Schwarzenberg_2019_Praha.jpg/220px-Karel_Schwarzenberg_2019_Praha.jpg",
            "https://www.top09.cz/files/photos/large/20090910162054.jpg",
            "https://g.denik.cz/1/f4/schwarzenberg-jelinek-jan_denik-320-16x9.jpg",
            "https://www.pametnaroda.cz/sites/default/files/witness/3142/3142-portrait_former.jpg",
            "https://pbs.twimg.com/profile_images/1560674071/Sprite_7.jpg",
            "https://img.cncenter.cz/img/11/full/6327740_karel-schwarzenberg-politik-top-09-drevic-zamek-schwarzenbergove-knize-slechtic-v0.jpg?v=0",
            "https://www.top09.cz/files/photos/large/20151216123921.jpg",
            "https://www.pametnaroda.cz/sites/default/files/witness/3142/photo/11445-photo.jpg",
            "https://cdn.xsd.cz/resize/d60c579c3db638279992be240d50dee8_extract=0,0,1024,576_resize=680,383_.jpg?hash=57b167d162ee4e87629e1622d4124ed5",
            "https://img.cncenter.cz/img/11/normal690/6327742_karel-schwarzenberg-politik-top-09-drevic-zamek-schwarzenbergove-knize-slechtic-v0.jpg?v=0",
            "https://img.cz.prg.cmestatic.com/media/images/original/Jun2015/1759374.jpg?9356",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRmbOufw5n8B1Dmtv-qhanbI7eI7GI3NvBmNA&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTyDEjAJZbr-ljLl_XIaspJmM7TFpjH1DUpug&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQAm7bra0W-ZL3zVFO3-6SSmM9AV6o7Sg0iVQ&usqp=CAU",
            "https://pbs.twimg.com/profile_images/3147900366/6ba91aec56dd169856eef5e327b0a9f6_400x400.jpeg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRmrWK1YpPwcBsZIob38KmVyhS3fuMyJI6L_A&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR3Bu-hEkJVOrPBGEwYlVehsjT_M8IY6OY3Mg&usqp=CAU",
            "https://upload.wikimedia.org/wikipedia/commons/c/cb/Karl_von_Schwarzenberg.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS9KMq6WPRefjWTc4HrCgsMVGJGmNYfbBh02g&usqp=CAU",
            "https://www.narodninoviny.cz/wp-content/uploads/2019/03/schwarzenberg_star%C3%BD-780x439.jpg",
            "https://img.ihned.cz/attachment.php/260/74578260/GO4EStb9yUNWRAmTIq21M658rkfnHlCV/jarvis_5e399363498e40c808c59134.jpeg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSemNL0nAJE2q7UeC8YKylIJxo4BJ3tvbspWg&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSl1g2l79yYQINuwv76WeOpPLsWP_GWBU9I2g&usqp=CAU",
            "https://cdn.xsd.cz/original/e0a76c7dca6431499bbf7d9a25671469.jpg"
        };

        [Command("schwarzenberg")]
        [Alias("schwarz", "švarc", "šwarc", "schwarc", "schvarz", "shvarz")]
        public async Task soukupisko()
        {
            Random random = new Random();
            int ovce = random.Next(url.Count);
            var ovcak = new EmbedBuilder();
            ovcak.WithTitle("**Here, take Some Spáč**");
            ovcak.WithImageUrl(url[ovce]);
            Console.WriteLine(ovce);
            ovcak.WithColor(Color.Red);
            ovcak.WithFooter(footer =>
            {
                footer
                .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                .WithText("Kandidát na prezidenta, který \"usnul na vavřínech\" od Milošbota");
            });
            await Context.Channel.SendMessageAsync(embed: ovcak.Build());

            ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("schwarz: " + url[ovce]);
        }
    }
}
