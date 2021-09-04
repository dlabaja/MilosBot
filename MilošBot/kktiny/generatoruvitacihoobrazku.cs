using Discord;
using Discord.Addons.Interactive;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class GeneratorUvitacihoObrazku : ModuleBase<SocketCommandContext>
    {
        public Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }

        /*

var channel = _client.GetChannel(728885647745744976) as SocketTextChannel; // Gets the channel to send the message in

await channel.SendMessageAsync("-----------------------------------------------------------------------------------------------------------\n" +
$@"Čest práci {gUser.Mention}! Vítej na **dbl gaming**, serveru, který má momentálně **{dbl.Users.Count}** členů"
); //Welcomes the new user
await channel.SendMessageAsync(gUser.GetAvatarUrl());

if (umisteni == false)
{
cesta = @"C:\Users\uzivatel 1\Pictures\discord_temp\" + context.Message.Attachments.First().Filename;
}
else
{
cesta = @"/home/kubak1500/Desktop/" + context.Message.Attachments.First().Filename;
}

using (var clientela = new WebClient())
{
clientela.DownloadFile(new System.Uri(url), cesta);
}
await logfeed.SendFileAsync(cesta);
File.Delete(cesta);

var u = context.User;
string msg = "Děkujeme za feedback! Až ho schválíme, dáme ti vědět " + context.User.Mention + " :)";
await Discord.UserExtensions.SendMessageAsync(u, msg);
await context.Channel.DeleteMessageAsync(message);*/

        public System.Drawing.Image CropImage(System.Drawing.Image img)
        {
            int x = img.Width / 2;
            int y = img.Height / 2;
            int r = Math.Min(x, y);

            Bitmap tmp = new Bitmap(2 * r, 2 * r);
            using (Graphics g = Graphics.FromImage(tmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TranslateTransform(tmp.Width / 2, tmp.Height / 2);
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(0 - r, 0 - r, 2 * r, 2 * r);
                Region rg = new Region(gp);
                g.SetClip(rg, CombineMode.Replace);
                Bitmap bmp = new Bitmap(img);
                g.DrawImage(bmp, new Rectangle(-r, -r, 2 * r, 2 * r), new Rectangle(x - r, y - r, 2 * r, 2 * r), GraphicsUnit.Pixel);
            }
            return tmp;
        }
    }
}