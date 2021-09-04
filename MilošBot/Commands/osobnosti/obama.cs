using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class obama : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8d/President_Barack_Obama.jpg/1200px-President_Barack_Obama.jpg",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_horizontal/public/images/2443256-2020-04-14t165112z_1311755908_rc2g4g995qrq_rtrmadp_3_usa-election-obama.jpg?itok=c6WT9V-h",
            "https://bostonglobe-prod.cdn.arcpublishing.com/resizer/lK67MLqx5xp3iH4yfDGw4QN_534=/1440x0/cloudfront-us-east-1.images.arcpublishing.com/bostonglobe/QKQUAZDGVO7GXVUP7TOZSRDEOY.jpg",
            "https://s.france24.com/media/display/3230a2b4-97f9-11ea-96e4-005056bf18d4/w:1280/p:16x9/063_1225292516.webp",
            "https://s.abcnews.com/images/Politics/200819_abcnl_dnc3_obama_hpMain_16x9_992.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_E_D/7b8BqlO.jpeg?fl=cro,0,41,800,450%7Cres,1200,,1%7Cwebp,75",
            "https://argo.cz/wp-content/uploads/2020/10/xUnder-4MBs_BarackObama_20190417_WashingtonDC_CrownPublishingGroup_Photo-PariDukovic_Usage4_1154-cropped_webx.jpg",
            "https://static01.nyt.com/images/2019/11/15/us/politics/15obama-abrams/merlin_163543902_077e4a4e-e58b-43f4-89f3-4602c2aa6e64-superJumbo.jpg",
            "https://dayton247now.com/resources/media2/16x9/full/1015/center/80/3ef32932-86e7-453b-8c01-a585ff036753-large16x9_Trump_Warw.jpg",
            "https://cdn.xsd.cz/resize/e8484398981935da86bee7bfc37c29e1_resize=680,383_.jpg?hash=fed284640c0f7662525dfb6a78c186f9",
            "https://static.politico.com/c0/b2/a9fc15064ee1bfdc2a5175128beb/200409-obama-getty-773.jpg¨",
            "https://api.time.com/wp-content/uploads/2017/12/barack-obama.jpeg",
            "https://media.newyorker.com/photos/5f94685ed2318879f732a52b/master/pass/Remnick-Obama.jpg",
            "https://www.usnews.com/dims4/USNEWS/5bf4a8a/2147483647/thumbnail/640x420/quality/85/?url=http%3A%2F%2Fmedia.beam.usnews.com%2Fae%2Fdb%2F2e552d164703bab229e532734ee4%2F171108-10thingsobama-editorial.jpg",
            "https://cdn.britannica.com/s:800x450,c:crop/43/172743-138-545C299D/overview-Barack-Obama.jpg",
            "https://cdn.xsd.cz/resize/c28a3e55c45d3452a2065b474d3cf1b4_extract=0,5,1270,713_resize=680,383_.png?hash=35a11c5e3a70acebb248fc8cce0f9df1",
            "https://upload.wikimedia.org/wikipedia/commons/1/1f/BarackObama2005portrait.jpg",
            "https://images.wsj.net/im-260560?width=620&size=1.5",
            "https://www.usnews.com/dims4/USNEWS/3d0189f/2147483647/thumbnail/640x420/quality/85/?url=http%3A%2F%2Fmedia.beam.usnews.com%2Fd8%2Fa6%2Fa3e3930d43c5b165884dee8a4147%2F200529-obama-editorial.jpg",
            "https://c.ndtvimg.com/2020-08/aqq76bgo_barack-obama-reuters_625x300_20_August_20.jpg",
            "https://www.ft.com/__origami/service/image/v2/images/raw/https%3A%2F%2Fd1e00ek4ebabms.cloudfront.net%2Fproduction%2F79b2e592-7ddf-4732-ba8f-439267f6fa82.jpg?fit=scale-down&source=next&width=700",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCZ8zTx7YF19S5c9HrYIfAaWPdKXoQqcPasQ&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSzBhAFjaslCisKvpVQ5vBmMUnWuEi9GYWRQA&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTFSrY7A9vf3c28K4TbH7y6ej5h6y41GE0KKA&usqp=CAU",
            "https://gray-wcjb-prod.cdn.arcpublishing.com/resizer/OGhRIOjWeOghcKcKGZX4k5hpN4k=/1200x675/smart/cloudfront-us-east-1.images.arcpublishing.com/gray/ARP3P2QQUFCHJDTQFAUF53RY5Y.jpg",
            "https://media.npr.org/assets/img/2020/10/16/ap_20212638905558-55093e854ba6c9d735587fccc3d65f54a6babc10-s800-c85.jpg",
            "https://www.barrandov.tv/obrazek/202005/5eba59905547b/crop-344070-f201702010519001_960x540.jpeg",
            "https://media.npr.org/assets/img/2020/11/13/ap_20305655166729-b6b27fbec7dab7de511923b260ab1a9c1fe092e9-s800-c85.jpg",
            "https://www.whitehouse.gov/wp-content/uploads/2021/01/44_barack_obama_family.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQoeUiljSFNbdWqzKyE1_5KuoKIq8FdgNq4Lg&usqp=CAU",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e9/Official_portrait_of_Barack_Obama.jpg/1200px-Official_portrait_of_Barack_Obama.jpg",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_horizontal/public/images/2172055-2018-09-07t170828z_2114039114_rc1cec0e1bc0_rtrmadp_3_usa-election-obama.jpg?itok=AszuUeMn",
            "https://www.czechcrunch.cz/wp-content/uploads/2019/12/barack-obama-820x436.jpg",
            "https://media3.s-nbcnews.com/j/newscms/2020_49/3432608/2201202-barack-obama-ew-1159a_95f24d5b0393deef658690eaccc12809.fit-760w.jpg",
            "https://bostonglobe-prod.cdn.arcpublishing.com/resizer/2frt1lzZThnxFOAgWQiZ-mSRUWc=/1440x0/cloudfront-us-east-1.images.arcpublishing.com/bostonglobe/7M247MUSFUI6VE7JQG3LLB7IAA.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQhRjog5Fv-dzw80wws8bPIM2ESQN4py1TDmQ&usqp=CAU",
            "https://1gr.cz/fotky/idnes/20/052/cl5/REJ836ddc_obama_1.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_F_F/QZkBDq9.jpeg?fl=cro,0,29,800,450%7Cres,1200,,1%7Cwebp,75",
            "https://www.rollingstone.com/wp-content/uploads/2019/12/Obama.jpg",
            "https://www.aljazeera.com/wp-content/uploads/2020/11/AP_20307716623510.jpg?resize=770%2C513",
            "https://m.dw.com/image/55387320_101.jpg",
            "https://static.onecms.io/wp-content/uploads/sites/6/2020/12/15/Barack-Obama.jpg",
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/10145/production/_112216856_gettyimages-1184274010.jpg",
            "https://cdn.xsd.cz/resize/3134287873ca3a6ab239cfac58b4da9d_extract=19,0,800,450_resize=680,383_.jpg?hash=347d143946cbd1f1a9f80354a70d346b",
            "https://media3.s-nbcnews.com/j/newscms/2021_04/3445167/210126-obama-2004-convention-mn-1515_3ccabec750d2a8c4876b7b8710a7b329.fit-760w.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ2ztm5r6H9fQ9t4W_UEcxbLFcXVD49SmhuPg&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTJwBc_zkAdBHJnx-y8-qp02pVUdaTfjba7Jw&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTg7Bm6TYZD23sx4gO2wlJ1GRlXyGWEo6VoiA&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSkQKpq2xuJRWhIfpR0fh_DyunrZdwxqWV3bQ&usqp=CAU",
            "https://d15-a.sdn.cz/d_15/c_img_F_F/SExn5F.jpeg?fl=cro,0,41,800,450%7Cres,1200,,1%7Cwebp,75",
            "https://static.novydenik.com/2018/11/2018-11-02T202203Z_575763762_RC162176C710_RTRMADP_3_USA-ELECTION-OBAMA.jpg",
            "https://img.etimg.com/thumb/width-640,height-480,imgsize-566440,resizemode-1,msid-79185824/news/international/world-news/barack-obama-his-policies-and-his-posture-just-won-a-third-term/obama.jpg",
        };

        [Command("barack")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some Demokrat **");
                ovcak.WithImageUrl(url[ovce]);

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Barva kůže je jedno, důležitý je obsah hlavy... od Milošbota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("obama: " + url[ovce]);
            }
        }
    }
}