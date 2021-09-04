using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Androuš : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://cdn.discordapp.com/emojis/789485419271422013.png?v=1",
            "https://cdn.discordapp.com/emojis/788857556600487966.png?v=1",
            "https://cdn.discordapp.com/emojis/815308269190512662.png?v=1",
            "https://cdn.discordapp.com/emojis/719271346626101341.png?v=1",
            "https://upload.wikimedia.org/wikipedia/commons/a/a9/A_Babi%C5%A1_Praha_2015.JPG" ,
            "https://www.forum24.cz/wp-content/uploads/2020/03/Andrej-Babi%C5%A1-grimasa-Petr-Kupec-%C4%8CTK-.jpeg" ,
            "https://cdn.xsd.cz/resize/8e6169744c47386f9bd7003b858cb462_extract=46,0,1024,576_resize=680,383_.jpg?hash=27642411cba44c1cd72e027603452d3e" ,
            "https://d15-a.sdn.cz/d_15/c_img_F_I/zS6BtYO.jpeg?fl=cro,0,46,1280,720%7Cres,1200,,1%7Cwebp,75" ,
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/7a59b557dd547162d741_200809-170758_oro.jpg?itok=l3bW3lCF" ,
            "https://d15-a.sdn.cz/d_15/c_img_F_I/zS6BtYO.jpeg?fl=cro,0,46,1280,720%7Cres,1200,,1%7Cwebp,75" ,
            "https://www.transparency.cz/wp-content/uploads/Andrej-Babi%C5%A1-zdroj-Luk%C3%A1%C5%A1-B%C3%ADba.jpg" ,
            "https://im.tiscali.cz/press/2019/12/17/1126227-profimedia-0487726063-1250x905.jpg?1587596281.0" ,
            "https://infocz-media.s3.amazonaws.com/infocz/production/files/2020/07/14/23/52/41/b35d3e12-6406-487a-a4ee-51e2cfa447cc/6273658.jpg" ,
            "https://img.cncenter.cz/img/11/full/6077223_andrej-babis-v0.jpg?v=0" ,
            "https://d15-a.sdn.cz/d_15/c_img_F_J/AntxSi.jpeg?fl=cro,0,0,1280,720%7Cres,1200,,1%7Cwebp,75" ,
            "https://d39-a.sdn.cz/d_39/c_img_QQ_T/YS0L4.jpeg?fl=cro,0,13,1800,1013%7Cres,1200,,1%7Cwebp,75",
            "https://cdn.discordapp.com/attachments/723512415198642177/807710347996823582/unknown.png",
            "https://infocz-media.s3.amazonaws.com/infocz/production/files/2020/07/14/23/52/41/b35d3e12-6406-487a-a4ee-51e2cfa447cc/6273658.jpg",
            "https://www.barrandov.tv/obrazek/202007/5f15ab508c7bb/crop-355867-ksan4825_960x540.jpg",
            "https://g.denik.cz/1/7b/praha-rozhovor-babis-4-03_galerie-980.jpg",
            "https://cdn.discordapp.com/attachments/723512415198642177/807710770221154324/unknown.png",
            "https://www.extra.cz/images/thumbs/95/cf/95cf0bb-146392-sswww-0d1860000-0d0000000-0d7440000-1d0000000-sector_360x340-crop.jpg",
            "https://img.cncenter.cz/img/3/full/5375436-img-babis-riha-v0.jpg?v=0",
            "https://www.transparency.cz/wp-content/uploads/Andrej-Babi%C5%A1-zdroj-Michal-R%C5%AF%C5%BEi%C4%8Dka-MAFRA.jpg	",
            "https://1.bp.blogspot.com/-9zItVXCjUJ8/Xxvl32dL8DI/AAAAAAAAWXw/KU1Hb08wKnwYIOcl5WLqs1xS9wiVBjVIQCNcBGAsYHQ/s1600/babisfacebook2.jpg",
            "https://cdn.discordapp.com/attachments/723512415198642177/807711100706881587/unknown.png",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_fotogalerie_large/public/uploader/andrej_babis_200921-193722_miz.jpg?itok=qaWPdXNe",
            "https://img.ihned.cz/attachment.php/940/70849940/4oRxvzJywVCfPODin2de5LT9ckrSjKIG/Stihany_Babis_Vsem_preji_aby_vec_dosla_k_soudu_az_tam_vyvrcholi_spravedlivy_proces_rika_Zeman.jpg",
            "https://www.ctidoma.cz/sites/default/files/styles/w800/public/imgs/15/babis1_0.jpg",
            "https://img.obrazky.cz/?url=398f60842f1898c2&size=2",
            "https://img.blesk.cz/img/1/normal620/5350417_andrej-babis-andrej-babis-ml-capi-hnizdo-unos-krym-v2.jpg?v=2",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSlnDcxtvBCSL2CjRcyKchkXT5kBIqmouk0Vw&usqp=CAU",
            "https://www.ctidoma.cz/sites/default/files/styles/image_detail/public/imgs/10/babis.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTS8YbmG_FKgvTF-lJlgkGxRdSPeV36EOMtgw&usqp=CAU",
            "https://img.cncenter.cz/img/3/article/6074529_kamiony-predjizdeni-andrej-babis-zakaz-v2.jpg?v=2",
            "https://d39-a.sdn.cz/d_39/c_img_G_O/Wf3F9.jpeg?fl=cro,0,93,1800,1012%7Cres,1200,,1%7Cwebp,75",
            "https://pbs.twimg.com/profile_images/1137468480121397251/04wzTH1q.jpg",
            "https://www.extra.cz/images/thumbs/b9/24/b924203-252192-baba-0d0000000-0d0508906-1d0000000-0d7659033-sector_740x416-crop.jpg",
            "https://zivotvcesku.cz/wp-content/uploads/optimg/2020/12/415bd502d1b2988c73416c76182aca263391e1f7-w680-h382.jpg",
            "https://img.cncenter.cz/img/11/normal690/3195906_andrej-babis-statni-rozpocet-ministr-financi-ministerstvo-financi-v0.jpg?v=0",
            "https://www.vlada.cz/assets/clenove-vlady/premier/zivotopis/Andrej_Babis-386x218.jpg",
            "https://cdn.xsd.cz/resize/d83672ffda16374088e29fd509a1c97c_extract=25,0,1879,1057_resize=680,383_.jpg?hash=a4087a0e704f14f788a9d107f9996b05	",
            "https://zivotvcesku.cz/wp-content/uploads/optimg/2020/09/86cd9e4c14e59fbe009dab19b0599aee32144c99-w680-h382.jpg",
            "https://img.cz.prg.cmestatic.com/media/images/original/Jul2019/2297055.jpg?6dda",
            "https://img.cz.prg.cmestatic.com/media/images/original/Dec2016/1943604.jpg?1fe1",
            "https://www.anobudelip.cz/file/edee/2013/09/babis-muj-pribeh07.jpg	",
            "https://img1.w4t.cz/data/articles/70547_4533228406_0.jpg",
            "https://img.cncenter.cz/img/18/full/2611876_babis-v0.jpg?v=0",
            "https://img.cz.prg.cmestatic.com/media/images/original/Jun2020/2400957.jpg?d41d",
            "https://d15-a.sdn.cz/d_15/c_img_E_K/jAYPGf.jpeg?fl=cro,0,1,1278,718%7Cres,1200,,1%7Cwebp,75",
            "https://img.blesk.cz/img/1/normal620/6132147_v1.jpg?v=1",
            "https://www.forum24.cz/wp-content/uploads/2020/12/ccc-770x460.png",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTecjR952o6EZGSttA4tZtfrNkDp8S7Db8E9A&usqp=CAU",
            "https://hlidacipes.org/wp-content/uploads/2020/02/85134872_1793038064166163_8555999978084892672_o-1100x500.jpg",
            "https://img.cncenter.cz/img/11/normal690/2914419_nadseni-andrej-babis-dlouho-zachovaval-zachmureny-vyraz-po-oznameni-definivnich-vysledku-ale-z-nej-napeti-uplne-opadlo-v2.jpg?v=2",
            "https://d39-a.sdn.cz/d_39/c_img_QO_U/RWzB1.jpeg?fl=cro,0,0,1600,900%7Cres,1200,,1%7Cwebp,75",
            "https://img.cz.prg.cmestatic.com/media/images/original/Oct2017/2062042.jpg?2e36",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/file-video_16x9/public/2525348-p202012270128501.jpeg?itok=_rw4ueiB",
            "https://eurozpravy.cz/pictures/photo/2019/08/26/69548997-1612583512211620-5798044560693133312-o-8eeed57ba0_660x371.jpg",
            "https://img.cncenter.cz/img/3/article/3793617_rx472017-v0.jpg?v=0",
            "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=BaboTrump_636924844455001521.JPG&id=141375",
            "https://echo24.cz/img/5e4c14adffd8fa2b25edc490/1180/614_sig=WG0YgCWNllMKRjE3yMku8uhlJN_BrWVze1gc_DYYRHY",
            "https://lh3.googleusercontent.com/proxy/m79HHp6JQhQ4HQtWP4eZjY_rtZK3JTJY3e6VuC5Z3E2akQUSvZxDffJg9nbCif7kvmDYNrnQYmXgHOnaLYhsXR0lUVz_Z0iiQ6ex",
            "https://www.barrandov.tv/obrazek/202006/5efb2ef212d45/crop-353118-ea4vcfnxyaaa2or_960x540.jpg",
            "https://jablickar.cz/wp-content/uploads/2019/01/Tim-Cook-Andrej-Babis-1.jpg",
            "https://cdn.xsd.cz/resize/fa3b67f32acd3bba84cca8b749057f94_extract=86,0,1750,985_resize=680,383_.jpg?hash=891d32da3776cf05ba47d24bbb2b725e	",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS87lzAlCx1Ou6l8_8I20Gggb8DYHIolXwBPg&usqp=CAU",
            "https://hlidacipes.org/wp-content/uploads/2017/05/Babis-s-lemurem-960x400.jpg",
            "https://img.ihned.cz/attachment.php/20/74790020/c8SLEpj6uxKw2dN9s4AUGabhMqJgo5rD/jarvis_5e836405498e75f6a3c0ec67.jpg",
            "https://operaplus.cz/wp-content/uploads/2020/10/000babis.jpg",
            "https://t.cncenter.cz/ras-cz/11-normal690-6605501.jpg?t=LzY5MHg0MDgvc21hcnQvZmlsdGVyczpxdWFsaXR5KDgwKTp3YXRlcm1hcmsocmFzLWN6LzExLW9yaWdpbi02MzU0NzI4LmpwZywxMCwtNDUsMCwxMCwxMCk%3D&h=cwr_j-rF2KbaPrOgLDwh5w&e=2145916800&v=0",
            "https://d39-a.sdn.cz/d_39/c_img_gS_S/Q24U.jpeg?fl=cro,0,99,1800,1012%7Cres,1200,,1%7Cwebp,75",
            "https://www.nasevojsko.eu/fotky4869/fotos/_vyr_6114Andrej-Babis.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/2018-09-05t125039z_2_180905-173000_ako.jpg?itok=fgc4pKca",
            "https://img.cncenter.cz/img/3/full/6452372-img-andrej-babis-summit-brusel-evropska-unie-koronavirus-v2.jpg?v=2	",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSdVAllv0cZ3QJzSNcueBgkINhrhk3yFUxufQ&usqp=CAU",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/crop_880x495/public/images/2474132-babis.jpg?itok=0c8u4Usw",
            "https://d39-a.sdn.cz/d_39/c_img_QI_V/R3kEh.jpeg?fl=cro,0,0,1920,1080%7Cres,1200,,1%7Cwebp,75",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTVzyECdktCLg_-f7wpfGvnrEWqioGgzkkyEQ&usqp=CAU",
            "https://img.cncenter.cz/img/11/full/6251427_andrej-babis-projev-koronavirus-rouska-premier-v1.jpg?v=1",
            "https://www.vlada.cz/assets/media-centrum/aktualne/1Z6_9005-do-textu.jpg",
            "https://i.ytimg.com/vi/VbHNGBGmceY/maxresdefault.jpg",
        };

        [Command("andrej")]
        [Alias("babiš", "babis", "mccz")]
        public async Task Andrejsaurus()
        {
            Random random = new Random();
            int ovce = random.Next(url.Count);
            var ovcak = new EmbedBuilder();
            ovcak.WithTitle("**Here, take Some Premiér**");
            ovcak.WithImageUrl(url[ovce]);
            ovcak.WithColor(Color.Red);
            ovcak.WithFooter(footer =>
            {
                footer
                .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                .WithText("Král uzenin a toustů čerstvě od MilošBota");
            });
            await Context.Channel.SendMessageAsync(embed: ovcak.Build());

            ITextChannel con = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
            await con.SendMessageAsync("babis: " + url[ovce]);
        }
    }
}