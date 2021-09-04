using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Harold : ModuleBase<SocketCommandContext>
    {
        List<string> url = new List<string>()
        {
            "https://www.postavy.cz/foto/109674-harold-foto.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTfBgVSPOtjeLxV1o5hDk92Kjxb6v5Ap9oSLQ&usqp=CAU",
            "https://images-na.ssl-images-amazon.com/images/I/41X9n0W8LtL._SX331_BO1,204,203,200_.jpg",
            "https://www.unilad.co.uk/wp-content/uploads/2020/05/Hide-the-Pain-Harold-Face-Mask.jpg",
            "https://cdn.shopify.com/s/files/1/1583/8217/products/shorts-harold-meme-shorts-1_1200x1200.png?v=1530150252",
            "https://www.handwerk.com/sites/default/files/styles/amp_1200x1200_1_1/public/2017-08/hide-the-pain-harold-deutsch04.jpg?itok=jkE3PWfM",
            "https://images-na.ssl-images-amazon.com/images/I/A1H5wnVFukL._SL1500_.jpg",
            "https://hungarytoday.hu/wp-content/uploads/2020/06/Hide-the-Pain-Harold-prof..jpg",
            "https://i.redd.it/p4kp361cdj731.png",
            "https://i.redd.it/yqbz0ezuoy661.jpg",
            "https://i.redd.it/3z0zu18gfg621.jpg",
            "https://pics.me.me/when-r-memes-brings-back-the-crying-cat-avatar-instead-of-41874387.png",
            "https://cdn.discordapp.com/attachments/719283159988043806/801390963490684998/unknown.png",
        };

        [Command("harold")]
        [Alias("herold", "chcidebilka", "dlabaja", "zarvok")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some Maďar**");
                ovcak.WithImageUrl(url[ovce]);
                ovcak.WithColor(Color.Red);
                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Debilní důchodce s debilním úsměvem od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());


                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("Harold: " + url[ovce]);
            }
        }
    }
}