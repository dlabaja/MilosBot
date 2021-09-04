using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Prymula : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://cdn.discordapp.com/attachments/798824268758646784/801766230406332416/unknown.png",
            "https://1gr.cz/fotky/idnes/20/073/vidw/LUH84fe0d_RomanPrymula_Topic2.jpg",
            "https://g.cz/sites/default/files/styles/gflex_landscape_large/public/field/image/2020/prymula_profimedia.jpg?itok=kSAuaofM",
            "https://cdn.xsd.cz/resize/2ba3bf7bf6653dc88d6a11e4bcd92b20_extract=12,0,1750,985_resize=680,383_.jpg?hash=f40bdca5fc22b7cc531da7fbae7a678e",
            "https://img.ihned.cz/attachment.php/590/75474590/NWJ8j91uH5kfV0gUy6FMCzLAcmv4Plwd/jarvis_5f8f29ff498e674ad5c455d9.jpeg",
            "https://cdn.administrace.tv/2020/11/15/small_169/a12da4dc5e685d3e509af959a6b2be0e.png",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_otvirak_velky/public/uploader/faltynek_-_prymula_201023-101553_ktm.png?itok=JOyGFFXO",
            "https://cdn.forbesmedia.cz/images/eyJ1IjoiXC91cGxvYWRzXC8yMDIwXC8wM1wvcHJ5bXVsYS5qcGciLCJ3IjoxMjMwLCJ2IjoiMS4wIn0%3D.jpg",
            "https://img.ihned.cz/attachment.php/590/74950590/VDJFM6RbtLWEjgepAUNh1moiz4w8lkBS/jarvis_5ec42bef498e75f6a7ccd516.jpeg",
            "https://www.irozhlas.cz/sites/default/files/styles/zpravy_fotogalerie_large/public/uploader/vojtech_prymula_9_200415-104110_mda.jpg?itok=glgX37I-",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSPO14u64EW_ptqWdaSAew5vIZGSBwzf2LKrQ&usqp=CAU",
            "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=zg_637390727923684021.jpg&id=153723",
            "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=zg_637390727923684021.jpg&id=153723",
            "https://img.cncenter.cz/img/11/normal690/6564090_roman-prymula-adam-vojtech-v0.jpg?v=0",
            "https://g.denik.cz/1/be/122568384-1070053576783921-1085553839601164849-n_denik-320-16x9.jpg",
            "https://lh3.googleusercontent.com/proxy/Z3MBbPD2wscSdy2OOnTeFUq4AKFoRAq8Ab6N5kKiVPhsrRRX2DSGMEia46O4d-tRFflaoL2-5u3_5sbiDiAXM-EhUaY6kf9en4BwFQHdsYSyf9Q036A9VzLIMy4H64gnfQxF",
            "https://d39-a.sdn.cz/d_39/c_img_QM_R/qGFGQ.jpeg?fl=cro,0,92,1800,1012%7Cres,1200,,1%7Cwebp,75",
            "https://zivotvcesku.cz/wp-content/uploads/optimg/2020/09/f8206a42f8730624883faa50db52e8096ba562e8-w680-h382.jpg",
            "https://img.ihned.cz/attachment.php/40/75486040/1UJD6aWQNgTCirFKO8Eescup7yoMLnkt/ezgif.com-gif-maker.jpg",
            "https://i.ytimg.com/vi/pkYah1wxk_I/maxresdefault.jpg",
        };

        [Command("prymula")]
        [Alias("prý", "prýmula", "restaurace", "hospoda")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some Generál**");
                ovcak.WithImageUrl(url[ovce]);
                ovcak.WithColor(Color.Red);
                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Ponaučení od MilošBota - nechoďte do restaurace, když ji samy předtím zavřete.");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("Harold: " + url[ovce]);
            }
        }
    }
}