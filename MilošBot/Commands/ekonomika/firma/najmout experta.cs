using Discord;
using Discord.Commands;
using Discord.WebSocket;
using MilošBot.Commands.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands.help
{
    public class NajmoutExperta : ModuleBase<SocketCommandContext>
    {
        private const int cenaExp = 20_000;

        [Command("najmout-experta")]
        [Alias("expert", "najmout-ex")]
        [FormatSummary("Najme experta za {0} peněz.", cenaExp)]
        public async Task NajmoutExpertaAsync([Summary("Počet, nepovinný parametr."), Remainder] string pocet = null)
        {
            bool result = int.TryParse(pocet, out var i);

            var ruka = Context.User as SocketGuildUser;

            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "malafirma");
            var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "zivnost");
            var role4 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "strednemalafirma");
            var role5 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "strednifirma");
            var role6 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "vetsifirma");
            var role7 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "velkafirma");
            var role8 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "akciovaspolecnost");
            var role9 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "korporace");
            var role10 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "nadnarodnispolecnost");

            if (ruka.Roles.Contains(role2) || ruka.Roles.Contains(role4) || ruka.Roles.Contains(role5) || ruka.Roles.Contains(role6) || ruka.Roles.Contains(role7) || ruka.Roles.Contains(role8) || ruka.Roles.Contains(role9) || ruka.Roles.Contains(role10))
            {
                Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");
                var najs = Context.User.Id.ToString();

                var client = new MongoClient("MongoDB connection string");
                var db = client.GetDatabase("dbl");
                var coll = db.GetCollection<Rootobject1>("ekonomika");

                var cisla = coll.Find(b => b.uzivatelid == najs).FirstAsync().Result;
                int uzivatel52 = cisla.zamestnanci;
                int uzivatel5 = cisla.pracujicimigranti;
                int uzivatel57 = cisla.mistri;
                int uzivatel55 = cisla.experti;
                int uzivatel571 = cisla.poradci;
                int uzivatel56 = cisla.riditelezavoduvesvete;
                int uzivatel = cisla.banka;

                int uzivatelx = uzivatel55 + i;

                int soucet = uzivatel5 + uzivatel55 + uzivatel56 + uzivatel57 + uzivatel52 + uzivatel571 + i;

                if (uzivatel55 >= 0 && ruka.Roles.Contains(role2) || uzivatelx > 0 && ruka.Roles.Contains(role2))
                {
                    await Context.Channel.SendMessageAsync("Maximální počet expertů  které na této úrovni firmy můžeš zaměstnat je 0. Pro postup na úroveň [středně malá firma] musíš mít 8 jakýchkoliv pracovníků");
                    return;
                }
                if (uzivatel55 >= 0 && ruka.Roles.Contains(role4) || uzivatelx > 0 && ruka.Roles.Contains(role4))
                {
                    await Context.Channel.SendMessageAsync("Maximální počet expertů které na této úrovni firmy můžeš zaměstnat je 0. Pro postup na úroveň [strednifirma] musíš mít 21 jakýchkoliv pracovníků");
                    return;
                }
                if (uzivatel55 >= 0 && ruka.Roles.Contains(role5) || uzivatelx > 0 && ruka.Roles.Contains(role5))
                {
                    await Context.Channel.SendMessageAsync("Maximální počet expertů které na této úrovni firmy můžeš zaměstnat je 0. Pro postup na úroveň [vetsifirma] musíš mít 32 jakýchkoliv pracovníků");
                    return;
                }
                if (uzivatel55 >= 3 && ruka.Roles.Contains(role6) || uzivatelx > 3 && ruka.Roles.Contains(role6))
                {
                    await Context.Channel.SendMessageAsync("Maximální počet expertů které na této úrovni firmy můžeš zaměstnat je 3. Pro postup na úroveň [velkafirma] musíš mít 106 jakýchkoliv pracovníků");
                    return;
                }
                if (uzivatel55 >= 8 && ruka.Roles.Contains(role7) || uzivatelx > 8 && ruka.Roles.Contains(role7))
                {
                    await Context.Channel.SendMessageAsync("Maximální počet expertů které na této úrovni firmy můžeš zaměstnat je 8. Pro postup na úroveň [akciovaspolecnost] musíš mít 206 jakýchkoliv pracovníků");
                    return;
                }
                if (uzivatel55 >= 10 && ruka.Roles.Contains(role8) || uzivatelx > 10 && ruka.Roles.Contains(role8))
                {
                    await Context.Channel.SendMessageAsync("Maximální počet expertů které na této úrovni firmy můžeš zaměstnat je 10. Pro postup na úroveň [korporace] musíš mít 652 jakýchkoliv pracovníků");
                    return;
                }
                if (uzivatel55 >= 50 && ruka.Roles.Contains(role9) || uzivatelx > 50 && ruka.Roles.Contains(role9))
                {
                    await Context.Channel.SendMessageAsync("Maximální počet expertů které na této úrovni firmy můžeš zaměstnat je 50. Pro postup na úroveň [nadnarodnispolecnost] musíš mít 1584 jakýchkoliv pracovníků");
                    return;
                }
                if (uzivatel55 >= 100 && ruka.Roles.Contains(role10) || uzivatelx > 100 && ruka.Roles.Contains(role10))
                {
                    await Context.Channel.SendMessageAsync("Maximální počet expertů které na této úrovni firmy můžeš zaměstnat je 100.");
                    return;
                }
                int uzivatel2 = 0;
                int slovo6 = 0;
                int mezisoucet = i * cenaExp;
                if (uzivatel >= cenaExp && mezisoucet == 0)
                {
                    await Context.Channel.SendMessageAsync("právě jsi si najmul experta, gratuluji");
                    goto label11;
                }
                if (uzivatel >= mezisoucet && mezisoucet > 0)
                {
                    await Context.Channel.SendMessageAsync("právě jsi si najmul experty, gratuluji");
                    goto label12;
                }
                if (uzivatel <= (cenaExp - 1) && i == 0 || i == 1)
                {
                    await Context.Channel.SendMessageAsync("nemáš dost peněz v bance na zaplacení migranta, až našetříš 20 000 můžeš to zkusit znovu");
                    return;
                }
                if (uzivatel < mezisoucet)
                {
                    await Context.Channel.SendMessageAsync("nemáš dost peněz v bance na zaplacení " + i + " migrantů, až našetříš " + mezisoucet + " můžeš to zkusit znovu");
                    return;
                }

                label11:
                uzivatel2 = uzivatel - cenaExp;  //doplnit do experta
                slovo6 = uzivatel55 + 1;
                goto label13;
                label12:
                uzivatel2 = uzivatel - mezisoucet;
                slovo6 = uzivatel55 + i;
                label13:
                var coll1 = db.GetCollection<BsonDocument>("ekonomika");
                var filter = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
                var update = Builders<BsonDocument>.Update.Set("banka", uzivatel2);
                var update1 = Builders<BsonDocument>.Update.Set("experti", slovo6);

                coll1.UpdateOne(filter, update);
                coll1.UpdateOne(filter, update1);

                int slovo7 = 1;

                if (soucet == 0 && soucet < 7 && ruka.Roles.Contains(role3))
                {
                    var coll11 = db.GetCollection<BsonDocument>("ekonomika");
                    var filter11 = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
                    var update12 = Builders<BsonDocument>.Update.Set("malafirma", slovo7);

                    coll11.UpdateOne(filter11, update12);

                    await ruka.AddRoleAsync(role2);
                    await ruka.RemoveRoleAsync(role3);
                    await Context.Channel.SendMessageAsync("Z tvé živnosti se právě stala malá firma");
                }
                if (soucet >= 7 && soucet < 20 && ruka.Roles.Contains(role2))
                {
                    await ruka.AddRoleAsync(role4);
                    await ruka.RemoveRoleAsync(role2);

                    var coll11 = db.GetCollection<BsonDocument>("ekonomika");
                    var filter11 = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
                    var update12 = Builders<BsonDocument>.Update.Set("strednemalafirma", slovo7);

                    coll11.UpdateOne(filter11, update12);
                    await Context.Channel.SendMessageAsync("Z tvé malé firmy se právě stala středně malá firma");
                }
                if (soucet >= 20 && soucet < 32 && ruka.Roles.Contains(role4))
                {
                    await ruka.AddRoleAsync(role5);
                    await ruka.RemoveRoleAsync(role4);

                    var coll11 = db.GetCollection<BsonDocument>("ekonomika");
                    var filter11 = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
                    var update12 = Builders<BsonDocument>.Update.Set("strednifirma", slovo7);

                    coll11.UpdateOne(filter11, update12);
                    await Context.Channel.SendMessageAsync("Z tvé středně malé firmy se právě stala střední firma");
                }
                if (soucet >= 32 && soucet < 106 && ruka.Roles.Contains(role5))
                {
                    await ruka.AddRoleAsync(role6);
                    await ruka.RemoveRoleAsync(role5);

                    var coll11 = db.GetCollection<BsonDocument>("ekonomika");
                    var filter11 = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
                    var update12 = Builders<BsonDocument>.Update.Set("vetsifirma", slovo7);

                    coll11.UpdateOne(filter11, update12);
                    await Context.Channel.SendMessageAsync("Z tvé střední firmy se právě stala větší firma");
                }
                if (soucet >= 106 && soucet < 206 && ruka.Roles.Contains(role6))
                {
                    await ruka.AddRoleAsync(role7);
                    await ruka.RemoveRoleAsync(role6);

                    var coll11 = db.GetCollection<BsonDocument>("ekonomika");
                    var filter11 = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
                    var update12 = Builders<BsonDocument>.Update.Set("velkafirma", slovo7);

                    coll11.UpdateOne(filter11, update12);
                    await Context.Channel.SendMessageAsync("Z tvé větší se právě stala velká firma");
                }
                if (soucet >= 206 && soucet < 652 && ruka.Roles.Contains(role7))
                {
                    await ruka.AddRoleAsync(role8);
                    await ruka.RemoveRoleAsync(role7);

                    var coll11 = db.GetCollection<BsonDocument>("ekonomika");
                    var filter11 = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
                    var update12 = Builders<BsonDocument>.Update.Set("akciovaspolecnost", slovo7);

                    coll11.UpdateOne(filter11, update12);
                    await Context.Channel.SendMessageAsync("Z tvé velké firmy se právě stala akciová společnost");
                }
                if (soucet >= 652 && soucet < 1584 && ruka.Roles.Contains(role8))
                {
                    await ruka.AddRoleAsync(role9);
                    await ruka.RemoveRoleAsync(role8);

                    var coll11 = db.GetCollection<BsonDocument>("ekonomika");
                    var filter11 = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
                    var update12 = Builders<BsonDocument>.Update.Set("korporace", slovo7);

                    coll11.UpdateOne(filter11, update12);
                    await Context.Channel.SendMessageAsync("Z tvé akciové společnosti se právě stala korporace");
                }
                if (soucet >= 1584 && ruka.Roles.Contains(role9))
                {
                    await ruka.AddRoleAsync(role10);
                    await ruka.RemoveRoleAsync(role9);

                    var coll11 = db.GetCollection<BsonDocument>("ekonomika");
                    var filter11 = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
                    var update12 = Builders<BsonDocument>.Update.Set("nadnarodnispolecnost", slovo7);

                    coll11.UpdateOne(filter11, update12);
                    await Context.Channel.SendMessageAsync("Z tvé korporace se právě stala nadnárodní společnost");
                }

                //log
                ITextChannel cons = Context.Client.GetChannel(814954423972266024) as ITextChannel;
                await cons.SendMessageAsync("najmout experta " + i + " " + ruka);
            }
            else
            {
                await Context.Channel.SendMessageAsync("Experty můžeš najímat až od větší firmy");
            }
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

