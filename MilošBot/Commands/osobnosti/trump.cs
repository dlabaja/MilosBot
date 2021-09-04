using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Trumpous : ModuleBase<SocketCommandContext>
    {
        List<string> url = new List<string>()
        {
            "https://cdn.cnn.com/cnnnext/dam/assets/201201143231-01-trump-1126-exlarge-169.jpg",
            "https://c.files.bbci.co.uk/BFAC/production/_115586094_trumptweets2.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_gS_O/yHsCDV.jpeg?fl=cro,1,0,1278,719%7Cres,1200,,1%7Cwebp,75",
            "https://img.cncenter.cz/img/11/normal690/6598903_usa-koronavirus-donald-trump-v4.jpg?v=4",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/images/59b1b1750ec2d240edf1e0eacf5bf9d4.jpeg?itok=jiOoOP8O",
            "https://www.barrandov.tv/obrazek/202008/5f364f959ae9b/crop-359723-depositphotos-387903548-s-2019_958x540.jpg",
            "https://pyxis.nymag.com/v1/imgs/666/4a5/bd0da1e327923361c8e667c0b3efb2dd9b-trump-michael-flynn-white-house.rsquare.w1200.jpg",
            "https://cdn.cnn.com/cnnnext/dam/assets/201216111257-trump-1212-large-169.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/images/cb48cf064e94dd49e58335c18c749dd5.jpg?itok=vaglDJmJ",
            "https://media.vanityfair.com/photos/5fbaa4624af36777a7346a25/master/pass/Donald-Trump.jpg",
            "https://d39-a.sdn.cz/d_39/c_img_QQ_T/CS0FG.jpeg?fl=cro,1,0,1313,739%7Cres,1200,,1%7Cwebp,75",
            "https://cdn.xsd.cz/resize/1605adb1f2653f0db21f5dd92d1508f2_extract=18,0,1948,1096_resize=680,383_.jpg?hash=2986bbf55d50c9b561b902c067eaa37c",
            "https://static.novydenik.com/2020/09/2020-08-13T160200Z_1925789400_RC24DI9OTR0X_RTRMADP_3_ISRAEL-EMIRATES-TRUMP-kushner-ozn%C3%A1men%C3%AD-dohody-Izrael-SAE-UAE-2.jpg",
            "https://d39-a.sdn.cz/d_39/c_img_QK_S/YkVj.jpeg?fl=cro,0,0,1920,1080%7Cres,1200,,1%7Cwebp,75",
            "https://bostonglobe-prod.cdn.arcpublishing.com/resizer/3l8Z6jqbNEMuDKXuUvNCblKmWAo=/1440x0/filters:focal(1050x240:1060x230)/cloudfront-us-east-1.images.arcpublishing.com/bostonglobe/3I5REI3PRM6ZLMOPNMG3ITYCWI.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_H_E/3saTkZ.jpeg?fl=cro,1,0,1278,719%7Cres,1200,,1%7Cwebp,75",
            "https://c.files.bbci.co.uk/3137/production/_115099521_hi061644034.jpg",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_horizontal/public/2476137-trumpbiden.jpg?itok=xuvAP0oP",
            "https://static01.nyt.com/images/2020/12/12/nyregion/11nytrump-vance1/11nytrump-vance1-superJumbo.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/trump_rouska_201006-135935_eku.JPG?itok=xV5vzPyk",
            "https://img.ihned.cz/attachment.php/500/75066500/IfDCtSlBA0iaVEgpHRL27J4FGrdwPhxQ/jarvis_5eef8f98498e40c80cd5f575.jpg",
            "https://www.barrandov.tv/obrazek/202010/5f8967cea7d98/crop-370012-donald-trump-1-facebook_947x533.jpg",
            "https://img.cncenter.cz/img/11/normal690/6582985_donald-trump-melanie-trump-melanie-trumpova-v0.jpg?v=0",
            "https://d15-a.sdn.cz/d_15/c_img_H_E/9MyQjd.jpeg?fl=cro,0,0,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/2020-10-10t191422z_1_201010-213000_jgr.JPG?itok=ifnKHUti",
            "https://m.dw.com/image/55598269_401.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQJK_TqJAdZh_lcmWx6EgY2sprpRaWMbI20Bg&usqp=CAU",
            "https://storage.googleapis.com/businessinfo_cz/2019/12/0e0f7744-donald-trump-shutterstock_677261236-scaled.jpg",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/file-video_16x9/public/images/2500170-2020-10-02t062850z_69093635_rc26aj9z8c9w_rtrmadp_3_health-coronavirus-usa-trump.jpg?itok=olwaj1DR",
            "https://www.barrandov.tv/obrazek/201912/5e05d4adc9ea5/crop-313221-f201912240565401_640x360.jpeg",
            "https://g.denik.cz/1/4d/trump-ma-mirne-priznaky-covidu-19-preventivne-bude-v-nemocnici_denik-320-16x9.jpg",
            "https://cdn.xsd.cz/resize/2ae29aabdaae3b108048b849313b2a48_extract=63,0,1961,1103_resize=680,383_.jpg?hash=067f8106b4e343400fa2c3fbd3b6fb53",
            "https://static01.nyt.com/newsgraphics/2019/08/01/candidate-pages/3b31eab6a3fd70444f76f133924ae4317567b2b5/trump.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_gU_P/hIFEeO.jpeg?fl=cro,1,0,1278,719%7Cres,1200,,1%7Cwebp,75"
        };

        [Command("trump")]
        [Alias("trumpeta", "trumpík", "trumpik", "donald")]
        public async Task Trumpoulina()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some Trumpeta**");
                ovcak.WithImageUrl(url[ovce]);
                Console.WriteLine(ovce);
                ovcak.WithColor(Color.Red);
                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("/Já nikdy neodstoupím/ exprezident od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("trump: " + url[ovce]);
            }
        }
    }
}
