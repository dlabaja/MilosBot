using Discord;
using Discord.Commands;
using MilošBot.Extensions;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Podnikatele : ModuleBase<SocketCommandContext>
    {
        private static readonly string[] urlGates = new[]
        {
        "https://cdn.forbesmedia.cz/images/eyJ1IjoiXC91cGxvYWRzXC8yMDIwXC8wM1wvYmlsbC5qcGciLCJ3IjoxMjMwLCJ2IjoiMS4wIn0%3D.jpg",
        "https://upload.wikimedia.org/wikipedia/commons/1/19/Bill_Gates_June_2015.jpg",
        "https://www.barrandov.tv/obrazek/202004/5ea412642aab9/crop-339886-p201901220888401_960x540.jpeg",
        "https://www.euro.cz/wp-content/uploads/2020/09/profimedia-0368846910-768x511.jpg",
        "https://cdn.forbesmedia.cz/images/eyJ1IjoiXC91cGxvYWRzXC8yMDIwXC8wOVwvYmlsbC1nYXRlcy0xLmpwZyIsInciOjQ0MCwidiI6IjEuMCJ9.jpg",
        "https://img.cncenter.cz/img/11/normal690/5474029_miliardari-majetek-chudoba-dane-oxfam-v0.jpg?v=0",
        "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/2018-04-21t174519z_2_181017-133525_rez.jpg?itok=c49qknIL",
        "https://img.ihned.cz/attachment.php/120/74670120/NHp5fu4bMI9ntsVUD8jJKFSPE7ByeWQz/0228FW1_CHINA-HEALTH-GATES_0228_11.jpg",
        "https://d39-a.sdn.cz/d_39/c_img_QJ_H/xd3V.jpeg?fl=cro,0,40,1280,720%7Cres,1200,,1%7Cwebp,75",
        "https://www.europarl.europa.eu/resources/library/images/20181018PHT16502/20181018PHT16502_original.jpg",
        "https://d15-a.sdn.cz/d_15/c_img_F_P/a8wY7R.jpeg?fl=cro,0,80,1250,703%7Cres,1200,,1%7Cwebp,75",
        "https://img.cncenter.cz/img/11/normal690/6708379_bill-gates-v0.jpg?v=0",
        "https://img.ihned.cz/attachment.php/380/49361380/cRE6ekFUBmJxngWuvrzdCf3OSoH19IhD/former-microsoft-ceo-bill-gates.jpg",
        "https://g.denik.cz/1/d0/bill-gates-f201612141245601_denik-320-16x9.jpg",
        "https://cdn.forbesmedia.cz/images/eyJ1IjoiXC91cGxvYWRzXC8yMDE5XC8wMlwvYmlsbC1nYXRlcy5qcGciLCJ3IjoxOTIwLCJ2IjoiMS4wIn0%3D.jpg",
        "https://cdr.cz/sites/default/files/bill-gates-5.jpg",
        "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_horizontal/public/images/2435766-2019-11-21t102437z_1483695636_rc2mfd9ynuh8_rtrmadp_3_china-economy.jpg?itok=aqkmYRnz",
        "https://www.czechcrunch.cz/wp-content/uploads/2019/06/bill-gates-3-820x436.jpg",
        "https://hlidacipes.org/wp-content/uploads/2020/07/bill-gates-1051x500.jpg",
        "https://d15-a.sdn.cz/d_15/c_img_H_E/IX3Yul.jpeg?fl=cro,0,67,1280,720%7Cres,1200,,1%7Cwebp,75",
        "https://d39-a.sdn.cz/d_39/c_img_QL_F/zooP.jpeg?fl=cro,28,0,715,402%7Cres,1200,,1%7Cwebp,75",
        "https://i.iinfo.cz/images/569/andrej-babis-a-bill-gates-1-thumb.jpg",
        "https://cdn.forbesmedia.cz/images/eyJ1IjoiXC91cGxvYWRzXC8yMDIwXC8wNVwvZ2F0ZXNvdnkta25paHkuanBnIiwidyI6MTIzMCwidiI6IjEuMCJ9.jpg",
        "https://img.ihned.cz/attachment.php/850/50294850/pCFb1mwhdu2B9rzMejOotW8nyxQA0vka/01_Bill_Gates.jpg",
        "https://pi.tedcdn.com/r/pe.tedcdn.com/images/ted/2c60223169fd66d3962f9f3c354081824d2914c5_2880x1620.jpg?c=1050%2C550&w=1050",
        "https://cdn.xsd.cz/resize/6ec275829b583bd2b2e9e89b1f50dfad_extract=83,0,800,450_resize=680,383_.jpg?hash=a8f685e772b29b9801cb4b4c1876318b",
        "http://www.hybrid.cz/i/auto/bill-gates-prvni-elektromobil-porsche-taycan.jpg",
        "https://d15-a.sdn.cz/d_15/c_img_E_I/ScqlKq.jpeg?fl=cro,136,0,1144,643%7Cres,1200,,1%7Cwebp,75",
        "https://cdn.24net.cz/1/obrazek/ikonka-266190/620w",
        "https://www.businessanimals.cz/wp-content/uploads/2018/07/Bill_Gates_2013.jpg",
        "https://data.computerworld.cz/img/article_title/title_l/8d/c663562fd82d7d6c539d2ddcae6afd.jpg",
        "https://img.cncenter.cz/img/11/normal690/5482605_summit-davos-bill-gates-v0.jpg?v=0",
        "https://www.muzivcesku.cz/wp-content/uploads/2020/04/bill-gates-coronavirus-covid-19.jpg",
        "https://g.denik.cz/1/3e/bill-gates-v-davos-01_galerie-980.jpg",
        "https://cdn.administrace.tv/2021/01/17/mini_21/cf8a4667444bfbc43ed6d9cf7aad93e4.jpg",
        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT4BsF8phrzxZAAMt65Ha4ji6uvdtadsXgbEw&usqp=CAU",
        "https://ichef.bbci.co.uk/images/ic/400xn/p08rhvfr.jpg¨",
        "https://diit.cz/sites/default/files/bill_gates_covid.jpg",
        "https://www.euro.cz/wp-content/uploads/2019/09/bill-gates-ilustrac48dnc3ad-foto.jpg",
        "https://www.yookee.cz/wp-content/uploads/2021/01/bill-gates3-1024x576.png",
        "https://backend.elektrickevozy.cz/wp-content/uploads/2020/02/bill-gates-taycan.jpg",
        "https://cdn.xsd.cz/resize/d6fd29019370389b8f0c32f8ea90bd86_resize=1500,1001_.jpg?hash=47455feb1da59b5cea02e7071cfa576e",
        "https://www.letemsvetemapplem.eu/wp-content/uploads/2017/07/sad-bill-gates.jpg",
        "https://m.zive.cz/getthumbnail.aspx?w=612&h=250&q=60&id_file=440009045",
        "https://upload.wikimedia.org/wikipedia/commons/c/ce/Bill_Gates_in_WEF%2C_2007.jpg",
        "https://www.peak.cz/wp-content/uploads/2016/12/bill-gates-energetika.jpg",
        "https://envivo.bancomundial.org/sites/default/files/styles/focal_point_bio_detail/public/experts/billgates.jpg?itok=D3UPRJ3R",
        "https://m.vtm.zive.cz/getthumbnail.aspx?w=612&h=250&q=60&id_file=738615521",
        "https://img.cncenter.cz/img/11/normal690/2831643_bill-gates-v2.jpg?v=2",
        };

        [Command("billgates")]
        [Alias("bill", "gates", "minecrosoft")]
        public async Task GatesAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Čipovač vakcín**",
                Color = Color.Red,
                ImageUrl = urlGates.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Velká firma = velké jmění MilošBota",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());

            var cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("Gates: " + eb.ImageUrl);
        }

        private static readonly string[] urlJobs = new[]
        {
            "https://cdn.24net.cz/1/obrazek/ikonka-307000",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/5/54/Steve_Jobs.jpg/1200px-Steve_Jobs.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dc/Steve_Jobs_Headshot_2010-CROP_%28cropped_2%29.jpg/1200px-Steve_Jobs_Headshot_2010-CROP_%28cropped_2%29.jpg",
            "https://www.biography.com/.image/ar_1:1%2Cc_fill%2Ccs_srgb%2Cg_face%2Cq_auto:good%2Cw_300/MTY2MzU3OTcxMTUwODQxNTM1/steve-jobs--david-paul-morrisbloomberg-via-getty-images.jpg",
            "https://i.imgur.com/GGv7DxP.jpg",
            "https://jablickar.cz/wp-content/uploads/2019/11/Steve-Jobs-Apple-logo.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/5/58/Stevejobs_Macworld2005.jpg",
            "https://www.ceskymac.cz/wp-content/uploads/2016/09/%C3%BAvodn%C3%AD.jpeg",
            "https://1gr.cz/fotky/idnes/11/121/vidw/JUP3fa535_steve_jobs_cover.jpg",
            "https://jablickar.cz/wp-content/uploads/2018/03/Steve-Jobs-introduces-iPad-zdroj-LIfewire.jpg",
            "https://www.businessanimals.cz/wp-content/uploads/2014/07/steve.jpg",
            "https://g.cz/sites/default/files/styles/gflex_landscape_large/public/field/image/2019/universal_0.png?itok=pe4SJdCB",
            "https://www.czechcrunch.cz/wp-content/uploads/2017/03/Steve_Jobs_at_Apple_iPad_Event.jpg",
            "https://g.cz/sites/default/files/styles/gflex_landscape_large/public/field/image/2021/steve_jobs.jpg?itok=LuyOdxDY",
            "https://www.zive.cz/getthumbnail.aspx?w=20000&h=20000&q=100&id_file=320552105",
            "https://thumbor.forbes.com/thumbor/fit-in/416x416/filters%3Aformat%28jpg%29/https%3A%2F%2Fspecials-images.forbesimg.com%2Fimageserve%2F5b8576db31358e0429c734e3%2F0x0.jpg%3Fbackground%3D000000%26cropX1%3D211%26cropX2%3D2381%26cropY1%3D900%26cropY2%3D3072",
            "https://www.incimages.com/uploaded_files/image/1920x1080/getty_96211512_200014742000928041_418201.jpg",
            "https://images.theconversation.com/files/693/original/aapone-20110118000290280654-file_usa_apple_steve_jobs-original.jpg?ixlib=rb-1.1.0&q=45&auto=format&w=926&fit=clip",
            "https://www.incimages.com/uploaded_files/image/1920x1080/getty_96211011_2000134813806405780_414357.jpg",
            "https://i2.wp.com/rayhaber.com/wp-content/uploads/2020/10/steve-jobs-kimdir.jpg?fit=1424%2C800&ssl=1",
            "https://image.cnbcfm.com/api/v1/image/104556423-steve-jobs-iphone-10-years.jpg?v=1532563811",
            "https://i1.wp.com/oslik.files.wordpress.com/2008/11/jobs_iphone_macworld_expo_2007.jpg",
            "https://img.ihned.cz/attachment.php/570/73227570/cspSBxnK8TItE6Vhjye1uzLa4RACl3iO/SJ_2.jpg",
            "https://s.france24.com/media/display/bb370f84-09f3-11e9-81ac-005056a964fe/w:1280/p:16x9/ipad-jobs_1.webp",
            "https://d62-a.sdn.cz/d_62/c_img_F_D/sg4CB5/steve-jobs.jpeg?fl=cro,0,115,1800,1013%7Cres,1200,,1%7Cwebp,75",
            "https://www.extra.cz/images/thumbs/10/83/1083c26-63296-2-0d0020000-0d0333333-0d9800000-0d8666667-sector_740x416-crop.jpg",
            "https://www.autoforum.cz/tmp/magazin/sn/Steve_Jobs_iPhone.jpg",
            "https://www.letemsvetemapplem.eu/wp-content/uploads/2017/10/Steve-Jobs-finger-FB.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQVr89zO3lMfWO2tEHmnHvc6etoJWPXwhCUJA&usqp=CAU",
            "https://g.denik.cz/1/31/ctk_svevejobs_apple_denik-320-16x9.jpg",
            "https://cms.qz.com/wp-content/uploads/2019/03/AP_070109057953.jpg?quality=75&strip=all&w=1600&h=900&crop=1",
            "https://lh3.googleusercontent.com/proxy/j9mRYGwIdh9JbxlM_rGXMYTEXXEOOPrlcwFtc7awx1Z3REeEQng7HeHD0qOmDAC8eo_MmVsFD1z9S7DF7QXjOuU7wsWiu-8hEO64a9Pvihi8Y4EP8jZb4Px7_clmsTEDHI-I9MA",
            "https://i.insider.com/56fd87d6918a0fd2443cf1de?width=1136&format=jpeg",
            "https://d15-a.sdn.cz/d_15/c_img_E_E/P4m7Iq.jpeg?fl=cro,0,61,800,450%7Cres,1200,,1%7Cwebp,75",
        };

        [Command("stevejobs")]
        [Alias("jobs", "steve", "apple")]
        public async Task JobsAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Jablíčkář**",
                Color = Color.Red,
                ImageUrl = urlJobs.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Apple be like od MilošBota",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());

            var cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("Jobs: " + eb.ImageUrl);
        }

        private static readonly string[] urlMusk = new[]
        {
            "https://upload.wikimedia.org/wikipedia/commons/8/85/Elon_Musk_Royal_Society_%28crop1%29.jpg",
            "https://assets.entrepreneur.com/content/3x2/2000/1612304478-20200212181203-elon-musk-hero.jpg",
            "https://thumbor.forbes.com/thumbor/fit-in/416x416/filters%3Aformat%28jpg%29/https%3A%2F%2Fspecials-images.forbesimg.com%2Fimageserve%2F5f47d4de7637290765bce495%2F0x0.jpg%3Fbackground%3D000000%26cropX1%3D1398%26cropX2%3D3908%26cropY1%3D594%26cropY2%3D3102",
            "https://cdn.vox-cdn.com/thumbor/nDW7YqKV8soKsZSfRorGXJLSH50=/1400x1400/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/22147179/1229892934.jpg",
            "https://cdn.forbesmedia.cz/images/eyJ1IjoiXC91cGxvYWRzXC8yMDIwXC8wN1wvZWxvbi1tdXNrLmpwZyIsInciOjEyMzAsInYiOiIxLjAifQ%3D%3D.jpg",
            "https://images.mktw.net/im-293489?width=620&size=1.452894438138479",
            "https://c.ndtvimg.com/2021-01/1ade279g_elon-musk-reuters_625x300_22_January_21.jpg",
            "https://cdn.vox-cdn.com/thumbor/4QtOwnOxCdwESvt1-CpQSTZvHHA=/1400x1400/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/19932738/1206292068.jpg.jpg",
            "https://images.mktw.net/im-294744?width=620&size=1.5005861664712778",
            "https://static01.nyt.com/images/2021/01/07/business/07econ-briefing-musk/07econ-briefing-musk-mediumSquareAt3X.jpg",
            "https://www.ctvnews.ca/polopoly_fs/1.5295422.1612447854!/httpImage/image.jpg_gen/derivatives/landscape_1020/image.jpg",
            "https://pyxis.nymag.com/v1/imgs/e0e/11b/93a73ed12f25f2fdcc4f5473fc9460a2ff-elon-musk.rsquare.w1200.jpg",
            "https://specials-images.forbesimg.com/imageserve/601a9cd20478f8d2047cdbdd/960x0.jpg?fit=scale",
            "https://www.gannett-cdn.com/media/2020/11/30/USATODAY/usatsports/imageForEntry29-u2e.jpg?width=660&height=372&fit=crop&format=pjpg&auto=webp",
            "https://images.mktw.net/im-283726?width=620&size=1.5005861664712778",
            "https://content.fortune.com/wp-content/uploads/2020/11/BPO01.21.gettyimages-1183851343-2048x2048-1.jpg",
            "https://cnet3.cbsistatic.com/img/DUIHQNk9-GrJShDOcpJQnH2WmSI=/940x0/2021/02/01/6ce897c6-0759-4d29-bbda-a30020420259/latemusk.jpg",
            "https://cdn.cnn.com/cnnnext/dam/assets/190319115821-20190319-elon-musk-large-169.jpg",
            "https://cdn.vox-cdn.com/thumbor/qVjMPtyFVT5Dtwl_jSOCj4Y33TM=/1400x1400/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/15980837/elon_musk_tesla_3036.jpg",
            "https://d39-a.sdn.cz/d_39/c_img_gS_L/8dUBN.jpeg?fl=cro,0,339,2048,1152%7Cres,1200,,1%7Cwebp,75",
            "https://static01.nyt.com/images/2019/11/01/multimedia/01xp-elonmusk/merlin_162496989_edfc836d-1bcf-45b1-8c42-68eaaac5d1de-superJumbo.jpg",
            "https://cdn.britannica.com/54/188754-050-A3613741/Elon-Musk-2010.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTW0ejNaoQQ2wvOAAYL3iJw9y2OTQKwDYwctw&usqp=CAU",
            "https://i.insider.com/5fd3e725e00bce00188baf80?width=700",
            "https://www.forum24.cz/wp-content/uploads/2020/12/ElonMusk_Kryptomagazin-1536x1024-1-850x480-1612207433.jpg",
            "https://s.yimg.com/ny/api/res/1.2/2v.EDriQ4dF1TUK2ihLbFw--/YXBwaWQ9aGlnaGxhbmRlcjt3PTk2MDtoPTY1NS40MTY5MjQwMjcxNzcz/https://s.yimg.com/os/creatr-uploaded-images/2021-01/d03f25e0-550c-11eb-be63-01440bda8429",
            "https://i.guim.co.uk/img/media/a780dcfc2d38935ab11a034b49fc83cf616a1d93/0_90_5284_3173/master/5284.jpg?width=445&quality=45&auto=format&fit=max&dpr=2&s=632b1db5bc5e0daaf6e85e737adb5c1e",
            "https://media.beam.usnews.com/d1/d8/8501ba714a21aed9a7327e02ade1/180515-10thingselonmusk-editorial.jpg",
            "https://cdn.vox-cdn.com/thumbor/igbYazFaVO2_XZDhv0ARbAU93bM=/1400x1400/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/19819160/1206292069.jpg.jpg",
            "https://s.yimg.com/ny/api/res/1.2/BoDcFJEF5vIQiE13QQyqMg--/YXBwaWQ9aGlnaGxhbmRlcjt3PTk2MDtoPTY0MA--/https://s.yimg.com/os/creatr-uploaded-images/2021-02/bf0e35b0-65a9-11eb-9dbe-3e2f8d0b2925",
            "https://backend.elektrickevozy.cz/wp-content/uploads/2021/01/elon-musk-1.jpg",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_horizontal/public/images/2210870-rtx4rl3z.jpg?itok=2e2m4GzT",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSX0a4CzbsjBHvdRLUBFVJUpvHz1YejBJljsQ&usqp=CAU",
            "https://image.cnbcfm.com/api/v1/image/105773423-1551716977818rtx6p9yw.jpg?v=1551717428",
            "https://m.economictimes.com/thumb/msid-80688125,width-1599,height-1061,resizemode-4,imgsize-46330/elon-musk.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTKKe-CP55y3PLD5Xcs-lTsWqjZqHZtKfxS6A&usqp=CAU",
            "https://d62-a.sdn.cz/d_62/c_img_F_G/KqpGO/Elon-Musk.jpeg",
            "https://media.vanityfair.com/photos/5f17314841790f180644c117/2:3/w_1481,h_2222,c_limit/ElonMusk-2020-GettyImages-930533866.jpg",
            "https://m.dw.com/image/52062541_401.jpg",
            "https://m.economictimes.com/thumb/msid-79255769,width-1200,height-900,resizemode-4,imgsize-601818/elon-musk.jpg",
            "https://cdn.theatlantic.com/thumbor/Mz06foswgJ8lWZXa6CVfnkpGwkQ=/0x803:5463x3648/960x500/https://cdn.theatlantic.com/assets/media/img/mt/2020/06/Win_McNamee_Getty/original.jpg",
            "https://ca-times.brightspotcdn.com/dims4/default/21acf7c/2147483647/strip/true/crop/3000x2194+0+0/resize/1486x1087!/quality/90/?url=https%3A%2F%2Fcalifornia-times-brightspot.s3.amazonaws.com%2F97%2Fcc%2F89cd824a410aa1be98eecbe703d1%2Fapphoto-elon-musk-lawsuit.JPG",
            "https://www.gannett-cdn.com/presto/2019/08/18/USAT/adad9ebd-0eea-4d46-aa29-0f1087d3a5f7-AFP_AFP_1IU935.JPG?width=660&height=401&fit=crop&format=pjpg&auto=webp",
            "https://cdn.britannica.com/s:250x250,c:crop/88/154388-050-11BCAE3C/CEO-Elon-Musk-SpaceX-car.jpg",
            "https://i.ytimg.com/vi/zIwLWfaAg-8/maxresdefault.jpg",
        };

        [Command("musk")]
        [Alias("ellon", "vesmir", "tesla")]
        public async Task MuskAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some IRL kerbal engineer?**",
                Color = Color.Red,
                ImageUrl = urlMusk.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Nejzajímavější podnikatel světa od MilošBota",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());

            var cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("musk: " + eb.ImageUrl);
        }

        private readonly static string[] urlZuckerberg = new[]
        {
            "https://thumbor.forbes.com/thumbor/fit-in/416x416/filters%3Aformat%28jpg%29/https%3A%2F%2Fspecials-images.forbesimg.com%2Fimageserve%2F5c76b7d331358e35dd2773a9%2F0x0.jpg%3Fbackground%3D000000%26cropX1%3D0%26cropX2%3D4401%26cropY1%3D0%26cropY2%3D4401",
            "https://www.biography.com/.image/ar_1:1%2Cc_fill%2Ccs_srgb%2Cfl_progressive%2Cq_auto:good%2Cw_1200/MTQyMDA0NDgwMzUzNzcyNjA2/mark-zuckerberg_gettyimages-512304736jpg.jpg",
            "https://media.npr.org/assets/img/2018/11/21/gettyimages-962142720-3f4af695a639cbc14deb90e88287cd3c19b676f4-s800-c85.jpg",
            "https://static01.nyt.com/images/2020/11/17/business/17techhearing-facebookpreview/merlin_163192374_92604511-ae28-43ba-8d7f-d3fbdae53e01-mobileMasterAt3x.jpg",
            "https://i.insider.com/5d84ce522e22af4c215743c6?width=1136&format=jpeg",
            "https://www.incimages.com/uploaded_files/image/1920x1080/GettyImages-1201476988_448569.jpg",
            "https://cdn.britannica.com/54/187354-050-BE0530AF/Mark-Zuckerberg.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/3/31/Mark_Zuckerberg_at_the_37th_G8_Summit_in_Deauville_018_v1.jpg",
            "https://www.californiamuseum.org/sites/main/files/imagecache/medium/main-images/screen_shot_2012-07-27_at_6.32.28_pm.png?1578063880",
            "https://img.ihned.cz/attachment.php/130/71238130/apgCBQ20kiVbFDGrUMf4SjK1ydcwHn7L/P201804110962601.jpg",
            "https://i.guim.co.uk/img/static/sys-images/Guardian/Pix/pictures/2014/11/8/1415445010984/Mark-Zuckerberg-012.jpg?width=445&quality=45&auto=format&fit=max&dpr=2&s=7c021d42242605824b6c267faf400a50",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQrV3wcIR6fjQeWpVRi8XIRZxHKoA5VPKRSg&usqp=CAU¨",
            "https://thumbor.forbes.com/thumbor/960x0/https%3A%2F%2Fblogs-images.forbes.com%2Fbriansolomon%2Ffiles%2F2016%2F04%2Fmark-zuckerberg.jpg",
            "https://static.theceomagazine.net/wp-content/uploads/2018/07/09100940/Cover-story_Zuckerberg_AU0818.jpg",
            "https://cdn.i-scmp.com/sites/default/files/styles/1920x1080/public/d8/images/methode/2020/02/03/7ffc02a0-432a-11ea-9fd9-ecfbb38a9743_image_hires_115830.jpeg?itok=E3rd9X6j&v=1580702317",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQstD7ScUjR-REeP0kCojmj8_UlPswR1z7wGg&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ56g7hYxe_ULnsCbEq3-w8zCcxk-7xD0pN2Q&usqp=CAU",
            "https://www.czechcrunch.cz/wp-content/uploads/2015/11/mark-820x436.png",
            "https://www.thetimes.co.uk/imageserver/image/%2Fmethode%2Ftimes%2Fprod%2Fweb%2Fbin%2F5875a7e8-5109-11eb-ad71-ea6bb4a570af.jpg?crop=4152%2C2768%2C0%2C0",
            "https://m.economictimes.com/thumb/msid-69050789,width-1200,height-900,resizemode-4,imgsize-584523/unprofitable-whatsapp-may-hit-facebooks-profitable-apps-mark-zuckerberg.jpg",
            "https://imagez.tmz.com/image/30/4by3/2020/05/13/3063f748ce324bf6be94652f4645f004_md.jpg",
            "https://res-4.cloudinary.com/crunchbase-production/image/upload/c_thumb,h_170,w_170,f_auto,g_faces,z_0.7,b_white,q_auto:eco/v1448830269/gzcifut4c2xah95x0ewd.jpg",
            "https://c.files.bbci.co.uk/1090A/production/_113205876_zuckneon.png",
            "https://media4.s-nbcnews.com/j/newscms/2018_45/2456801/180606-mark-zuckerberg-se-3221p_bb99e5f9cd63bddb4392bf22625a2998.nbcnews-fp-1200-630.JPG",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRx2mODY9Mt17aZQ3xltTwlYj7Kwh400xyYEQ&usqp=CAU",
            "https://www.czechcrunch.cz/wp-content/uploads/2018/04/mark-820x436.jpg",
            "https://cdn.vox-cdn.com/thumbor/DSeAqRTlQwn0IoVP3j8zb79W2Qk=/1400x1400/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/8348857/511573652.jpg",
            "https://static.toiimg.com/thumb/msid-79073934,width-1070,height-580,imgsize-120212,resizemode-75,overlay-toi_sw,pt-32,y_pad-40/photo.jpg",
            "https://i.gadgets360cdn.com/large/mark_zuckerberg_reuters_full_1570166841662.JPG",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQD-q3ihI_nDwCFaKxcXG1xMHG5tsVEpJePjA&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHlmKKqW1IpVITXx5PTHX_AKmV6qea7MCEgA&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSMqBkTXbp2MO3PL5CEJZl3wlACk6wA6X9dMQ&usqp=CAU",
            "https://static.politico.com/dims4/default/c63280a/2147483647/resize/1160x%3E/quality/90/?url=https%3A%2F%2Fstatic.politico.com%2Fd4%2F67%2F295d35ac4751a6ab803e8c7bfcc7%2F200626-zuckerberg-gty-773.jpg",
            "https://www.telegraph.co.uk/content/dam/technology/2016/06/06/97592784-zuckerberg-tech_trans_NvBQzQNjv4BqI0P8f9bO4E3qjnGDTmoejZmAcdQ7jx2xxRjqAC1pdgY.jpg",
            "https://www.telegraph.co.uk/content/dam/technology/2016/06/06/97592784-zuckerberg-tech_trans_NvBQzQNjv4BqI0P8f9bO4E3qjnGDTmoejZmAcdQ7jx2xxRjqAC1pdgY.jpg",
            "https://i.guim.co.uk/img/media/ce033b7b8568d45c134e5c80c54a13c9e40add23/0_135_3000_1799/master/3000.jpg?width=1200&height=1200&quality=85&auto=format&fit=crop&s=83af2a105c41eb474388a932d99d0527",
        };

        [Command("facebook")]
        [Alias("zuckerberg", "mark")]
        public async Task ZuckerbergAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Mark**",
                Color = Color.Red,
                ImageUrl = urlZuckerberg.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Vaše osobní data jsou v bezpečí... možná xd  od MilošBota",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());

            var cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("zuckerberg: " + eb.ImageUrl);
        }
    }
}