namespace MilošBot.Commands.help
{
    public class hesdsadsadasdasdaaast : ModuleBase<SocketCommandContext>
    {
        [Command("najmout-experta")]
        [Alias("expert", "najmout-ex")]
        public async Task Mildosfdsadadseaggurus1()  //pridat kontrolu zivnosti
        {
            var ruka = Context.User as SocketGuildUser;

            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "malafirma");
            var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "zivnost");
            var role4 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "strednemalafirma");
            var role5 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "strednifirma");
            var role6 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "vetsifirma");
            var role7 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "velkafirma");
            var role8 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "akciovaspolecnost");
            var role9 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "korporace");
            var role10 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "nadnarodnispolecnost");

            if (ruka.Roles.Contains(role6) || ruka.Roles.Contains(role7) || ruka.Roles.Contains(role8) || ruka.Roles.Contains(role9) || ruka.Roles.Contains(role10))
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Uzivatel\Dropbox\My PC (Počítač)\Desktop\milda\update 4\MilošBot\Databáze.mdf;Integrated Security=True";
                using (SqlConnection pripojeni = new SqlConnection(connectionString))
                {
                    Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");
                    pripojeni.Open();
                    var slovo = Context.User.Id;
                    string slovo1 = slovo.ToString();

                    SqlCommand dotaz = new SqlCommand();
                    dotaz.Connection = pripojeni;
                    dotaz.CommandText = @"SELECT zamestnanci FROM dbo.Kam WHERE uzivatelid=@slovo1";
                    dotaz.Parameters.AddWithValue("@slovo1", slovo1);
                    int uzivatel52 = (int)dotaz.ExecuteScalar();

                    SqlCommand dotaz1 = new SqlCommand();
                    dotaz1.Connection = pripojeni;
                    dotaz1.CommandText = @"SELECT pracujicimigranti FROM dbo.Kam WHERE uzivatelid=@slovo1";
                    dotaz1.Parameters.AddWithValue("@slovo1", slovo1);
                    int uzivatel5 = (int)dotaz1.ExecuteScalar();

                    SqlCommand dotaz12 = new SqlCommand();
                    dotaz12.Connection = pripojeni;
                    dotaz12.CommandText = @"SELECT mistri FROM dbo.Kam WHERE uzivatelid=@slovo1";
                    dotaz12.Parameters.AddWithValue("@slovo1", slovo1);
                    int uzivatel57 = (int)dotaz12.ExecuteScalar();

                    SqlCommand dotaz17 = new SqlCommand();
                    dotaz17.Connection = pripojeni;
                    dotaz17.CommandText = @"SELECT experti FROM dbo.Kam WHERE uzivatelid=@slovo1";
                    dotaz17.Parameters.AddWithValue("@slovo1", slovo1);
                    int uzivatel55 = (int)dotaz17.ExecuteScalar();

                    SqlCommand dotaz171 = new SqlCommand();
                    dotaz171.Connection = pripojeni;
                    dotaz171.CommandText = @"SELECT poradci FROM dbo.Kam WHERE uzivatelid=@slovo1";
                    dotaz171.Parameters.AddWithValue("@slovo1", slovo1);
                    int uzivatel571 = (int)dotaz171.ExecuteScalar();

                    SqlCommand dotaz16 = new SqlCommand();
                    dotaz16.Connection = pripojeni;
                    dotaz16.CommandText = @"SELECT riditelezavoduvesvete FROM dbo.Kam WHERE uzivatelid=@slovo1";
                    dotaz16.Parameters.AddWithValue("@slovo1", slovo1);
                    int uzivatel56 = (int)dotaz16.ExecuteScalar();

                    int soucet = uzivatel5 + uzivatel55 + uzivatel56 + uzivatel57 + uzivatel52 + uzivatel571;

                    SqlCommand prikaz = new SqlCommand();

                    prikaz.Connection = pripojeni;
                    prikaz.CommandText = @"SELECT banka FROM dbo.Kam WHERE uzivatelid=@slovo1";
                    prikaz.Parameters.AddWithValue("@slovo1", slovo1);

                    int uzivatel = (int)prikaz.ExecuteScalar();

                    if (uzivatel55 >= 0 && ruka.Roles.Contains(role2))
                    {
                        await Context.Channel.SendMessageAsync("Maximální počet expertů  které na této úrovni firmy můžeš zaměstnat je 0. Pro postup na úroveň [středně malá firma] musíš mít 8 jakýchkoliv pracovníků");
                        return;
                    }
                    if (uzivatel55 >= 0 && ruka.Roles.Contains(role4))
                    {
                        await Context.Channel.SendMessageAsync("Maximální počet expertů které na této úrovni firmy můžeš zaměstnat je 0. Pro postup na úroveň [strednifirma] musíš mít 21 jakýchkoliv pracovníků");
                        return;
                    }
                    if (uzivatel55 >= 0 && ruka.Roles.Contains(role5))
                    {
                        await Context.Channel.SendMessageAsync("Maximální počet expertů které na této úrovni firmy můžeš zaměstnat je 0. Pro postup na úroveň [vetsifirma] musíš mít 32 jakýchkoliv pracovníků");
                        return;
                    }
                    if (uzivatel55 >= 3 && ruka.Roles.Contains(role6))
                    {
                        await Context.Channel.SendMessageAsync("Maximální počet expertů které na této úrovni firmy můžeš zaměstnat je 3. Pro postup na úroveň [velkafirma] musíš mít 106 jakýchkoliv pracovníků");
                        return;
                    }
                    if (uzivatel55 >= 8 && ruka.Roles.Contains(role7))
                    {
                        await Context.Channel.SendMessageAsync("Maximální počet expertů které na této úrovni firmy můžeš zaměstnat je 8. Pro postup na úroveň [akciovaspolecnost] musíš mít 206 jakýchkoliv pracovníků");
                        return;
                    }
                    if (uzivatel55 >= 10 && ruka.Roles.Contains(role8))
                    {
                        await Context.Channel.SendMessageAsync("Maximální počet expertů které na této úrovni firmy můžeš zaměstnat je 10. Pro postup na úroveň [korporace] musíš mít 652 jakýchkoliv pracovníků");
                        return;
                    }
                    if (uzivatel55 >= 50 && ruka.Roles.Contains(role9))
                    {
                        await Context.Channel.SendMessageAsync("Maximální počet expertů které na této úrovni firmy můžeš zaměstnat je 50. Pro postup na úroveň [nadnarodnispolecnost] musíš mít 1584 jakýchkoliv pracovníků");
                        return;
                    }
                    if (uzivatel55 >= 100 && ruka.Roles.Contains(role10))
                    {
                        await Context.Channel.SendMessageAsync("Maximální počet expertů které na této úrovni firmy můžeš zaměstnat je 100.");
                        return;
                    }
                    if (uzivatel >= 20000)
                    {
                        await Context.Channel.SendMessageAsync("právě jsi si najmul experta, gratuluji");
                        goto label11;
                    }
                    if (uzivatel <= 19999)
                    {
                        await Context.Channel.SendMessageAsync("nemáš dost peněz v bance na zaplacení experta, až našetříš 20 000 můžeš to zkusit znovu");
                        return;
                    }

                label11:
                    int uzivatel2 = uzivatel - 20000;
                    int slovo6 = uzivatel55 + 1;

                    SqlCommand dotaz11 = new SqlCommand();
                    dotaz11.Connection = pripojeni;
                    dotaz11.CommandText = "UPDATE Kam SET banka=@slovo5, experti=@slovo6 WHERE uzivatelid=@slovo1";
                    dotaz11.Parameters.AddWithValue("@slovo5", uzivatel2);
                    dotaz11.Parameters.AddWithValue("@slovo1", slovo1);
                    dotaz11.Parameters.AddWithValue("@slovo6", slovo6);
                    int radku = dotaz11.ExecuteNonQuery();

                    if (soucet == 0 && radku == 1)
                    {
                        await ruka.AddRoleAsync(role2);
                        await ruka.RemoveRoleAsync(role3);
                        int slovo7 = 1;
                        SqlCommand dotaz111 = new SqlCommand();
                        dotaz111.Connection = pripojeni;
                        dotaz111.CommandText = "UPDATE Kam SET malafirma=@slovo6 WHERE uzivatelid=@slovo1";
                        dotaz111.Parameters.AddWithValue("@slovo1", slovo1);
                        dotaz111.Parameters.AddWithValue("@slovo6", slovo7);
                        int radku1 = dotaz111.ExecuteNonQuery();
                        await Context.Channel.SendMessageAsync("Z tvé živnosti se právě stala malá firma");
                    }
                    if (soucet == 7 && radku == 1)
                    {
                        await ruka.AddRoleAsync(role4);
                        await ruka.RemoveRoleAsync(role2);
                        int slovo7 = 1;
                        SqlCommand dotaz111 = new SqlCommand();
                        dotaz111.Connection = pripojeni;
                        dotaz111.CommandText = "UPDATE Kam SET strednemalafirma=@slovo6 WHERE uzivatelid=@slovo1";
                        dotaz111.Parameters.AddWithValue("@slovo1", slovo1);
                        dotaz111.Parameters.AddWithValue("@slovo6", slovo7);
                        int radku1 = dotaz111.ExecuteNonQuery();
                        await Context.Channel.SendMessageAsync("Z tvé malé firmy se právě stala středně malá firma");
                    }
                    if (soucet == 20 && radku == 1)
                    {
                        await ruka.AddRoleAsync(role5);
                        await ruka.RemoveRoleAsync(role4);
                        int slovo7 = 1;
                        SqlCommand dotaz111 = new SqlCommand();
                        dotaz111.Connection = pripojeni;
                        dotaz111.CommandText = "UPDATE Kam SET strednifirma=@slovo6 WHERE uzivatelid=@slovo1";
                        dotaz111.Parameters.AddWithValue("@slovo1", slovo1);
                        dotaz111.Parameters.AddWithValue("@slovo6", slovo7);
                        int radku1 = dotaz111.ExecuteNonQuery();
                        await Context.Channel.SendMessageAsync("Z tvé středně malé firmy se právě stala střední firma");
                    }
                    if (soucet == 32 && radku == 1)
                    {
                        await ruka.AddRoleAsync(role6);
                        await ruka.RemoveRoleAsync(role5);
                        int slovo7 = 1;
                        SqlCommand dotaz111 = new SqlCommand();
                        dotaz111.Connection = pripojeni;
                        dotaz111.CommandText = "UPDATE Kam SET vetsifirma=@slovo6 WHERE uzivatelid=@slovo1";
                        dotaz111.Parameters.AddWithValue("@slovo1", slovo1);
                        dotaz111.Parameters.AddWithValue("@slovo6", slovo7);
                        int radku1 = dotaz111.ExecuteNonQuery();
                        await Context.Channel.SendMessageAsync("Z tvé střední firmy se právě stala větší firma");
                    }
                    if (soucet == 106 && radku == 1)
                    {
                        await ruka.AddRoleAsync(role7);
                        await ruka.RemoveRoleAsync(role6);
                        int slovo7 = 1;
                        SqlCommand dotaz111 = new SqlCommand();
                        dotaz111.Connection = pripojeni;
                        dotaz111.CommandText = "UPDATE Kam SET velkafirma=@slovo6 WHERE uzivatelid=@slovo1";
                        dotaz111.Parameters.AddWithValue("@slovo1", slovo1);
                        dotaz111.Parameters.AddWithValue("@slovo6", slovo7);
                        int radku1 = dotaz111.ExecuteNonQuery();
                        await Context.Channel.SendMessageAsync("Z tvé větší se právě stala velká firma");
                    }
                    if (soucet == 206 && radku == 1)
                    {
                        await ruka.AddRoleAsync(role8);
                        await ruka.RemoveRoleAsync(role7);
                        int slovo7 = 1;
                        SqlCommand dotaz111 = new SqlCommand();
                        dotaz111.Connection = pripojeni;
                        dotaz111.CommandText = "UPDATE Kam SET akciovaspolecnost=@slovo6 WHERE uzivatelid=@slovo1";
                        dotaz111.Parameters.AddWithValue("@slovo1", slovo1);
                        dotaz111.Parameters.AddWithValue("@slovo6", slovo7);
                        int radku1 = dotaz111.ExecuteNonQuery();
                        await Context.Channel.SendMessageAsync("Z tvé velké firmy se právě stala akciová společnost");
                    }
                    if (soucet == 652 && radku == 1)
                    {
                        await ruka.AddRoleAsync(role9);
                        await ruka.RemoveRoleAsync(role8);
                        int slovo7 = 1;
                        SqlCommand dotaz111 = new SqlCommand();
                        dotaz111.Connection = pripojeni;
                        dotaz111.CommandText = "UPDATE Kam SET korporace=@slovo6 WHERE uzivatelid=@slovo1";
                        dotaz111.Parameters.AddWithValue("@slovo1", slovo1);
                        dotaz111.Parameters.AddWithValue("@slovo6", slovo7);
                        int radku1 = dotaz111.ExecuteNonQuery();
                        await Context.Channel.SendMessageAsync("Z tvé akciové společnosti se právě stala korporace");
                    }
                    if (soucet == 1584 && radku == 1)
                    {
                        await ruka.AddRoleAsync(role10);
                        await ruka.RemoveRoleAsync(role9);
                        int slovo7 = 1;
                        SqlCommand dotaz111 = new SqlCommand();
                        dotaz111.Connection = pripojeni;
                        dotaz111.CommandText = "UPDATE Kam SET nadnarodnispolecnost=@slovo6 WHERE uzivatelid=@slovo1";
                        dotaz111.Parameters.AddWithValue("@slovo1", slovo1);
                        dotaz111.Parameters.AddWithValue("@slovo6", slovo7);
                        int radku1 = dotaz111.ExecuteNonQuery();
                        await Context.Channel.SendMessageAsync("Z tvé korporace se právě stala nadnárodní společnost");
                    }
                    //log
                    ITextChannel cons = Context.Client.GetChannel(814954423972266024) as ITextChannel;
                    await cons.SendMessageAsync("najmout experta " + ruka);
                }
            }
            else
            {
                await Context.Channel.SendMessageAsync("Experty můžeš najímat až od větší firmy");
            }
        }
    }
}*/