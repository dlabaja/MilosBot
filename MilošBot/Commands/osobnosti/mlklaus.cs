using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class cvaclavklausmladsi : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://upload.wikimedia.org/wikipedia/commons/2/2f/Konference_-_M%C3%A9dia_a_moc_-_2.3.2017_-_V%C3%A1clav_Klaus_ml.png",
            "https://1gr.cz/fotky/lidovky/18/062/lnc460/JHO74130d_154503_9313659.jpg",
            "https://g.denik.cz/63/d2/5592357-ostrava-vaclav-klaus-mladsi_denik-320-16x9.jpg",
            "https://paralelnilisty.cz/wp-content/uploads/2020/01/5-P201909040385301-2.jpg",
            "https://img.ihned.cz/attachment.php/150/71958150/RdgEzWywx92qBGSQ1muCjHJNFcroklha/jarvis_5b75b5ae498e61d7e64f3372.jpeg",
            "https://eurozpravy.cz/pictures/photo/2020/03/03/c-eurozpravycz-incorp-images-snemovna-leden-2020-krepelka-20200118-d8a8611-c993a03061_660x371.jpg",
            "https://cdn.xsd.cz/resize/31084cd00333374eb72272d661737d20_extract=28,0,1615,909_resize=480,270_.jpg?hash=f4fb3ed0ced652b664518eae0f4cde8e",
            "https://refstatic.sk/article/muzeum-romske-kultury-pozaduje-omluvu-od-vaclava-klause-ml-za-meme-ktere-sdilel-na-facebooku-fakt-to-nebudu-mazat-odpovedel~5193f17e93be67cc1dfd.jpg?is=919x570c&ic=124x39x1407x879&c=2w&s=d8d77ebb11714ad0f2300c780d4257a1fb37c2db04bba4f00c934b63461aaef0",
            "https://d15-a.sdn.cz/d_15/c_img_E_D/6eeBoSz.jpeg?fl=cro,0,0,798,450%7Cres,1200,,1%7Cwebp,75",
            "https://d39-a.sdn.cz/d_39/c_img_H_I/B0wrP.mpo?fl=cro,827,361,4219,2376%7Cres,1200,,1%7Cwebp,75",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/images/9a23b3dba298cf84ee2d5c9ac733dc39.jpg?itok=turaFkvh",
            "https://img.blesk.cz/img/1/normal620/3743613_klaus-ml-zeny-vztahy-rozvod-pritelkyne-v10.jpg?v=10",
            "https://d39-a.sdn.cz/d_39/c_img_QQ_M/Jlpm.jpeg",
            "https://www.focus-age.cz/m-journal/files/2018%20Petr/cerven%202018/zzn_vkml_m.jpg",
            "https://img.cncenter.cz/img/3/article/5601149_strunc-video-info-cz-klaus-ml-v2.jpg?v=2",
            "https://3.bp.blogspot.com/-NFclNYdMK9E/Wn1UJJ-hZdI/AAAAAAAAJ_0/XWaxEEsnztEW165r62wzG-WCU66dNxWaQCLcBGAs/s1600/klausmladsipsp.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/images/03789780.jpeg?itok=6NTDty0P",
            "https://echo24.cz/img/5da0b6e5ffd8ca9dcd9cfdbc/1180/614?_sig=AxLgKZtyTU8qSBKBBZ5pCczAOySFgodhkKJpYzV0ifo",
            "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=DSC_8610-1_636763917068692732.JPG&id=136885",
            "https://echo24.cz/img/5d976792ffd8ca9dcd00c38a/1180/614?_sig=hAel7Nf8QWassEtrCZY7J_ykdRl0rZKFdy6SixqBKH4",
            "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=IMG_7574_636240521397196945.jpg&id=120456",
            "https://img.cncenter.cz/img/3/article/5677056_vaclav-klaus-mladsi-syn-exprezident-v0.jpg?v=0",
            "https://www.extra.cz/images/thumbs/07/42/0742fbf-173215-ffwefwefwefwf-0d0120000-0d0568562-1d0000000-0d9866221-sector_740x416-crop.png",
            "https://lh3.googleusercontent.com/proxy/n4aaEvTohVjX5ECbit64o2edUkNMi18qbZmwe0KtxTXXt-ZUfciXstC_pb3239oqD3QHf9djBdOd6D7rjkeA9fdjz3ZqoWoLWaofYmeyMLZJOGu8",
            "https://www.plzen.cz/wp-content/uploads/2020/01/83117615_127677445391817_699782564885299200_o-e1579681781848.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_F_G/MtEGaP.jpeg?fl=cro,0,0,798,450%7Cres,1200,,1%7Cwebp,75",
            "https://www.barrandov.tv/obrazek/201911/5dc3e951b9c51/crop-300731-vaclav-klaus-mladsi_960x540.jpg",
            "https://www.prazskypatriot.cz/obrazky/volby-2017/vaclav-klaus-ml-06.jpgv",
            "https://img.cncenter.cz/img/3/full/5757447-img-vaclav-klaus-ml-v0.jpg?v=0",
            "https://www.drbna.cz/files/drbna/images/page/2019/05/10/size4-15574757930454-139-size4-15527684131604-139-size4-15525503706218-139-28795337-628771167454112-3745271401200746496-n.jpg",
            "https://pbs.twimg.com/profile_images/1260234174339977216/5nJ8UkDu.jpg",
            "https://img.ihned.cz/attachment.php/790/75195790/JrdjV6fFz3aC8EQIH0RtipeMhUTOBboc/jarvis_5e0a3892498e40c807533662.jpg",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/crop_880x495/public/images/2489193-200901intklaus.jpg?itok=tccJTUMV",
            "https://cdncz1.img.sputniknews.com/img/909/22/9092207_0:800:1010:1347_1000x541_80_0_0_bda5db0ecffa4d846b118125f584743c.jpg",
            "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=IMG_1440_636957757549122005.jpg&id=142324v",
            "https://www.barrandov.tv/obrazek/201911/5dd28293b9b66/crop-303232-klaus-mladsi_960x540.jpg",
            "https://img.cncenter.cz/img/11/normal690/5605177_vaclav-klaus-ml-v0.jpg?v=0",
            "https://echo24.cz/img/59de36dd9c40fe88e4a98745/1180/614?_sig=b75dqHUmyQadNhXFpcF-TAdmi-_PL03bibRjnd-Pi1k",
            "https://img.cz.prg.cmestatic.com/media/images/original/Jan2013/1439124.jpg?5d26",
            "https://im.tiscali.cz/press/2017/01/10/752037-profimedia-0101899644-1250x758.jpg?1587596281.0",
            "https://d15-a.sdn.cz/d_15/c_img_F_F/kjYBbgg.jpeg?fl=cro,0,0,800,450%7Cres,1200,,1%7Cwebp,75",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/p201906100646801_190610-171107_jak.jpeg?itok=s9kKt9zV",
            "https://img.ihned.cz/attachment.php/300/74033300/fBm2UN1ePAsR9i036gI8DnySTxulLjdq/P201909280293101.jpg",
            "https://img.cncenter.cz/img/18/new_article/3230430-img-vaclav-klaus-ml-v6.jpg?v=6",
            "https://www.tyden.cz/obrazek/201703/58d7cfaae1228/crop-1174976-klaus_520x250.png",
            "https://img.ihned.cz/attachment.php/430/45352430/PKjCchfevt9xnQD1dLrsTmU4M80buHwE/SVOZ3B6767.JPG",
            "https://imagebox.cz.osobnosti.cz/foto/vaclav-klaus-mladsi/vaclav-klaus-mladsi.jpg",
            "https://pbs.twimg.com/profile_images/1147815570936668160/G5gtwcnj.png",
            "https://www.tyden.cz/obrazek/201910/5d97717a12681/crop-1938875-vlkml.jpg",
            "https://d39-a.sdn.cz/d_39/c_img_H_L/kAKBby.jpeg?fl=cro,0,0,1920,1080%7Cres,1200,,1%7Cwebp,75",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSMq6tvTufXin9s0ESiJWs0UNvbBx3p-ZX0hQ&usqp=CAU",
            "https://im.tiscali.cz/press/2018/04/10/922992-profimedia-0310709158-base_16x9.jpg.1152?1606486588.0",
            "https://img.blesk.cz/img/1/full/1341624_vaclav-klaus-mladsi-kamila-lucie-v0.jpg?v=0",
            "https://1gr.cz/fotky/lidovky/19/041/lnc460/VAG7a6bc1_110616_3900281.jpg",
            "https://www.mojevlast.cz/wp-content/uploads/2021/01/klaus_mladsi_trikolora.png",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/scale_1180/public/images/2362187-vkml4.jpg?itok=bxV9ZLIQ",
            "https://globe24.cz/pictures/photo/2017/12/06/23795014-573211526343410-9211840332848148867-n-c9e0c0a380-660x371.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT_d_Qyx8tjRn9TFH1c95pD9X2t_vBr_pcjtg&usqp=CAU",
            "https://plus.rozhlas.cz/sites/default/files/styles/cro_3x2_mobile/public/images/82ddb36d66dc8a6f9708db2ad72657bf.jpg?itok=5xISvYny",
            "https://img.cncenter.cz/img/11/full/5759997_vaclav-klaus-ml-trikolora-v0.jpg?v=0",
        };

        [Command("mlklaus")]
        [Alias("klausmladsi")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some Klaus s postiženým obličejem**");
                ovcak.WithImageUrl(url[ovce]);

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Předseda Trikolóry (**postižené strany**) od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("klausml: " + url[ovce]);
            }
        }
    }
}