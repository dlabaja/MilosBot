using Discord;
using Discord.Commands;
using MilošBot.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Pohadky : ModuleBase<SocketCommandContext>
    {
        private static readonly string[] urlKrtek = new[]
        {
            "https://i.ytimg.com/vi/GdUXaG-i3kI/hqdefault.jpg	",
            "https://c1.primacdn.cz/sites/default/files/styles/landscape_extra_large/public/1/13/5030384-dlazdice-krtek.jpg?itok=cdU31DlF&c=def_cloudinary	",
            "https://www.veselepohadky.cz/assets/nahlady-kategorie/267/social/krtek-a-panda-pohadka.jpg	",
            "https://i.ytimg.com/vi/vge5JChc2P4/hqdefault.jpg	",
            "https://cdn.xsd.cz/resize/20fea9c7b0a53716b1d9a47d9d846bd1_extract=400,0,1345,757_resize=680,383_.jpg?hash=3e2bdb02990d075233deee0fe959542f	",
            "https://i.ytimg.com/vi/DWGhpGGKdkM/hqdefault.jpg	",
            "https://img.csfd.cz/files/images/film/photos/161/398/161398106_006d97.jpg?w370h370	",
            "https://forbesmedia.cz/uploads/2020/11/krtek.jpeg	",
            "https://i.ytimg.com/vi/jm9ZuadIJ6c/hqdefault.jpg	",
            "https://1gr.cz/fotky/lidovky/16/034/lnc460/HEP624c9d_krtekapanda2.jpg	",
            "https://media.discordapp.net/attachments/719289692474048675/807548505161728050/krtekapanda.gif	",
            "https://1gr.cz/fotky/lidovky/15/062/lnc460/ELE5bff31_krtek.jpg	",
            "https://i.pinimg.com/564x/d7/f8/71/d7f87191cdcb77e369e49ecdd636783d.jpg	",
            "https://www.jenpohadky.cz/public/foto/output/Pr1vibMnr6xV9pb_220x200.jpg	",
            "https://www.veselepohadky.cz/assets/nahlady/4786/krtek-a-panda-zajimava-past.jpg	",
            "https://i.ytimg.com/vi/jMPPS99ISYE/hqdefault.jpg	",
            "https://images.justwatch.com/backdrop/49372948/s1440/krtek-a-panda	",
            "https://d27-a.sdn.cz/d_27/c_img_G_K/dSGBiu.jpeg	",
            "https://www.urania.cz/wp-content/uploads/2017/09/Krtek-a-Panda-38.mov_snapshot_03.55_2017.07.24_15.15.49.jpg	",
            "https://img.youtube.com/vi/o95THhM-Hgw/0.jpg	",
            "https://www.rexo.cz/images/cs/pohadky/b/Krtek-a-panda--Co-se-to-blyska.jpg	",
            "https://i.pinimg.com/564x/b4/88/87/b48887dcc97c21bfab065f4d53b1466e.jpg	",
            "https://i.ytimg.com/vi/c3UJgFD3SMc/hqdefault.jpg	",
            "https://img.fdb.cz/galerie_ms/e/eda6d39d4f262ceeecd76a573c0.jpg	",
            "https://i.pinimg.com/564x/b9/b1/93/b9b193f4133633107276666241e423aa.jpg	",
            "https://www.atlaso.cz/videa/data/uploads/2020/10/krtek-a-panda-jak-vylecit-draka-6-dil.jpg	",
            "https://i.ytimg.com/vi/u1SOtlQUfmY/hqdefault.jpg	",
            "https://bilder.wunschliste.de/sendung/hr/v37689.png	",
        };

        [Command("krtek")]
        [Alias("krtecek")]
        public async Task KrtekAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Čínskej krtek s pandou **",
                ImageUrl = urlKrtek.GetRandom(),
                Color = Color.Red,
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Věc která vám zkazí dětství od Médi PÚ a MilošBota",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());

            var cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("krtek: " + eb.ImageUrl);
        }

        private static readonly string[] urlKrtecek = new[]
        {
            "https://img.cncenter.cz/img/11/normal690/3591820_zdenek-miler-vnucka-krtecek-v0.jpg?v=0	",
            "https://cdn.alza.cz/ImgW.ashx?fd=f3&cd=HRAa7011	",
            "https://i.pinimg.com/originals/c9/cb/b9/c9cbb9dab6de47277363e225a205e2ea.jpg	",
            "https://lh3.googleusercontent.com/proxy/40btyih8iM5VbpAcmPf69Ehxr1Trwrko7IJMMV_hI73XlbjidMI8XpY7HqiUkDZaZgubS9RHfYTH5PFJ0MAR6cgGCseCyaMGj6q3-YWNWJ69_DI228N2poLJ	",
            "https://g.cz/sites/default/files/styles/gflex_square_big/public/field/image/2018/rajpohadek.cz_.jpg?itok=Rdo1djY3	",
            "https://lh3.googleusercontent.com/proxy/B1RNUu7dKF68mOdHnEUhbNu8MxitjY0S9YRo8dKUbqcYsQTnoPuLhJmhpTEq1rkIgLrR4wtt64RoH1Z8q0TOe52ISlMPtoSEEovfmoLw6TQ8RRFeWdaFKTV9_6887ijUuQrwPw	",
            "https://cdn.alza.cz/Foto/imggalery/Image/Article/EFL26e756_Krtek_a_kalhotky.jpg	",
            "https://lh3.googleusercontent.com/proxy/zlYiTOTXFBYkwG_MjAKtqnSv6mk-NyJ9Zg941s3z117zQe-Ij7A2iTe585goGhmu8Lrbf9QGRsg3Vb2GDt2BikBOSvj6Lv1QL-De5i2OuoBMYFEeaVr9G5G48KiYjSej	",
            "https://i.pinimg.com/originals/d6/71/aa/d671aa58dade177463415b9e22d798e1.jpg	",
            "https://tradag.cz/sites/default/files/obrazy/obraz-krtek.jpg	",
            "https://lh3.googleusercontent.com/proxy/zlYiTOTXFBYkwG_MjAKtqnSv6mk-NyJ9Zg941s3z117zQe-Ij7A2iTe585goGhmu8Lrbf9QGRsg3Vb2GDt2BikBOSvj6Lv1QL-De5i2OuoBMYFEeaVr9G5G48KiYjSej	",
            "https://d11-a.sdn.cz/d_11/c_img_H_L/5KJGpS.jpeg?fl=res,1280,720,1,%7Cjpg,60,,1	",
            "https://i.ytimg.com/vi/I7SZxoZlkxY/maxresdefault.jpg	",
            "https://g.denik.cz/1/57/471074-krtecek-zdenek-miler_denik-320-16x9.jpg	",
            "https://mestokladno.cz/assets/Image.ashx?id_org=6506&id_obrazky=242697	",
            "https://www.mojedino.cz/out/pictures/z3/335257_03_z3.jpg	",
            "https://www.puzzle-puzzle.cz/ImgZbozi/Maxi/m-puzzle-krtecek-narozeniny-maxi-24-dilku-45966.jpg	",
            "https://lh3.googleusercontent.com/proxy/V8AEutBH-JCFallBeEtxkK8Fl-DXJ_oQvBlYVWRFj__UEm6x19aoI6oR3d8XBGikyUZmjqqXJGY7eHilJ01c2fM0IUaJl9wIRFfE1g1ku6Bh7o5ZFGWpNOilv9M18yn8b3kZ8GaZGLBM1KBjl0Av1w	",
            "http://1.bp.blogspot.com/-wMwpHdQoADo/TrBpx3D3ZmI/AAAAAAAACIg/JElc75h-9cE/s1600/images.jpg	",
            "https://www.chcipovleceni.cz/media/catalog/product/cache/4/image/62ab0471f1c06ac4153e310c30a18b6d/d/e/detska-osuska-krtek-a-kvetiny-zluta-b.jpg	",
            "https://cdn.xsd.cz/resize/21449bb26c69375b910917cd2abda356_extract=388,0,1024,683_resize=480,320_.jpg?hash=f3cea8d343cc1f5a41a527b56afb0c6b	",
            "https://www.zlate-mince.cz/mince/Krtecek_snek.jpg	",
            "https://www.vesna.cz/upload/2916-1111269598.jpg	",
            "https://www.maxmax.cz/images/thumbnails/879/879/detailed/144/574_1_little_mole.jpg	",
            "https://d25-a.sdn.cz/d_25/d_15112464/img/57/600x428_23UU_v.jpg?fl=res%2C350%2C350%2C1%7Cwebp%2C80	",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTO_SQv8pjItl42rc3rdPqA1ALNplW1-KLujQ&usqp=CAU	",
            "https://www.sablonynazed.cz/c/12-category_default/krtecek.jpg	",
            "https://img.cncenter.cz/img/18/new_article/2472476-img-krtkova-dobrodruzstvi-krtecek-vecernicek-v5.jpg?v=5	",
            "https://i.pinimg.com/originals/9b/7e/bc/9b7ebc9205ecee04da055a2246b498ed.jpg	",
            "https://blog.feedo.cz/wp-content/uploads/2018/05/Krte%C4%8Dek-ve-vod%C4%9B-1-1024x299.jpg	",
            "https://cdn.myshoptet.com/usr/www.pohlednice-tap.cz/user/shop/big/16682_krtek-2.jpg?5f902cc5	",
            "https://www.nejbaby.cz/files/photos/1600-1200/8/8a0a9ab482f17b4f77dc367b3b0b727ce6024d95.jpg	",
            "https://img.maxikovy-hracky.cz/Images/maxik/dino-krtecek-drevene-kostky-12ks-krtek-a-pratele/7954/2d4f9816a333ad5610d04fa99433c3-detail.jpg	",
            "https://lh3.googleusercontent.com/proxy/mnfVJm56UBFTau4GQg9klk3_FNIL_obX6w5El3yE9JeCWQu3nc2FSG257q7896mQ-s4NKIyzEU6eqC6WC-fAG3d4UAAFBa-0gwzwo9Gp0cKh-Tec-Vn1-5xzJBUauRuQwHFQ	",
            "https://www.a-puzzle.cz/thumbs/uploads/products/638/0_1200x1200/32331068.jpg	",
            "https://lh3.googleusercontent.com/proxy/wYrKy78qMb8WvcXFHfsTCWXv8obNL-RDt8rPZRxngzJkkSL24kkD2pDaVdE5xBfcL3UwO3Rir693a6RFJFAPfptuAXa6HsZw7exLf0RGTDSp3cZLOVsMfO_TJ28KBFA5qkkWGSE595_SLLepkw	",
            "https://i.ytimg.com/vi/KkPjVuQupng/maxresdefault.jpg	",
            "https://lh3.googleusercontent.com/proxy/QpWwEpnjHHf5rrj-d2oxg5EfqxbpuJr7PCW14U-clo9JyH83YNISvooBd8hD5CbnOQH2VbL8ekeAfx-MpqjrVkdIvQRr2YN2W1y1Vw	",
            "https://img.4kids.cz/Images/4kids/dino-kostky-krtek-a-ptacek-12k/108848/7945749ada7ca30fd2f64992e840b5-detail.jpg	",
            "http://www.zeme-deti.cz/fotky5032/fotos/DD-WBD8101-bordura-krtek-auticko.jpg	",
            "http://www.podlaharstvi-policka.cz/img/podlahy/detske-koberce/krtecek-a-kamaradi.jpg	",
            "https://www.chcipovleceni.cz/media/catalog/product/cache/4/image/62ab0471f1c06ac4153e310c30a18b6d/d/e/detska-osuska-krtek-a-slunicko-cervena-b.jpg	",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSl9xeeBAEJPrJ5nY17VPj0NVrnWp4zy5E6MQ&usqp=CAU	",
            "https://img.cncenter.cz/img/11/normal690/2357699_krtek-krtecek-panda-cina-serial-v0.jpg?v=0	",
            "https://img.ihned.cz/attachment.php/90/62475090/S8CFIDxVLPH6tJrlA1TpR904KGuWOadQ/252-11F-Zeman-Krtecek_iPad.jpg	",
        };

        [Command("ceskejkrtek")]
        [Alias("krtekceskej")]
        public async Task KrtecekAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Normální českej krteček**",
                ImageUrl = urlKrtecek.GetRandom(),
                Color = Color.Red,
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Nezkažená pohádka z našich dětství od MilošBota",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());

            var cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("czkrtek: " + eb.ImageUrl);
        }

        private static readonly string[] urlKremilek = new[]
        {
            "https://i.ytimg.com/vi/aDK_Wj5RzkI/maxresdefault.jpg",
            "https://www.mall.cz/i/44537189/550/550	",
            "https://tradag.cz/sites/default/files/styles/600x800/public/obrazy/8100_0586_kav-6.jpg?itok=p4rC8Gdd",
            "https://cdn.knihcentrum.cz/6948392_zdenek-smetana---omalovanka-se-samolepkami.jpg",
            "https://www.kudyznudy.cz/files/47/475a61cf-4171-4bcb-9680-007232d664e0.jpg?v=20200826152113",
            "https://tradag.cz/sites/default/files/styles/600x800/public/obrazy/8100_0585_kav-5.jpg?itok=HHpQHODP",
            "https://img.ceskatelevize.cz/program/porady/898296/foto09/01.jpg?1361787457",
            "https://www.jenpohadky.cz/public/foto/output/0Rd6fD35XifJzoz_484x330.jpg",
            "https://lh3.googleusercontent.com/proxy/QmOXXF0fT3ZDfb7Sj9UFmu2Jy3IFgITLFhux71WvghYDc_0iq1e1qavWvaUOf1aqvBpeyuLT1kE_of0wWVkrEmsYtTK93dh5cV8wooiAhihpeX4eBpkEH2YSO8iCxqFBiWj-cv6OXAZ5Fg	",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/kv_bw_color_01_181001-144905_kro.jpg?itok=-ynB8scZ	",
            "https://kidshouse.cz/wp-content/uploads/2020/04/Kremilek-a-Vochomurka-3-1024x652.jpg",
            "http://img.ceskatelevize.cz/ivysilani/episodes/photos/crop/898296/51904.jpg?1542111379",
            "https://www.postavy.cz/foto-dila/kremilek-a-vochomurka-foto.jpg",
            "https://img.youtube.com/vi/O9j6aLWVynE/0.jpg",
            "https://tradag.cz/sites/default/files/alba/fotoalbum-kremilek-a-vochomurka-spi.jpg	",
            "https://1gr.cz/fotky/lidovky/13/101/lnc460/EBR4e5a00_kemilekavochomurka.jpg",
            "https://lh3.googleusercontent.com/proxy/iDfDmrpB3g8sxQlEbhHz_F5z7jdv_4yLsnVlRCdtnfhikPKTDx96kUgZt0lbosOE8pQbRzWKwTYhqPPKx72ZG4wFYa2CZ62yhhMhF6oZXaQCElqwys_X4zGZY9vpi44M14wFhPDHPVBHuudmtiGoOYs",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRX_tzDFTd4aDfrNpjMZMFDq6cksMVhlk5T8w&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQswv7MHqXPUlXPXU4lZsgSRGXv5yH66IHToQ&usqp=CAU",
            "https://i.ytimg.com/vi/G6zfxcATbL0/hqdefault.jpg",
            "https://kidshouse.cz/wp-content/uploads/2020/04/Kremilek-a-Vochomurka-2-1024x683.jpg",
            "https://img.blesk.cz/img/1/full/2472431_pohadky-z-mechu-a-kapradi-kremilek-a-vochomurka-vecernicek-v0.jpg?v=0	",
            "https://cdn.myshoptet.com/usr/www.pohlednice-tap.cz/user/shop/big/6221_6221-2-pohlednice-kremilek-a-vochomurka-vypraveji-pohadku.jpg?5f7eea23",
            "https://cdn.albatrosmedia.cz/Images/Product/21138/?ts=636575456798130000",
            "https://lh3.googleusercontent.com/proxy/s8DYpH_ZU3xGLfZFgl2VYdL1yIhvJ_72x-WCWF4GL4c9ZXgUeRvItd5V19XDBayOj02DbXmg905rPRfbuvdEV725oqg0eUwj56osVvL32G78Ceg",
            "https://img.youtube.com/vi/iyRpkUF3UyU/0.jpg",
            "https://cdn.xsd.cz/original/5a7b45e01fb83bd987e992890ef2d638.png",
            "https://lh3.googleusercontent.com/proxy/xWuPXGu_rSXFj8g1fhxxxDnEY8blJC3jp9ns1vwBTGNy-VhXGWLu6bHWY9Ltgw624RYmCL2GmybhhI4QN2BcW8w9lHmAJxzujkrhAdCXIQ-1ocvP8Fl20Dus3lUtw0dXrr7dFrw",
            "https://tradag.cz/sites/default/files/obrazy/kremilek-a-vochomurka-na-louce.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRNAXFc95eZhA6X5dOE31Kauu-BYQb8FQWjng&usqp=CAU",
        };

        [Command("kremilekavochomurka")]
        [Alias("vochomurka", "kremilek")]
        public async Task KremilekVochomurkaAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Pohádky z Mechu a kapradí**",
                ImageUrl = urlKremilek.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Křemílek a Vochomůrka od MilošBota",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());

            var cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("pohadkyzmechuakapradi: " + eb.ImageUrl);
        }

        private static readonly string[] urlRakosnicek = new[]
        {
            "https://i.ytimg.com/vi/xgt9YOYYSeI/maxresdefault.jpg",
            "https://www.sablonynazed.cz/395-large_default/rakosnicek-01.jpg",
            "https://storage.cinemaware.eu/katalogy/images/f/f/ff238313-ea67-11e7-8e7d-000c29a578f8.jpg",
            "http://msplananl.wbs.cz/rakosnicek.jpg",
            "https://cdn.myshoptet.com/usr/www.pohledy.cz/user/shop/big/7425_pohlednice-rakosnicek-1.jpg?5d0b45ed",
            "https://i.pinimg.com/originals/0d/21/90/0d219056294b2f573c2fd13481fb0240.png",
            "https://cdn.alza.cz/ImgW.ashx?fd=f3&cd=AKA475",
            "https://cdn.myshoptet.com/usr/www.pohlednice-tap.cz/user/shop/big/12617_12617-3-pohlednice-rakosnicek-a-hlemyzd.jpg?5f7eea7f",
            "https://d15-a.sdn.cz/d_15/c_img_F_F/0YEK6Q.jpeg?fl=cro,0,75,800,450%7Cres,1200,,1%7Cwebp,75",
            "https://www.mall.cz/i/42928997/550/550",
            "https://tradag.cz/sites/default/files/styles/600x800/public/obrazy/rakosnicek-a-rybnik.jpg?itok=EcWIqHs_",
            "https://tradag.cz/sites/default/files/obrazy/8100_0192_rakosnicek_2.jpg",
            "https://cdn.myshoptet.com/usr/www.pohledy.cz/user/shop/big/965_pohlednice-rakosnicek-3.jpg?5cc0b4a2",
            "https://c1.primacdn.cz/sites/default/files/styles/landscape_extra_large/public/images_original/0/328510polivka-na-vine-4-dil-rakosnicek-sedmivlas.jpg?itok=NxvyEvN1&c=def_cloudinary	",
            "https://tradag.cz/sites/default/files/obrazy/rakosnicek.jpg",
            "https://cdn.albatrosmedia.cz/Images/Product/20832/?ts=636575456798130000",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTmmZU4YF9j772bp2er6rmCZSdX2oXKBOyICw&usqp=CAU",
            "https://www.e-color.cz/image/big/tapetka_rak.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRT50XedAWs52NgGXN34XNzh79d_JmtfsakRQ&usqp=CAU",
            "https://d15-a.sdn.cz/d_15/c_img_E_E/wdiK0W.jpeg?fl=cro,0,0,800,799%7Cres,1200,,1%7Cwebp,75",
            "https://cdn.myshoptet.com/usr/www.pohlednice-tap.cz/user/shop/big/12614_12614-3-pohlednice-rakosnicek-a-fen.jpg?5f7eea7f",
            "https://img-cloud.megaknihy.cz/175054-original/33450e7d43b1032b87c2cb246d33be31/rakosnicek-a-jeho-rybnik-dvd.jpg",
            "https://cdn.myshoptet.com/usr/www.pohlednice-tap.cz/user/shop/detail/12617_12617-3-pohlednice-rakosnicek-a-hlemyzd.jpg?5f7eea7f",
            "https://www.sablonynazed.cz/400-large_default/rakosnicek-06.jpg",
            "https://cdn.myshoptet.com/usr/www.pohledy.cz/user/shop/big/962_pohlednice-rakosnicek-2.jpg?5cc0b4a2",
            "https://i.ytimg.com/vi/FvFuklLl7k0/hqdefault.jpg",
            "https://www.koukalek.cz/www/ir/produkt-images/rakosnicek-a-hvezdy-1193--mm1024x768.jpg",
            "https://img.blesk.cz/img/1/full/3102412_jirina-bohdalova-rakosnicek-brcalnik-pohadky-vecernicek-hlas-narozeniny-vyroci-v0.jpg?v=0",
            "https://www.tvguru.cz/wp-content/uploads/2019/05/24/majka-kucerovablahova/rakosnicek.jpg",
            "https://i.ytimg.com/vi/LDgY6Q5Fsbk/maxresdefault.jpg",
        };

        [Command("rakosnicek")]
        public async Task RakosnicekAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Rákosníček a jeho rybník**",
                ImageUrl = urlRakosnicek.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Bohdalka od MilošBota",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());

            var cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("rakosnicek: " + eb.ImageUrl);
        }
    }
}
