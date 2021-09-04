using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Milouš : ModuleBase<SocketCommandContext>
    {
        List<string> url = new List<string>()
        {
            "https://www.google.com/url?sa=i&url=https%3A%2F%2Fcs.wikipedia.org%2Fwiki%2FMilo%25C5%25A1_Zeman&psig=AOvVaw3UVDHuv_eHlk6pC63MD4xW&ust=1608386423180000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCKCC0rzY1-0CFQAAAAAdAAAAABAE",
            "https://www.hrad.cz/file/edee/cs/prezident-cr/milos-zeman.jpg",
            "https://img.ihned.cz/attachment.php/810/75153810/Irwf2gB4lioVb185HkncDPxuQzOTLpmG/jarvis_5f15eab9498e75f68d697f00.jpeg",
            "https://d15-a.sdn.cz/d_15/c_img_F_I/UVhBifb.jpeg?fl=cro,0,52,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/zuzana_caputova_2_190621-000051_mda.jpg?itok=Yt0z6J5M",
            "https://d15-a.sdn.cz/d_15/c_img_E_G/4BzBUGp.jpeg?fl=cro,0,13,800,450%7Cres,1200,,1%7Cwebp,75",
            "https://upload.wikimedia.org/wikipedia/commons/d/d1/Milo%C5%A1_Zeman_2013.JPG",
            "https://img.cncenter.cz/img/3/full/3899049-img-zeman-nova-rozhovor-prezidentske-volby-2018-v0.jpg?v=0",
            "https://cdn.xsd.cz/resize/1a7b6d451cc231aa9f184941ed5565f7_extract=92,0,1280,720_resize=680,383_.jpg?hash=ab38ea74d090d34587cd031475f7c05c",
            "https://www.transparentnivolby.cz/prezident2013/wp-content/uploads/zeman_vyrez.jpg",
            "https://cdn.xsd.cz/resize/4dc895eb23613ce9a1398e401f06c442_extract=131,0,1750,985_resize=680,383_.jpg?hash=f2f7316d8f43d271a0cf054dff3ed7e8",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_fotogalerie_large/public/uploader/zeman_4_190918-172016_mda.jpg?itok=ZG-1Qu1w",
            "https://d39-a.sdn.cz/d_39/c_img_F_N/X89CdO.jpeg?fl=cro,97,37,2337,1316%7Cres,1200,,1%7Cwebp,75",
            "https://g.denik.cz/56/6b/zeman-d2008279rg351_sip-1140.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/6/64/Milo%C5%A1_Zeman_2012-12-03_cropped.jpg",
            "https://img.cncenter.cz/img/11/normal690/3909008_milos-zeman-v12.jpg?v=12",
            "https://1gr.cz/fotky/idnes/18/013/c460/JB70f473_za2.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSnxd3L__Zz1Ha3fIvuHjzdKme91GaHOhHwlg&usqp=CAU",
            "https://www.irozhlas.cz/sites/all/modules/custom/cro_zpravy_election_2018_president/img/zeman_692x846.png",
            "https://img.cncenter.cz/img/11/normal690/3743362_vondrackova-v0.jpg?v=0",
            "https://www.forum24.cz/wp-content/uploads/2019/10/bbb-55.jpg",
            "https://cdn.xsd.cz/resize/5c7ec0b7d65b3e29b96347ba604163ca_resize=680,383_.jpg?hash=d81b178c15c2e53aa2c8ffdb34a3a147",
            "https://euractiv.cz/wp-content/uploads/sites/7/2012/12/IMG_6606.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_E_I/eyvBGS6.jpeg?fl=cro,68,12,961,540%7Cres,1200,,1%7Cwebp,75",
            "https://img.ceskatelevize.cz/program/porady/10123387294/foto09/01.jpg?1362396526",
            "https://www.forum24.cz/wp-content/uploads/2020/08/Sni%CC%81mek-obrazovky-2020-08-26-v-15.20.39-770x460.png",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSlW0L2hUQCrGK7n6v2fewVJgdoaL2BB4COsA&usqp=CAU",
            "https://img.cncenter.cz/img/18/new_article/6515823-img-milos-zeman-v0.jpg?v=0",
            "https://www.extra.cz/images/thumbs/61/9e/619e17d-196695-zeman-0d1000000-0d0000000-0d9780000-0d7576687-sector_740x416-crop.png",
            "https://d15-a.sdn.cz/d_15/c_img_F_I/1fct1f.jpeg?fl=cro,0,9,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://img.kurzy.cz/news/foto/prezident-2018/zeman.png",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/p201801270629101_180127-165654_kno.jpeg?itok=knxkKmOw",
            "https://upload.wikimedia.org/wikipedia/commons/9/9b/Milo%C5%A1_Zeman_cropped.jpg",
            "https://d39-a.sdn.cz/d_39/c_img_E_M/7ZbBBF.png?fl=cro,0,0,1920,1080%7Cres,1200,,1%7Cwebp,75",
            "https://g.denik.cz/50/01/brno-kraj-navsteva-prezident-milos-zeman-letce-hejtman-bohumil-simek-23-clone_denik-320-16x9.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRE-IyqyfTs8XC4zUWqQrUfSMAlFDbwYjp4FA&usqp=CAU",
            "https://d15-a.sdn.cz/d_15/c_img_E_I/m1bBa3q.jpeg?fl=cro,0,59,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://region.rozhlas.cz/sites/default/files/images/d6fb651ed182dfb89d73ba2fa4970841.jpg",
            "https://www.barrandov.tv/obrazek/202010/5f8ec838c1fbd/crop-370820-milos-zeman2-facebook_960x540.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSb0UdbO4XgNHC3K6d9AZFC_dZU_hMJm7j_DA&usqp=CAU",
            "https://i.ytimg.com/vi/kGHliPZ2khY/maxresdefault.jpg",
            "https://img.ceskatelevize.cz/program/porady/10123387294/foto/uni.jpg?1362396987",
            "https://cdn.xsd.cz/resize/46512de7d49439d7a3bc48da80135aa4_resize=680,383_.jpg?hash=a38b4c40ceac5034ac3ba89fa52ff47f",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcReWeV4vxz-2_FPKnAqFCan49VulyadrtYcWw&usqp=CAU",
            "https://i.ytimg.com/vi/-JJnU_gmBRg/hqdefault.jpg",
            "https://www.lifee.cz/wp-content/uploads/2019/09/5813193_-672x378.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ3tNlVzmPFus5swBtx0V_VCC1QpX9kIv1JwA&usqp=CAU",
            "https://stabruntalsko.cz/wp-content/uploads/2019/12/milos_zeman_prezident_vanoce.jpg",
            "https://img.novydenik.com/wp-static/2018/12/F201810121601101.jpg?fm=jpg&q=85&w=640",
            "https://img.cncenter.cz/img/3/full/6228673-img-milos-zeman-v0.jpg?v=0",
            "https://stars24.cz/pictures/photo/2020/08/26/c-eurozpravycz-incorp-images-caputova-a-zeman-krepelka-20190620-413a3202-22c48d2153-d55b8f318d-660x371.jpg",
            "https://radiozurnal.rozhlas.cz/sites/default/files/styles/facebook/public/uploader/vlcsnap-2020-10-28-1_201028-145222_kro.png?itok=bHGLiKRs",
            "https://www.tyden.cz/obrazek/202002/5e4404e70a01d/crop-2017934-p201710040825401_520x250.jpeg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8b/Milo%C5%A1_Zeman_b%C4%9Bhem_25._v%C3%BDro%C4%8D%C3%AD_Sametov%C3%A9_revoluce_na_Albertov%C4%9B_v_Praze_2014_%2810%29.JPG/220px-Milo%C5%A1_Zeman_b%C4%9Bhem_25._v%C3%BDro%C4%8D%C3%AD_Sametov%C3%A9_revoluce_na_Albertov%C4%9B_v_Praze_2014_%2810%29.JPG",
            "https://m.smedata.sk/api-media/media/image/sme/8/64/6491498/6491498_1200x.jpeg?rev=3",
            "https://cdn.xsd.cz/resize/878d0efe40613db7ad665db75f901fbc_resize=1960,1306_.jpg?hash=8e73bf18eac80799977e9f80fc23019a",
            "https://img.blesk.cz/img/1/normal620/5993446_milos-zeman-prezident-v12.jpg?v=12",
            "https://lh3.googleusercontent.com/proxy/s7Rm6RQuTlAhD7Sys4u0RyapySTDSTS3hQ49zf3tm3umwqIURauFRCUXmEgLpRBLjHWadof8w6KFLrMRUx6F7qJZNC_CFzXFlso8r8KHie4hB_XrH3mvIikvDJDF-JKQ1LWSK8gLpew-qvaOv_B-48xRrmqhcqv_OC1ktz47xN4L5a0wm5I2BF4",
            "https://img.cncenter.cz/img/18/new_article/6271404-img-milos-zeman-s-prezidentem-v-lanech-v12.jpg?v=12",
            "https://img.blisty.cz/img/-13519.jpg?id=-13519&size=450&mg=0",
            "https://i.ytimg.com/vi/v_hYJvLq4Mw/maxresdefault.jpg",
            "https://neovlivni.cz/wp-content/uploads/2019/08/milos_zeman_databaze_lzi.jpg",
            "https://prazska.drbna.cz/files/drbna/images/page/2020/10/16/size4-16028373202968-241-milos-zeman-dnes-vecer-vystoupi-s-projevem-k-narodu.jpg",
            "https://zivotvcesku.cz/wp-content/uploads/optimg/2020/08/c3f5428bde7fc594517d0f7efd28ee6dc6454eb5-w680-h382.jpg",
            "https://www.forum24.cz/wp-content/uploads/2015/05/zeman-amu.jpeg",
            "https://www.lifee.cz/wp-content/uploads/2019/09/5813193_.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7a/Milo%C5%A1_Zeman_Senate_of_Poland.JPG/220px-Milo%C5%A1_Zeman_Senate_of_Poland.JPG",
            "https://www.extra.cz/images/thumbs/77/24/7724d3b-196436-miloszeman-0d0000000-0d0000000-1d0000000-1d0000000-sector_668x376-crop.png",
            "https://1gr.cz/fotky/idnes/20/101/r7/TJZ86771d_zeman.00_01_37_15.Still001.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_E_J/IGiSbH.jpeg?fl=cro,0,102,1212,681%7Cres,1200,,1%7Cwebp,75",
            "https://www.sinagl.cz/images/stories/9prechod/Zeman_opilec.jpg",
            "https://dafilms.cz/media/gallery/2014/08/25/03.jpg",
            "https://g.denik.cz/18/11/do-naseho-kraje-se-prezident-vrati_denik-320-16x9.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT68EyqIadtftqLYf44Tv0_eLLxqIRJVGcgYA&usqp=CAU",
            "https://cdn.xsd.cz/resize/776bb863fb603b7d9488ea3ebfc3838b_resize=680,383_.jpg?hash=0c9a9ae850b6d33f030fc53ba2f48bbd",
            "https://zivotvcesku.cz/wp-content/uploads/optimg/2020/10/21e013cb5a77438cf18fd45b9ed22db2ed56cc7d-w680-h382.jpg",
            "https://eurozpravy.cz/pictures/photo/2020/03/07/c-eurozpravycz-incorp-images-lany-krepelka-20200307-d8a1089-873e7b96b3_660x371.jpg",
            "https://slisty.cz/wp-content/uploads/2019/04/i253.jpg",
            "https://cdncz1.img.sputniknews.com/img/07e4/0a/14/12679089_166:0:3024:2016_638x450_80_0_0_d51a5afceb8d8644318698efed01b220.jpg",
            "https://img.novydenik.com/wp-static/2020/05/P202005110583801.jpg?fm=jpg&q=85&w=640",
            "https://pbs.twimg.com/profile_images/1178300631796387840/Q4pilEsH_400x400.jpg",
            "https://infocz-media.s3.amazonaws.com/infocz/production/files/2020/07/14/23/19/08/bc25a903-6e42-4031-9408-26f150746d90/4857245.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/p202003191050501_200319-201304_jgr.jpeg?itok=CSwelVLh",
            "https://img.cncenter.cz/img/11/full/6609915_milos-zeman-s-prezidentem-v-lanech-v0.jpg?v=0",
            "https://d15-a.sdn.cz/d_15/c_img_E_I/ArCBtyf.jpeg?fl=cro,0,9,1250,703%7Cres,1200,,1%7Cwebp,75",
            "https://www.tyden.cz/obrazek/202005/5eb9598f7e227/crop-2071883-p202005110585501_520x250.jpeg",
            "https://1gr.cz/fotky/idnes/20/042/cl5/KOT82a947_Zeman_Partie_2.jpg",
            "https://stars24.cz/pictures/photo/2019/04/03/56232233-2296721937046757-4333884149287878656-n-f9ef7b99a2-660x371.jpg",
            "https://zivotvcesku.cz/wp-content/uploads/optimg/2020/08/3646b1f1cbca09df56769e993fe70398a5b1415b-w680-h382.jpg",
            "https://i.ytimg.com/vi/rz1FgsSFGKo/maxresdefault.jpg",
            "https://g.denik.cz/111/bb/nasracky-1_dotyk-640.jpg",
            "https://img.cncenter.cz/img/18/new_article/1402828-img-zemanova-ivana-milos-v0.jpg?v=0",
            "https://img.ihned.cz/attachment.php/830/70448830/G3wcd7o2lxMqB6iJUHETVruL8bN0vjmz/jarvis_5a4f81c6498ec211fed1866e.jpeg",
            "https://www.novinykraje.cz/praha/wp-content/uploads/sites/13/2020/03/dsc_5560-20190321-085302-678x381.jpg",
            "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=IMG_2574_636620952252658451.JPG&id=132717",
            "https://g.denik.cz/64/c9/milos-zeman-holesov-161015-05_denik-320-16x9.jpg",
            "https://1gr.cz/fotky/idnes/19/082/r7/PES7d5cb2_miloszeman1998.jpg",
            "https://www.extra.cz/images/thumbs/2b/99/2b996bc-205087-profimedia-0392626042-0d0000000-0d0570571-1d0000000-0d9009009-sector_740x416-crop.jpg",
            "https://img3.kurzy.cz/zpravy/obrazky/33/435333-prezident-milos-zeman-prijal-na-hrade-vaclava-klause/1467036_w420h315.jpg",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/scale_1180/public/images/1595998-zeman.jpg?itok=-IMBeBR4",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHLEoX_577lhkQRYYzCnvDHFoE4EsAKBSRKg&usqp=CAU",
            "https://img.cncenter.cz/img/18/new_article/4880842-img-katerina-zemanova-v5.jpg?v=5",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSi9B4nsJhDVPiLGtUeCTkCyx6yGNjcP3QlNw&usqp=CAU",
            "https://eurozpravy.cz/pictures/photo/2020/03/07/c-eurozpravycz-incorp-images-lany-krepelka-20200307-d8a1069-0f845f66c1_660x371.jpg",
            "https://static.novydenik.com/2019/09/MIlo%C5%A1-Zeman-Foto-%C3%9A%C5%99ad-vl%C3%A1dy.jpg",
            "https://cesky.radio.cz/sites/default/files/styles/lightbox/public/images/zeman_manzelka.jpg?itok=oX7E5gUU",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8b/Milo%C5%A1_Zeman_b%C4%9Bhem_25._v%C3%BDro%C4%8D%C3%AD_Sametov%C3%A9_revoluce_na_Albertov%C4%9B_v_Praze_2014_%2810%29.JPG/220px-Milo%C5%A1_Zeman_b%C4%9Bhem_25._v%C3%BDro%C4%8D%C3%AD_Sametov%C3%A9_revoluce_na_Albertov%C4%9B_v_Praze_2014_%2810%29.JPG"
        };


        [Command("zeman")]
        [Alias("miloš", "milos", "milda", "milouš", "milous")]
        public async Task Mildosaurus()
        {
            Random random = new Random();
            int ovce = random.Next(url.Count);
            Console.WriteLine(ovce);
            var ovcak = new EmbedBuilder();
            ovcak.WithTitle("**Here, take Some Miloš**");
            ovcak.WithImageUrl(url[ovce]);
            ovcak.WithColor(Color.Red
                );
            ovcak.WithFooter(footer =>
            {
                footer
                .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                .WithText("Čerstvý Milda od MilošBota");
            });
            await Context.Channel.SendMessageAsync(embed: ovcak.Build());

            ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("zeman: " + url[ovce]);
        }
    }
}
