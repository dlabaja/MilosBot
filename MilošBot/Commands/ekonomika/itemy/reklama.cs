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
    public class helgpaaaost : ModuleBase<SocketCommandContext>
    {
        private const int cena = 30_000;

        [Command("pristupdoreklam")]
        [Alias("4")]
        [FormatSummary("Koupí přístup do reklam za {0} peněz.", cena)]
        public async Task Mildosfdseaggurus1()
        {
            var najs = Context.User.Id.ToString();

            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "reklama");
            var ruka = Context.User as SocketGuildUser;

            if (ruka.Roles.Contains(role2))
            {
                await Context.Message.Channel.SendMessageAsync("Už nejspíše můžeš psát do reklam");
                return;
            }

            Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");

            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");

            var coll = db.GetCollection<Rootobject1>("itemy");
            var cisla = coll.Find(b => b.uzivatelid == najs).FirstAsync().Result;
            int uzivatel55 = cisla.item2;

            var coll5 = db.GetCollection<Rootobject1>("ekonomika");
            var cisla5 = coll5.Find(b => b.uzivatelid == najs).FirstAsync().Result;
            int penizeBanka = cisla5.banka;

            if (uzivatel55 == 1)
            {
                await Context.Channel.SendMessageAsync("už nejspíše vlastníš přístup do reklam, ale někdo ti odebral roli, pro její navrácení napiš do #feedback děkuji");
                return;
            }
            if (penizeBanka < cena)
            {
                await Context.Channel.SendMessageAsync("nemáš dost peněz ke koupi reklamy, až našetříš 30 000 můžeš to zkusit znovu");
                return;
            }
            await Context.Channel.SendMessageAsync("právě si jsi zakoupil přístup do reklam, gratuluji");
            int uzivatel2 = penizeBanka - cena;
            int slovo6 = 1;
            await ruka.AddRoleAsync(role2);

            var coll1 = db.GetCollection<BsonDocument>("ekonomika");

            var coll15 = db.GetCollection<BsonDocument>("ekonomika");

            var filter = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
            var update = Builders<BsonDocument>.Update.Set("banka", uzivatel2);

            var filter5 = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
            var update1 = Builders<BsonDocument>.Update.Set("item2", slovo6);

            coll1.UpdateOne(filter, update);
            coll15.UpdateOne(filter5, update1);

            var ovcak = new EmbedBuilder();
            ovcak.WithTitle($"V bance máš momentálně " + uzivatel2 + agr + " STORKSCOINS+vlastníš právě zakoupený přístup do reklam, kde....");
            await Context.Channel.SendMessageAsync(embed: ovcak.Build());

            //log
            ITextChannel cons = Context.Client.GetChannel(814954423972266024) as ITextChannel;
            await cons.SendMessageAsync("koupit REKLAMU " + ruka);
        }
    }
}

/*
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

namespace MilošBot.Commands.help
{
    public class helpaaaost : ModuleBase<SocketCommandContext>
    {
        [Command("spálit-trenky")]
        [Alias("koupit-tr", "buy-tr", "buy-trenky")]
        public async Task Mildosfdseaggurus1()
        {
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "trenky");
            var ruka = Context.User as SocketGuildUser;

            if (ruka.Roles.Contains(role2))
            {
                await Context.Message.Channel.SendMessageAsync("Už nejspíše popel z červených trenek");
                return;
            }

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Uzivatel\Dropbox\My PC (Počítač)\Desktop\milda\update 4\MilošBot\Databáze.mdf;Integrated Security=True";

            using (SqlConnection pripojeni = new SqlConnection(connectionString))
            {
                Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");
                var src = DateTime.Now;
                pripojeni.Open();
                var slovo = Context.User.Id;
                string slovo1 = slovo.ToString();

                SqlCommand dotaz = new SqlCommand();
                dotaz.Connection = pripojeni;
                dotaz.CommandText = @"SELECT cervenetrenyrky FROM dbo.Kam WHERE uzivatelid=@slovo1";
                dotaz.Parameters.AddWithValue("@slovo1", slovo1);
                int uzivatel55 = (int)dotaz.ExecuteScalar();

                if (uzivatel55 == 0)
                {
                    goto label22;
                }
                if (uzivatel55 == 1)
                {
                    goto label21;
                }

            label21:
                await Context.Channel.SendMessageAsync("už nejspíše vlastníš spálené červené trenky, ale někdo ti odebral roli, pro její navrácení napiš do #feedback děkuji");
                return;
            label22:

                int radku = dotaz.ExecuteNonQuery();

                SqlCommand prikaz = new SqlCommand();

                prikaz.Connection = pripojeni;
                prikaz.CommandText = @"SELECT banka FROM dbo.Kam WHERE uzivatelid=@slovo1";
                prikaz.Parameters.AddWithValue("@slovo1", slovo1);

                int uzivatel = (int)prikaz.ExecuteScalar();

                if (uzivatel >= 20000)
                {
                    await Context.Channel.SendMessageAsync("právě si jsi zakoupil trenýrky ke spálení, gratuluji");
                    goto label11;
                }
                if (uzivatel <= 19999)
                {
                    goto label12;
                }
            label11:
                int uzivatel2 = uzivatel - 20000;
                int slovo6 = 1;
                await ruka.AddRoleAsync(role2);
                goto label13;
            label12:
                await Context.Channel.SendMessageAsync("nemáš dost peněz ke koupi trenek, až našetříš 20 000 můžeš to zkusit znovu");
                return;
            label13:
                SqlCommand dotaz1 = new SqlCommand();
                dotaz1.Connection = pripojeni;
                dotaz1.CommandText = "UPDATE Kam SET banka=@slovo5, cervenetrenyrky=@slovo6 WHERE uzivatelid=@slovo1";
                dotaz1.Parameters.AddWithValue("@slovo5", uzivatel2);
                dotaz1.Parameters.AddWithValue("@slovo1", slovo1);
                dotaz1.Parameters.AddWithValue("@slovo6", slovo6);
                int radku1 = dotaz1.ExecuteNonQuery();

                pripojeni.Close();

                var ovcak = new EmbedBuilder();
                ovcak.WithTitle($"V bance máš momentálně " + uzivatel2 + agr + " STORKSCOINS+vlastníš právě zakoupené trenky k maskonání při tvích loupežích, které od teď můžes provádět");
                await Context.Channel.SendMessageAsync("", false, ovcak.Build());

                //log
                ITextChannel cons = Context.Client.GetChannel(814954423972266024) as ITextChannel;
                await cons.SendMessageAsync("koupit trenky " + ruka);
            }
        }
    }
}*/