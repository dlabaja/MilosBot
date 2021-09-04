using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Putin : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8d/Vladimir_Putin_%282020-02-20%29.jpg/1200px-Vladimir_Putin_%282020-02-20%29.jpg",
            "https://dynaimage.cdn.cnn.com/cnn/c_fill,g_auto,w_1200,h_675,ar_16:9/https%3A%2F%2Fcdn.cnn.com%2Fcnnnext%2Fdam%2Fassets%2F201215031414-putin-biden-split.jpg",
            "https://cdni0.trtworld.com/w960/h540/q75/92530_RUS11182020RUSSIAKARABAKHREUTERS_1605652707936.JPG",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3dE8BVY5tbDyS1aPGmCTIxXmLekUD88jXew&usqp=CAU",
            "https://i3.cn.cz/15/1581621549_P202002131027501.jpg",
            "https://infocz-media.s3.amazonaws.com/infocz/production/files/2020/07/15/00/21/49/697666b2-203a-4f0d-998e-9072bee89100/5677917.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSFh-whURhSZ1Isv3H8WpX03-ZocbsCWzRM7g&usqp=CAU",
            "https://api.time.com/wp-content/uploads/2014/03/putin-cell-phone.jpg?quality=85&w=1200&h=628&crop=1",
            "https://d15-a.sdn.cz/d_15/c_img_E_D/FCcBqoK.jpeg?fl=cro,0,51,800,450%7Cres,1200,,1%7Cwebp,75",
            "https://img.cncenter.cz/img/3/full/6272610-img-koronavirus-rusko-vladimir-putin-v0.jpg?v=0",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR8OHhqKWzuLVmh7M1DWhBZGLPubccmejfmhw&usqp=CAU",
            "https://media4.s-nbcnews.com/j/newscms/2020_19/2662856/181129-trump-putin-mc-11056_c09465f4628454299e2f2b2e858cf445.fit-760w.JPG",
            "https://img.cncenter.cz/img/18/new_article/6144675-img-izrael-holokaust-forum-konference-jeruzalem-jad-vasem-vladimir-putin-v0.jpg?v=0",
            "https://assets.bwbx.io/images/users/iqjWHBFdfxIU/iZ6tawScgGE8/v0/1000x-1.jpg",
            "https://d39-a.sdn.cz/d_39/c_img_E_M/fRLCXQ.png?fl=cro,0,0,1920,1080%7Cres,1200,,1%7Cwebp,75",
            "https://g.denik.cz/1/c2/ctk-putin-dal-najevo-podporu-lukasenovi-slibil-miliardovy-uver_denik-320-16x9.jpg",
            "https://e3.365dm.com/19/03/768x432/skynews-vladimir-putin-russia_4618798.jpg?20190325134349",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHMWK8ntDdeNmo8QY0gYxrHKopOHh-efn-6w&usqp=CAU",
            "https://pyxis.nymag.com/v1/imgs/6af/d6c/26cd6125882e55475038280280ed424f15-trump-putin.rhorizontal.w700.jpg",
            "https://static.novydenik.com/2018/11/2018-11-11T110212Z_199865770_RC1A18729010_RTRMADP_3_WW1-CENTURY-FRANCE-CEREMONY.jpg",
            "https://d39-a.sdn.cz/d_39/c_img_E_M/YZ3Czb.jpeg?fl=cro,0,33,640,360%7Cres,1200,,1%7Cwebp,75",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR4M9egXchea078cPNUQ4FcnB8TUvGbTjk-_g&usqp=CAU",
        };

        [Command("Putin")]
        [Alias("vzor", "sssr")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some Mildův největši vzor a kamarád. **");
                ovcak.WithImageUrl(url[ovce]);

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Né nadarmo vymírají..  od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("putin: " + url[ovce]);
            }
        }
    }
}