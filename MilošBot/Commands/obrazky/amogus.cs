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
    public class Amogus : ModuleBase<SocketCommandContext>
    {
        [Command("amogus")]
        [Alias("sus")]
        public async Task AmongUsAsync(SocketGuildUser user = null)
        {
            user ??= Context.User as SocketGuildUser; // pokud je v user null tak se použije hodnota za ??=
            var User1 = Context.User as SocketGuildUser;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Volič");
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Starosta");
            var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");

            if (User1.Roles.Contains(role) || User1.Roles.Contains(role2) || User1.Roles.Contains(role3))
            {
                var avatar = user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl();
                // pokud Context.User.GetAvatarUrl() vrátí null
                // tak se použije Context.User.GetDefaultAvatarUrl()

                var ms = new MemoryStream();
                using (var clientela = new HttpClient())
                {
                    var data = await clientela.GetStreamAsync(avatar);
                    await data.CopyToAsync(ms);
                }
                var profilovka = System.Drawing.Image.FromStream(ms);
                ms.Dispose();
                Bitmap bitmap1 = (Bitmap)System.Drawing.Image.FromFile(Data.Pictrazky("sus.png"));
                Size original = new Size(profilovka.Width, profilovka.Height);
                int maxSize = 120;
                float percent = (new List<float> { maxSize / (float)original.Width, maxSize / (float)original.Height }).Min();
                Size resultSize = new Size((int)Math.Floor(original.Width * percent), (int)Math.Floor(original.Height * percent));
                var logo = new Bitmap(profilovka, resultSize);
                using (Graphics graphics = Graphics.FromImage(bitmap1))
                {
                    graphics.DrawImage(logo, 25, 70);
                }
                ms = new MemoryStream();
                bitmap1.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Bitmap bitmap2 = (Bitmap)System.Drawing.Image.FromStream(ms);
                Bitmap sus = (Bitmap)System.Drawing.Image.FromFile(Data.Pictrazky("amogus.png"));
                using (Graphics graphics = Graphics.FromImage(bitmap2))
                {
                    graphics.DrawImage(sus, 0, 0);
                }
                ms = new MemoryStream();
                bitmap2.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;
                var zprava = await Context.Channel.SendFileAsync(ms, "kal.png");
                await zprava.AddReactionAsync(Emote.Parse("<:sus:809806610946981928>"));
            }
            else
            {
                await ReplyAsync("O co se to jako snažíš? Tento příkaz můžeš použít až od levelu 3!");
            }

            /*public static System.Drawing.Image FixedSize(System.Drawing.Image imgPhoto, int Width, int Height)
            {
                int sourceWidth = imgPhoto.Width;
                int sourceHeight = imgPhoto.Height;
                int sourceX = 0;
                int sourceY = 0;
                int destX = 0;
                int destY = 0;

                float nPercent = 0;
                float nPercentW = 0;
                float nPercentH = 0;

                nPercentW = ((float)Width / (float)sourceWidth);
                nPercentH = ((float)Height / (float)sourceHeight);
                if (nPercentH < nPercentW)
                {
                    nPercent = nPercentH;
                    destX = System.Convert.ToInt16((Width -
                                  (sourceWidth * nPercent)) / 2);
                }
                else
                {
                    nPercent = nPercentW;
                    destY = System.Convert.ToInt16((Height -
                                  (sourceHeight * nPercent)) / 2);
                }

                int destWidth = (int)(sourceWidth * nPercent);
                int destHeight = (int)(sourceHeight * nPercent);

                Bitmap bmPhoto = new Bitmap(Width, Height,
                                  PixelFormat.Format24bppRgb);
                bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                                 imgPhoto.VerticalResolution);

                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                grPhoto.Clear(System.Drawing.Color.Red);
                grPhoto.InterpolationMode =
                        InterpolationMode.HighQualityBicubic;

                grPhoto.DrawImage(imgPhoto,
                    new Rectangle(destX, destY, destWidth, destHeight),
                    new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                    GraphicsUnit.Pixel);

                grPhoto.Dispose();
                return bmPhoto;*/
        }
    }
}