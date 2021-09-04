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
    public class ZalozitZivnost : ModuleBase<SocketCommandContext>
    {
        private const int cenaZiv = 20_000;

        [Command("zalozit-zivnost")]
        [Alias("zivnost", "zalozit-ziv")]
        [FormatSummary("Založí živnost za {0} peněz.", cenaZiv)]
        public async Task ZalozitZivnostAsync()
        {
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "zivnost");
            var ruka = Context.User as SocketGuildUser;

            //log
            ITextChannel cons = Context.Client.GetChannel(814954423972266024) as ITextChannel;
            await cons.SendMessageAsync("**zalozit zivnost ** " + ruka);

            if (ruka.Roles.Contains(role2))
            {
                await Context.Message.Channel.SendMessageAsync("Už nejspíše vlastníš živnost (můžeš vlasnit pouze jednu živnost)");
                return;
            }

            Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");
            var najs = Context.User.Id.ToString();

            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");
            var coll = db.GetCollection<Rootobject1>("ekonomika");

            var cisla = coll.Find(b => b.uzivatelid == najs).FirstAsync().Result;
            int zivnost1 = cisla.zivnost;
            int penizeBanka = cisla.banka;

            if (zivnost1 == 1)
            {
                await Context.Channel.SendMessageAsync("Už nejspíše vlastníš živnost, ale už jsi na vašší úrovni, nebo ti někdo odebral roli, pro její navrácení napiš do #feedback děkuji.");
                return;
            }

            if (penizeBanka < cenaZiv)
            {
                await Context.Channel.SendMessageAsync("Nemáš dost peněz ke koupi licence k živnosti, až našetříš 20 000 můžeš to zkusit znovu.");
                return;
            }
            await Context.Channel.SendMessageAsync("Právě jsi si založil živnost, gratuluji, dalším stupněm je malá firma, která se z tebe stane přijetím prvního zaměstnance.");

            int uzivatel2 = penizeBanka - cenaZiv;
            int slovo6 = 1;
            await ruka.AddRoleAsync(role2);
            Console.WriteLine(uzivatel2);

            var coll1 = db.GetCollection<BsonDocument>("ekonomika");
            var filter = Builders<BsonDocument>.Filter.Eq("uzivatelid", najs);
            var update = Builders<BsonDocument>.Update.Set("banka", uzivatel2);
            var update1 = Builders<BsonDocument>.Update.Set("zivnost", slovo6);

            coll1.UpdateOne(filter, update);
            coll1.UpdateOne(filter, update1);
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
    public class helpaaaaost : ModuleBase<SocketCommandContext>
    {
        public class helpaaaost : ModuleBase<SocketCommandContext>
        {
            [Command("zalozit-zivnost")]
            [Alias("zivnost", "zalozit-ziv")]
            public async Task Mildosfdseaggurus1()
            {
                var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "zivnost");
                var ruka = Context.User as SocketGuildUser;

                if (ruka.Roles.Contains(role2))
                {
                    await Context.Message.Channel.SendMessageAsync("Už nejspíše vlastníš živnost (můžeš vlasnit pouze jednu živnost)");
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
                    dotaz.CommandText = @"SELECT zivnost FROM dbo.Kam WHERE uzivatelid=@slovo1";
                    dotaz.Parameters.AddWithValue("@slovo1", slovo1);
                    int uzivatel55 = (int)dotaz.ExecuteScalar();

                    if (uzivatel55 == 0)
                    {
                        goto label22;
                    }
                    if (uzivatel55 == 1)
                    {
                        await Context.Channel.SendMessageAsync("už nejspíše vlastníš živnost, ale někdo ti odebral roli, pro její navrácení napiš do #feedback děkuji");
                        return;
                    }

                label22:
                    SqlCommand prikaz = new SqlCommand();
                    prikaz.Connection = pripojeni;
                    prikaz.CommandText = @"SELECT banka FROM dbo.Kam WHERE uzivatelid=@slovo1";
                    prikaz.Parameters.AddWithValue("@slovo1", slovo1);
                    int uzivatel = (int)prikaz.ExecuteScalar();
                    pripojeni.Close();

                    if (uzivatel >= 20000)
                    {
                        await Context.Channel.SendMessageAsync("právě jsi si založil živnost, gratuluji, dalším stupněm je malá firma, která se z tebe stane přijetím prvního zaměstnance");
                        goto label11;
                    }
                    if (uzivatel <= 19999)
                    {
                        await Context.Channel.SendMessageAsync("nemáš dost peněz ke koupi licence k živnosti, až našetříš 20 000 můžeš to zkusit znovu");
                        return;
                    }
                label11:
                    int uzivatel2 = uzivatel - 20000;
                    int slovo6 = 1;
                    await ruka.AddRoleAsync(role2);
                    Console.WriteLine(uzivatel2);

                    SqlCommand dotaz51 = new SqlCommand();
                    dotaz51.Connection = pripojeni;
                    pripojeni.Open();
                    dotaz51.CommandText = "UPDATE Kam SET banka=@slovo5, zivnost=@slovo6 WHERE uzivatelid=@slovo1";
                    dotaz51.Parameters.AddWithValue("@slovo5", uzivatel2);
                    dotaz51.Parameters.AddWithValue("@slovo6", slovo6);
                    dotaz51.Parameters.AddWithValue("@slovo1", slovo1);
                    int radku1 = dotaz51.ExecuteNonQuery();

                    Console.WriteLine(radku1);
                    pripojeni.Close();
                }
            }
        }
    }
}*/