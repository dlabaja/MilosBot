using Discord;
using Discord.Commands;
using Discord.WebSocket;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Mdz : ModuleBase<SocketCommandContext>
    {
        [Command("laska")]
        [Alias("láska")]
        public async Task LaskaAsync(SocketGuildUser user = null)
        {
            var User1 = Context.User as SocketGuildUser;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Volič");
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Starosta");
            var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");
            if (User1.Roles.Contains(role) || User1.Roles.Contains(role2) || User1.Roles.Contains(role3))
            {
                if (user == null || user == Context.User)
                {
                    await ReplyAsync("Opravdu chceš vyznat lásku sám sobě?");
                    return;
                }

                var avatar = Context.User.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl();

                var ms = new MemoryStream();
                using (var clientela = new HttpClient())
                {
                    var data = await clientela.GetStreamAsync(avatar);
                    await data.CopyToAsync(ms);
                }
                var profilovka = System.Drawing.Image.FromStream(ms);
                ms.Dispose();
                Bitmap bitmap = (Bitmap)System.Drawing.Image.FromFile(Data.Pictrazky("baleni.png"));
                Size original = new Size(profilovka.Width, profilovka.Height);
                int maxSize = 400;
                float percent = (new List<float> { maxSize / (float)original.Width, maxSize / (float)original.Height }).Min();
                Size resultSize = new Size((int)Math.Floor(original.Width * percent), (int)Math.Floor(original.Height * percent));
                var logo = new Bitmap(profilovka, resultSize);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.DrawImage(logo, 420, 100);
                }
                ms = new MemoryStream();
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Position = 0;
                await Context.Channel.SendFileAsync(ms, "kal.jpg", Context.User.Username + " ti vyznal lásku, " + user.Mention + " ❤️");
                await UserExtensions.SendMessageAsync(user, Context.User + " ti vyznal lásku ❤️");
            }
            else
            {
                await ReplyAsync("O co se to jako snažíš? Tento příkaz můžeš použít až od levelu 3!");
            }
        }
    }
}