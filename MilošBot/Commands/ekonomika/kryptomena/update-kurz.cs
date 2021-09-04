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
using MongoDB.Driver;
using MongoDB.Bson;

namespace MilošBot.Commands
{
    public class kurzupdate : ModuleBase<SocketCommandContext>
    {
        public async Task updatekurz()
        {
            var client55 = new MongoClient("MongoDB connection string");
            var db = client55.GetDatabase("dbl");
            var coll55 = db.GetCollection<Rootobject1>("statistiky");

            var idcko = new ObjectId("603d418f3327a936bcba734e");
            var cisla = coll55.Find(b => b._id == idcko).FirstAsync().Result;
            DateTime porovnani = cisla.timer2;
            int zpravy = cisla.zpravy;
            var hod1 = DateTime.UtcNow.AddHours(1);
            DateTime secondsLeft = porovnani.AddDays(1);
            DateTime hod = porovnani.AddDays(1);

            if (porovnani <= hod1)
            {
                string nula = "aaaaa";
                int nula1 = 0;

                var filter9 = Builders<Rootobject1>.Filter.Eq("uzivatelid", nula);
                var update9 = Builders<Rootobject1>.Update.Set("timer2", secondsLeft);
                coll55.UpdateOne(filter9, update9);

                var coll5515 = db.GetCollection<Rootobject1>("cislo");

                var idcko1 = new ObjectId("603d510a6b05e30f18f4647b");
                var cisla1 = coll5515.Find(b => b._id == idcko1).FirstAsync().Result;
                int i = cisla1.uzivat;

                int ii = i + 1;
                Console.WriteLine(ii);
                var coll551 = db.GetCollection<Rootobject1>("cislo");
                var filter99 = Builders<Rootobject1>.Filter.Eq("ahoj", nula1);
                var update99 = Builders<Rootobject1>.Update.Set("uzivat", ii);
                coll551.UpdateOne(filter99, update99);

                var coll1 = db.GetCollection<Rootobject1>("test");
                var cisla7 = coll1.Find(b => b.uzi == i).FirstAsync().Result;
                int rozdil = cisla7.rozdil;

                int kurz = zpravy - rozdil;

                var db2 = client55.GetDatabase("dbl");
                var coll11 = db2.GetCollection<BsonDocument>("test");
                var pridani1 = new BsonDocument
            {
                {"uzi",ii},
                {"timer1",hod},
                {"ahoj",kurz},
                {"rozdil",zpravy}
            };
                await coll11.InsertOneAsync(pridani1);

                var gUser = Context.User as SocketGuildUser;
                SocketGuild dbl = gUser.Guild;
                int users = dbl.Users.Count;

                var coll117 = db2.GetCollection<BsonDocument>("test1");
                var pridani17 = new BsonDocument
            {
                {"uzi",ii},
                {"timer1",hod},
                {"ahoj",users},
            };
                await coll117.InsertOneAsync(pridani17);

                var coll19 = db.GetCollection<Rootobject1>("test");

                var cisla12 = coll19.Find(b => b.uzi == ii - 2).FirstAsync().Result;
                DateTime datum1 = cisla12.timer1;
                int ahoj1 = cisla12.ahoj;

                var cisla2 = coll19.Find(b => b.uzi == ii - 3).FirstAsync().Result;
                DateTime datum2 = cisla2.timer1;
                int ahoj2 = cisla2.ahoj;

                var cisla3 = coll19.Find(b => b.uzi == ii - 4).FirstAsync().Result;
                DateTime datum3 = cisla3.timer1;
                int ahoj3 = cisla3.ahoj;

                var cisla4 = coll19.Find(b => b.uzi == ii - 5).FirstAsync().Result;
                DateTime datum4 = cisla4.timer1;
                int ahoj4 = cisla4.ahoj;

                var cisla5 = coll19.Find(b => b.uzi == ii - 6).FirstAsync().Result;
                DateTime datum5 = cisla5.timer1;
                int ahoj5 = cisla5.ahoj;

                var cisla6 = coll19.Find(b => b.uzi == ii - 7).FirstAsync().Result;
                DateTime datum6 = cisla6.timer1;
                int ahoj6 = cisla6.ahoj;

                var cisla72 = coll19.Find(b => b.uzi == ii - 8).FirstAsync().Result;
                DateTime datum7 = cisla72.timer1;
                int ahoj7 = cisla72.ahoj;

                var cisla8 = coll19.Find(b => b.uzi == ii - 9).FirstAsync().Result;
                DateTime datum8 = cisla8.timer1;
                int ahoj8 = cisla8.ahoj;

                var cisla9 = coll19.Find(b => b.uzi == ii - 10).FirstAsync().Result;
                DateTime datum9 = cisla9.timer1;
                int ahoj9 = cisla9.ahoj;

                var cisla10 = coll19.Find(b => b.uzi == ii - 11).FirstAsync().Result;
                DateTime datum10 = cisla10.timer1;
                int ahoj10 = cisla10.ahoj;

                var cisla112 = coll19.Find(b => b.uzi == ii - 12).FirstAsync().Result;
                DateTime datum11 = cisla112.timer1;
                int ahoj11 = cisla112.ahoj;

                var cisla122 = coll19.Find(b => b.uzi == ii - 13).FirstAsync().Result;
                DateTime datum12 = cisla122.timer1;
                int ahoj12 = cisla122.ahoj;

                var cisla13 = coll19.Find(b => b.uzi == ii - 14).FirstAsync().Result;
                DateTime datum13 = cisla13.timer1;
                int ahoj13 = cisla13.ahoj;

                var cisla14 = coll19.Find(b => b.uzi == ii - 15).FirstAsync().Result;
                DateTime datum14 = cisla14.timer1;
                int ahoj14 = cisla14.ahoj;

                var cisla15 = coll19.Find(b => b.uzi == ii - 16).FirstAsync().Result;
                DateTime datum15 = cisla15.timer1;
                int ahoj15 = cisla15.ahoj;

                var cisla16 = coll19.Find(b => b.uzi == ii - 17).FirstAsync().Result;
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

                plt.SaveFig(@"/home/kubak1500/Desktop/nsdm.jpg");

                ITextChannel cons1 = Context.Client.GetChannel(816642007497310208) as ITextChannel;
                await cons1.SendFileAsync(@"/home/kubak1500/Desktop/nsdm.jpg");

                //test 2

                var pcoll19 = db.GetCollection<Rootobject1>("test1");

                var pcisla12 = pcoll19.Find(b => b.uzi == ii - 2).FirstAsync().Result;
                DateTime pdatum1 = pcisla12.timer1;
                int pahoj1 = pcisla12.ahoj;

                var pcisla2 = pcoll19.Find(b => b.uzi == ii - 3).FirstAsync().Result;
                DateTime pdatum2 = pcisla2.timer1;
                int pahoj2 = pcisla2.ahoj;

                var pcisla3 = pcoll19.Find(b => b.uzi == ii - 4).FirstAsync().Result;
                DateTime pdatum3 = pcisla3.timer1;
                int pahoj3 = pcisla3.ahoj;

                var pcisla4 = pcoll19.Find(b => b.uzi == ii - 5).FirstAsync().Result;
                DateTime pdatum4 = pcisla4.timer1;
                int pahoj4 = pcisla4.ahoj;

                var pcisla5 = pcoll19.Find(b => b.uzi == ii - 6).FirstAsync().Result;
                DateTime pdatum5 = pcisla5.timer1;
                int pahoj5 = pcisla5.ahoj;

                var pcisla6 = pcoll19.Find(b => b.uzi == ii - 7).FirstAsync().Result;
                DateTime pdatum6 = pcisla6.timer1;
                int pahoj6 = pcisla6.ahoj;

                var pcisla72 = pcoll19.Find(b => b.uzi == ii - 8).FirstAsync().Result;
                DateTime pdatum7 = pcisla72.timer1;
                int pahoj7 = pcisla72.ahoj;

                var pcisla8 = pcoll19.Find(b => b.uzi == ii - 9).FirstAsync().Result;
                DateTime pdatum8 = pcisla8.timer1;
                int pahoj8 = pcisla8.ahoj;

                var pcisla9 = pcoll19.Find(b => b.uzi == ii - 10).FirstAsync().Result;
                DateTime pdatum9 = pcisla9.timer1;
                int pahoj9 = pcisla9.ahoj;

                var pcisla10 = pcoll19.Find(b => b.uzi == ii - 11).FirstAsync().Result;
                DateTime pdatum10 = pcisla10.timer1;
                int pahoj10 = pcisla10.ahoj;

                var pcisla112 = pcoll19.Find(b => b.uzi == ii - 12).FirstAsync().Result;
                DateTime pdatum11 = pcisla112.timer1;
                int pahoj11 = pcisla112.ahoj;

                var pcisla122 = pcoll19.Find(b => b.uzi == ii - 13).FirstAsync().Result;
                DateTime pdatum12 = pcisla122.timer1;
                int pahoj12 = pcisla122.ahoj;

                var pcisla13 = pcoll19.Find(b => b.uzi == ii - 14).FirstAsync().Result;
                DateTime pdatum13 = pcisla13.timer1;
                int pahoj13 = pcisla13.ahoj;

                var pcisla14 = pcoll19.Find(b => b.uzi == ii - 15).FirstAsync().Result;
                DateTime pdatum14 = pcisla14.timer1;
                int pahoj14 = pcisla14.ahoj;

                var pcisla15 = pcoll19.Find(b => b.uzi == ii - 16).FirstAsync().Result;
                DateTime pdatum15 = pcisla15.timer1;
                int pahoj15 = pcisla15.ahoj;

                var pcisla16 = pcoll19.Find(b => b.uzi == ii - 17).FirstAsync().Result;
                DateTime pdatum16 = pcisla16.timer1;
                int pahoj16 = pcisla16.ahoj;

                string pahh1 = (pdatum1.ToString("MM/dd HH"));
                string pahh2 = (pdatum2.ToString("MM/dd HH"));
                string pahh3 = (pdatum3.ToString("MM/dd HH"));
                string pahh4 = (pdatum4.ToString("MM/dd HH"));
                string pahh5 = (pdatum5.ToString("MM/dd HH"));
                string pahh6 = (pdatum6.ToString("MM/dd HH"));
                string pahh7 = (pdatum7.ToString("MM/dd HH"));
                string pahh8 = (pdatum8.ToString("MM/dd HH"));
                string pahh9 = (pdatum9.ToString("MM/dd HH"));
                string pahh10 = (pdatum10.ToString("MM/dd HH"));
                string pahh11 = (pdatum11.ToString("MM/dd HH"));
                string pahh12 = (pdatum12.ToString("MM/dd HH"));
                string pahh13 = (pdatum13.ToString("MM/dd HH"));
                string pahh14 = (pdatum14.ToString("MM/dd HH"));
                string pahh15 = (pdatum15.ToString("MM/dd HH"));
                string pahh16 = (pdatum16.ToString("MM/dd HH"));

                var pplt = new ScottPlot.Plot(1000, 400);

                double[] pamplitudes = { pahoj16, pahoj15, pahoj14, pahoj13, pahoj12, pahoj11, pahoj10, pahoj9, pahoj8, pahoj7, pahoj6, pahoj5, pahoj4, pahoj3, pahoj2, pahoj1 };
                string[] pfrequencies = { pahh16, pahh15, pahh14, pahh13, pahh12, pahh11, pahh10, pahh9, pahh8, pahh7, pahh6, pahh5, pahh4, pahh3, pahh2, pahh1 };

                double[] ppositions = DataGen.Consecutive(pfrequencies.Length);
                pplt.PlotScatter(ppositions, pamplitudes);

                string[] plabels = pfrequencies.Select(x => x.ToString()).ToArray();
                pplt.XTicks(ppositions, plabels);

                pplt.Title("kurz virtuální kryptoměny BiTStorK");
                pplt.YLabel("kurz");
                pplt.XLabel("čas (měsíc den hodina)");

                pplt.SaveFig(@"C:/home/kubak1500/Desktop/bitstork.jpg");

                await cons1.SendFileAsync(@"C:/home/kubak1500/Desktop/bitstork.jpg");
            }
            else { Console.WriteLine("není čes na připsání dokumetu"); }
        }
    }
}*/