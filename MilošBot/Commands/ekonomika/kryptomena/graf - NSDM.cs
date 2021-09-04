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
using ScottPlot;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MilošBot.Commands
{
    public class helposdshjsklkt : ModuleBase<SocketCommandContext>
    {
        [Command("NSDM")]
        public async Task Mildosdshuzuuaggdsurus1()
        {
            await Context.Channel.SendFileAsync(@"/home/kubak1500/Desktop/nsdm.jpg");

            //log
            var ruka = Context.User as SocketGuildUser;
            ITextChannel cons1 = Context.Client.GetChannel(814954423972266024) as ITextChannel;
            await cons1.SendMessageAsync("Graf NSDM " + ruka);

            /* var client55 = new MongoClient("MongoDB connection string");
             var db = client55.GetDatabase("dbl");
             var coll55 = db.GetCollection<Rootobject1>("cislo");

             var idcko = new ObjectId("603d510a6b05e30f18f4647b");
             var cisla = coll55.Find(b => b._id == idcko).FirstAsync().Result;
             int i = cisla.uzivat;
             Console.WriteLine(i);

             var coll19 = db.GetCollection<Rootobject1>("test");

             var cisla1 = coll19.Find(b => b.uzi == i - 2).FirstAsync().Result;
             DateTime datum1 = cisla1.

            1;
             int ahoj1 = cisla1.ahoj;

             var cisla2 = coll19.Find(b => b.uzi == i - 3).FirstAsync().Result;
             DateTime datum2 = cisla2.timer1;
             int ahoj2 = cisla2.ahoj;

             var cisla3 = coll19.Find(b => b.uzi == i - 4).FirstAsync().Result;
             DateTime datum3 = cisla3.timer1;
             int ahoj3 = cisla3.ahoj;

             var cisla4 = coll19.Find(b => b.uzi == i - 5).FirstAsync().Result;
             DateTime datum4 = cisla4.timer1;
             int ahoj4 = cisla4.ahoj;

             var cisla5 = coll19.Find(b => b.uzi == i - 6).FirstAsync().Result;
             DateTime datum5 = cisla5.timer1;
             int ahoj5 = cisla5.ahoj;

             var cisla6 = coll19.Find(b => b.uzi == i - 7).FirstAsync().Result;
             DateTime datum6 = cisla6.timer1;
             int ahoj6 = cisla6.ahoj;

             var cisla7 = coll19.Find(b => b.uzi == i - 8).FirstAsync().Result;
             DateTime datum7 = cisla7.timer1;
             int ahoj7 = cisla7.ahoj;

             var cisla8 = coll19.Find(b => b.uzi == i - 9).FirstAsync().Result;
             DateTime datum8 = cisla8.timer1;
             int ahoj8 = cisla8.ahoj;

             var cisla9 = coll19.Find(b => b.uzi == i - 10).FirstAsync().Result;
             DateTime datum9 = cisla9.timer1;
             int ahoj9 = cisla9.ahoj;

             var cisla10 = coll19.Find(b => b.uzi == i - 11).FirstAsync().Result;
             DateTime datum10 = cisla10.timer1;
             int ahoj10 = cisla10.ahoj;

             var cisla11 = coll19.Find(b => b.uzi == i - 12).FirstAsync().Result;
             DateTime datum11 = cisla11.timer1;
             int ahoj11 = cisla11.ahoj;

             var cisla12 = coll19.Find(b => b.uzi == i - 13).FirstAsync().Result;
             DateTime datum12 = cisla12.timer1;
             int ahoj12 = cisla12.ahoj;

             var cisla13 = coll19.Find(b => b.uzi == i - 14).FirstAsync().Result;
             DateTime datum13 = cisla13.timer1;
             int ahoj13 = cisla13.ahoj;

             var cisla14 = coll19.Find(b => b.uzi == i - 15).FirstAsync().Result;
             DateTime datum14 = cisla14.timer1;
             int ahoj14 = cisla14.ahoj;

             var cisla15 = coll19.Find(b => b.uzi == i - 16).FirstAsync().Result;
             DateTime datum15 = cisla15.timer1;
             int ahoj15 = cisla15.ahoj;

             var cisla16 = coll19.Find(b => b.uzi == i - 17).FirstAsync().Result;
             DateTime datum16 = cisla16.timer1;
             int ahoj16 = cisla16.ahoj;

             string ahh1 = (datum1.ToString("MM/dd HH"));
             string ahh2 = (datum2.ToString("MM/dd HH"));
             string ahh3 = (datum3.ToString("MM/dd HH"));
             string ahh4 = (datum4.ToString("MM/dd HH"));
             string ahh5 = (datum5.ToString("MM/dd HH"));
             string ahh6 = (datum6.ToString("MM/dd HH"));
             string ahh7 = (datum7.ToString("MM/dd HH"));
             string ahh8 = (datum8.ToString("MM/dd HH"));
             string ahh9 = (datum9.ToString("MM/dd HH"));
             string ahh10 = (datum10.ToString("MM/dd HH"));
             string ahh11 = (datum11.ToString("MM/dd HH"));
             string ahh12 = (datum12.ToString("MM/dd HH"));
             string ahh13 = (datum13.ToString("MM/dd HH"));
             string ahh14 = (datum14.ToString("MM/dd HH"));
             string ahh15 = (datum15.ToString("MM/dd HH"));
             string ahh16 = (datum16.ToString("MM/dd HH"));

             var plt = new ScottPlot.Plot(1000, 400);

             double[] amplitudes = { ahoj16, ahoj15, ahoj14, ahoj13, ahoj12, ahoj11, ahoj10, ahoj9, ahoj8, ahoj7, ahoj6, ahoj5, ahoj4, ahoj3, ahoj2, ahoj1 };
             string[] frequencies = { ahh16, ahh15, ahh14, ahh13, ahh12, ahh11, ahh10, ahh9, ahh8, ahh7, ahh6, ahh5, ahh4, ahh3, ahh2, ahh1 };

             double[] positions = DataGen.Consecutive(frequencies.Length);
             plt.PlotScatter(positions, amplitudes);

             string[] labels = frequencies.Select(x => x.ToString()).ToArray();
             plt.XTicks(positions, labels);

             plt.Title("kurz virtuální kryptoměny dbl gamingu ==>> NSDM");
             plt.YLabel("kurz");
             plt.XLabel("čas (měsíc den hodina)");

             plt.SaveFig(@"/home/kubak1500/Desktop/ahojd.jpg");

             await Context.Channel.SendFileAsync(@"/home/kubak1500/Desktop/ahojd.jpg");*/

            //log
            /*var ruka = Context.User as SocketGuildUser;
            ITextChannel cons1 = Context.Client.GetChannel(814954423972266024) as ITextChannel;
            await cons1.SendMessageAsync("Graf NSDM " + ruka);*/
        }
    }
}