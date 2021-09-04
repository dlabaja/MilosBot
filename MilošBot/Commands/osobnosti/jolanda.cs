using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class jolanda : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
           "https://1gr.cz/fotky/lidovky/20/012/lnc460/OGO53a462_jolanda.JPG",
           "https://liberecka.drbna.cz/files/drbna/images/page/2020/01/18/size4-15793735977117-103-size4-15793729765194-60-jolanda.jpg",
           "https://echo24.cz/img/5e23580dffd8fa2b235a6628/1180/614?_sig=Be47CtDnRgCRDNUG9wka1qM4OY9Gs1ft0RBad6HyANQ",
           "https://refstatic.sk/article/d2d9a3add02253d27a7c.jpg?ic=43x88x1900x999&is=1200x630c&c=2w&s=9a392d2b3f0965117547e2ad1c775a69f0214edadbd1cc1c98e09e99f9e803df",
           "https://img.cncenter.cz/img/3/article/3211841_jolanda-v2.jpg?v=2",
           "https://g.cz/sites/default/files/field/image/2018/ved3fd6c0_jolanda_0.jpg",
           "https://1gr.cz/fotky/bulvar/19/023/cl6/LAR797f50_maxresdefault.jpg",
           "https://g.denik.cz/56/54/jolanda-d200113b0y451.jpg",
           "https://img.blesk.cz/img/1/normal620/1079222_cikanka-jolanda-v0.jpg?v=0",
           "https://g.denik.cz/56/bb/jolanda-d190731jl5er1.jpg",
           "https://1gr.cz/fotky/idnes/20/012/cl5/KOT80d026_jolanda.jpg",
           "https://media.super.cz/images/gallery/0000000007990449/cfmBss10aMpJHYhj-EEY0g/50cdeb75614f1351c3fb0200-24490?size=539",
           "https://1gr.cz/fotky/idnes/20/012/r7/MAH80d054_profimedia_0201824517.jpg",
           "https://i.ytimg.com/vi/sCv7AEsVUbU/maxresdefault.jpg",
           "https://img.blesk.cz/img/1/normal620/6136613_v9.jpg?v=9",
           "https://i.ytimg.com/vi/LbadZFVlBGs/maxresdefault.jpg",
           "https://www.barrandov.tv/obrazek/202001/5e2351f32532f/crop-317550-img-20200118-wa0002_960x540.jpg",
           "https://pbs.twimg.com/profile_images/1319181236703813632/JUg3DKAW_400x400.jpg",
           "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQeLmV5vxpBIQ1KKhLcM6YWpSp1u0VFmebNyg&usqp=CAU",
           "https://stars24.cz/pictures/photo/2018/09/06/maxresdefault-4202fe9c27.jpg",
           "https://m.actve.net/evropa2/2019/08/maxresdefault-1-2.jpg",
           "https://1gr.cz/fotky/idnes/20/013/cl6/HEL80e6f1_Jolandasestrih.jpg",
           "https://g.cz/sites/default/files/styles/gflex_landscape_large/public/field/image/2015/jolanda_hp.png?itok=8KBL5SYN",
           "https://s2.dmcdn.net/v/CCxmJ1MI4xv3tiHmP/x1080",
           "https://media.super.cz/images/top_foto1/0063000009090511/ZqG2GvTK-VI7lrBziEpmfg/586ce9ae9e8251918a630100-202294.jpg?20170104132951&size=539",
           "https://img.blesk.cz/img/1/full/5155259_michaela-jilkova-kotel-mate-slovo-jolanda-regina-kartarka-jasnovidka-saaveda-saman-v0.jpg?v=0",
           "https://www.tyden.cz/obrazek/201812/5c07e4134be49/crop-1696023-img-0146.jpg",
           "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSbCZ3qGKj96hxD2gwHMC9gilK60wpOpvvOmQ&usqp=CAU",
           "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRnIVsbl9CuBPKUmEbMiiZLTVsg-2W5ANotvw&usqp=CAU",
           "https://lh3.googleusercontent.com/proxy/aQirnTtUSaEQrI_u0Ut0oo8NdOrrRncUWcWa_If__YFqh0zfuIHZG_w512YHyiXP9qlYVa-94beFleCE5QVP2qlJUMzCtQF4-CeM26YTwj7vl1wnwtNOOmFd8auUGZkVG_iVwfRsJd8XrdY5w_35QyEg-4fhOmrgXS7T74tbditMQiSW4bbJERXZCXjl-i_AzURorBQHmUQ-QCYz7UIc8-QU5SR69EXRD_jde2aZBAewKR_SBFIwJPIC08_QaQFo4SPZqA",
           "https://img.cncenter.cz/img/18/new_article/1625369_jolanda-vlastik-plaminek-v0.jpg?v=0",
           "https://g.denik.cz/56/7b/jolanda-03_denik-630-16x9.jpg",
           "https://d48-a.sdn.cz/d_48/c_img_G_C/wbhB0Zm.jpeg",
           "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTk3oev8Z6d97oI6ZYh2eM8CINuurTDbuLAzw&usqp=CAU",
           "https://img.blesk.cz/img/1/full/5406331_jolanda-jaromir-jagr-veronika-koprivova-rozchod-svatba-prepoved-v0.jpg?v=0",
           "https://prosvet.cz/wp-content/uploads/2020/01/0.jpg",
           "https://g.denik.cz/56/d2/jolanda-02_sip-1140.jpg",
        };

        [Command("jolanda")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some Věštkyně **");
                ovcak.WithImageUrl(url[ovce]);

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("F od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("jolanda: " + url[ovce]);
            }
        }
    }
}