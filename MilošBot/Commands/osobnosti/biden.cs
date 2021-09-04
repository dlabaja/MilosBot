using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Bidous : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://thumbnails.texastribune.org/VGQaPdzVuIqCHzMfHIM5eXdXa88=/1200x804/smart/filters:quality(95)/static.texastribune.org/media/files/20ddd1716338a3c77a767d8833a40208/Joe%20Biden%20MS%20TT.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Joe_Biden_official_portrait_2013_cropped.jpg/1200px-Joe_Biden_official_portrait_2013_cropped.jpg",
            "https://img.ihned.cz/attachment.php/70/75130070/bGl8DE1wvOJzmStjy2QqsRNpgUWo7rTf/jarvis_5f0b1ee4498e40c80d3fbce5.jpeg",
            "https://www.history.com/.image/ar_16:9%2Cc_fill%2Ccs_srgb%2Cfl_progressive%2Cg_faces:center%2Cq_auto:good%2Cw_768/MTc2MzAyNDY4NjM0NzgwODQ1/joe-biden-gettyimages-1267438366.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/2020-12-15t004425z_1_201215-063241_ako.JPG?itok=H22GUaMp",
            "https://static.politico.com/dims4/default/77db620/2147483647/resize/1160x%3E/quality/90/?url=https%3A%2F%2Fstatic.politico.com%2Fe3%2F5e%2F3ba27c9c4f00b80e8b1e6788411a%2Fap20350034179902-1-c.jpg",
            "https://cdn.cnn.com/cnnnext/dam/assets/201123131505-joe-biden-for-ghitis-oped-large-169.jpg",
            "https://img.cncenter.cz/img/11/full/6650296_usa-volby-prezident-joe-biden-wilmington-v0.jpg?v=0",
            "https://d15-a.sdn.cz/d_15/c_img_gS_Q/sIsNT.jpeg?fl=cro,0,53,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://image.cnbcfm.com/api/v1/image/106813571-16083074592020-12-16t210033z_1603265100_rc2lok93i17t_rtrmadp_0_usa-biden.jpeg?v=1608307490&w=678&h=381",
            "https://cdn.cnn.com/cnnnext/dam/assets/201216121804-01-biden-buttigieg-1216-large-169.jpg",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_wide/public/images/2481012-rtx7mc2k.jpg?itok=KFcxxPC5",
            "https://g.denik.cz/1/9a/sbor-volitelu-potvrdil-vysledky-a-zvolil-bidena-prezidentem-usa_denik-630-16x9.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/2020-11-19t213339z_1_201123-200720_kro.JPG?itok=O72GIwd5",
            "https://1gr.cz/fotky/idnes/20/093/cl5/AHA864a06_WAS449_USA_ELECTION_BIDEN_0923_11.JPG",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_horizontal/public/images/2449718-p202005020231701.jpeg?itok=kKXIDADY",
            "https://img.ihned.cz/attachment.php/340/74745340/dqSJ3vk8OponIj9PwKrs7yEV1zTC6m0G/jarvis_5e73bd05498e40c80aacc81f.jpeg",
            "https://image.cnbcfm.com/api/v1/image/106802320-1606315910893-gettyimages-1229768698-biden-11242020-markmakela24.jpeg?v=1606316007"
        };

        [Command("biden")]
        [Alias("bidet")]
        public async Task Bidik()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                var ovcak = new EmbedBuilder();
                ovcak.WithColor(Color.Red);
                ovcak.WithTitle("Here, take Some Biden");
                ovcak.WithImageUrl(url[ovce]);
                Console.WriteLine(ovce);
                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("/Možná jednou/ prezident od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("biden: " + url[ovce]);
            }
        }
    }
}
