using Discord;
using Discord.Commands;
using MilošBot.Extensions;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Kuchari : ModuleBase<SocketCommandContext>
    {
        private static readonly string[] urlBabica = new[]
        {
            "https://upload.wikimedia.org/wikipedia/commons/a/a1/Babica_Ji%C5%99%C3%AD_PA235378.jpg",
            "https://i.ytimg.com/vi/uP8PVCsvkDs/maxresdefault.jpg",
            "https://img.cncenter.cz/img/18/new_article/1502020-img-jirka-babica-v5.jpg?v=5",
            "https://img.blesk.cz/img/1/full/1163889_jiri-babica-kuchar-televize-v0.jpg?v=0",
            "https://g.cz/sites/default/files/styles/gflex_landscape_large/public/field/image/2019/babica1.jpg?itok=MhSBirIa",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_fotogalerie_large/public/uploader/profimedia-015713523_171114-142609_pj.jpg?itok=fsKFQ3hI",
            "https://media.super.cz/images/top_foto1/0000000005370302/SUhN5vyxM9B0CF4A0gS9nA/59ad1c3819b6a64f567d0000-222676.jpg?20170904112618&size=539",
            "https://www.kucharidodomu.cz/upload/obrazky/galerie_obrazku/jiri-babica-profil-2636.jpg",
            "https://img.cncenter.cz/img/18/new_article/1507715-img-v0.jpg?v=0",
            "https://img.blesk.cz/img/1/full/619759_jiri-babica-v0.jpg?v=0",
            "https://1gr.cz/fotky/lidovky/10/042/lnc460/GLU327b91_babica_14.jpg",
            "https://img.cncenter.cz/img/11/normal690/2982030_jiri-babica-v0.jpg?v=0",
            "https://media.super.cz/images/top_foto1/0000000009990563/cK-qIRN3a4BDrqNGZd_TXg/5322e160db7fabd8b1430700-106275.jpg?20150217161256&size=539",
            "http://images.uncyclomedia.co/necyklopedie/cs/8/8f/Babica_a_Pohlreich.jpeg",
            "https://www.receptyonline.cz/data/pics/kuchari/jiri-babica.jpg",
            "https://1gr.cz/fotky/idnes/11/063/cl5/NH3bf350_babica.jpg",
            "https://i.ytimg.com/vi/fJkgpkC6T-M/maxresdefault.jpg",
            "https://img.cncenter.cz/img/18/new_article/1163453-img-jirka-babica-crop-v0.jpg?v=0",
            "https://www.kucharidodomu.cz/upload/obrazky/firmy/obrazek-331-1.jpg",
            "https://1gr.cz/fotky/idnes/11/063/cl5/NH3bf350_babica.jpg",
            "https://i.ytimg.com/vi/fJkgpkC6T-M/maxresdefault.jpg",
            "https://img.cncenter.cz/img/18/new_article/1163453-img-jirka-babica-crop-v0.jpg?v=0",
            "https://www.lifee.cz/wp-content/uploads/2019/04/ca0986bd69a6ac9429fdc880798e85d2-672x378.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ3D5_A7v_vKZ-dXbtkQKOv6xagWbYc5oSh4w&usqp=CAU",
            "https://imagebox.cz.osobnosti.cz/foto/jiri-babica/M331780-40015.jpg",
            "https://zena-in.cz/media/clanky2/161958/fb.jpg",
            "https://1gr.cz/fotky/bulvar/20/034/cl6/LAR825f91_babica.PNG",
            "https://cdn.xsd.cz/resize/e8c534286e0e301395f69a8271c4719c_extract=55,108,1608,905_resize=680,383_.jpg?hash=15c5093b140d3cb89782861a1a22ed64",
            "https://img.blesk.cz/img/1/normal620/533287_jiri-babica-kuchar-syn-televize-porad-crop-v0.jpg?v=0",
            "https://d227-a.sdn.cz/d_227/c_img_gU_B/FPKB.jpeg",
            "https://www.dama.cz/getthumbnail.aspx?q=100&crop=0&height=20000&width=20000&id_file=448694709",
            "https://www.barrandov.tv/obrazek/201508/55e001b1b35cf/crop-138156-babica-vs-sapik-(18)-mala_1999x958.jpg",
            "https://imagebox.cz.osobnosti.cz/foto/jiri-babica/M331781-50015.jpg",
            "https://img.cncenter.cz/img/18/new_article/1161817-img-jiri-babica-v0.jpg?v=0",
            "https://www.filmarena.cz/obrazky/film_16530_3.jpg",
            "https://www.krajskelisty.cz/images/theme/20140821190401_BabicaNova.jpg",
            "https://img.novydenik.com/wp-static/2019/06/032f9c4c-dd4c-49c3-9425-b6059398d0e2.jpg?fm=jpg&q=85&w=800",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR0S7ZtpoWq1BPv0RICB_rPp8CTwRhWacOFyw&usqp=CAU",
            "https://www.extra.cz/images/thumbs/5b/3c/5b3c466-104749-bab3-0d0220000-0d0392157-0d9740000-0d9150327-sector_740x416-crop.jpg",
            "https://i.ytimg.com/vi/vmG0MNAC2kw/mqdefault.jpg",
            "https://media.super.cz/images/gallery/0000000007351501/CvXc0HpN_FS69n1S1Xm49w/530f246162a36ecb4d8b0500-104689?size=539",
            "https://img.blesk.cz/img/1/full/1488918_jiri-babica-v6.jpg?v=6",
            "https://i.iinfo.cz/images/50/jiri-babica-1.jpg",
            "https://zena-in.cz/media/2012/01/13/uvod.jpg",
            "https://d227-a.sdn.cz/d_227/c_img_gT_B/O38B.jpeg?fl=res,1280,720,1,%7Cjpg,60,,1",
            "https://1gr.cz/fotky/lidovky/10/042/lngal/TAI327b7a_CF048610_resize.jpg",
            "https://www.dama.cz/getthumbnail.aspx?crop=1&w=690&h=345&q=60&id_file=829435112",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTQA0FTM-0bBb_GSMMIkrmi8QncNcPywfSXAw&usqp=CAU",
        };

        [Command("babica")]
        public async Task BabicaAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Kečupák **",
                ImageUrl = urlBabica.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Ten hnus fakt jíst nechceš! Od MilošBota",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());

            var cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("babica: " + eb.ImageUrl);
        }

        private static readonly string[] urlLada = new[]
        {
            "https://img.primadoma.cz/r/8f/d6/avatar_small/8fd656637ad6c9dcae32f260aecfff80_lada-hruska.jpg",
            "https://img.blesk.cz/img/1/normal620/2730907_lada-hruska-nemovitost-investice-moderator-barabizna-v29.jpg?v=29",
            "https://1gr.cz/fotky/idnes/14/083/cl5/ZAR5559c5_h11.jpg",
            "https://www.bvv.cz/public/galleries/64/63501/hruska.jpg?8e05a2d352056aaa7ccfc2880bf45cbc",
            "https://sedmicka.tyden.cz/obrazek/202002/5e42963e5181c/crop-2017299-yan-6631_888x600.jpg",
            "https://img.cncenter.cz/img/18/full/3136892_lada-hruska-v0.jpg?v=0",
            "https://cdn.xsd.cz/resize/8f093b50e40f35aa90e2683693dac86d_extract=69,0,1326,746_resize=620,349_.jpg?hash=7de443a23ee673419b46a6fff2c14f85",
            "https://media.super.cz/videos/gallery/56d8400c2af3d51d04530000-8628.jpg",
            "https://cdn.xsd.cz/resize/1c5c611d5c0f36c4a340652ea949c35b_extract=121,65,1774,998_resize=680,383_.jpg?hash=b3f84c7225ec1cd2cfc3c7bb29c424fd",
            "https://d108-a.sdn.cz/d_108/c_img_G_B/Z7tBl.jpeg?fl=res,1280,720,1,%7Cjpg,60,,1",
            "https://paralelnilisty.cz/wp-content/uploads/2018/05/ladahruskamain.jpg",
            "https://media.super.cz/images/gallery/0000000015991065/gdgvA3MHRw5LTb0sgmpVog/59b456d961f1f5d882200400-223207?size=539",
            "https://1gr.cz/fotky/lidovky/14/111/lnc460/MEV4c2627_hruska2.jpg",
            "https://img.cncenter.cz/img/18/new_article/2424368-img-lada-hruska-v10.jpg?v=10",
            "https://sedmicka.tyden.cz/obrazek/202008/5f3e61b39fe73/crop-2128523-22-00-hruska-lada-0004_800x540.jpg",
            "https://1gr.cz/fotky/lidovky/14/113/lnc460/HM57617a_81072355.jpg",
            "https://1gr.cz/fotky/idnes/15/031/cl5/MLB57cc09_Lada_Hruska.jpg",
            "http://img.blesk.cz/img/1/full/2030676-img-lada-hruska.jpg",
            "https://media.super.cz/images/top_foto1/0000000015990901/gWDozyOvI6Snme7ua8P5Yg/54255163527cb764b1d20500-126860.jpg?20140926134333&size=539v",
            "https://knihydobrovsky.cz/thumbs/author-description/authors/196866/photo.JPG",
            "https://nasehvezdy.cz/wp-content/uploads/hruska_kniha.jpg",
            "https://www.novinykraje.cz/vysocina/wp-content/uploads/sites/11/2020/03/L%C3%A1%C4%8Fa-Hru%C5%A1ka-e1584897823912-678x381.jpg",
            "https://i.ytimg.com/vi/ezNJSyKdC_4/maxresdefault.jpg",
            "https://pbs.twimg.com/profile_images/1318235311449800706/KPBDpuR0.jpg",
            "https://1gr.cz/fotky/bulvar/17/043/cl6/REN6aef4f_profimedia_0254927081.jpg",
            "https://www.showbiz.cz/files/gallery/41/41a22dcdf08678e804f2ccc1c555f1ac.jpg",
            "https://www.databazeknih.cz/img/books/26_/260913/bmid_lada-hruska-se-vraci-kucharka-pro-s-260913.jpg",
            "https://m.actve.net/frekvence1/edee/clanky/18124/hruska-foto-610x443.jpg",
            "https://im9.cz/iR/importprodukt-orig/e4a/e4a00cd403593bafc7e383a52aa9e6f5.jpg",
            "https://img.primadoma.cz/r/c2/e5/column/c2e53c738aeb8c2c9e10028de63c1a52_rizky-reznika-krkovicky.jpg",
            "https://img.blesk.cz/img/1/normal620/3486512_mejdan-party-kapitan-morgan-vltava-naplavka-lada-hruska-v4.jpg?v=4",
            "https://zena-in.cz/media/2020/09/14/5f5f335c57d01YAN-4385.jpg",
            "https://pbs.twimg.com/profile_images/441206502485798913/LXVgT-x5_400x400.jpeg",
            "https://prima-receptar.cz/wp-content/uploads/2014/10/kniha-lada-hruska.jpg",
            "https://c1.primacdn.cz/sites/default/files/styles/landscape_extra_large/public/728daa6e/3729567-10vychytavky.jpg?itok=EBMtXIEd&c=def_cloudinary",
            "http://1gr.cz/fotky/idnes/15/103/vidw/VIR5eeaf1_hruska_1.jpg",
            "https://www.showbiz.cz/files/gallery/0c/0ce17380f7b486dc2bafe391ad797b60.jpg",
            "https://stars24.cz/pictures/photo/2019/08/13/57569381-10217365044505520-86880913450860544-n-14a65ef5d5-660x371.jpg",
            "https://www.vecerni-praha.cz/wp-content/uploads/2019/12/lada-hruska-05.jpg",
            "https://hruskovyrecepty.cz/wp-content/uploads/2017/06/DSC_0173-1024x680.jpg",
            "https://instory.cz/content/images/55/b7/55b7de3c2749e.jpg",
            "https://www.svetandroida.cz/media/2015/02/lada-hruska.jpg",
            "https://1gr.cz/fotky/lidovky/14/122/lnc460/MMU57ec45_81072352.jpgv",
            "https://1gr.cz/fotky/idnes/20/043/vidw/JB8304fd_a8445114x.jpg",
            "https://g.denik.cz/1/8e/vychytavky-lada-hruska-domaci-avivaz-09_denik-320-16x9.jpg",
            "https://www.centrumnews.cz/sites/default/files/clanky/2016/12/hruska-pivo.jpg",
            "https://www.extra.cz/images/thumbs/e1/70/e170fc0-289999-lh2-0d0000000-0d0000000-1d0000000-1d0000000-sector_740x416-crop.png",
            "https://www.onlyu.cz/wp-content/uploads/2021/01/lada_hruska-1.jpg",
            "http://img.blesk.cz/img/1/full/2007905-img-lada-hruska-rozhovor.jpg",
            "https://d2emjept89nv7b.cloudfront.net/podcast-covers/1043/266825/1/1000/lada-hruska-kdyz-nejde-o-zivot-tak-jde-o-houby.jpg",
            "https://www.krajskelisty.cz/images/theme/20140408144727_hruska2.jpg",
            "https://img.cz.prg.cmestatic.com/media/images/390x215/Feb2015/1731206.jpg?d41d",
            "https://hradec.rozhlas.cz/sites/default/files/images/ccca9b47e06bcd17fa40a95ea4ca5fa4.JPG",
            "https://img.cncenter.cz/img/18/new_article/2646982-img-hruska-v5.jpg?v=5",
            "https://media.super.cz/videos/gallery/54292d03b987eaf205470000-5523.jpg",
            "https://cdn.xsd.cz/resize/9ac401f4f189363384466e64409ccc82_resize=1080,608_.jpg?hash=502e8f33d2b05116e60992603d13f689",
            "https://img.blesk.cz/img/1/normal620/6218390_lada-hruska-v2.jpg?v=2",
            "https://d15-a.sdn.cz/d_15/c_img_E_F/ySLEmf.jpeg?fl=cro,0,26,800,450%7Cres,1200,,1%7Cwebp,75",
            "https://www.extra.cz/images/thumbs/d1/d1/d1d117b-290000-hruska02-408x230-crop.jpg",
            "https://lh3.googleusercontent.com/proxy/M8VWAjvwmrD2IQaid16z-SnYwQ46-t-cOwhv3ijFpgtzy6giLQIubjd7L_xyEhF13vHV9ZuFMSnvInQ3YC0wtQEwH6lTxYw7V9Fa23AMjauOwolOBIBVUfla09oIo3xs7l-McLlSJ3TnVKHyplcyXg",
            "https://img.cz.prg.cmestatic.com/media/images/600x338/Jan2014/1602178.jpg?6e7a",
            "https://lh3.googleusercontent.com/proxy/Lktc2ncd0R6jSt2-GMHCMJYxgGEmoRCVHaszig2Q6sKY_odk8KOBWgNH5xS0K9e9UJJi8j0P4h1WwGew9aeiLekJgHsUb0yMRBRl8DFFUxIMB1J5qzpm1MfxeV9EMvMgX7ucrHaNTgWTZ_CJCyiDZX0Ct5s",
            "https://lh3.googleusercontent.com/proxy/zX2wspV7SjVN1Per2XJNrQIuJbeksGOuKzIbfsRFTbG3JteOYoQDIDFlpbD3owAnl4aKsxR71lmu9UJqRe7DloP8aFC3GkWfmSl1B_1b5hWzKN_6NEuYA3hyEZEKr2M6",
            "https://www.medricske-listy.cz/images/stories/Zpravy/8_2019/matejicek_hruska_nataceni_velikonoce_2019_3.jpg",
        };

        [Command("ladahruska")]
        [Alias("lada", "hrusky", "hruška", "láďa")]
        public async Task LadaAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Potravinový inspektor**",
                ImageUrl = urlLada.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Král kuřecích kůžiček od MilošBota",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());

            var cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("láďa: " + eb.ImageUrl);
        }

        private static readonly string[] urlPohlreich = new[]
        {
           "https://www.zdenekpohlreich.cz/wp-content/uploads/2019/10/Pohlreich-homepage.png",
           "https://upload.wikimedia.org/wikipedia/commons/thumb/3/32/Z_POLREICH_2014.JPG/252px-Z_POLREICH_2014.JPG",
           "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/images/2237ed6cdf5372535a7e6d3a82007942.jpg?itok=qky9xuRH",
           "https://g.denik.cz/45/6c/zdenek-pohlreich-bonte-2013-pce_denik-630-16x9.jpg",
           "https://img.cncenter.cz/img/18/new_article/3243475-img-zdenek-pohlreich-v11.jpg?v=11",
           "https://i.iinfo.cz/images/490/zdenek-pohlreich-1.jpg",
           "https://www.chefshop.cz/user/articles/images/zdenek_pohlreich_-_pohlreich_selection.jpg",
           "https://www.gourmetacademy.cz/data/images/employees/3/1600698519-zdenda.jpg",
           "https://www.extra.cz/images/thumbs/a2/52/a252486-206013-pohlreich7-658x900-fit.jpg",
           "https://1gr.cz/fotky/lidovky/17/122/lnc460/ELE6f4308__OM_1836.JPG",
           "https://imagebox.cz.osobnosti.cz/foto/zdenek-pohlreich/zdenek-pohlreich.jpg",
           "https://www.golfdigest.cz//files/thumbnails/20180530-20-48-58-pohlreich-crop-700-419-1529275028.jpg",
           "https://img.blesk.cz/img/1/normal620/3362537_pohlreich-v0.jpg?v=0",
           "https://sedmicka.tyden.cz/obrazek/202001/5e32e64b32571/crop-2010083-22-00-hlavni-zdenek-pohlreich---tiskovka-tv-prima43(1)_800x540.jpg",
           "https://sumpersko.net/admin/lib/get-image.php?module=ModuleClanek&image=129292.jpg&ws=634&hs=353&type=1",
           "http://www.divinis.cz/wp-content/uploads/2019/04/pohlreich-big-848x1024.jpg",
           "https://upload.wikimedia.org/wikipedia/commons/c/c9/Zdenek_Pohlreich_na_autogramiade_v_Brne.jpg",
           "https://media.super.cz/videos/gallery/581060009726d206537e0000-10026.jpg",
           "https://lh3.googleusercontent.com/proxy/0flsj_ylQ3oocppoPsm65XXw9yJrh-ttaRsik7AFsreubat7ayRQOsKikgSFPf0nBktcwKbVnrmh4yE5CTaaqz8gwJG5YWwQA2RkZTibfw-s",
           "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSkHBNRgxawOH51m4NEgaunL7sS0llaOhV24w&usqp=CAU",
           "https://i.ytimg.com/vi/nmBdBRcs9x0/maxresdefault.jpg",
           "https://refstatic.sk/article/zdenek-pohlreich-se-vraci-v-novem-poradu-se-bude-prevlekat-a-tajne-hodnotit-jidla-restauraci~0633207fe9b63f9d7666.jpg?is=919x570c&ic=58x55x1111x693&c=2w&s=6caac205f27a55379defdbbeb72e7ec25fa92ebf65e55d1af8d5d1b026c55364",
           "https://www.krajskelisty.cz/images/theme/20160927132024_Ano_sefe_Simsalabim_3132.jpg",
           "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0a/Zden%C4%9Bk_Pohlreich_2014.JPG/1200px-Zden%C4%9Bk_Pohlreich_2014.JPG",
           "https://img.blesk.cz/img/1/full/2218902_zdenka-pohlreichova-pohlreich-zdenek-v0.jpg?v=0",
           "https://zivotvcesku.cz/wp-content/uploads/optimg/2020/11/7f8ecd79e25ccdacfa59ef4b99bf3c7ffca68bdc-w680-h382.jpg",
           "https://www.lui.cz/uploads/gallery/16423-zdenek-pohlreich-o-prekonavani-prekazek-je-nutne-zakousnout-se-a-vydrzet-to-zadne-lepsi-rady-neexistuji/Zdenek-Pohlreich-2.jpg",
           "https://cdn.xsd.cz/resize/08ff796c4743367d8ecc368038aa2f1b_resize=1080,608_.jpg?hash=33762017f1f5260a5a325a8cdc32bf39",
           "https://cdn.forbesmedia.cz/images/eyJ1IjoiXC91cGxvYWRzXC8yMDIwXC8wNFwvcG9obHJlaWNoLmpwZyIsInciOjEyMzAsInYiOiIxLjAifQ%3D%3D.jpg",
           "https://sedmicka.tyden.cz/obrazek/201902/5c755539b91c3/crop-1768547--13a0323_746x504.jpg",
           "https://1gr.cz/fotky/idnes/18/081/r7/DEN752ba6_pohlreich_1.jpg",
           "https://media.super.cz/images/top_foto1/0000000015990900/epIhfzr-8ta_lPe-AucPPQ/5914072c241b664cac3d0400-213034.jpg?20170511083942&size=539",
           "https://prakul.cz/images/upload/lector_midi/q5141c7b675876_f83_pohlreich.png",
           "https://g.denik.cz/5/0e/food-festival-zdenek-pohlreich-cb180118_denik-320-16x9.jpg",
           "https://mediagurucdneu.azureedge.net/media/11463/supersef.jpg",
           "https://next-door.cz/wp-content/uploads/2019/04/zajimavosti-Zden%C4%9Bk-Pohlreich-kopie-1-1310x859.jpg",
           "https://attsportzone.cz/wp-content/uploads/2019/09/zdenek_pohlreich-759x458.jpg",
           "https://img.cz.prg.cmestatic.com/media/images/original/Jul2011/775910.jpg?df3a",
           "https://c1.primacdn.cz/sites/default/files/styles/landscape_extra_large/public/f/dd/5115243-aplikace-ano_sefe-7.jpg?itok=Bktr0sIA&c=def_cloudinary",
           "https://i.ytimg.com/vi/eTKl9m2ECXE/maxresdefault.jpg",
           "https://i.iinfo.cz/images/507/zdenek-pohlreich-1.jpg",
           "https://www.mujrozhlas.cz/sites/default/files/styles/detail/public/rapi/6bf5c8eef2ba91de3e4617d000887024.jpg?itok=SkiuIMbQ",
           "https://radiozurnal.rozhlas.cz/sites/default/files/images/01058481.jpeg",
           "https://c1.primacdn.cz/sites/default/files/c/b/4617712-import_I8LauB.jpeg",
           "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=pohlreich2_637411916481321393.JPG&id=154142",
           "https://next-door.cz/wp-content/uploads/2019/04/zajimavosti-Zden%C4%9Bk-Pohlreich-kopie-268x300.jpg",
           "https://babinet.cz/images/19560/1aa55ce67a43f0bb421153c10017af46.jpg",
           "https://g.denik.cz/1/d0/pohlreich4_denik-320-16x9.jpg",
           "https://i.ytimg.com/vi/x8M1TnnBxT4/maxresdefault.jpg",
           "https://www.chytrazena.cz/obrazky/admin/clanek/prostreno-zdenek-pohlreich-31-8-2020-5.jpg",
           "https://cdn.xsd.cz/resize/561642d5fe743078a7d5730e3817cbc0_resize=1400,933_.jpg?hash=3d5b1a0448428458b83187b11afc08a8",
           "https://img.cncenter.cz/img/18/new_article/5192065-img-zdenek-pohlreich-v16.jpg?v=16",
           "https://brno.rozhlas.cz/sites/default/files/images/03155080.png",
        };

        [Command("pohlreich")]
        public async Task PohlreichAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Zbankrotovaný Šéfkuchař **",
                ImageUrl = urlPohlreich.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Játrový knedlíček od MilošBota",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());

            var cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("pohlreich: " + eb.ImageUrl);
        }
    }
}
