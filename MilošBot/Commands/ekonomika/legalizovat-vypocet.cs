using Discord;
using Discord.Commands;
using Discord.WebSocket;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands.help
{
    public class hejkklpost : ModuleBase<SocketCommandContext>
    {
        [Command("legalizovat-výpočet1")]
        [Alias("legálně-vyp", "legalizovat-v")]
        [Summary("Zobrazí procenta peněz pro legalizování.")]
        public async Task LegalizovatVypAsync([Remainder][Summary("nepovinná parametr, slouží k zištění konkrétních procent")] int i = 0)
        {
            //log
            var ruka = Context.User as SocketGuildUser;
            ITextChannel cons = Context.Client.GetChannel(DChannelId.ekonomikalog) as ITextChannel;
            await cons.SendMessageAsync($"lagalizovat-výpočet {ruka}");

            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "databáze");

            if (!ruka.Roles.Contains(role2))
            {
                await Context.Message.Channel.SendMessageAsync("nejspíše nejsi registrován do ekonomiky, použij příkaz .registrovat");
                return;
            }

            Emote agr = Emote.Parse("<:storksCoin:768931857332305921>");

            var najs = Context.User.Id.ToString();

            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");
            var coll = db.GetCollection<Rootobject1>("ekonomika");
            var cisla = await coll.Find(b => b.uzivatelid == najs).FirstAsync();
            int uzivatel = cisla.cernaruka;

            if (i == 0)
            {
                int mez1 = uzivatel / 20;
                int mez3 = uzivatel / 10;
                int mez5 = uzivatel / 100 * 15;

                var ovcak = new EmbedBuilder();
                ovcak.WithColor(Color.Orange);
                ovcak.WithTitle($"5% peněz na tvé černé ruce je {mez1} {agr} STORKSCOINS \n 10 % peněz na tvé černé ruce je {mez3} {agr} STORKSCOINS \n 15 % peněz na tvé černé ruce je {mez5} {agr} STORKSCOINS");
                await Context.Channel.SendMessageAsync(embed: ovcak.Build());
            }

            if (i != 0)
            {
                double proc = i / uzivatel * 100;
                double proc1 = proc * 100;
                var ovcak1 = new EmbedBuilder();
                ovcak1.WithColor(Color.Orange);
                ovcak1.WithTitle($"{i} je {proc}% z tvích STORKSCOINS");
                await Context.Channel.SendMessageAsync(embed: ovcak1.Build());
            }
        }
    }
}