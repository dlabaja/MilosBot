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
    public class PadelanouSmlouvu : ModuleBase<SocketCommandContext>
    {
        private const int cena = 20_000;

        [Command("padelat-smlouvu")]
        [Alias("koupit-smlouvu", "buy-smlouvu", "buy-sm", "koupit-sm", "2")]
        [FormatSummary("Koupí padělanou smlouvu za {0} peněz.", cena)]
        public async Task KoupitPadelanouSmlouvuAsync()
        {
            var najs = Context.User.Id.ToString();

            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "padelanasmlouva");
            var ruka = Context.User as SocketGuildUser;

            if (ruka.Roles.Contains(role2))
            {
                await Context.Message.Channel.SendMessageAsync("Už nejspíše vlastníš padělanou smlouvu.");
                return;
            }
            Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");

            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");
            var coll = db.GetCollection<Rootobject1>("ekonomika");

            var cisla = coll.Find(b => b.uzivatelid == najs).FirstAsync().Result;
            int uzivatel55 = cisla.padelanasmlouva;
            int penizeCernaRuka = cisla.cernaruka;

            if (uzivatel55 == 1)
            {
                await Context.Channel.SendMessageAsync("Už nejspíše vlastníš padelanousmlouvu, ale někdo ti odebral roli, pro její navrácení napiš do #feedback děkuji.");
                return;
            }

            if (penizeCernaRuka < cena)
            {
                await Context.Channel.SendMessageAsync("nemáš dost peněz ke koupi padelanésmlouvy, až našetříš 20 000 můžeš to zkusit znovu");
                return;
            }
            await Context.Channel.SendMessageAsync("právě si jsi zakoupil padelanousmlouvu, gratuluji");
            int uzivatel2 = penizeCernaRuka - cena;
            int slovo6 = 1;
            await ruka.AddRoleAsync(role2);

            var coll1 = db.GetCollection<BsonDocument>("ekonomika");

            var filter = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
            var update = Builders<BsonDocument>.Update.Set("cernaruka", uzivatel2);
            var update1 = Builders<BsonDocument>.Update.Set("padelanasmlouva", slovo6);

            coll1.UpdateOne(filter, update);
            coll1.UpdateOne(filter, update1);

            var ovcak = new EmbedBuilder();
            ovcak.WithTitle($"Na černé ruce máš momentálně " + uzivatel2 + agr + " STORKSCOINS+vlastníš právě zakoupenou padelanousmlouvu, která ti zrychlí vydělávání");
            await Context.Channel.SendMessageAsync("", false, ovcak.Build());

            //log
            ITextChannel cons = Context.Client.GetChannel(814954423972266024) as ITextChannel;
            await cons.SendMessageAsync("padelat smlouvu " + ruka);
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
    public class helpoaaast : ModuleBase<SocketCommandContext>
    {
        [Command("padelat-smlouvu")]
        [Alias("koupit-smlouvu", "buy-smlouvu", "buy-sm", "koupit-sm")]
        public async Task Mildosfdsadadseaggurus1()
        {
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "padelanasmlouva");
            var ruka = Context.User as SocketGuildUser;

            if (ruka.Roles.Contains(role2))
            {
                await Context.Message.Channel.SendMessageAsync("Už nejspíše vlastníš padělanou smlouvu.");
                return;
            }

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Uzivatel\Dropbox\My PC (Počítač)\Desktop\milda\update 4\MilošBot\Databáze.mdf;Integrated Security=True";

            using (SqlConnection pripojeni = new SqlConnection(connectionString))
            {
                Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");
                pripojeni.Open();
                var slovo = Context.User.Id;
                string slovo1 = slovo.ToString();

                SqlCommand dotaz = new SqlCommand();
                dotaz.Connection = pripojeni;
                dotaz.CommandText = @"SELECT padelanasmlouva FROM dbo.Kam WHERE uzivatelid=@slovo1";
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
                await Context.Channel.SendMessageAsync("Už nejspíše vlastníš padelanousmlouvu, ale někdo ti odebral roli, pro její navrácení napiš do #feedback děkuji.");
                return;
            label22:

                SqlCommand prikaz = new SqlCommand();

                prikaz.Connection = pripojeni;
                prikaz.CommandText = @"SELECT cernaruka FROM dbo.Kam WHERE uzivatelid=@slovo1";
                prikaz.Parameters.AddWithValue("@slovo1", slovo1);

                int uzivatel = (int)prikaz.ExecuteScalar();

                if (uzivatel >= 20000)
                {
                    await Context.Channel.SendMessageAsync("právě si jsi zakoupil padelanousmlouvu, gratuluji");
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
                await Context.Channel.SendMessageAsync("nemáš dost peněz ke koupi padelanésmlouvy, až našetříš 20 000 můžeš to zkusit znovu");
                return;
            label13:
                SqlCommand dotaz1 = new SqlCommand();
                dotaz1.Connection = pripojeni;
                dotaz1.CommandText = "UPDATE Kam SET cernaruka=@slovo5, padelanasmlouva=@slovo6 WHERE uzivatelid=@slovo1";
                dotaz1.Parameters.AddWithValue("@slovo5", uzivatel2);
                dotaz1.Parameters.AddWithValue("@slovo1", slovo1);
                dotaz1.Parameters.AddWithValue("@slovo6", slovo6);

                int radku1 = dotaz1.ExecuteNonQuery();
                pripojeni.Close();

                var ovcak = new EmbedBuilder();
                ovcak.WithTitle($"Na ruce máš momentálně " + uzivatel2 + agr + " STORKSCOINS+vlastníš právě zakoupenou padelanousmlouvu, která ti zrychlí vydělávání");
                await Context.Channel.SendMessageAsync("", false, ovcak.Build());

                //log
                ITextChannel cons = Context.Client.GetChannel(814954423972266024) as ITextChannel;
                await cons.SendMessageAsync("padelat smlouvu " + ruka);
            }
        }
    }
}*/