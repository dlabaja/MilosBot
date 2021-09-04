using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class paroubek : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://zivotvcesku.cz/wp-content/uploads/optimg/2021/01/97050be18c7cdbaf8f21ace3eb2d092c86ce64b1-w680-h382.jpg",
            "https://img.cncenter.cz/img/18/new_article/5207155-img-paroubek-v0.jpg?v=0",
            "https://img.cz.prg.cmestatic.com/media/images/original/Feb2017/1966869.jpg?d41d",
            "https://cdn.xsd.cz/resize/c4ddf2d57f2d36949ceefb94bdbf33eb_resize=680,383_.jpg?hash=d61641fff1e2e69821508f2eccaa4253",
            "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=Paroubek%205_635296932544720403.jpg&id=16982",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_16x9/public/images/1694119-p-ctpr160212_a166-00000906.jpg?itok=qhD4byiW",
            "https://1gr.cz/fotky/bulvar/20/043/cl6/LAR82e85b_EXCZ17086_Jiri_Paroubek_po_.jpg",
            "https://g.denik.cz/1/22/praha-rozhovor-paroubek-08_denik-630-16x9.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/Jiri_Paroubek_2009.JPG/1200px-Jiri_Paroubek_2009.JPG",
            "https://img.blesk.cz/img/1/normal620/4925321_jiri-paroubek-v9.jpg?v=9",
            "https://img.ihned.cz/attachment.php/340/69819340/RHoxmOq691ys4pGSFvnAbz7TD2U50aNC/paroubek_mezi_lidmi.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/3/35/Jiri_Paroubek.jpg",
            "https://img.cz.prg.cmestatic.com/media/images/600x338/Feb2015/1731204.jpg?16f4",
            "https://ipravda.sk/res/2021/01/25/thumbs/jiri-paroubek-clanokW.jpg",
            "https://hlavnizpravy.eu/wp-content/uploads/2020/11/paroubekbabis.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/navrh_bez_nazvu_210125-114702_pj.png?itok=7P1ZcQ6v",
            "https://1gr.cz/fotky/idnes/13/091/cl5/JAV4daf9f_134412_4230061.jpg",
            "https://g.denik.cz/57/59/billboard-paroubek-chuck-norris201809-02_denik-630.jpg",
            "https://cdn.xsd.cz/resize/874568eea40736cc93c7fc7807661aac_resize=1956,1309_.jpg?hash=53bb38208565bfb5dc334e1579ee01d8",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR41NbU4B-e08dCcX4iHrddBVG72jpOTr_fYQ&usqp=CAU",
            "https://d15-a.sdn.cz/d_15/c_img_F_F/m8H8kh.jpeg?fl=cro,0,11,800,450%7Cres,1200,,1%7Cwebp,75",
        };

        [Command("Paroubek")]
        [Alias("paruba", "hotel", "teplice")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some bejvalej préma **");
                ovcak.WithImageUrl(url[ovce]);

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("To, že nemáš žádnou funkci, ze které tě mohou odvolat, neznamená, že můžeš porušovat pravidla..    od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("paroub: " + url[ovce]);
            }
        }
    }
}