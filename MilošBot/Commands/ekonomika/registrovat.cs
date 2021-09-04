using Discord;
using Discord.Commands;
using Discord.WebSocket;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class helpasdaost : ModuleBase<SocketCommandContext>
    {
        [Command("registrovat")]
        [Alias("reg", "dblekonomikaregistrace")]
        [Summary("Registrování do DBL ekonomiky.")]
        public async Task Mildosaggurus1()
        {
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "databáze");
            var ruka = Context.User as SocketGuildUser;

            if (ruka.Roles.Contains(role2))
            {
                await Context.Message.Channel.SendMessageAsync("Už si se asi registroval do ekonomiky, pokud ne kontaktuj qwer8, nebo ten dlabaja");
                return;
            }
            await ruka.AddRoleAsync(role2);
            await Context.Channel.SendMessageAsync("< úspěšně si se registroval");

            var slovo5 = Context.User.ToString();

            var slovo = Context.User.Id;
            string slovo1 = slovo.ToString();
            int slovo4 = 0;

            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");
            var coll = db.GetCollection<BsonDocument>("ekonomika");

            var collec = db.GetCollection<Rootobject1>("cislo");
            var idckoo = new ObjectId("6045f2e774137e2c24f83dd8");
            var cislaa = await collec.Find(b => b._id == idckoo).FirstAsync();
            int cislo78 = cislaa.uzivat;

            var coll18 = db.GetCollection<Rootobject1>("cislo");
            var filter = Builders<Rootobject1>.Filter.Eq("ahoj", 2);
            var update1 = Builders<Rootobject1>.Update.Set("uzivat", cislo78 + 1);
            coll18.UpdateOne(filter, update1);

            var pridani = new BsonDocument
            {
                {"uzivatel",slovo5},
                {"uzivatelid",slovo1},
                {"cum",slovo4},
                {"cernaruka",slovo4},
                {"banka",slovo4},
                {"kreditka",slovo4},
                {"padelanasmlouva",slovo4},
                {"cervenetrenyrky",slovo4},
                {"zamestnanci",slovo4},
                {"pracujicimigranti",slovo4},
                {"mistri",slovo4},
                {"experti",slovo4},
                {"poradci",slovo4},
                {"riditelezavoduvesvete",slovo4},
                {"zivnost",slovo4},
                {"malafirma",slovo4},
                {"strednemalafirma",slovo4},
                {"strednifirma",slovo4},
                {"vetsifirma",slovo4},
                {"velkafirma",slovo4},
                {"akciovaspolecnost",slovo4},
                {"korporace",slovo4},
                {"nadnarodnispolecnost",slovo4},
                {"premium",slovo4},
                {"poradi",cislo78+1}
            };

            await coll.InsertOneAsync(pridani);

            var db1 = client.GetDatabase("dbl");
            var coll1 = db1.GetCollection<BsonDocument>("timery");

            var hod = DateTime.UtcNow.AddHours(1);
            var pridani1 = new BsonDocument
            {
                {"uzivatel",slovo5},
                {"uzivatelid",slovo1},
                {"timer1",hod},
                {"timer2",hod},
                {"timer3",hod},
                {"timer4",hod},
                {"timer5",hod},
                {"timer6",hod},
                {"timer7",hod},
                {"timer8",hod},
                {"timer9",hod},
                {"timer10",hod},
                {"timer11",hod},
                {"timer12",hod},
                {"timer13",hod},
                {"timer14",hod},
                {"timer15",hod},
                {"timer16",hod},
                {"timer17",hod},
                {"timer18",hod},
                {"timer19",hod},
                {"timer20",hod},
                {"timer21",hod}
            };
            await coll1.InsertOneAsync(pridani1);

            var db11 = client.GetDatabase("dbl");
            var coll11 = db11.GetCollection<BsonDocument>("kryptomena1");

            var pridani11 = new BsonDocument
            {
                {"uzivatel",slovo5},
                {"uzivatelid",slovo1},
                {"kryptomena1",slovo4},
                {"kryptomena2",slovo4},
                {"timer4",hod},
                {"timer5",hod},
            };
            await coll11.InsertOneAsync(pridani11);

            var db15 = client.GetDatabase("dbl");
            var coll15 = db15.GetCollection<BsonDocument>("itemy");

            var pridani15 = new BsonDocument
            {
                {"uzivatel",slovo5},
                {"uzivatelid",slovo1},
                {"item1",slovo4},
                {"item2",slovo4},
                {"item3",slovo4},
                {"item4",slovo4},
                {"item5",slovo4},
                {"item6",slovo4},
                {"item7",slovo4},
                {"item8",slovo4},
                {"item9",slovo4},
                {"item10",slovo4},
                {"item11",slovo4},
                {"item12",slovo4},
                {"item13",slovo4},
                {"item14",slovo4},
                {"item15",slovo4},
                {"item16",slovo4},
                {"item17",slovo4},
                {"item18",slovo4},
                {"item19",slovo4},
                {"item20",slovo4},
                {"item21",slovo4},
            };
            await coll15.InsertOneAsync(pridani15);
            var db158 = client.GetDatabase("dbl");
            var coll158 = db158.GetCollection<BsonDocument>("free");

            var pridani158 = new BsonDocument
            {
                {"uzivatel",slovo5},
                {"uzivatelid",slovo1},
                {"free1",slovo4},
                {"free2",slovo4},
                {"free3",slovo4},
                {"free4",slovo4},
                {"free5",slovo4},
                {"free6",slovo4},
                {"free7",slovo4},
                {"free8",slovo4},
                {"free9",slovo4},
                {"free10",slovo4},
                {"free11",slovo4},
                {"free12",slovo4},
                {"free13",slovo4},
                {"free14",slovo4},
                {"free15",slovo4},
                {"free16",slovo4},
                {"free17",slovo4},
                {"free18",slovo4},
                {"free19",slovo4},
                {"free20",slovo4},
                {"free21",slovo4},
                {"free22",slovo4},
                {"free23",slovo4},
                {"free24",slovo4},
                {"free25",slovo4},
                {"free26",slovo4},
                {"free27",slovo4},
                {"free28",slovo4},
                {"free29",slovo4},
                {"free30",slovo4},
                {"free31",slovo4},
                {"free32",slovo4},
                {"free33",slovo4},
                {"free34",slovo4},
                {"free35",slovo4},
                {"free36",slovo4},
                {"free37",slovo4},
                {"free38",slovo4},
                {"free39",slovo4},
                {"free40",slovo4},
                {"free41",slovo4},
                {"free42",slovo4},
                {"free43",slovo4},
                {"free44",slovo4},
                {"free45",slovo4},
                {"free46",slovo4},
                {"free47",slovo4},
                {"free48",slovo4},
                {"free49",slovo4},
                {"free50",slovo4},
            };
            await coll158.InsertOneAsync(pridani158);

            ITextChannel cons1 = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;
            await cons1.SendMessageAsync($"***registrovat*** {ruka}");
        }
    }
}

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

