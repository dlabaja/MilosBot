using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Ohidibczaa : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://www.swmag.cz/assets/novinky/2009-05/novinka00531/upload/photo/%C4%8Cesk%C3%A1%20pir%C3%A1tsk%C3%A1%20strana.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_F_I/GvrBN74.jpeg?fl=cro,0,91,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://www.pirati.cz/assets/pdf/A4-plakat.png",
            "https://www.pirati.cz/assets/eurovolby/plakat-1.jpg",
            "https://cdn.xsd.cz/resize/d7d48c9b6c8f3a72b11291a4c01fe600_resize=1386,1848_.jpg?hash=a83dfde63db0b081e72e5150450c93f9",
            "https://www.byznysnoviny.cz/wp-content/uploads/2019/01/Pir%C3%A1ti-Barto%C5%A1-leden-2019-e1547896493534.png",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/pirati_31_200114-150445_mda.jpg?itok=CUifhbAe",
            "https://unikovahralednice.cz/wp-content/uploads/2018/10/pirati-350x386.png",
            "https://www.pirati.cz/assets/img/articles/2020/STAN%20Pir%C3%A1ti%20Barto%C5%A1%20Raku%C5%A1an%20koalice.png",
            "https://piratipracuji.cz/api/img/https%3A%2F%2Fraw.githubusercontent.com%2Fpirati-web%2Fpirati.cz%2Fgh-pages%2Fassets%2Fimg%2Farticles%2F2021%2Fmiki_ferjencik99.jpg?w=720	",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTYfC1XCjWEWB-f6ygduhjAxuWdIwIgE8J6uQ&usqp=CAU",
            "https://www.starostove-nezavisli.cz/data/kraje/OLK/files/logo%20pirati%20a%20starostove.jpg",
            "https://raw.githubusercontent.com/pirati-web/pirati.cz/gh-pages/assets/img/articles/2019/holomcik-bartos-ferjencik.jpg",
            "https://i3.cn.cz/15/1606763850_P202011300823301.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRg00kMhcVycaWTz_IKDsaxgXuDoaawzAGMSQ&usqp=CAU"
        };

        [Command("piráti")]
        [Alias("pirati")]
        public async Task soukupisko()
        {
            Random random = new Random();
            int ovce = random.Next(url.Count);
            var ovcak = new EmbedBuilder();
            ovcak.WithTitle("**Here, take Some Piráti**");
            ovcak.WithImageUrl(url[ovce]);
            Console.WriteLine(ovce);
            ovcak.WithColor(Color.Red);
            ovcak.WithFooter(footer =>
            {
                footer
                .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                .WithText("Vyhrají díky drdům, nebo drbům svého předsedy? Od Milošbota");
            });
            await Context.Channel.SendMessageAsync(embed: ovcak.Build());

            ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("pirati: " + url[ovce]);
        }
    }
}