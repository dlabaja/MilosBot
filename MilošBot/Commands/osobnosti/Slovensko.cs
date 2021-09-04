using Discord;
using Discord.Commands;
using MilošBot.Extensions;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Slovensko : ModuleBase<SocketCommandContext>
    {
        private static readonly string[] urlFico = new[]
        {
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/-17Ud921QDX0DT0nT52vQw.1280~Predseda-Smeru-SD-Robert-Fico.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/1e1d005ecfc3575811c10882267279fd.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/201802nrsr683526-e1591619777427.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/230px-Fico_Juncker_(cropped).jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/23oktober2020_NRSR_Matovic_14736019-1.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/2428596-fo00095735.jpeg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/2547203_400x700.jpeg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/28d2d67289d887e2fa58a6061da7d78c.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/323552_1200x.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/353cc536c4dbd8b73930072ce7e6d47f.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/3563401_240x240.jpeg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/3ab11ff3-f925-4e7a-b200-0b7ae0d9a812_3-23112020-robert-fico-financne-riaditelstvo-sr742981.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/4-1afad0dd9596e2b32904ad09b5e3da763d980907.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/4-6982ce2b389dbb633a98532281bfe75969630116.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/4-71a663e51ada29fbc3460a665256dbbc909b5938.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/4-a07750b84612782969eaae3a6be986065e26cc01.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/53bc7c3b-d1c6-48d1-9b34-3fb15679977f.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/6131021_1200x.jpeg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/6397591_1200x.jpeg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/6907d0c2-3865-40ee-8f6f-7c27d5504d41_17december2020-nrsr-3747769.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/6_Fico.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/91527_robert-fico-andrej-kiska-676x451.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/99f8fc3b2b5de0dc3e4a01906cd2e6df.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/9UjL.predseda_smer_sd_robert_fico_.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/9ee9ab41e89965b752b70ac610f2af51.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/Bop4.predseda_smer_sd_robert_fico_.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/FICO-2-740x365.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/Fico1.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/Fico_Juncker_(cropped).jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/HANDSHAKE_-_BRATISLAVA_SUMMIT_16._SEPTEMBER_2016_(29090292373)_(cropped).jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/IMG_4100.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/JMgv21oNSAyvdMPqZDKvaQ.1280~Predseda-strany-Smer-Robert-Fico.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/JueKdui2SW70TA2gfJZQFQ~Fico-uverejnil-video-v-saku.png",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/JvDT.fico_jpg.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/N8nE.1marec2020_fico_volby_nrsr2020_3686916_jpg.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/P9Yw.predseda_strany_smer_socialna_demokracia_robert_fico_.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/RJP9DXhYTXCATrxzge-xsQ.1280~Predseda-Smeru-SD-Robert-Fico.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/Robert-Fico.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/Robert_Fico_2017.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/Valdis_Dombrovskis_tiekas_ar_Slov%C4%81kijas_premjeru_Robertu_Fico_(8053988819)_(cropped)_2.png",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/a3b01dff347c056409a1163d5a8410a9.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/bfbffa.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/c54d11a6-413c-49b1-86bc-39202a47a456_phptcysxi.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/cfc0f04c2dc0323a5e2b734af73b77b3.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/dmF43_kqTM2_FgX-f4YybA~Robert-Fico-sa-vzdal-svojej-kandidat-ry-aby-n-sledne-zablokoval-cel-proces-vo-by-nov-ch-sudcov.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/eDxy.fico3_jpg.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/fBiHLQSoSBTensSUvXrgRA.1280~Robert-Fico.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/fico.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/fico_29_5.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/fico_pellegrini.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/ficosady-posprejovali-znacku-obce-v-ktorej-stoji-luxusny-kastiel-kde-chodi-prespavat-robert-fico~40cee1c6b94f161256c4.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/gHco.ficiakweb_jpg_bez_watermarku_1_jpg.jpg",
            "https://media1.tenor.com/images/5abd9b3c40d8cad35ac03f959c7b949e/tenor.gif?itemid=17477020",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/headline.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/image-44147.jpeg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/image-47242.jpeg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/img_1719-1-scaled-1-676x451.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/lsuJe29yRU-7M0qfrNQuhA~Robert-Fico.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/pTq3TJX1QtDOSBEa9Laqdg.1280~Predseda-strany-Smer-SD-Robert-Fico.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/robert-fico-4-676x451.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/robert-fico-clanokW.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/robert-fico-kampan-clanokW.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/robert-fico-predseda-strany-smer-clanokW.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/sghbhgfh.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/unnamed.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/ficoska/zgngfngns.jpg",
            "https://media1.tenor.com/images/a407db10e3c78952a824e9afdea81c89/tenor.gif?itemid=15403689",
            "https://media1.tenor.com/images/3e8e8eca767a4331128a8f3570e5f631/tenor.gif?itemid=17248775",
            "https://media1.tenor.com/images/1fd6b103fc4a4b8b686196bfb7db0388/tenor.gif?itemid=12756379",
            "https://media1.tenor.com/images/30fbc0c9d26aa0a965f6472d22231507/tenor.gif?itemid=17279061",
            "https://media1.tenor.com/images/8675f55c4825d0332576e2f26b1bc940/tenor.gif?itemid=7738288",
            "https://media1.tenor.com/images/5099b7c9dcfd74124700f8ad6ed1aa47/tenor.gif?itemid=7738252",
            "https://media1.tenor.com/images/fba195c4acc9477f8032a875c67df7a5/tenor.gif?itemid=12426648",
        };

        [Command("fico")]
        [Alias("robertek", "robert")]
        public async Task FicoAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "Here, take Some** ~~Robertek~~ **Politik s děsivým výrazem**",
                Color = Color.Red,
                ImageUrl = urlFico.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Čerstvého Fica poskytl CharlieCat",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());

            var cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("fico: " + eb.ImageUrl);
        }

        private static readonly string[] urlHrabin = new[]
        {
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/0w1D.harabin_png.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/13119915_208070492911881_5394729093732418795_o.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/1f6cf0760ea104e954fa3c7eae7dbb81.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/252eaa836215a273064720614b6d4717.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/3874751_1200x.jpeg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/39888.png",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/4-37f7639ebfe66a7dbe8f3334b89442b1f5cd68bf.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/4-697fcd9670f03bd6a55a46bf7ffbe1c69a597c8d.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/4035093_240x240.jpeg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/4079536_1200x.jpeg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/4U8qsi92Tr-UT23JCRzwCA.1280~Pojedn-vanie-so-tefanom-Harabinom-bolo-odro-en%20-%20ko%CC%81pia.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/4U8qsi92Tr-UT23JCRzwCA.1280~Pojedn-vanie-so-tefanom-Harabinom-bolo-odro-en%20-%20k%C3%B3pia.jpg44%20minutes%20ago",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/4U8qsi92Tr-UT23JCRzwCA.1280~Pojedn-vanie-so-tefanom-Harabinom-bolo-odro-en.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/4f4b8c07-a1c7-4553-b520-8de1e173c3e2_spokojny-stefan-harabin-netaji-radost-z-uspechov-svojho-syna.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/5971183_1200x.jpeg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/6161283_1200x.jpeg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/712-768x548.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/7bfbc068-80fd-4548-92e9-cd2c1f945a8f_dam-urlranygb.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/8d8431f9-1728-4c57-825d-3c81720da8a1",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/Bez-n%C3%A1zvu.png",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/FcUNM1tgTEa9odctdkIKIg~Robert-Fico-a-tefan-Harabin.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/HCcAZ-m6Sl7e91gxO3RPXg~tefan-Harabin.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/HCcAZ-m6Sl7e91gxO3RPXg~tefan-Harabin.jpg.aria2",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/Harabin.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/IMG_1062.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/IMG_9767-1170x780.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/KV9fL6lkTb3R5jPdvlz9aw~tefan-Harabin-s-man-elkou-Gabrielou-pri-pr-chode-do-volebn-ho-t-bu.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/NafLy__jTMPahTjtmS4d8A~tefan-Harabin.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/Obr%C3%A1zok1-2.png",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/SF-IMG_0153-vyrez.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/Stefan-Harabin.1.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/TBEN7505.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/TBEN8654b.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/TBEN8690.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/TBEN8694.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/TX3Y.stefan_harabin.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/XwKPKkcJSmHh-XIpjwkSaw.2560~tefan-Harabin.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/aAEC2ETo_400x400.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/c41bdda4-b497-44db-8a41-8fa01ed03aa3_dam-urlqgrrxd.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/ce8ad6bc-e5a5-49e3-a2cc-c2d988eef1f7_ms-svk-20200220-baranik-harabin-010-h.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/d2826f9b-f026-4625-adbd-a5d091db5cd0_php2ktppm.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/e42db64bae717ff122d4f919e34f83d0",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/e4f9d7a9-1639-4eee-a867-89c3aa2b1ce3",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/e84128ab-21e4-4855-9622-ff593faf364c_dam-urlivwb55.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/har_OR_4134x-1170x780.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/har_OR_4183-1-1170x780.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/harabin%20-%20ko%CC%81pia.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/harabin%20-%20k%C3%B3pia.jpg44%20minutes%20ago",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/headline.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/image-12-370x197.jpeg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/images",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/img_1831-676x451.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/kandidat-stefan-harabin-%E2%80%93-vychodniar-s-velkou-rodinou-a-slabostou-pre-meciara-448.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/obrazok_clanok_article_detail52e7ce9b765e7588e72abdcd0842f63e.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/sr-harabin-vlast-lsns-kotleba-bax-clanokW.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/stefan-harabin-676x451.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/stefan-harabin-clanokW.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/stefan-harabin-sa-objavil-na-proteste-1.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/stefan-harabin-si-na-kampan-pozical-770-tisic-eur-minul-viac-ako-milion-od-statu-nedostane-ani-cent~06a9375fc4da11a6f102.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/stefan-harabin-strana-vlast-676x451.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/stefan-harabin-vlast-676x470.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/stefan-harabin-vlast-992x689.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/stefan-harabin-zvazuje-ustavnu-staznost-na-priebeh-volieb-vraj-strane-vlast-umyselne-znizili-pocty-hlasov~e32970f1bcec74d48939.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/stefan-harabin.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/stefan-harabin.png",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/stefan_harabin.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/unnamed.1.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/unnamed.jpg",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/vlast_og_image.png",
            "https://bkjsvdbkjsdvhbsdkjbsdhbhsdfhbsd.netlify.app/hrabanin/"
        };

        [Command("harabin")]
        [Alias("harab", "stefan", "harabín", "štefan")]
        public async Task HarabinAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Nejstarší Youtuber na Slovensku**",
                Color = Color.Red,
                ImageUrl = urlHrabin.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Děkujeme CharlieCatovi za fresh Harabina",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());

            var cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("harabin: " + eb.ImageUrl);
        }
        
        private static readonly string[] urlPelegriny = new[]
        {
            "https://upload.wikimedia.org/wikipedia/commons/6/62/Peter_Pellegrini_May_2019.jpg	",
            "https://pbs.twimg.com/profile_images/1201151204392394753/qWvxnVFN.jpg	",
            "https://www.globsec.org/wp-content/uploads/2018/04/pellegrini1.jpg	",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_horizontal/public/2214938-p201809200307901.jpeg?itok=vnTJJNbn	",
            "https://ec.europa.eu/info/sites/info/files/peter_pellegrini.jpg	",
            "https://www.barrandov.tv/obrazek/202002/5e55032573e15/crop-325311-p202002210412801_960x540.jpeg	",
            "https://img.ihned.cz/attachment.php/700/75025700/aEVrSNUHwbdCOMht2FQki1zxTJ8nyesq/jarvis_5ee12ed9498e75f6cd0f928d.jpeg	",
            "https://cdn.xsd.cz/resize/abefe2cd03e533bc9cbc1647b7523f81_resize=680,383_.jpg?hash=8efe698213b2a4dce1cd099d33a12d22	",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_twitter/public/uploader/2018-05-02t145632z_2_180502-220325_ako.jpg?itok=QPMiwnoo	",
            "https://cdn.xsd.cz/resize/06999468d0e03177b80dc8b264bfbef0_extract=0,0,1750,985_resize=680,383_.jpg?hash=c7f45769566a1334d7f6daeff0d24041	",
            "https://upload.wikimedia.org/wikipedia/commons/6/64/Peter_Pellegrini_-_2015.jpg	",
            "https://i2.wp.com/kafkadesk.org/wp-content/uploads/2020/07/peter-pellegrini-hlas-party-smer.jpg?fit=950%2C534&ssl=1	",
            "https://roscongress.org/upload/resize_cache/iblock/7fc/289_289_2/_.jpg	",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/2018-03-15t123420z_8_180315-161915_ako.jpg?itok=7N1WsbmQ	",
            "https://cdn.xsd.cz/resize/84a60021a48f35b4a7577e40c14cbd7d_extract=100,0,1934,1088_resize=680,383_.jpg?hash=03e70c1dfe453c38a0629db269a7e9ae	",
            "https://www.broadband4europe.com/wp-content/uploads/2014/11/peter-pellegrini.jpg	",
            "https://img.cncenter.cz/img/3/article/4863259_slovensko-vladni-krize-smer-sd-peronalni-zmeny-fico-kalinak-pellegrini-v0.jpg?v=0	",
            "https://emerging-europe.com/wp-content/uploads/2020/03/afp-990x556.jpeg	",
            "https://img.blesk.cz/img/1/full/5840216_peter-pellegrini-slovensko-premier-dovolena-italie-v1.jpg?v=1	",
            "https://m.smedata.sk/api-media/media/image/spectator/1/60/6019851/6019851_1200x.jpeg?rev=3	",
            "https://assets.bwbx.io/images/users/iqjWHBFdfxIU/idCzkpYJMm4A/v0/1000x-1.jpg	",
            "https://m.smedata.sk/api-media/media/image/spectator/2/12/121222/121222_1200x.jpeg?rev=3	",
            "https://d15-a.sdn.cz/d_15/c_img_E_I/LN9veR.jpeg?fl=cro,0,262,720,405%7Cres,1200,,1%7Cwebp,75	",
            "https://pbs.twimg.com/media/CoR4RssWYAA5SFz.jpg	",
            "https://plus.rozhlas.cz/sites/default/files/styles/cro_16x9_tablet/public/images/e5a42d6ba7180b9a2e4626ce119bac52.jpg?itok=rFW4dzns	",
            "https://m.dw.com/image/42990944_401.jpg	",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/scale_1180/public/images/2431984-rts32txt.jpg?itok=8xDfq2gS	",
            "https://static.novydenik.com/2020/06/Peter-Pellegirini.-Foto-Foto-N-%E2%80%93-Tom%C3%A1%C5%A1-Benedikovi%C4%8D.jpg	",
            "https://www.euractiv.com/wp-content/uploads/sites/2/2020/03/igor-800x450.jpg	",
            "https://cdncz1.img.sputniknews.com/img/1073/57/10735798_0:43:3072:1705_1000x541_80_0_0_26b943f10b13bf1470446d572642d062.jpg	",
            "https://img.cncenter.cz/img/11/normal690/5195733_slovensko-eu-peter-pellegrini-jean-claude-juncker-jan-kuciak-crop-v0.jpg?v=0	",
            "https://g.denik.cz/1/68/peter-pellegrini-d180404ut3y71_denik-320-16x9.jpg	",
            "https://www.europarl.europa.eu/resources/library/images/20190312PHT31129/20190312PHT31129-cl.jpg	",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSB9pz_kKsZ5Ms5iy8pixHB5qVkcM9Q2uY5ng&usqp=CAU	",
            "https://img.blesk.cz/img/1/full/5840217_peter-pellegrini-slovensko-premier-dovolena-italie-v0.jpg?v=0	",
            "https://d2v9ipibika81v.cloudfront.net/uploads/sites/193/pelle-1140x684.jpg	",
            "https://1gr.cz/fotky/idnes/18/032/r7/BUR71fc76_89MGO018_SLOVAKIA_CRIME_POLITICS_031.JPG	",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_maly/public/uploader/2020-06-22t000000z_8_200722-191557_ako.JPG?itok=PUFboe6S	",
            "https://img.cncenter.cz/img/11/full/5692619_.jpg	",
            "https://www.euractiv.com/wp-content/uploads/sites/2/2019/09/w_55235349-800x450.jpg	",
            "https://i.refresher.sk/public/tina-hamarova/radom_sprav_9/96790675_1621744247992973_7773728206888108032_n.jpg	",
            "https://d2emjept89nv7b.cloudfront.net/podcast-covers/873/275621/1/1000/peter-pellegrini-poslanci-hlasu-by-odvolavanie-premiera-podporili.jpg	",
            "https://static.novydenik.com/2020/03/TBEN0511-e1554395986989-1000x796-1.jpg	",
            "https://img.cncenter.cz/img/3/full/4870392_slovensko-vlada-koalice-fico-pellegrini-v0.jpg?v=0	",
            "https://m.smedata.sk/api-media/media/image/spectator/2/37/3785002/3785002_1200x.jpeg?rev=3	",
            "https://t.aimg.sk/magaziny/gKCAzgF3QOT_XQQQoaDysw.1280~Peter-Pellegrini.jpg?t=L2ZpdC1pbi84MDB4MA%3D%3D&h=fGtVF8Smt2Lg6Obh9kFGCw&e=2145916800&v=2	",
            "https://rmx.news/media/6d5/atc_thumb_6d5e5b7a463c09ccf8f91c93303d85ad72493169.jpeg	",
            "https://cdncz1.img.sputniknews.com/img/1071/41/10714139_0:181:2541:1556_1000x541_80_0_0_2407cb703cb6bcd889d5aeacf6e872c5.jpg	",
            "https://pbs.twimg.com/media/ETUvwNtWsAUvhQI.jpg	",
            "https://infocz-media.s3.amazonaws.com/infocz/production/files/2020/07/19/16/39/29/52bb3ccc-eae7-407e-a0db-ba1f3423f917/4902611.jpg	",
            "https://cdn.xsd.cz/resize/7adf6c1c8cbb3c5688060019b2bd8e33_resize=1219,1750_.jpg?hash=e0474cd103d51f774706454eeea21a4f	",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSyBSwyfhrVzFg-5MPrnhDfb9dOiNr2p04cOQ&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT-R7nVIYIwriyEUgc-l5I90Sst0MQNnyZhsQ&usqp=CAU",
        };

        [Command("pelegrini")]
        [Alias("peleg", "peter", "pellegrini")]
        public async Task PelegriniAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Peter**",
                Color = Color.Red,
                ImageUrl = urlPelegriny.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Čerstvého Pellegriniho od Kubaka přináší MilošBot",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());

            var cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await cons.SendMessageAsync("peleg: " + eb.ImageUrl);
        }
        
        private static readonly string[] urlDanko = new[]
        {
            "https://upload.wikimedia.org/wikipedia/commons/0/08/Andrej_Danko.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/c/c8/Andrej_Danko_2018.jpg",
            "https://m.smedata.sk/api-media/media/image/sme/5/31/3118635/3118635_240x240.jpeg%3Frev%3D2",
            "https://www.parlament.gv.at/WWER/PAD_00000/8514355_500.jpg",
            "https://refstatic.sk/article/plagiator-andrej-danko-je-najhorsim-prikladom-pre-slovenskych-studentov-ako-sa-z-neho-mozeme-poucit~15e9701bb21d9024f8cf.jpg%3Fis%3D919x570c%26ic%3D0x80x1200x744%26c%3D2w%26s%3Ddf0ef07383ab8ad28948838f3a28be9a9f0d7422fb60fadf8eb7806d4c000dd0",
            "https://static.markiza.sk/a501/image/file/21/1551/Moq1.andrej_danko.jpg",
            "https://img.projektn.sk/wp-static/2019/05/danko-putin.jpg%3Ffm%3Djpg%26q%3D85%26w%3D690",
            "https://m.smedata.sk/api-media/media/image/spectator/2/37/3706672/3706672_1200x.jpeg%3Frev%3D2",
            "https://ipravda.sk/res/2020/01/25/thumbs/andrej-danko-clanokW.jpg",
            "https://m.smedata.sk/api-media/media/image/sme/0/43/4389010/4389010_1200x.jpeg%3Frev%3D4",
            "https://www.tyzden.sk/data/tmp/2b005a5-1250x1250xintelligent/c2/f4/17f58d57c9f312406fd52339f63d6a48.jpg",
            "https://m.faz.net/media0/ppmedia/aktuell/1225528571/1.6369656/mmobject-still_full/andrej-danko.jpg",
            "https://cloudia.hnonline.sk/r740x/36f8ee42-87fc-4a9b-8c7c-aa1342e46af4",
            "https://dam.nmhmedia.sk/image/8e952cb7-e2ce-4929-a06c-fe3983fa6762_phpomegim.jpg/960/540",
            "https://cdn.webnoviny.sk/sites/32/2020/07/img_8635-2-min-1-scaled-1-676x451.jpg",
            "https://img.joj.sk/r960x/44c5cff551dd065a9943019da46b88df",
            "https://cloudia.hnonline.sk/r740x/2c6504939b67d531c8804a03fc69c188",
            "https://ipravda.sk/res/2018/11/15/thumbs/andrej-danko_01-clanokW.jpg",
            "https://m.smedata.sk/api-media/media/image/sme/3/56/5632653/5632653_300x200.jpeg%3Frev%3D3",
            "https://i.ytimg.com/vi/cjbVtCMsmuA/maxresdefault.jpg",
            "https://www.expres.sk/wp-content/uploads/2019/10/andrej-danko.jpg",
            "https://m.smedata.sk/api-media/media/image/sme/2/43/4322392/4322392_970x647.jpeg%3Frev%3D3",
            "https://cdn.webnoviny.sk/sites/32/2019/11/jaroslav-paska-andrej-danko-eva-smolikova-anton-hrnko-676x451.jpg",
            "https://www.tyzden.sk/data/tmp/2b005a5-1250x1250xintelligent/6b/12/5d41316cc92dfc5a3884f0f63f260389.jpg",
            "https://ipravda.sk/res/2018/10/17/thumbs/andrej-danko-clanokW.jpg",
            "https://static.markiza.sk/a501/image/file/16/1748/BvD8.andrej_danko_.jpg",
            "https://static.markiza.sk/a501/image/file/2/0750/Owey.vylozky_jpg.jpg",
            "https://img.projektn.sk/wp-static/2017/01/danko_vylozky-1.jpg%3Ffm%3Djpg%26q%3D85%26w%3D627",
            "https://img.joj.sk/r810x456n/7be2b83528f720ed76e953b0c2010884",
            "https://mfa.gov.by/upload/2019-08-07-leshchenya-slovakia.jpg",
            "https://img.topky.sk/big/2738509.jpg/Andrej-Danko.jpg",
            "https://cloudia.hnonline.sk/r740x/36f8ee42-87fc-4a9b-8c7c-aa1342e46af4",
            "https://i.ytimg.com/vi/zhRwECqfzmQ/maxresdefault.jpg",
            "https://m.smedata.sk/api-media/media/image/fici/2/23/2348872/2348872_625x.jpeg%3Frev%3D2",
            "https://encrypted-tbn0.gstatic.com/images%3Fq%3Dtbn:ANd9GcS6GgULcscGUuRUInUmqt2c5RkjeENVzG2vgQ%26usqp%3DCAU",
            "https://cloudia.hnonline.sk/r1200x/52d3d519-9843-4e15-b021-0abb0a489360",
            "https://static.markiza.sk/a501/image/file/2/0357/snrS.danko_jpg.jpghttps://img.projektn.sk/wp-static/2019/01/29012018Tatry_Danko_2589045.jpg%3Ffm%3Djpg%26q%3D85%26w%3D600",
            "https://ipravda.sk/res/2021/01/23/thumbs/andrej-danko-clanokW.jpg",
            "https://www.tyzden.sk/data/tmp/2b005a5-1250x1250xintelligent/15/99/9980856c6befb612c2ac9923a75fca5a.jpg",
            "https://encrypted-tbn0.gstatic.com/images%3Fq%3Dtbn:ANd9GcTIsNeO6ab3dTG1fELpOz7oACXP7xNFfk3Kng%26usqp%3DCAU",
            "https://www.postoj.sk/uploads/6207/conversions/headline.jpg",
            "https://refstatic.sk/article/andrej-danko-chce-aby-sa-na-slovensku-ockovalo-aj-ruskou-vakcinou-sucasna-vlada-je-podla-neho-zahladena-len-na-zapad~20cf931e48aee8e0c266.jpg%3Fis%3D919x570c%26ic%3D615x109x1198x750%26c%3D2w%26s%3D92c27b2162da96e15d54bed211f2b286fdd3d5a5a59c29f801da070be7b2deb0",
            "https://img.joj.sk/r1200x/ac07703e-6a23-487b-a756-2bc88b6c22ff",
            "https://tv.nrsr.sk/teaser/other/3853.jpg",
            "https://dam.nmhmedia.sk/image/8e952cb7-e2ce-4929-a06c-fe3983fa6762_phpomegim.jpg/960/540",
            "https://www.postoj.sk/uploads/7168/conversions/headline.jpg",
            "https://prefer.sk/wp-content/uploads/2019/03/Sni%25CC%2581mka-obrazovky-2019-03-06-o-8.49.54-360x240.png",
            "https://zhumor.sk/wp-content/uploads/2019/06/cover.jpg",
            "https://img.topky.sk/big/1477921.jpg/SNS-Andrej-Danko.jpg",
            "https://img.joj.sk/r1010xn/e8a649452ecc11fb0d2d470ba65995b3.jpg",
            "https://www.napalete.sk/wp-content/uploads/2016/03/Danko-vonku-1.jpg",
            "https://www.tyzden.sk/data/tmp/2b005a5-1250x1250xintelligent/30/e8/d4698899cc81193c9f9ab29c77f77762.jpg",
            "https://encrypted-tbn0.gstatic.com/images%3Fq%3Dtbn:ANd9GcSjGx2pUlVSsIF3d67t3H6366SApNWuINeUmw%26usqp%3DCAU",
            "https://regiony.zoznam.sk/wp-content/uploads/2018/10/43537977_474389926406727_7847649760897925120_o-1-1170x780.jpg",
            "https://cloudia.hnonline.sk/r740x/b7014424-4c09-4de2-b14f-ec9d55c0db3d",
            "https://img.uncyc.org/sk/thumb/0/02/Danko.jpg/240px-Danko.jpg",
            "https://www.tyzden.sk/data/tmp/2b005a5-1250x1250xintelligent/88/0f/8b09e57d987b47b9e581feeb09c2b326.jpg",
            "https://dam.nmhmedia.sk/image/4cebf60b-686f-471f-964c-b91d482a1f20_phpserdlg.jpg/960/540",
            "https://cdn.webnoviny.sk/sites/3/2018/11/46103760_310968686168016_8339739706517925602_n-640x800.jpg",
            "https://upload.emefka.sk/posts/new/img1/07/01/90701.jpg",
            "https://www.attelier.sk/wp-content/uploads/2019/11/tenor-1.gif",
            "https://thumbs.gfycat.com/EmotionalFluidAmericanmarten-size_restricted.gif",
            "https://ocdn.eu/pulscms-transforms/1/0EqktkpTURBXy8yYTBlNDBjYTdhYjM4OTA5ODE5NGY0ODkxNjRkYWM3ZS5wbmeSlQLNAcwAwsOVAgDNA8DCww",
            "https://encrypted-tbn0.gstatic.com/images%3Fq%3Dtbn:ANd9GcSWm-mBsFuCiQ8G8Hu5ZHwFwtXVU0gnPw3_Nw%26usqp%3DCAU",
            "https://static.markiza.sk/a501/image/file/21/0485/3GOm.andrej_danko_vypravuje_ic_vlak.jpg",
            "https://img.wattpad.com/999dda1f6fff0e787cf4799b0b3d2389fe250ea1/68747470733a2f2f73332e616d617a6f6e6177732e636f6d2f776174747061642d6d656469612d736572766963652f53746f7279496d6167652f5f5a70306457314a394c6e3958773d3d2d3530342e3136333439636366643530353636653036323935343932393334312e6a7067%3Fs%3Dfit%26w%3D720%26h%3D720",
            "https://encrypted-tbn0.gstatic.com/images%3Fq%3Dtbn:ANd9GcR6A4JTyvMocbE66Uu19TA564yD2oWUR_CZ_Q%26usqp%3DCAU",
        };

        [Command("danko")]
        [Alias("kapitán", "kapitan", "captain")]
        public async Task DankoAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Plagiátor**",
                Color = Color.Red,
                ImageUrl = urlDanko.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Kontroverzního kapitána poskytl MilošBotovi CharlieCat",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());

            var con = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await con.SendMessageAsync("danko: " + eb.ImageUrl);
        }
    }
}
