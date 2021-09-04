/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.API;
using Discord.Rest;
using Discord.WebSocket;
using System.Text;
using System.Data.SqlClient;
using System.Net;
using ScottPlot;

namespace MilošBot.Commands
{
    public class helposydshjklkt : ModuleBase<SocketCommandContext>
    {
        [Command("bitcoin1")]
        public async Task Mildosdshuzuuaggdsurus1()
        {
            Random random = new Random();
            int smrt1 = random.Next(1, 50);
            int smrt2 = random.Next(1, 50);
            int smrt3 = random.Next(1, 50);
            int smrt4 = random.Next(1, 50);
            int smrt5 = random.Next(1, 50);
            int smrt6 = random.Next(1, 50);
            int smrt7 = random.Next(1, 50);
            int smrt8 = random.Next(1, 50);
            int smrt9 = random.Next(1, 50);
            int smrt10 = random.Next(1, 50);
            int smrt11 = random.Next(1, 50);
            int smrt12 = random.Next(1, 50);
            int smrt13 = random.Next(1, 50);
            int smrt14 = random.Next(1, 50);
            int smrt15 = random.Next(1, 50);
            int smrt16 = random.Next(1, 50);
            int smrt17 = random.Next(1, 50);
            int smrt18 = random.Next(1, 50);
            int smrt19 = random.Next(1, 50);
            int smrt20 = random.Next(1, 50);
            int smrt21 = random.Next(1, 50);

            var plt = new ScottPlot.Plot(600, 400);

            double[] amplitudes = { smrt1, smrt2, smrt3, smrt4, smrt5, smrt6, smrt7, smrt8, smrt9, smrt10,
                        smrt11, smrt12, smrt13, smrt14, smrt15, smrt16, smrt17, smrt18, smrt19, smrt20, smrt21 };
            double[] frequencies = { 50, 63, 80, 100, 125, 160, 200, 250, 315, 400, 500, 630,
                         800, 1000, 1250, 1600, 2000, 2500, 3150, 4000, 5000 };

            double[] positions = DataGen.Consecutive(frequencies.Length);
            plt.PlotScatter(positions, amplitudes);

            string[] labels = frequencies.Select(x => x.ToString()).ToArray();
            plt.XTicks(positions, labels);

            plt.Title("Vibrational Coupling");
            plt.YLabel("Amplitude (dB)");
            plt.XLabel("Frequency (Hz)");

            plt.SaveFig(@"C:\Users\Uzivatel\Desktop\ahojd.jpg");

            await Context.Channel.SendFileAsync(@"C:\Users\Uzivatel\Desktop\ahojd.jpg");
        }
    }
}*/