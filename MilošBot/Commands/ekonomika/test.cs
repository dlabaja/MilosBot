using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using MongoDB.Bson;
using MongoDB.Driver;
using ScottPlot;

namespace MilošBot.Commands
{
    public class Helsadadadapost : ModuleBase<SocketCommandContext>
    {
        [Command("testbt")]
        public async Task PingAsync()
        {
            var clientik = new MongoClient("MongoDB connection string");
            var datab = clientik.GetDatabase("dbl");
            var coll19 = datab.GetCollection<Rootobject1>("test1");

            var coll5515 = datab.GetCollection<Rootobject1>("cislo");

            var idcko1 = new ObjectId("603d510a6b05e30f18f4647b");
            var cisla11 = await coll5515.Find(b => b._id == idcko1).FirstAsync();
            int i = cisla11.uzivat;

            List<double> amplitudes = new List<double>();
            List<string> frequencies = new List<string>();
            for (int x = 2; x < 18; x++)
            {
                var cisla1 = await coll19.Find(b => b.uzi == i - x).FirstAsync();
                DateTime datum1 = cisla1.timer1;
                amplitudes.Add(cisla1.ahoj);
                frequencies.Add(datum1.ToString("MM/dd HH"));
            }
            var plt = new Plot(1000, 400);
            amplitudes.Reverse();
            frequencies.Reverse();
            double[] positions = DataGen.Consecutive(frequencies.Count);
            plt.AddScatter(positions, amplitudes.ToArray());

            string[] plabels = frequencies.Select(x => x.ToString()).ToArray();
            plt.XTicks(positions, plabels);

            plt.Title("kurz virtuální kryptoměny BiTStorK");
            plt.YLabel("kurz");
            plt.XLabel("čas (měsíc den hodina)");

            plt.SaveFig(@"C:/home/kubak1500/Desktop/ahojd.jpg");

            ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;
            await cons.SendFileAsync(@"C:/home/kubak1500/Desktop/ahojd.jpg");
        }
    }
}