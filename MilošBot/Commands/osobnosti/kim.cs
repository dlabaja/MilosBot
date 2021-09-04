using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class kimik : ModuleBase<SocketCommandContext>
    {
        List<string> url = new List<string>()
        {
            "https://cdn.xsd.cz/original/73f2e87b804e3811b61c544bf4feb589.jpg",
            "https://cdn.xsd.cz/resize/6dbbfc8b1fd3369e8937b8c10ee07720_resize=680,383_.jpg?hash=ecbf9d7f95926b8b4cfa802ba2a755f1",
            "https://img.cncenter.cz/img/11/normal690/6393549_kim-cong-un-kldr-v0.jpg?v=0",
            "https://img.cz.prg.cmestatic.com/media/images/original/Sep2020/2422530.jpg?e9db",
            "https://www.forum24.cz/wp-content/uploads/2016/06/Kim-%C4%8Cong-un.jpg",
            "https://echo24.cz/img/5eac9d37ffd8581612b9d20e/1180/614?_sig=6JazHGLD_9agEokHXlJJnhe5vRzPfifPa2lffuwP0ms",
            "https://img.ihned.cz/attachment.php/200/74860200/dptr4yNeM6PiwhBcsDqgR2am0ubTVx1I/jarvis_5cc0a36b498e11e9de3ce86d.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/2018-01-01t045529z_1_180101-074255_mis.jpg?itok=StxHaeQC",
            "https://cdn.xsd.cz/resize/f24cb35602a23608b0652e97f5367b91_resize=680,383_.jpg?hash=e0a63522f2633a4cde2fa3fbf18ea348",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/file-video_16x9/public/images/1811258-2016-09-13t085304z_562810860_s1beubanpgaa_rtrmadp_3_northkorea-politics.jpg?itok=h_OPaBk2",
            "https://img.cncenter.cz/img/3/full/4944562-img-mezikorejsky-summit-kim-cong-un-mun-ce-in-ochranka-v0.jpg?v=0",
            "https://servis.idnes.cz/fbimg.aspx?foto=ERT6da1af_profimedia_0335966048.jpg&c=A170829_104640_zahranicni_ert",
            "https://g.denik.cz/111/b2/kimcongunkure_dotyk-400-16x9.jpg",
            "https://g.denik.cz/1/c3/kim-cong-un-kim-jo-cong_denik-320-16x9.jpg",
            "https://img.cz.prg.cmestatic.com/media/images/original/May2016/1869940.jpg?d41d",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRmIJYx-LIRJ9ZpDlG4UbEoD1W0rLCLm5zhkA&usqp=CAU",
            "https://www.extra.cz/images/thumbs/da/5b/da5b8a6-265672-kim-0d0000000-0d0000000-1d0000000-1d0000000-sector_740x416-crop.png",
            "https://img.cncenter.cz/img/11/normal690/6568488_kldr-jizni-korea-kim-ranni-prehled-v0.jpg?v=0",
            "https://g.denik.cz/1/43/americky-prezident-trump-privital-ze-se-vudce-kldr-kim-cong-un-po-tydnech-znovu-objevil-na_denik-320-16x9.jpg",
            "https://t.aimg.sk/magaziny/rUUF5N90TqCu45dEh1AJcw.1280~Vodca-K-DR-Kim-ong-Un.jpg?t=LzB4NDk6MTI4MHg3NjgvODAweDQ1MC9zbWFydA%3D%3D&h=nvrVHaglK_FbiHaWJxA_Cw&e=2145916800&v=5",
        };

        [Command("kimík")]
        [Alias("Un", "čong", "kldr", "kim")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some Velevůdce **");
                ovcak.WithImageUrl(url[ovce]);

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Lidé nemají hlad, říká sám stopadesátikilový Kim při vojenské předlídce...  od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());


                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("Kimík: " + url[ovce]);
            }
        }
    }
}