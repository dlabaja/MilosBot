using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class masaryk : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
             "https://upload.wikimedia.org/wikipedia/commons/6/6c/Tom%C3%A1%C5%A1_Garrigue_Masaryk_1925.PNG",
             "https://upload.wikimedia.org/wikipedia/commons/3/3c/Tom%C3%A1%C5%A1_Garrigue_Masaryk%2C_Bain_News_Service_%28Library_of_Congress%2C_Bain_Collection%29_crop.jpg",
             "https://www.hrad.cz/file/edee/2015/07/tomas-garrigue-masaryk.jpg",
             "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_vertical/public/images/1519007-6698.jpg?itok=-nVjADht",
             "https://g.denik.cz/67/12/tomas-garrigue-masaryk-tgm_denik-320-16x9.jpg",
             "https://ct24.ceskatelevize.cz/sites/default/files/styles/node-article_wide/public/2197064-masaryk.jpg?itok=biDoIZfp",
             "https://www.neaktuality.cz/wp-content/uploads/tgmasaryk.jpg",
             "https://imagebox.cz.osobnosti.cz/foto/tomas-garrigue-masaryk/tomas-garrigue-masaryk.jpg",
             "https://1gr.cz/fotky/lidovky/17/091/lnc460/ELE6de109_masaryk.jpeg",
             "https://cdn.xsd.cz/resize/57d98dc7038c3e6a9f2b5b567de962e1_resize=462,640_.jpg?hash=41fa5c1187147241f5f59348f9174260",
             "https://lh3.googleusercontent.com/proxy/_7e7pXCoeQhqvmWytJukmR7YwrK1Nyf925ea269sCqmwIQLLMZ9tbTIwUTlEqpHvGvaz--ljZmB1Ox3m4clK3sXbZ44WaksjZxCjASSRy9e3fBdvVCx5nIFbs7auZTjsZnw4jFkliutJWGdYaqqQpVvapYoxJRjAcYrbGnOQ-2oY",
             "https://c1.primacdn.cz/sites/default/files/styles/landscape_extra_large/public/8/b0/4136367-tomas_garrigue_masaryk.jpg?itok=aLPg0rg0&c=def_cloudinary",
             "https://cdn.xsd.cz/resize/cbf2c13d04de37b7add4800fe073a7ed_resize=1287,1750_.jpg?hash=7473ed80f6c3b12448945411e49a9f8f",
             "https://d15-a.sdn.cz/d_15/c_img_F_G/KrnHMe.jpeg?fl=cro,0,102,800,450%7Cres,1200,,1%7Cwebp,75",
             "https://dobryzpravy.cz/app/uploads/2018/09/masaryk-po-jedn%C3%A1n%C3%AD.jpg",
             "https://img.cncenter.cz/img/3/article/3662672_masaryk-v0.jpg?v=0",
             "https://g.cz/sites/default/files/styles/gflex_landscape_large/public/field/image/2020/02397390.jpeg?itok=XIUNCKy6",
             "https://ct24.ceskatelevize.cz/sites/default/files/styles/scale_1180/public/images/1183198-389112.jpg?itok=lP1N2sUb",
             "https://lh3.googleusercontent.com/proxy/QxyoZXXbvgGrIszZbeDZa2h-HeMqK6UsRlrG6nKB5Nvknzd3AVRgxwxM4318NzoTF8zxQsgLlhmN1pxNjA2wNblSAcOxLyrAesKzlzhsom2Ge2QjRzXLGn4mRKEm8DTSV6M2f3-c2bcfUx6PMQKrhukWiguWTIGh7YRDTujQ",
             "https://regiony.rozhlas.cz/sites/default/files/images/00598645.jpeg",
             "http://www.dejepis.com/wp-content/uploads/2013/09/Masaryk1919.jpg",
             "https://www.rexter.cz/obrazek/5bd5da9336ca5/tomas-garrigue-masaryk_590x332.jpg",
             "https://1gr.cz/fotky/idnes/20/031/r7/VOJ81cdca_pred100_masarykslavi70_1.jpg",
             "https://www.cd.cz/images/img/masaryk.jpg",
             "https://cms.parlamentnilisty.cz/image.ashx?w=632&h=307&f=masaryk-634831325633379000.jpg&id=7294",
             "https://lh3.googleusercontent.com/proxy/twK-l0E1U9m4SFSaE9vzZVPjW7WAgecZT6cEwqdM3V-8bFZ6zlOqCNqpW4HoQk3FHX084sXJAn9zIJv3ezS45F0oICOiPBEA4f1ZiR4bb8I-Gy_LZYFI1Jch5Yd9IOFhT3ehVAsne1dqqIHy",
             "https://img.cncenter.cz/img/11/normal690/2915122_tomas-garrigue-masaryk-v4.jpg?v=4",
             "https://encyklopedie.brna.cz/data/images/0004/img0196.jpg",
             "https://regiony.rozhlas.cz/sites/default/files/images/03177885.jpeg",
             "https://1gr.cz/fotky/lidovky/15/082/lnorg/JEL10192f_T.G.jpg",
             "https://img.cncenter.cz/img/18/full/1397481_tomas-garrigue-masaryk-v13.jpg?v=13",
             "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcStfiulHiz8ywisSTfz3MUf4gAAO-XsTW-HaQ&usqp=CAU",
             "https://lh3.googleusercontent.com/proxy/-yBncTRNUDkb7d3evEoHsJFbX5tT9TnNNP7K6wLOK8o4kOot2eEiVWK4jkhmqNZu0ZbWqnYcBfMD_oWDr9fkDBAy90Dntt8rX3XxzFBNMXVnviL8ajBvl9iy_IIgCaOEU9beigAYHrlITsksfHPzhIJ6Iff_uZF1e2aq8BkhnCJRln_3nmy0gzTKJIjJ",
             "https://www.zlate-mince.cz/i/F320.jpg",
             "https://rotanazdar.cz/wp-content/uploads/Sb%C3%ADrky/Historicke_fotografie/2017/Foto_tydne_TGM_orez.jpg",
        };

        [Command("masaryk")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some První prezident**");
                ovcak.WithImageUrl(url[ovce]);
                ovcak.WithColor(Color.Red);
                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Vtipy stranou, tohle byl fakt dobrý politik... od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("masaryk: " + url[ovce]);
            }
        }
    }
}