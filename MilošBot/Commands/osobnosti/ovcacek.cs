using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class ovcacek : ModuleBase<SocketCommandContext>
    {
        [Command("ovcacek")]
        [Alias("ovčáček", "ovce")]
        public async Task Ovcacek()
        {
            Random random = new Random();
            int ovce = random.Next(1, 51);

            var ovcak = new EmbedBuilder();

            ovcak.WithTitle("**Here, take Some Ovčáček**");
            switch (ovce)
            {
                case 1:
                    ovcak.WithImageUrl($"https://pbs.twimg.com/profile_images/1235130881523830786/VSW6K4SO_400x400.jpg");
                    break;
                case 2:
                    ovcak.WithImageUrl($"https://d15-a.sdn.cz/d_15/c_img_E_G/zGtN2S.jpeg?fl=cro,0,9,800,450%7Cres,1200,,1%7Cwebp,75");
                    break;
                case 3:
                    ovcak.WithImageUrl($"https://www.forum24.cz/wp-content/uploads/2020/08/Sni%CC%81mek-obrazovky-2020-08-26-v-15.20.39-385x230.png");
                    break;
                case 4:
                    ovcak.WithImageUrl($"https://hlidacipes.org/wp-content/uploads/2018/12/48964947_2299483423395670_7207322436881088512_n-e1545861808645-720x500.jpg");
                    break;
                case 5:
                    ovcak.WithImageUrl($"https://radiozurnal.rozhlas.cz/sites/default/files/images/03452429.jpeg");
                    break;
                case 6:
                    ovcak.WithImageUrl($"https://img.ihned.cz/attachment.php/70/72090070/e5uRydKOPVMSHGfaiWx40lqs7nUN1gJv/_DSC6054_bigger_LR_.jpg");
                    break;
                case 7:
                    ovcak.WithImageUrl($"https://img.cncenter.cz/img/11/normal690/5986809-img-ovcacek-tiskova-konferenci-summit-v0.jpg?v=0");
                    break;
                case 8:
                    ovcak.WithImageUrl($"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQhorkCm18JqtZWHXYk-7VnDML3Zl_n_h8gCQ&usqp=CAU");
                    break;
                case 9:
                    ovcak.WithImageUrl($"https://img.cncenter.cz/img/3/article/5863718_ovcacek-thao-v0.jpg?v=0");
                    break;
                case 10:
                    ovcak.WithImageUrl($"https://www.forum24.cz/wp-content/uploads/2016/12/ovcacek-850x480.jpeg");
                    break;
                case 11:
                    ovcak.WithImageUrl($"https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=IMG_0652_636196469105772915.jpg&id=119125");
                    break;
                case 12:
                    ovcak.WithImageUrl($"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQnYssdxlxCDeOJEc-N9XQvTlWJ63ETm-lDyg&usqp=CAU");
                    break;
                case 13:
                    ovcak.WithImageUrl($"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS58NzNjoZLwMEhp_lXo3c1XTUbCwzMHeIH5w&usqp=CAU");
                    break;
                case 14:
                    ovcak.WithImageUrl($"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcShn-hd9cIT8r_1oS-llbUVxMaEjovobONaLw&usqp=CAU");
                    break;
                case 15:
                    ovcak.WithImageUrl($"https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=IMG_9807_635797536988449031.jpg&id=106803");
                    break;
                case 16:
                    ovcak.WithImageUrl($"https://img.cz.prg.cmestatic.com/media/images/original/Jul2018/2158488.jpg?d41d");
                    break;
                case 17:
                    ovcak.WithImageUrl($"https://olomoucka.drbna.cz/files/drbna/images/page/2019/07/15/size4-15632161007905-124-size4-15632087936404-139-dsc-1828.jpg");
                    break;
                case 18:
                    ovcak.WithImageUrl($"https://eurozpravy.cz/pictures/photo/2019/06/20/c-eurozpravycz-incorp-images-caputova-a-zeman-krepelka-20190620-413a3065-292da5701d_200x113.jpg");
                    break;
                case 19:
                    ovcak.WithImageUrl($"https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_16x9/public/images/1098224-526018.jpg?itok=cxyLcQ_S");
                    break;
                case 20:
                    ovcak.WithImageUrl($"https://cdncz1.img.sputniknews.com/img/1101/52/11015286_0:244:1080:828_1000x541_80_0_0_0a453331685141d763182a8f7e001f56.jpg");
                    break;
                case 21:
                    ovcak.WithImageUrl($"https://lh3.googleusercontent.com/proxy/JfU465WSJNlXbgOrcgWypYxc1ZuJzlA1EHbVorbt4ukwRFX9Kb1E-383jrUUXQEWLEqm6qfeX60kJjseR7YrgcM80tbNwrrxG80q5FsmOPLGeoXVjipyC5KmZ2YJmBrkIUvzyR4g");
                    break;
                case 22:
                    ovcak.WithImageUrl($"https://g.denik.cz/63/a2/p201810050664801_denik-320-16x9.jpg");
                    break;
                case 23:
                    ovcak.WithImageUrl($"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQVXQ_m6ShIjyFSGM79hsyu0IfrkyLv3yAOEQ&usqp=CAU");
                    break;
                case 24:
                    ovcak.WithImageUrl($"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSngfHd6X6paXAW4Wu2x584FNj3GW0_A1xHXA&usqp=CAU");
                    break;
                case 25:
                    ovcak.WithImageUrl($"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQsXbCnvJ5_lgSYLvpCXo_21yCJhNl-PKKpw&usqp=CAU");
                    break;
                case 26:
                    ovcak.WithImageUrl($"https://www.krajskelisty.cz/images/theme/20130709170656_penize.bmp");
                    break;
                case 27:
                    ovcak.WithImageUrl($"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTKI_8lX5vKasCSUKkXfiFOPWcmDy57OKyiSw&usqp=CAU");
                    break;
                case 28:
                    ovcak.WithImageUrl($"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQwa9WiExq2exqTPUI4Mtjk18wIOjB15w4uA&usqp=CAU");
                    break;
                case 29:
                    ovcak.WithImageUrl($"https://globe24.cz/pictures/photo/2016/03/29/cina-hrad-krepelka-20160329-50b8814-47c980113b-660x371.jpg");
                    break;
                case 30:
                    ovcak.WithImageUrl($"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRvaJ0QUW7hyLhD1DFoRjxHe6WvKLUBLq8O9w&usqp=CAU");
                    break;
                case 31:
                    ovcak.WithImageUrl($"https://globe24.cz/pictures/photo/2016/03/29/cina-hrad-krepelka-20160329-50b8438-30bf581db0-660x371.jpg");
                    break;
                case 32:
                    ovcak.WithImageUrl($"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTbjoec5JjKeFnRgfh5a-3rVmmeUfyuctITjg&usqp=CAU");
                    break;
                case 33:
                    ovcak.WithImageUrl($"https://www.forum24.cz/wp-content/uploads/2019/07/67229817_2312313665503470_4262530367245778944_n-770x460-1581504654.jpg?1581504695");
                    break;
                case 34:
                    ovcak.WithImageUrl($"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS8bGodXrV8kxzSCc2bCqB4yhA8iuVWxRuksQ&usqp=CAU");
                    break;
                case 35:
                    ovcak.WithImageUrl($"https://www.irozhlas.cz/sites/default/files/styles/zpravy_rubrikovy_nahled/public/uploader/p201806140791601_1_180614-172354_mos.jpeg?itok=NCTCU991");
                    break;
                case 36:
                    ovcak.WithImageUrl($"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR1RUJ-wznfQY5Fl0uJrDj1Xkj9Ofs0sUpxSw&usqp=CAU");
                    break;
                case 37:
                    ovcak.WithImageUrl($"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTG0n0KKpjJWuL6p1s_gFNUK8ZJGT52fSNYnQ&usqp=CAU");
                    break;
                case 38:
                    ovcak.WithImageUrl($"https://infocz-media.s3.amazonaws.com/infocz/production/files/2020/07/16/06/19/28/ae71e474-83af-4570-b550-893d903b84ef/3697384.jpg");
                    break;
                case 39:
                    ovcak.WithImageUrl($"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHAT42EWrZ93LkbxVr6K3Kjg5u--ny9VNXGg&usqp=CAU");
                    break;
                case 40:
                    ovcak.WithImageUrl($"https://pbs.twimg.com/media/DsXqzFkWkAAt-gL.jpg");
                    break;
                case 41:
                    ovcak.WithImageUrl($"https://img.cncenter.cz/img/3/gallery/2279525_rx122015-obalka-v0.jpg?v=0");
                    break;
                case 42:
                    ovcak.WithImageUrl($"https://img.ihned.cz/attachment.php/170/59816170/F3a5h6robHk9LiTvN841eswuljgtJxfn/MS_JIRI_OVCACEK_8.jpg");
                    break;
                case 43:
                    ovcak.WithImageUrl($"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRUgHxw-H6Nb5QRjJOjABfIZ0KeCseynkCEqQ&usqp=CAU");
                    break;
                case 44:
                    ovcak.WithImageUrl($"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRMSS1fWom6PpHv2hRLnS4LsEDD_3nNEBKS2g&usqp=CAU");
                    break;
                case 45:
                    ovcak.WithImageUrl($"https://im.tiscali.cz/press/2016/10/19/717450-profimedia-0274678119-1250x908.jpg?1587596281.0");
                    break;
                case 46:
                    ovcak.WithImageUrl($"https://img.blisty.cz/img/23570.jpg?id=23570&size=450&mg=0");
                    break;
                case 47:
                    ovcak.WithImageUrl($"https://cdn.discordapp.com/attachments/756546749018931373/785500641606762497/images.jpg");
                    break;
                case 48:
                    ovcak.WithImageUrl($"https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=IMG_1034_637102972322688490.jpg&id=146238");
                    break;
                case 49:
                    ovcak.WithImageUrl($"https://1gr.cz/fotky/idnes/13/113/cl5/JB4f8dbb_ovcacek.jpg");
                    break;
                case 50:
                    ovcak.WithImageUrl($"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSGnC1Yju3PXUi9FQ5WXRA8ETelQGoKJL67Vg&usqp=CAU");
                    break;

            }
            ovcak.WithColor(Color.Red);
            Console.WriteLine(ovce);
            ovcak.WithFooter(footer =>
            {
                footer
                .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                .WithText("Čerstvý Ovčáček od MilošBota");
            });

            await Context.Channel.SendMessageAsync("", false, ovcak.Build());

            ITextChannel cons = Context.Client.GetChannel(795684253953163274) as ITextChannel;
            await cons.SendMessageAsync("ovcacek: " + ovce);
        }
    }
}