namespace MilošBot.Commands
{
    public class helpasdaost : ModuleBase
    {
        [Command("registrovat")]
        [Alias("reg", "dblekonomikaregistrace")]
        public async Task Mildosaggurus1()
        {
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "databáze");
            var ruka = Context.User as SocketGuildUser;

            if (ruka.Roles.Contains(role2))
            {
                await Context.Message.Channel.SendMessageAsync("Už si se asi registroval do ekonomiky, pokud ne kontaktuj qwer8, nebo ten dlabaja");
                return;
            }
            await ruka.AddRoleAsync(role2);

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Uzivatel\Dropbox\My PC (Počítač)\Desktop\milda\update 4\MilošBot\Databáze.mdf;Integrated Security=True";

            using (SqlConnection pripojeni = new SqlConnection(connectionString))
            {
                var src = DateTime.Now;
                pripojeni.Open();
                var slovo = Context.User.Id;
                string slovo1 = slovo.ToString();
                var slovo5 = Context.User.ToString();
                int slovo4 = 0;

                Console.WriteLine(slovo1);
                Console.WriteLine(src + "   Database connected");

                SqlCommand dotaz = new SqlCommand();
                dotaz.Connection = pripojeni;
                dotaz.CommandText = "INSERT INTO Kam (uzivatel, cum, uzivatelid, kreditka, cernaruka, padelanasmlouva, cervenetrenyrky, banka, zamestnanci, pracujicimigranti, zivnost, malafirma, strednemalafirma, nadnarodnispolecnost, korporace, akciovaspolecnost, velkafirma, vetsifirma, strednifirma, riditelezavoduvesvete, poradci, experti, mistri) VALUES (@slovo5,@slovo4, @slovo1, @slovo98, @slovo86, @slovo87,  @slovo89, @slovo81, @slovo91, @slovo92, @slovo93, @slovo94, @slovo95, @slovo59, @slovo58, @slovo57, @slovo56, @slovo55, @slovo54, @slovo53, @slovo52, @slovo51, @slovo50)";
                dotaz.Parameters.AddWithValue("@slovo5", slovo5);
                dotaz.Parameters.AddWithValue("@slovo1", slovo1);
                dotaz.Parameters.AddWithValue("@slovo4", slovo4);
                dotaz.Parameters.AddWithValue("@slovo98", slovo4);
                dotaz.Parameters.AddWithValue("@slovo86", slovo4);
                dotaz.Parameters.AddWithValue("@slovo87", slovo4);
                dotaz.Parameters.AddWithValue("@slovo89", slovo4);
                dotaz.Parameters.AddWithValue("@slovo81", slovo4);
                dotaz.Parameters.AddWithValue("@slovo91", slovo4);
                dotaz.Parameters.AddWithValue("@slovo92", slovo4);
                dotaz.Parameters.AddWithValue("@slovo93", slovo4);
                dotaz.Parameters.AddWithValue("@slovo94", slovo4);
                dotaz.Parameters.AddWithValue("@slovo95", slovo4);
                dotaz.Parameters.AddWithValue("@slovo50", slovo4);
                dotaz.Parameters.AddWithValue("@slovo51", slovo4);
                dotaz.Parameters.AddWithValue("@slovo52", slovo4);
                dotaz.Parameters.AddWithValue("@slovo53", slovo4);
                dotaz.Parameters.AddWithValue("@slovo54", slovo4);
                dotaz.Parameters.AddWithValue("@slovo55", slovo4);
                dotaz.Parameters.AddWithValue("@slovo56", slovo4);
                dotaz.Parameters.AddWithValue("@slovo57", slovo4);
                dotaz.Parameters.AddWithValue("@slovo58", slovo4);
                dotaz.Parameters.AddWithValue("@slovo59", slovo4);
                int radku = dotaz.ExecuteNonQuery();
                Console.WriteLine(radku);

                await Context.Channel.SendMessageAsync($"úspěšně si se registroval");
            }
        }
    }
}*/