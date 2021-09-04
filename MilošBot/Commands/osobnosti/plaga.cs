using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class plaga : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://d15-a.sdn.cz/d_15/c_img_gV_O/byY8v.jpeg?fl=cro,0,36,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/Plaga_2016.jpg/1200px-Plaga_2016.jpg",
            "https://www.msmt.cz/uploads/gallery/detail/7665.jpg",
            "https://www.extra.cz/images/thumbs/9c/fc/9cfce2e-259659-profimedia-0373338208-0d0000000-0d0000000-1d0000000-1d0000000-sector_740x416-crop.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_facebook/public/uploader/plaga_201001-153709_mda.jpg?itok=8kIo46rc",
            "https://cdn.xsd.cz/resize/d2d5a14be1d0394babc5d9c27af95032_extract=0,0,1920,1080_resize=680,383_.jpg?hash=749898d3af96fc29d0840c22cc6ce6a8",
            "https://eurozpravy.cz/pictures/photo/2021/01/27/snemovna-20200127-ra9145-9f18be78f6_660x371.jpg",
            "https://www.barrandov.tv/obrazek/201911/5dc17ae108b8e/crop-300296-p201911010626301_960x540.jpeg",
            "https://cdn.administrace.tv/2020/09/16/small_169/85e37d6abad16117038de57ce9a966c1.jpg",
            "https://cdn.administrace.tv/2020/11/02/small_169/d0b0153dfa699af7c0f069073ced6e84.jpg",
            "https://g.denik.cz/1/94/praha-rozhovor-plaga-01-14-11_denik-320-16x9.jpg",
            "https://eurozpravy.cz/pictures/photo/2020/11/19/snemovna-listopad-2020-krepelka-20201119-r1a1386-e501dbbce2_660x371.jpg",
            "https://img.cncenter.cz/img/11/normal690/5132649_robert-plaga-ministr-skolstvi-v0.jpg?v=0",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/plaga_1_191009-224232_mda.jpg?itok=njFDn4Us",
            "https://d15-a.sdn.cz/d_15/c_img_gS_S/K6JJM.jpeg?fl=cro,0,21,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/file-video_16x9/public/images/2252012-pl.jpg?itok=_wd0ZJAE",
            "https://echo24.cz/img/600e8fceffd8cd3c506f648d/1180/614?_sig=SfLk3HgWuOaNDeRB0_8CPuVw9Vtj37s9OQpE2tkGWxU",
            "https://img.cz.prg.cmestatic.com/media/images/original/Apr2018/2135861.jpg?d41d",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/file-video_16x9/public/2214242-tt.jpg?itok=nLP5q38d",
            "https://g.denik.cz/1/00/praha-rozhovor-plaga-01-14-06_denik-320-16x9.jpg",
            "https://cdn.xsd.cz/resize/f71f78e113e93ec8a8d63570d4678c90_extract=0,0,1960,1103_resize=680,383_.jpg?hash=90aa7c3cafe754eee8f9bd5a6a603018",
            "https://img.cncenter.cz/img/11/normal690/6657298_blatny-plaga-skolstvi-koronavirus-v0.jpg?v=0",
            "https://www.msmt.cz/uploads/gallery/full/8242.jpg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/p201712110575901_171213-205639_ako.jpeg?itok=tPTd9DE_",
            "https://d39-a.sdn.cz/d_39/c_img_F_R/qT4dp.jpeg?fl=cro,0,187,1800,1013%7Cres,1200,,1%7Cwebp,75",
            "https://img.ihned.cz/attachment.php/200/74870200/9ds5VQwfD4Ppt1ibMJN8zASk6unxv2aU/jarvis_5ea08dbe498e40c80b9ba39f.jpg",
            "https://www.forum24.cz/wp-content/uploads/2020/10/plaga-1.jpg",
            "https://cdncz1.img.sputniknews.com/img/07e4/09/10/12523413_0:66:1621:942_1000x541_80_0_0_e2fbeb37ce3fc7e7468299d7de8532b9.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQnmjCmJNWC1ZnGpUiN47FCdxuA3I1OYy4HBA&usqp=CAU",
            "https://www.pardubickyvecernik.cz/uploads/article/9041/pic/msmt.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQi5AAPe53TuTghfzJjs8SLTrmItTIkrIdM9g&usqp=CAU",
            "https://img.cncenter.cz/img/3/article/6442751_vlada-metnar-benesova-plaga-strakova-akademie-v1.jpg?v=1",
            "https://g.denik.cz/1/c8/praha-rozhovor-plaga-011-09_denik-320-16x9.jpg",
            "https://img.ihned.cz/attachment.php/460/70473460/wn7i9RN4BF6TVrlPyJIdOfaQW8C0GMSA/jarvis_5a551655498ec21104607a6f.jpeg",
            "https://img1.kurzy.cz/zpravy/obrazky/96/576096-ministr-skolstvi-robert-plaga-predstavuje-podobu-maturit-a-zaverecnych-zkousek-ve-skolnim-roce/139970153_874979286407399_6200533201473599138_n_w420h315.jpg",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/crop_880x495/public/images/2532224-210128plaga_edited_0.jpg?itok=vb6cmiLc",
            "http://www.romea.cz/aaa/img.php?src=/img_upload/03ec66ac77713bab242255f6194ad3ff/robert-plaga-msmt.jpg&w=630",
            "https://img.cncenter.cz/img/11/normal690/6295982_robert-plaga-ministr-skolstvi-v0.jpg?v=0",
            "https://echo24.cz/img/5f6f41d9ffd8581621a1e527/1180/614?_sig=MANCiX-l043ijFByhwKHmWV7kj3RzcYjANL2mVnVp90",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfz5Na-pl1Di8wmLDyPcFDD1ZQq_szUAFRTA&usqp=CAU",
            "https://d15-a.sdn.cz/d_15/c_img_QK_O/ZPQFJc.jpeg?fl=cro,0,24,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRIkVXZazfq2riA2sR-YpVnM3gYZ_F_UcXhrQ&usqp=CAU",
            "https://img.ihned.cz/attachment.php/770/74888770/x6CtFJTod0aU9gyKpGuq3V1NMiBhElLO/jarvis_5e96178b498e40c80b47e9d9.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrgX0u2plsMymApoNH-ZW4SYFAWolqF3aBbQ&usqp=CAU",
            "https://d15-a.sdn.cz/d_15/c_img_E_I/WB6BMpz.jpeg?fl=cro,0,57,1280,720%7Cres,1200,,1%7Cwebp,75",
            "https://cdn.xsd.cz/resize/3e57577de7b5349b8ac0c2bf0e4c67e8_resize=680,383_.jpg?hash=cb374e17cc9876e71e76fa88a677df63",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ6vRuwpovNDzdjjDGMmSEzY3ekAs7wxFu_Xg&usqp=CAU",
            "https://echo24.cz/img/5e77c098ffd801dc618fe041/1180/614?_sig=CAgfuhgcjLHjOJDsWPMyAymwahbNc_Y3NrWw7NHy1UE",
            "https://www.mzv.cz/public/cb/fd/d7/3788233_2256700_R_Plaga.jpg",
            "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=IMG_5784_637163496256891480.jpg&id=147784",
            "https://img.cncenter.cz/img/11/normal690/5666659_vlada-jednani-zasedani-robert-plaga-ministr-skolstvi-v2.jpg?v=2",
            "https://www.mujrozhlas.cz/sites/default/files/styles/detail/public/rapi/865f5a107aa426f2bdbe7799a5945941.jpg?h=8b7966f8&itok=njnM3CHe",
            "https://www.kverulant.org/wp-content/uploads/2020/09/Plaga-a-z%C3%A1%C5%A1tita-142.jpeg",
            "https://plus.rozhlas.cz/sites/default/files/uploader/_cha0810_191029-171627_jak.JPG",
        };

        [Command("plaga")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some plagiátor áááááááááááááááááááááá **");
                ovcak.WithImageUrl(url[ovce]);

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Škola je zbytečná... xdd   od Milošbota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("plaga: " + url[ovce]);
            }
        }
    }
}