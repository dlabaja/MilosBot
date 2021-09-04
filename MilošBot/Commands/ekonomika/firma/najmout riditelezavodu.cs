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
    public class NajmeRiditeleZavodu : ModuleBase<SocketCommandContext>
    {
        private const int cenaRZ = 30_000;

        [Command("najmout-riditelezavoduvesvete")]
        [Alias("riditelezavoduvesvete", "najmout-ri", "najmout-riditele")]
        [FormatSummary("Najme řiditele zavod za {0} peněz.", cenaRZ)]
        public async Task NajmeRiditeleZavoduAsync([Summary("Počet, nepovinný parametr."), Remainder] string count = null)
        {
            bool result = int.TryParse(count, out var i);

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

            if (ruka.Roles.Contains(role8) || ruka.Roles.Contains(role9) || ruka.Roles.Contains(role10))
            {
                Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");
                var najs = Context.User.Id.ToString();

                var client = new MongoClient("MongoDB connection string");
                var db = client.GetDatabase("dbl");
                var coll = db.GetCollection<Rootobject1>("ekonomika");

                var cisla = coll.Find(b => b.uzivatelid == najs).FirstAsync().Result;
                int uzivatel52 = cisla.zamestnanci;
                int uzivatel56 = cisla.pracujicimigranti;
                int uzivatel57 = cisla.mistri;
                int uzivatel5 = cisla.experti;
                int uzivatel571 = cisla.poradci;
                int uzivatel55 = cisla.riditelezavoduvesvete;
                int uzivatel = cisla.banka;

                int uzivatelx = uzivatel55 + i;

                int soucet = uzivatel5 + uzivatel55 + uzivatel56 + uzivatel57 + uzivatel52 + uzivatel571 + i;

                if (uzivatel55 >= 1 && ruka.Roles.Contains(role8) || uzivatelx > 1 && ruka.Roles.Contains(role8))
                {
                    await Context.Channel.SendMessageAsync("Maximální počet řiditelů závodů ve světě, které na této úrovni firmy můžeš zaměstnat je 1. Pro postup na úroveň [korporace] musíš mít 652   jakýchkoliv pracovníků");
                    return;
                }
                if (uzivatel55 >= 5 && ruka.Roles.Contains(role9) || uzivatelx > 5 && ruka.Roles.Contains(role9))
                {
                    await Context.Channel.SendMessageAsync("Maximální počet řiditelů závodů ve světě, které na této úrovni firmy můžeš zaměstnat je 5. Pro postup na úroveň [nadnarodnispolecnost] musíš mít 1584  jakýchkoliv pracovníků");
                    return;
                }
                if (uzivatel55 >= 15 && ruka.Roles.Contains(role10) || uzivatelx > 15 && ruka.Roles.Contains(role10))
                {
                    await Context.Channel.SendMessageAsync("Maximální počet řiditelů závodů ve světě, které na této úrovni firmy můžeš zaměstnat je 15.");
                    return;
                }

                int uzivatel2 = 0;
                int slovo6 = 0;
                int mezisoucet = i * cenaRZ;
                if (uzivatel >= cenaRZ && mezisoucet == 0)
                {
                    await Context.Channel.SendMessageAsync("právě jsi si najmul řiditele závodů ve světě, gratuluji");
                    goto label11;
                }
                if (uzivatel >= mezisoucet && mezisoucet > 0)
                {
                    await Context.Channel.SendMessageAsync("právě jsi si najmul najmul" + i + "řiditele závodů ve světě, gratuluji");
                    goto label12;
                }
                if (uzivatel <= (cenaRZ - 1) && i == 0 || i == 1)
                {
                    await Context.Channel.SendMessageAsync("nemáš dost peněz v bance na zaplacení najmul řiditele závodů ve světě, až našetříš 5 000 můžeš to zkusit znovu");
                    return;
                }
                if (uzivatel < mezisoucet)
                {
                    await Context.Channel.SendMessageAsync("nemáš dost peněz v bance na zaplacení " + i + " najmul řiditelů závodů ve světě, až našetříš " + mezisoucet + " můžeš to zkusit znovu");
                    return;
                }

                label11:
                uzivatel2 = uzivatel - cenaRZ;
                slovo6 = uzivatel55 + 1;
                goto label13;
                label12:
                uzivatel2 = uzivatel - mezisoucet;
                slovo6 = uzivatel55 + i;
                label13:
                var coll1 = db.GetCollection<BsonDocument>("ekonomika");
                var filter = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
                var update = Builders<BsonDocument>.Update.Set("banka", uzivatel2);
                var update1 = Builders<BsonDocument>.Update.Set("riditelezavoduvesvete", slovo6);

                coll1.UpdateOne(filter, update);
                coll1.UpdateOne(filter, update1);

                int slovo7 = 1;

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
                await cons.SendMessageAsync("najmout riditele " + i + " " + ruka);
            }
            else
            {
                await Context.Channel.SendMessageAsync("řiditele závodů ve světě můžeš najímat až od akciové společnosti");
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
    public class hesdsadsadsadasdast : ModuleBase<SocketCommandContext>
    {
        [Command("najmout-riditelezavoduvesvete")]
        [Alias("riditelezavoduvesvete", "najmout-ri", "najmout-riditele")]
        public async Task Mildosfdsadadseaggurus1()
        {
            var ruka = Context.User as SocketGuildUser;

            var role5 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "strednifirma");
            var role6 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "vetsifirma");
            var role7 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "velkafirma");
            var role8 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "akciovaspolecnost");
            var role9 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "korporace");
            var role10 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "nadnarodnispolecnost");

            if (ruka.Roles.Contains(role8) || ruka.Roles.Contains(role9) || ruka.Roles.Contains(role10))
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
                    int uzivatel571 = (int)dotaz17.ExecuteScalar();

                    SqlCommand dotaz171 = new SqlCommand();
                    dotaz171.Connection = pripojeni;
                    dotaz171.CommandText = @"SELECT poradci FROM dbo.Kam WHERE uzivatelid=@slovo1";
                    dotaz171.Parameters.AddWithValue("@slovo1", slovo1);
                    int uzivatel56 = (int)dotaz171.ExecuteScalar();

                    SqlCommand dotaz16 = new SqlCommand();
                    dotaz16.Connection = pripojeni;
                    dotaz16.CommandText = @"SELECT riditelezavoduvesvete FROM dbo.Kam WHERE uzivatelid=@slovo1";
                    dotaz16.Parameters.AddWithValue("@slovo1", slovo1);
                    int uzivatel55 = (int)dotaz16.ExecuteScalar();

                    int soucet = uzivatel5 + uzivatel55 + uzivatel56 + uzivatel57 + uzivatel52 + uzivatel571;

                    SqlCommand prikaz = new SqlCommand();

                    prikaz.Connection = pripojeni;
                    prikaz.CommandText = @"SELECT banka FROM dbo.Kam WHERE uzivatelid=@slovo1";
                    prikaz.Parameters.AddWithValue("@slovo1", slovo1);

                    int uzivatel = (int)prikaz.ExecuteScalar();

                    if (uzivatel55 >= 1 && ruka.Roles.Contains(role8))
                    {
                        await Context.Channel.SendMessageAsync("Maximální počet řiditelů závodů ve světě, které na této úrovni firmy můžeš zaměstnat je 1. Pro postup na úroveň [korporace] musíš mít 652   jakýchkoliv pracovníků");
                        return;
                    }
                    if (uzivatel55 >= 5 && ruka.Roles.Contains(role9))
                    {
                        await Context.Channel.SendMessageAsync("Maximální počet řiditelů závodů ve světě, které na této úrovni firmy můžeš zaměstnat je 5. Pro postup na úroveň [nadnarodnispolecnost] musíš mít 1584  jakýchkoliv pracovníků");
                        return;
                    }
                    if (uzivatel55 >= 15 && ruka.Roles.Contains(role10))
                    {
                        await Context.Channel.SendMessageAsync("Maximální počet řiditelů závodů ve světě, které na této úrovni firmy můžeš zaměstnat je 15.");
                        return;
                    }
                    if (uzivatel >= 30000)
                    {
                        await Context.Channel.SendMessageAsync("právě jsi si najmul řiditele závodu ve světě, gratuluji");
                        goto label11;
                    }
                    if (uzivatel <= 29999)
                    {
                        await Context.Channel.SendMessageAsync("nemáš dost peněz v bance na zaplacení řiditele závodu ve světě, až našetříš 30 000 můžeš to zkusit znovu");
                        return;
                    }

                label11:
                    int uzivatel2 = uzivatel - 25000;
                    int slovo6 = uzivatel55 + 1;

                    SqlCommand dotaz11 = new SqlCommand();
                    dotaz11.Connection = pripojeni;
                    dotaz11.CommandText = "UPDATE Kam SET banka=@slovo5, riditelezavoduvesvete=@slovo6 WHERE uzivatelid=@slovo1";
                    dotaz11.Parameters.AddWithValue("@slovo5", uzivatel2);
                    dotaz11.Parameters.AddWithValue("@slovo1", slovo1);
                    dotaz11.Parameters.AddWithValue("@slovo6", slovo6);
                    int radku = dotaz11.ExecuteNonQuery();

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
                    await cons.SendMessageAsync("najmout riditele " + ruka);
                }
            }
            else
            {
                await Context.Channel.SendMessageAsync("řiditele závodů ve světě můžeš najímat až od akciové společnosti");
            }
        }
    }
}*/