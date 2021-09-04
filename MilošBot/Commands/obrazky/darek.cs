using Discord.Commands;
using Discord.WebSocket;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class darek : ModuleBase<SocketCommandContext>
    {
        [Command("darek")]
        [Alias("dárek")]
        [Summary("Kalousek ti pošle dárek - nezapomeň mu k tomu přidat obrázek!")]
        public async Task DarekAsync([Summary("Url adresa obrázku.")]string url = null)
        {
            var User1 = Context.User as SocketGuildUser;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Volič");
            var role2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Starosta");
            var role3 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Politik");
            if (User1.Roles.Contains(role) || User1.Roles.Contains(role2) || User1.Roles.Contains(role3))
            {
                if (Context.Message.Attachments.Count == 0 && url == null)
                {
                    await Context.Channel.SendFileAsync(Data.Pictrazky("kalouserror.png"));
                    return;
                }
                if (url != null)
                {
                    if (url[0] == '<' && url.Last() == '>')
                        url = url.Substring(1, url.Length - 2);
                }
                else
                {
                    url = Context.Message.Attachments.First().Url;
                }
                var ms = new MemoryStream();
                using (var clientela = new HttpClient())
                {
                    var data = await clientela.GetStreamAsync(url);
                    await data.CopyToAsync(ms);
                }
                Image profilovka = Image.FromStream(ms);
                ms.Dispose();
                Bitmap bitmap = (Bitmap)Image.FromFile(Data.Pictrazky("kalousek.png"));
                Size original = new Size(profilovka.Width, profilovka.Height);
                int maxSize = 400;
                float percent = (new List<float> { maxSize / (float)original.Width, maxSize / (float)original.Height }).Min();
                Size resultSize = new Size((int)Math.Floor(original.Width * percent), (int)Math.Floor(original.Height * percent));
                var logo = new Bitmap(profilovka, resultSize);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.DrawImage(logo, 170, 270);
                }
                ms = new MemoryStream();
                bitmap.Save(ms, ImageFormat.Jpeg);
                ms.Position = 0;
                await Context.Channel.SendFileAsync(ms, "kal.jpg", "**Kalousek ti chce něco dát**");
            }
            else
            {
                await ReplyAsync("O co se to jako snažíš? Tento příkaz můžeš použít až od levelu 3!");
            }
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
