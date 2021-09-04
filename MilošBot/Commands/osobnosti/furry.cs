using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class furry : ModuleBase<SocketCommandContext>
    {
        private List<string> url = new List<string>()
        {
            "https://www.wesa.fm/sites/wesa/files/styles/x_large/public/201907/20190707_180726.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/f/fb/Anthro_vixen_colored.jpg",
            "https://dynaimage.cdn.cnn.com/cnn/w_768,h_1024,c_scale/https%3A%2F%2Fdynaimage.cdn.cnn.com%2Fcnn%2Fx_156%2Cy_210%2Cw_1209%2Ch_1612%2Cc_crop%2Fhttps%253A%252F%252Fstamp.static.cnn.io%252F5bae1c384db3d70020c01c40%252FfireflyWolfy.jpg",
            "https://nypost.com/wp-content/uploads/sites/2/2016/05/furry.jpg?quality=80&strip=all",
            "https://dynaimage.cdn.cnn.com/cnn/c_fill,g_auto,w_1200,h_675,ar_16:9/https%3A%2F%2Fcdn.cnn.com%2Fcnnnext%2Fdam%2Fassets%2F181007184119-furry-costume-pink-wolf.jpg",
            "https://dazedimg-dazedgroup.netdna-ssl.com/747/azure/dazed-prod/1260/7/1267894.jpg",
            "https://zena-in.cz/media/2020/01/09/profimedia-0397087420.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4d/Otakuthon_2014_%2814850728278%29.jpg/220px-Otakuthon_2014_%2814850728278%29.jpg",
            "https://i.cbc.ca/1.3885173.1481126073!/fileImage/httpImage/furries-furry-subculture.jpg",
            "https://i.ytimg.com/vi/jDwCyBENWc4/maxresdefault.jpg",
            "https://i.pinimg.com/originals/c7/d8/fe/c7d8fe9a70c65e466dab7abc9f1ca176.jpg",
            "https://dailyiowan.com/wp-content/uploads/2019/05/DSF4167-900x600.jpg",
            "https://hornet.fullcoll.edu/wp-content/uploads/2016/10/oc-furry.jpg",
            "https://cdn.vox-cdn.com/thumbor/SvLIA3pSwB-yiZ-_hsLVjH2a-Dk=/53x246:1166x1081/1200x800/filters:focal(53x246:1166x1081)/cdn.vox-cdn.com/uploads/chorus_image/image/44306254/4756098992_5fbae5e9a3_o.0.0.jpg",
            "https://i.ebayimg.com/images/g/szkAAOSwqvxd8zxC/s-l300.jpg",
            "https://cdn.psychologytoday.com/sites/default/files/field_blog_entry_images/886bc50131c66e0eff9cee091bb9bc9d.jpg",
            "https://img.thedailybeast.com/image/upload/c_crop,d_placeholder_euli9k,h_1439,w_2560,x_0,y_0/dpr_2.0/c_limit,w_600/f_jpg/fl_lossy,q_auto/v1492180000/articles/2017/04/13/neo-nazis-are-tearing-apart-the-furry-world/170413-weill-furry-fallout-tease_y8xatp",
            "https://cdn.xsd.cz/resize/54ced3fa303f396dac9a6da084d3b6c9_resize=680,383_.jpg?hash=874966f5864a555b7c56de754bae5eed",
            "https://c3.iggcdn.com/indiegogo-media-prod-cld/image/upload/c_fill,w_695,g_auto,q_auto,dpr_2.6,f_auto,h_460/tnnztizqi8fnxnzgxijh",
            "https://pyxis.nymag.com/v1/imgs/004/aac/2905e296b9ffd7c26f47e43379eda94dbc-22-furry.rsquare.w700.jpg",
            "https://www.abc.net.au/cm/rimage/11796116-3x4-large.jpg?v=3",
            "https://www.arcurrent.com/wp-content/uploads/2019/12/IMG_5955-2_WEB-1000x667.jpg",
            "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/aurora-bloom-2-jpg-1579817827.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSdfQySn4RCR_NyAIsExi9iK42vNtF33cdHbg&usqp=CAU",
            "https://img.huffingtonpost.com/asset/5bad8e102500003600378df2.jpeg?ops=scalefit_630_noupscale",
            "https://ichef.bbci.co.uk/images/ic/320xn/p06h3ymt.jpg",
            "https://zena-in.cz/media/2020/01/09/5e17029792a7cprofimedia-0397087429.jpg",
            "https://paisano-online.com/wp-content/uploads/2018/01/15621833_367586243604160_4279087299539152048_n-900x506.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTjCvKYKcxDRPx0PinokRyd9gkHM_tRacxBZw&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTCpneIYrClsPIPtAztlTR0LqalMRHWYCG_oA&usqp=CAU",
            "https://i2-prod.cornwalllive.com/incoming/article3942652.ece/ALTERNATES/s1200c/0_LT_CL_120320furries_03.jpg",
            "https://static.wikia.nocookie.net/gvf-war/images/c/ce/Furry.jpg/revision/latest/top-crop/width/360/height/450?cb=20190228231627",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT5Q-Ma9Qlk8BfmGfko5fUq2RVGLBuaSieFnQ&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0axs5u9KTuvBJc8bdU04zoR5UuyUfOH6UAA&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRT3IxAhGq_EpXOOIsnYLhJDXw8BVPMFdsg1Q&usqp=CAU",
            "https://g.denik.cz/63/f7/7156986-praha-furry-priznivci-sraz_denik-630-16x9.jpg",
            "https://lh3.googleusercontent.com/proxy/s3FKvBQJIgF7505cHbrtJNjDlCO8_sGP9tzrVQtQYNHGyUIOpWbyNYDX_Jebh4wEx3IgFFU9DHo_6Ik6uQCUNILlTsVEbjCVCqU8MlfU4PM43Wwj_V7idVk0WRQ",
            "https://www.gannett-cdn.com/presto/2019/06/18/PMJS/5590573f-4f16-4a94-b87e-a5932ed67224-Dany_PrideFest.jpg?crop=1212,682,x1,y0&width=660&height=372&format=pjpg&auto=webp",
            "https://g.denik.cz/63/bb/7156985-praha-furry-priznivci-sraz_denik-300.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHTi_cTjP79KkY51zhy5OsDQFu-eK5bs01gg&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTw9B8cEfrNvgcgL2BgrIneseTKY5MSsBfnaQ&usqp=CAU",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS8Y4eJnFRBblsrK1zfUt9dpenPL9JONJbvHw&usqp=CAU",
            "https://storiescdn.hornet.com/wp-content/uploads/2020/11/13144457/furries-furry-fandom-teaser-1000x500.jpg",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRxuxu2Rmz23NDgqiLe-rM8HLGBZXoO2k7Rxg&usqp=CAU",
            "https://cdn.vox-cdn.com/thumbor/sRuz3IEMCnFiFA5IVcijrlgU0JQ=/253x0:4348x3071/1200x675/filters:focal(253x0:4348x3071)/cdn.vox-cdn.com/uploads/chorus_image/image/46693798/Grinning_Tiger_Disorder_-_photo_credit__Julian_Paavola_-characters__Ravi_and_Tenki_.0.0.JPG",
        };

        [Command("furrik")]
        [Alias("scunt")]
        public async Task Mildosaurus()
        {
            using (Context.Channel.EnterTypingState())
            {
                Random random = new Random();
                int ovce = random.Next(url.Count);
                Console.WriteLine(ovce);
                var ovcak = new EmbedBuilder();
                ovcak.WithTitle("**Here, take Some Furry trash **");
                ovcak.WithImageUrl(url[ovce]);

                ovcak.WithFooter(footer =>
                {
                    footer
                    .WithIconUrl("https://cdn.discordapp.com/emojis/778284745448357888.png?v=1")
                    .WithText("Ti lidi co se převlíkaj za zvířata od MilošBota");
                });
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());

                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosOsobnosti) as ITextChannel;
                await cons.SendMessageAsync("furry: " + url[ovce]);
            }
        }
    }
}