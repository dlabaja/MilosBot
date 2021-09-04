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
    public class KoupitKreditku : ModuleBase<SocketCommandContext>
    {
        private const int cena = 2_000;

        [Command("koupit-kreditku")]
        [Alias("koupit-kr", "buy-kr", "buy-kreditku", "1")]
        [FormatSummary("Koupí kreditku za {0} peněz.", cena)]
        public async Task KoupitKreditkuAsync()
        {
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "kreditka");
            var ruka = Context.User as SocketGuildUser;

            if (ruka.Roles.Contains(role2))
            {
                await Context.Message.Channel.SendMessageAsync("Už nejspíše vlastníš kreditku");
                return;
            }

            Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");

            var najs = Context.User.Id.ToString();

            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");
            var coll = db.GetCollection<Rootobject1>("ekonomika");

            var cisla = await coll.Find(b => b.uzivatelid == najs).FirstAsync();
            int uzivatel55 = cisla.kreditka;
            int uzivatel = cisla.cum;

            if (uzivatel55 == 1)
            {
                await Context.Channel.SendMessageAsync("už nejspíše vlastníš kreditku, ale někdo ti odebral roli, pro její navrácení napiš do #feedback děkuji");
                return;
            }

            if (uzivatel < cena)
            {
                await Context.Channel.SendMessageAsync("nemáš dost peněz ke koupi kreditky, až našetříš 2 000 můžeš to zkusit znovu");
                return;
            }
            await Context.Channel.SendMessageAsync("právě si jsi zakoupil kreditku, gratuluji");
            int uzivatel2 = uzivatel - cena;
            int slovo6 = 1;
            await ruka.AddRoleAsync(role2);

            var coll1 = db.GetCollection<BsonDocument>("ekonomika");

            var filter = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
            var update = Builders<BsonDocument>.Update.Set("cum", uzivatel2);
            var update1 = Builders<BsonDocument>.Update.Set("kreditka", slovo6);

            coll1.UpdateOne(filter, update);
            coll1.UpdateOne(filter, update1);

            var ovcak = new EmbedBuilder();
            ovcak.WithTitle($"Na ruce máš momentálně " + uzivatel2 + agr + " STORKSCOINS+vlastníš právě zakoupenou kreditku, která ti zrychlí vydělávání");
            await Context.Channel.SendMessageAsync(embed: ovcak.Build());

            //log
            ITextChannel cons = Context.Client.GetChannel(814954423972266024) as ITextChannel;
            await cons.SendMessageAsync("koupit kreditku " + ruka);
        }
    }
}/*

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
    public class helpasadaaost : ModuleBase<SocketCommandContext>
    {
        [Command("koupit-kreditku")]
        [Alias("koupit-kr", "buy-kr", "buy-kreditku")]
        public async Task Mildosfdseaggurus1()
        {
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "kreditka");
            var ruka = Context.User as SocketGuildUser;

            if (ruka.Roles.Contains(role2))
            {
                await Context.Message.Channel.SendMessageAsync("Už nejspíše vlastníš kreditku");
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
                dotaz.CommandText = @"SELECT kreditka FROM dbo.Kam WHERE uzivatelid=@slovo1";
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
                await Context.Channel.SendMessageAsync("už nejspíše vlastníš kreditku, ale někdo ti odebral roli, pro její navrácení napiš do #feedback děkuji");
                return;
            label22:

                int radku = dotaz.ExecuteNonQuery();

                SqlCommand prikaz = new SqlCommand();

                prikaz.Connection = pripojeni;
                prikaz.CommandText = @"SELECT cum FROM dbo.Kam WHERE uzivatelid=@slovo1";
                prikaz.Parameters.AddWithValue("@slovo1", slovo1);

                int uzivatel = (int)prikaz.ExecuteScalar();

                if (uzivatel >= 2000)
                {
                    await Context.Channel.SendMessageAsync("právě si jsi zakoupil kreditku, gratuluji");
                    goto label11;
                }
                if (uzivatel <= 1999)
                {
                    goto label12;
                }
            label11:
                int uzivatel2 = uzivatel - 2000;
                int slovo6 = 1;
                await ruka.AddRoleAsync(role2);
                goto label13;
            label12:
                await Context.Channel.SendMessageAsync("nemáš dost peněz ke koupi kreditky, až našetříš 2 000 můžeš to zkusit znovu");
                return;
            label13:
                SqlCommand dotaz1 = new SqlCommand();
                dotaz1.Connection = pripojeni;
                dotaz1.CommandText = "UPDATE Kam SET Cum=@slovo5, kreditka=@slovo6 WHERE uzivatelid=@slovo1";
                dotaz1.Parameters.AddWithValue("@slovo5", uzivatel2);
                dotaz1.Parameters.AddWithValue("@slovo1", slovo1);
                dotaz1.Parameters.AddWithValue("@slovo6", slovo6);
                int radku1 = dotaz1.ExecuteNonQuery();

                pripojeni.Close();

                var ovcak = new EmbedBuilder();
                ovcak.WithTitle($"Na ruce máš momentálně " + uzivatel2 + agr + " STORKSCOINS+vlastníš právě zakoupenou kreditku, která ti zrychlí vydělávání");
                await Context.Channel.SendMessageAsync("", false, ovcak.Build());

                //log
                ITextChannel cons = Context.Client.GetChannel(814954423972266024) as ITextChannel;
                await cons.SendMessageAsync("koupit kreditku " + ruka);
            }
        }
    }
}*/