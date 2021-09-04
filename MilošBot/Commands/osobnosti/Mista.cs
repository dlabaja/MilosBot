using Discord;
using Discord.Commands;
using MilošBot.Extensions;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Mista : ModuleBase<SocketCommandContext>
    {
        private static readonly string[] urlCernobyl = new[]
        {
            "https://www.flowee.cz/images/.thumbnails/images/misa_2019/cerven/cernobyl_otv.840x540c.jpg",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/scale_1180/public/images/1733686-fo00525943.jpeg?itok=DuTRAWaD",
            "https://vedator.org/wp-content/uploads/2019/06/NOW-15-800x445.png",
            "https://www.ttg.cz/wp-content/uploads/cernobyl_2.png",
            "https://d15-a.sdn.cz/d_15/c_img_E_E/JQ033k.jpeg?fl=cro,0,0,800,450%7Cres,1200,,1%7Cwebp,75",
            "https://melnicko.cz/wp-content/uploads/2020/03/Cernobyl.jpg",
            "https://cdn.eoit.cz/filecms/kontaminovana-zona-cernobyl.jpg",
            "https://data.ceskekormidlo.cz/Zajezd/12139/93293.jpeg",
            "https://d39-a.sdn.cz/d_39/c_img_gV_D/ZAyU.jpeg?fl=cro,0,129,1800,1012%7Cres,1200,,1%7Cwebp,75",
            "https://d11-a.sdn.cz/d_11/c_img_G_J/bJ0GcZ.jpeg?fl=res,1280,720,1,%7Cjpg,60,,1",
            "https://globe24.cz/pictures/photo/2016/12/01/kryt-78918b15c9-660x371.jpg",
            "https://img.cncenter.cz/img/18/new_article/5762468-img-cernobyl-ukrajina-radioaktivita-jaderna-elektrarna-v0.jpg?v=0",
            "https://img.cncenter.cz/img/11/normal690/4944115_cernobyl-v0.jpg?v=0",
            "https://www.fotoaparat.cz/imgs/a/27/2734/fxmwh35h-cernobyl-5-230x173x9.jpg",
            "https://regionzapad.cz/uws_images/firmy/144566/clanky/cernobyl-a-pripjat-jaderna-katastrofa-152983/nuclear-waste-1471361_1280_28318_karlov",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_maly/public/uploader/img_2821_190603-115312_dbr.jpg?itok=vMzHdJr1",
            "https://g.denik.cz/1/ee/p201604200375201_denik-320-16x9.jpg",
        };

        [Command("cernobyl")]
        [Alias("booom", "radiace", "Pripjať")]
        public async Task CernobylAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Jaderná hlavice, která bouchla při startu na USA (Ano Gorbačov nebyl rád, ale stálo to hlavu jen jedo poradce....) **",
                ImageUrl = urlCernobyl.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Hold někdy to bouchne, ale trocha ozářeni není na škodu...   od MilošBota",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());

            var cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("cernob: " + eb.ImageUrl);
        }

        private static readonly string[] urlDukovany = new[]
        {
           "https://atominfo.cz/wp-content/uploads/2019/08/dukovany-2016-1024x768.jpg",
           "https://vysocina-news.cz/wp-content/uploads/2018/07/DOD-Dukovany.jpg",
           "https://img.cncenter.cz/img/11/normal690/6342723_dukovany-jaderna-elektrarna-jaderna-energetika-v1.jpg?v=1",
           "https://img.ihned.cz/attachment.php/820/68552820/ijSIsKtmphwJlrCebgOAzM4D9v8L0FUG/jarvis_5745d487498e3caf0ae0d56c.jpg",
           "https://vysocina-news.cz/wp-content/uploads/2018/09/Dukovany-no%C4%8Dn%C3%AD-prohl%C3%ADdky-3-687x358.jpg",
           "https://www.kudyznudy.cz/files/84/84b0fbba-e944-4e7f-88c6-3ef441900daa.jpg?v=20200827035140",
           "https://cdn.xsd.cz/resize/3e9683c5c78332238ec0fb5bf04fbb54_resize=680,383_.jpg?hash=6f8de1e80536a30b0a337077b5bcc9e4",
           "https://1gr.cz/fotky/idnes/14/031/cl5/MV51a88c_171237_3635556.jpg",
           "https://www.tzb-info.cz/docu/clanky/0194/019468og.jpg",
           "https://www.cez.cz/edee/content/img/produkty-a-sluzby/velkoodberatele/udrzba-a-opravy-reaktoru-reakt1.jpg",
           "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQwvDcoceoxnaUgUFRhGQxGYeWS6hoMKfqEGA&usqp=CAU",
           "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSeSwimRmTv0RtI-t3HO92_MMoMIsPNdXZEvA&usqp=CAU",
           "https://img.blesk.cz/img/1/normal620/5242886_elektrarna-babis-dukovany-zivotnost-v8.jpg?v=8",
           "https://ct24.ceskatelevize.cz/sites/default/files/styles/scale_1180/public/images/2118886-dukovany.jpg?itok=fhz-egJC",
           "https://www.b2b-nn.com/wp-content/uploads/Dukovany-jadern%C3%A1-elektr%C3%A1rna.jpg",
           "https://hlidacipes.org/wp-content/uploads/2020/04/babis-drabova-dukovany.jpg",
           "https://iuhli.cz/wp-content/uploads/2015/10/dukovany-historie-1024x702.jpg",
           "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRMWpZlxr3BDUYFflruo9h_ZjU5KVkE7Wo2VQ&usqp=CAU",
           "https://imultimedia.ctk.cz/storage/foto/F201502120805501/515x515.wm/F201502120805501.jpeg",
           "https://aa.ecn.cz/img_upload/e6ffb6c50bc1424ab10ecf09e063cd63/15535245280_08605119b9_k.jpg",
        };

        [Command("dukovany")]
        [Alias("cernobyl2.0", "rakousko", "čez")]
        public async Task DukovanyAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Zatím nedostavěný český Černobyl **",
                ImageUrl = urlDukovany.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Proč asi ti komunisté ji postavili tak blízko hranic s Rakouskem? Protože Rakousko nebylo komunistické...    od MilošBota",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());


            var cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("dukov: " + eb.ImageUrl);
        }

        private static readonly string[] urlOrloj = new[]
        {
            "https://1gr.cz/fotky/idnes/11/124/cl5/SFO382d77_163042_1939160.jpg?v=9",
            "https://www.drobnepamatky.cz/files/2015/okres-brno-mesto-obec-brno-ku-mesto-brno-49-1948-16-60861-13859.jpg",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_16x9/public/images/1612350-433025.jpg?itok=fc5ZBjFa",
            "https://www.kudyznudy.cz/files/e4/e42b675d-c53d-4187-8b3e-a394d66f53a5.jpg?v=20200826184853",
            "https://www.centrumnews.cz/sites/default/files/styles/article/public/clanky/2018/06/csm_180611_nam_8_c67ed7f472.jpg?itok=fQZiX9wS",
            "https://img.blesk.cz/img/1/full/1141243_brno-orloj-ochrana-v0.jpg?v=0",
            "https://img19.rajce.idnes.cz/d1902/8/8557/8557657_7cb53c8dfe54d715c86405c03e63f1aa/images/040.jpg",
            "https://pbs.twimg.com/media/ERmcFh9XUAIH_qS?format=jpg&name=small",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ31yncmy2ZCWojuW0i1z-x438hWp4GLpOQ_w&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQroasnWohX4V52RUmyqrJnBB-c9L55QM2t7Q&usqp=CAU",
            "https://www.brnotoday.cz/wp-content/uploads/2020/07/200709_Hodiny_na_Nam__22_-1024x720.jpg",
            "https://media.loupak.fun/soubory/obrazky_n/_vlastni/sranda/9e3e97749a0becb5280d0baefdeb56be.jpg",
            "https://www.brnotoday.cz/wp-content/uploads/2019/11/Sn%C3%ADmek-obrazovky-2019-11-04-v-15.25.50-760x490.png",
            "https://www.coolbrnoblog.cz/wp-content/uploads/2015/12/x2014_03-brno_je_zlata_lod-tema-dildo-1a-1280x852.jpg.pagespeed.ic_.5Wn4yQwgMw-1024x682.jpg",
            "https://zazabavou.cz/_files/200000722-89e138adb2/BO1_sm.jpg",
            "https://www.cmgp.cz/wp-content/uploads/brnensky-orloj.jpg",
            "https://cdn.discordapp.com/attachments/775078670104264744/779377921387003924/hradecna.png",
        };

        [Command("orloj")]
        [Alias("dyldo", "brno", "chloubaBrna")]
        public async Task OrlojAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Kdo se bojí nesmí do Brna **",
                ImageUrl = urlOrloj.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Brno volí Bidena, Trumpovci se mu obloukem vyhýbaj...    od MilošBota",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());

            var cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("orloj: " + eb.ImageUrl);
        }
    }
}
