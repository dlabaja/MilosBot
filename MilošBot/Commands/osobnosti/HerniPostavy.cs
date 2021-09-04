using Discord;
using Discord.Commands;
using MilošBot.Extensions;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class HerniPostavy : ModuleBase<SocketCommandContext>
    {
        private static readonly string[] urlFreeman = new[]
        {
            "https://static.wikia.nocookie.net/half-life/images/f/f3/Gordon_Freeman_%28Template%29.jpg/revision/latest?cb=20191221105246&path-prefix=en",
            "http://zakoupit.cz/221-large_default_2x/plakat-half-life-2-gordon-freeman.jpg",
            "https://www.zing.cz/wp-content/uploads/2017/12/3821-gordon-freeman-zije-750x375.jpg",
            "https://static.wikia.nocookie.net/bohaterowie/images/d/da/GordonFreeman.png/revision/latest/top-crop/width/360/height/450?cb=20190708201219&path-prefix=pl",
            "https://www.postavy.cz/uzivatele/ikony/gordon-freeman-ikona.jpg",
            "https://static.wikia.nocookie.net/half-life/images/9/98/Gordon_player.jpg/revision/latest/scale-to-width-down/196?cb=20100309185146&path-prefix=en",
            "https://i.pinimg.com/originals/72/a3/bb/72a3bbcad59801ea32f881b0fe85748a.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSik4vd7HmQqlZz5PhTSXHTWawC8frHzjnKyQ&usqp=CAU",
            "https://i.refresher.sk/public/tony/0718/Screenshot_2r.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSt0V6OcRv-DUhjPWVCuAlWrJR3AqS8K_vZAg&usqp=CAU",
            "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/ba077243-f680-467a-89f5-df0bb62368f2/ddgwo9u-8f2a15da-0acb-4f4c-9c85-757cd4a20964.png/v1/fill/w_1920,h_1304,q_80,strp/_hl__gordon_freeman_by_greenstorm64_ddgwo9u-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9MTMwNCIsInBhdGgiOiJcL2ZcL2JhMDc3MjQzLWY2ODAtNDY3YS04OWY1LWRmMGJiNjIzNjhmMlwvZGRnd285dS04ZjJhMTVkYS0wYWNiLTRmNGMtOWM4NS03NTdjZDRhMjA5NjQucG5nIiwid2lkdGgiOiI8PTE5MjAifV1dLCJhdWQiOlsidXJuOnNlcnZpY2U6aW1hZ2Uub3BlcmF0aW9ucyJdfQ.QQnqXulAjG6D44GvVa_2-pEjMgExZCtZi867iFLsthE",
            "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/7cb0b86a-e6c6-411b-a8ab-77660ebb7eae/d1ejtmj-fd719464-8fbb-40be-8acc-12986c007510.jpg/v1/fill/w_800,h_428,q_75,strp/gordon_freeman_from_half_life_by_jfury_d1ejtmj-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOiIsImlzcyI6InVybjphcHA6Iiwib2JqIjpbW3siaGVpZ2h0IjoiPD00MjgiLCJwYXRoIjoiXC9mXC83Y2IwYjg2YS1lNmM2LTQxMWItYThhYi03NzY2MGViYjdlYWVcL2QxZWp0bWotZmQ3MTk0NjQtOGZiYi00MGJlLThhY2MtMTI5ODZjMDA3NTEwLmpwZyIsIndpZHRoIjoiPD04MDAifV1dLCJhdWQiOlsidXJuOnNlcnZpY2U6aW1hZ2Uub3BlcmF0aW9ucyJdfQ.tDCD1gpXYQcHaOWRS2NNoPnF0Ty24UfxLrztuEKN7e0",
            "https://i.pinimg.com/originals/f2/69/dd/f269dd8643dd10721799749cc499e137.jpg",
            "https://static.displate.com/280x392/displate/2020-08-18/8b41381244c246aac32d82bb0a322df6_a697ce102fc3614af55b7d053e5654cc.jpg",
            "https://www.arthipo.com/image/cache/catalog/genel-tasarim/all-posters/oyun/0154-half-life-1000x1000.jpg",
            "https://i.ytimg.com/vi/u7jBHW05s4A/maxresdefault.jpg",
        };

        [Command("freeman")]
        [Alias("gordon", "gordonfreeman", "halflife")]
        public async Task FreemanAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Gorgeous Freeman**",
                ImageUrl = urlFreeman.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Ta hlavní postava ze hry Half-life od MilošBota",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());
        }

        private static readonly string[] urlColin = new[]
        {
            "https://static.wikia.nocookie.net/changedgame/images/6/6c/Lin.png/revision/latest/top-crop/width/360/height/450?cb=20180601213716",
            "https://i.pinimg.com/originals/fe/39/fb/fe39fb75b378a19cb89c64ebd536e1fc.gif",
            "https://i.pinimg.com/originals/c2/d7/57/c2d7579185b9c06a217e4b191a79cf64.jpg",
            "https://preview.redd.it/5hrt8agc1rx51.png?width=752&format=png&auto=webp&s=e754008103f14c3ee4574644e8fc7ee0fdb29756",
            "http://pm1.narvii.com/7264/82a28f6fee28e9279d1dfa616f65872c5a727d57r1-209-319v2_00.jpg",
            "https://uploads.scratch.mit.edu/users/avatars/45614016.png",
            "https://static.wikia.nocookie.net/changed1449/images/e/e3/True_End.png/revision/latest/smart/width/250/height/250?cb=20180917020325",
            "https://lh3.googleusercontent.com/zCxp7tA_6f9cbWHv2qVti1TjXSW9BJ-FGh9MhcZrT0DzatCp5OYDgjori1p6rQY4kS8nd1uUcJAWc5BmTbxiZg=s400",
            "https://static.wikia.nocookie.net/changed1449/images/8/80/Betrayal_End.png/revision/latest/smart/width/250/height/250?cb=20201104211806",
            "https://pbs.twimg.com/media/Esi7kOWU0AAKXYb.png",
            "https://static.wikia.nocookie.net/changed1449/images/6/68/Transfur1.png/revision/latest/smart/width/250/height/250?cb=20210105194612",
            "https://i.pinimg.com/originals/53/6f/a4/536fa4e37ced10565b5ff50c5a35f4e8.jpg",
            "https://i.pinimg.com/236x/87/2a/d1/872ad1bbb8ad17e22cd86533679b3012.jpg",
            "https://i.pinimg.com/originals/ab/b4/cd/abb4cdd08ae9de9cbf2c7dcb4d02d8c1.jpg",
            "https://steamuserimages-a.akamaihd.net/ugc/951849971062473150/FED7015C50F3AAAB9231F3F5A15F8BC8470F1C68/?imw=268&imh=268&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=true",
            "https://i.pinimg.com/236x/50/f3/e6/50f3e6692ba913f9c6d8c34cadda0e95.jpg",
            "https://media.tenor.com/images/c6743bbaf48f30c3ab791855c3bc2db3/tenor.gif",
            "https://media.tenor.com/images/a0af3b43ad06126aa229c882e2ba5907/tenor.gif",
            "https://media.tenor.com/images/c0a7252cfeed1a28be6c359945e2daf3/tenor.gif",
            "http://pa1.narvii.com/7045/825c7479b713f5c3a476d59233fcb208378dc17er1-320-320_00.gif",
            "https://cdn2.scratch.mit.edu/get_image/gallery/4964073_170x100.png",
        };

        [Command("colin")]
        [Alias("lin")]
        public async Task ColinAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Human**",
                ImageUrl = urlColin.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Ten co nechce být furík ze scuntovy nejoblíbenější hry od MilošBota",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());
        }

        private static readonly string[] urlPuro = new[]
        {
            "https://static.wikia.nocookie.net/changed1449/images/e/ef/Puro.png/revision/latest/top-crop/width/360/height/450?cb=20210316122012",
            "https://cdn.discordapp.com/attachments/762039293082075146/836329104961044480/unknown.png",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQJXxQ8-wkNTyxvqi2G_45XZojfP9bpKVEwrw&usqp=CAU",
            "https://i.imgflip.com/517d3p.jpg",
            "https://i.redd.it/7w0q7pk3i8e61.jpg",
            "https://pbs.twimg.com/media/EtiIm_bXMAAN6Vo.jpg",
            "https://media.tenor.com/images/918abb71818af077b756a73a64ebe654/tenor.gif",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSU859Z0RlGJ_oCjkNHYuQZRO6vbgFVo64J6A&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRqLWO1jujj0SUBs-vbwIGEdxnB8xI25Q85HA&usqp=CAU",
        };

        [Command("puro")]
        [Alias("scunt")]
        public async Task PuroAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "**Here, take Some Cutie**",
                ImageUrl = urlPuro.GetRandom(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = "Ten hodnej furík ze scuntovy nejoblíbenější hry od MilošBota",
                    IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1"
                }
            };
            await Context.Channel.SendMessageAsync(embed: eb.Build());
        }
    }
}
