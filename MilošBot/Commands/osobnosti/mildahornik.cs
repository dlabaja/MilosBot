using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Hornik : ModuleBase<SocketCommandContext>
    {
        List<string> url = new List<string>()
        {
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/scale_1180/public/images/1545614-631614.jpg?itok=OSZW40JZ",
            "https://ct24.ceskatelevize.cz/sites/default/files/styles/scale_1180/public/images/1548394-635494.jpg?itok=Dy6s5MU9",
            "https://img.ihned.cz/attachment.php/360/62902360/JzynH6TE3mR7qtUI8piPQoCGNW4gV2ew/jarvis_567849cbe4b02e4e841db563.jpeg",
            "https://oenergetice.cz/wp-content/uploads/2015/10/Uheln%C3%BD-d%C5%AFl-Garzweiler-e1444205376150.jpg",
            "https://img.ihned.cz/attachment.php/450/43938450/76l0GmqtarDHnxRwoPbL9pBVFyeWf18A/Machinery_13.jpg",
            "https://1gr.cz/fotky/idnes/13/092/cl5/RJA4d13d0_IMG_9846.JPG",
            "https://www.tyden.cz/obrazek/201604/5711df6635feb/crop-974599-p201407240927601.jpeg",
            "https://www.hornicky-klub.info/foto/silesia.jpg",
            "https://lh3.googleusercontent.com/proxy/CE-sQ65QuWiXtEFYCw3finRNEiReK44twuI5U9xKLZ6jxUW3nodbBn1bQnVtWKZVpJkAqYnbflWbFQR0hhOp2ZZiD6atc00ujQgNFzI",
            "https://1gr.cz/fotky/idnes/12/101/cl5/PL463c09_090837_3153710.jpg",
            "https://1gr.cz/fotky/idnes/12/032/cl5/TOP41d71f_11.jpg",
            "https://cdn.discordapp.com/attachments/719289692474048675/803525214842912798/unknown.png",
            "https://cdn.discordapp.com/attachments/719289692474048675/803529585349754900/unknown.png",
            "https://cdn.discordapp.com/attachments/719289692474048675/803531095077421057/unknown.png",
            "https://img20.rajce.idnes.cz/d2002/7/7670/7670998_e43a796b9ecdd476e49ca3a9fbbe2168/images/IMG_1612.jpg",
            "https://1gr.cz/fotky/idnes/12/032/vidw/TOP41d71e_1.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSFc3_nt8esZ79ri6DojJHVRQTOMI5az72FYA&usqp=CAU",
            "https://lh3.googleusercontent.com/proxy/JhWEkdvHrUvDsiZaaWDt0T-sbwmuBdIk-LG3gR_1jVIkoCc1lT6BRAexpkTBKHCeHNmxUbkN1fgg14yQMwxjRcrh9E-etO9461lcjGZyNk81LWeZxRhVAOB154QoOe8s49i8YSZ0yK0sSgK3wLV9",
            "https://iuhli.cz/wp-content/uploads/2015/05/lom_bilina-800x600_compressed.jpg",
            "https://i3.cn.cz/15/1575115375_P201911300268401.jpg",
            "https://ekonomickydenik.cz/wp-content/uploads/2015/07/P1190665.jpg",
        };

        [Command("mildahornik")]
        [Alias("Jáchymov", "doly", "uran", "uranium-ore", "coal-ore", "uhlí")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some Milošovo živobytí **");
                ovcak.WithImageUrl(url[ovce]);

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("hory doly a hlavně bez uhlíkové stopy od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("hornik: " + url[ovce]);
            }
        }
    }

}
