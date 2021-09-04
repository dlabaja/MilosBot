using Discord;
using Discord.Commands;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace MilošBot.Commands
{
    public class test : ModuleBase<SocketCommandContext>
    {
        [Command("resend")]
        [Summary("Přepošle ověřovací kód do DM")]
        public async Task Mildosaurus1()
        {
            var user = Context.User;
            string cesta = Data.Pictrazky("kod.jpg");
            //string cesta = @"/home/kubak1500/Desktop/discord_temp/kalousek.png";
            /*string cesta = @"C:\Users\uzivatel 1\Pictures\discord_temp\kalousek.png";
            string cestá = @"C:\Users\uzivatel 1\Pictures\discord_temp\kalousekdone.jpg";
            string trip = @"C:\Users\uzivatel 1\Pictures\discord_temp\priloha.png";
            string error = @"C:\Users\uzivatel 1\Pictures\discord_temp\kalouserror.png";*/
            var client = new MongoClient("MongoDB connection string");
            var db = client.GetDatabase("dbl");
            var coll = db.GetCollection<RootobjectI>("uzivatele");
            var data = coll.Find(b => b.idcko == user.Id.ToString()).FirstOrDefaultAsync().Result;

            Bitmap bitmap1 = (Bitmap)System.Drawing.Image.FromFile(cesta);
            using (Graphics graphics = Graphics.FromImage(bitmap1))
            {
                using (Font arialFont = new Font("Comic Sans MS", 100))
                {
                    StringFormat format = new StringFormat();
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Center;
                    graphics.DrawString(data.tagkod.ToString(), arialFont, Brushes.Black, 357, 130, format);
                }
            }
            var ms = new MemoryStream();
            bitmap1.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Position = 0;
            //await Context.Message.DeleteAsync();
            try
            {
                await UserExtensions.SendFileAsync(user, ms, "kal.jpg");
            }
            catch (Discord.Net.HttpException e)
            {
                Console.WriteLine(e);
            }
            var _client = new DiscordSocketClient();
            ITextChannel log = _client.GetChannel(DChannelId.ConsoleLog) as ITextChannel;
            await log.SendMessageAsync("resend " + user);
            await Context.Message.DeleteAsync();
        }
    }
}