using System;

/*using System.Collections.Generic;
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
    public class helposdsahjklkt : ModuleBase<SocketCommandContext>
    {
        [Command("bitcoin")]
        public async Task Mildosdshuzuuaggdsurus1()
        {
            // Code from /src/ScottPlot.Demo/PlotTypes/Finance.cs
            var plt = new ScottPlot.Plot(600, 400);

            // start with random stock data
            Random rand = new Random(0);
            ScottPlot.OHLC[] ohlcs = DataGen.RandomStockPrices(rand, 75, sequential: true);
            plt.PlotCandlestick(ohlcs);

            // calculate SMAs of different durations using helper methods
            double[] xs = DataGen.Consecutive(ohlcs.Length);
            double[] sma8xs = xs.Skip(8).ToArray();
            double[] sma8ys = ScottPlot.Statistics.Finance.SMA(ohlcs, 8).Skip(8).ToArray();
            double[] sma20xs = xs.Skip(20).ToArray();
            double[] sma20ys = ScottPlot.Statistics.Finance.SMA(ohlcs, 20).Skip(20).ToArray();

            plt.PlotScatter(sma8xs, sma8ys, label: "8 day SMA", color: Color.Blue, markerSize: 0, lineWidth: 2);
            plt.PlotScatter(sma20xs, sma20ys, label: "20 day SMA", color: Color.Blue, markerSize: 0, lineWidth: 2);

            // decorate the plot
            plt.Title("Simple Moving Averages (SMA)");
            plt.YLabel("Stock Price (USD)");
            plt.XLabel("Day");
            plt.Legend();*/
// Code from /src/ScottPlot.Demo/PlotTypes/ScatterHighlight.cs

// Code from /src/ScottPlot.Demo/Customize/Axis.cs
/* var plt = new ScottPlot.Plot(600, 400);

 Random rand = new Random(0);
 double[] ys = DataGen.RandomWalk(rand, 100);
 double[] xs = new double[ys.Length];

 DateTime dtStart = new DateTime(1985, 9, 24);
 for (int i = 0; i < ys.Length; i++)
 {
     DateTime dtNow = dtStart.AddSeconds(i);
     xs[i] = dtNow.ToOADate();
 }

 plt.PlotScatter(xs, ys);
 plt.Ticks(dateTimeX: true);
 plt.Title("DateTime Axis Labels");

 plt.SaveFig(@"C:\Users\Uzivatel\Desktop\ahojd.png");

 await Context.Channel.SendFileAsync(@"C:\Users\Uzivatel\Desktop\ahojd.png");*/
// Code from /src/ScottPlot.Demo/Quickstart/Quickstart.cs
/*var plt = new ScottPlot.Plot(600, 400);

Random rand = new Random(0);
int pointCount = (int)1e6;
int lineCount = 1;

for (int i = 0; i < lineCount; i++)
    plt.PlotSignal(DataGen.RandomWalk(rand, pointCount));

plt.Title("Signal Plot Quickstart (5 million points)");
plt.YLabel("Vertical Units");
plt.XLabel("Horizontal Units");

plt.SaveFig(@"C:\Users\Uzivatel\Desktop\ahojd.png");

await Context.Channel.SendFileAsync(@"C:\Users\Uzivatel\Desktop\ahojd.png");*/

// Code from /src/ScottPlot.Demo/Customize/Axis.cs
/* var plt = new ScottPlot.Plot(600, 400);

 Random rand = new Random(0);
 double[] ys = DataGen.RandomWalk(rand, 50);
 double[] xs = new double[ys.Length];

 DateTime start = new DateTime(1985, 9, 24);
 for (int i = 0; i < ys.Length; i++)
 {
     DateTime dtNow = start.AddMinutes(i * 15);
     xs[i] = dtNow.ToOADate();
 }

 plt.PlotScatter(xs, ys);
 plt.Ticks(dateTimeX: true, dateTimeFormatStringX: "HH:mm:ss");
 plt.Title("Time Axis Labels");

 plt.SaveFig(@"C:\Users\Uzivatel\Desktop\ahojd.jpg");

 await Context.Channel.SendFileAsync(@"C:\Users\Uzivatel\Desktop\ahojd.jpg");

// Code from /src/ScottPlot.Demo/Customize/Ticks.cs
var plt = new ScottPlot.Plot(600, 400);

// these are our nonlinear data values we wish to plot
double[] amplitudes = { 23.9, 24.2, 24.3, 24.5, 25.3, 26.3, 27.6, 31.4, 33.7, 36,
            38.4, 42, 43.5, 46.1, 48.8, 51.5, 53.2, 55, 56.9, 58.7, 45.3 };
double[] frequencies = { 50, 63, 80, 100, 125, 160, 200, 250, 315, 400, 500, 630,
             800, 1000, 1250, 1600, 2000, 2500, 3150, 4000, 5000 };

// ignore the "real" X values and plot data at consecutive X values (0, 1, 2, 3...)
double[] positions = DataGen.Consecutive(frequencies.Length);
plt.PlotScatter(positions, amplitudes);

// then define tick labels based on "real" X values, rotate them, and give them extra space
string[] labels = frequencies.Select(x => x.ToString()).ToArray();
plt.XTicks(positions, labels);

// apply axis labels, trigging a layout reset
plt.Title("Vibrational Coupling");
plt.YLabel("Amplitude (dB)");
plt.XLabel("Frequency (Hz)");

plt.SaveFig(@"C:\Users\Uzivatel\Desktop\ahojd.jpg");

await Context.Channel.SendFileAsync(@"C:\Users\Uzivatel\Desktop\ahojd.jpg");
}
}
}

using System;
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

namespace MilošBot.Commands
{
public class helposdsahjklkt : ModuleBase<SocketCommandContext>
{
[Command("bitcoin")]
public async Task Mildosdshuzuuaggdsurus1()
{
double kurz = 0;
WebClient ovce = new WebClient();
string ovcacek = ovce.DownloadString(
String.Format(
"https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/vybrane.html?od={0}&do={1}&mena=EUR&format=html",
DateTime.Today.AddDays(-5).ToString("dd.MM.yyyy"), DateTime.Today.AddDays(-5).ToString("dd.MM.yyyy")));
ovcacek = ovcacek.Substring(ovcacek.LastIndexOf('|') + 1);
kurz = Convert.ToDouble(ovcacek);
Console.WriteLine(kurz);*/