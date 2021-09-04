using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class lenin : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://upload.wikimedia.org/wikipedia/commons/6/65/Lenin_in_Switzerland.jpg",
            "https://www.extrastory.cz/wp-content/uploads/2014/10/Lenin-1.jpgv",
            "https://upload.wikimedia.org/wikipedia/commons/5/52/Vladimir-Ilich-Lenin-1918.jpg",
            "https://g.denik.cz/127/30/leninstalincrop.jpg",
            "https://www.bejvavalo.cz/clanky/foto/leninuv-proslov.jpg",
            "https://casopiskontexty.cz/wp-content/uploads/2020/05/stalin2.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_E_I/K73BOpj.jpeg?fl=cro,0,0,1280,1732%7Cres,1200,,1%7Cwebp,75",
            "https://www.ctidoma.cz/sites/default/files/styles/w800/public/imgs/21/lenin1_0.jpg",
            "https://images.uncyclomedia.co/necyklopedie/cs/thumb/7/72/2.64.jpg/300px-2.64.jpg",
            "https://d15-a.sdn.cz/d_15/c_img_F_F/H9PBP6E.jpeg?fl=cro,0,176,800,450%7Cres,1200,,1%7Cwebp,75",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/scale_1180/public/images/1370756-5306.jpg?itok=Bt0INC8W",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/4/47/19190501-lenin_speech_red_square.jpg/440px-19190501-lenin_speech_red_square.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/1/17/Vladimir_Lenin.jpg",
            "http://www.nasevojsko.eu/fotky4869/fotos/_vyr_5048Hrnicky_Lenin-strana.png",
            "https://g.cz/sites/default/files/styles/gflex_landscape_large/public/field/image/2020/348029d410a63449b8bc3368ca3070ed_extract31201135639_resize680383_.jpg?itok=pW2Nxm3s",
            "https://www.tatry.cz/media/image/v_i_lenin-1870-1924.jpg",
            "https://citaty.net/media/authors/1281_vladimir-iljic-lenin.jpg",
            "https://eurozpravy.cz/pictures/photo/2012/12/01/lenin-1354317782-55fa5f0d_660x371.jpg",
            "http://upload.wikimedia.org/wikipedia/commons/c/c6/Bundesarchiv_Bild_183-71043-0003%2C_Wladimir_Iljitsch_Lenin.jpg",
            "https://c1.primacdn.cz/sites/default/files/1/5e/4968761-lenin_-_obraz.jpg",
            "https://skompasem.cz/wp-content/uploads/2018/04/V.I.Lenin_.jpg",
            "http://www.totalita.cz/images/o_leninv_1914.jpg",
            "http://ostravskesochy.cz/original/1711.png",
            "https://img.blesk.cz/img/1/normal620/6648379-img-zivoty-slavnych-lenin-v0.jpg?v=0",
            "https://www.bejvavalo.cz/clanky/foto/leninuv-proslov-barva.jpg",
            "https://img.ceskatelevize.cz/program/porady/11900794557/foto09/right.jpg?1510558353",
            "https://static.wikia.nocookie.net/theamericans/images/d/d5/Lenin_painting.jpg/revision/latest/scale-to-width-down/340?cb=20180203013359",
            "https://i.guim.co.uk/img/media/0c487e12cb4a787f0a5a539cefee521e205ecd8d/0_206_4848_2909/master/4848.jpg?width=1200&quality=85&auto=format&fit=max&s=6ca0c79f5fe73b228a3a1854467d28c4",
            "https://1gr.cz/fotky/idnes/18/102/cl6/VOV76bbbf_LeninStalin.jpg",
            "https://149357032.v2.pressablecdn.com/wp-content/uploads/fly-images/440/558f5-lenin-1440x750.jpg",
        };

        [Command("lenin")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some Lenin**");
                ovcak.WithImageUrl(url[ovce]);
                ovcak.WithColor(Color.Red);
                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Mausoleum si nemůže dovolit jen tak někdo - od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("lenin: " + url[ovce]);
            }
        }
    }
}