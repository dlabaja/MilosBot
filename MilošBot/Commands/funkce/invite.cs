using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class Invite : ModuleBase<SocketCommandContext>
    {
        [Command("invite")]
        [Alias("pozvat")]
        [Summary("Pozvi své kamarády na **dbl gaming**")]
        public async Task Trumpoulina(IGuildUser user = null)
        {
            if (user == null)
            {
                var u = Context.User;
                string msg = "`Hledáš herní komunitu **s lehce politickým nádechem?** ?\nPak nezoufej, právě jsi ji našel!\n\n*Co nabízíme ?*\n\n**[:robot:]Vlastní MilošBot\n[:amphora:]Hon za Tomiovými relikviemi\n[:postal_horn:]Možnost reklamy\n[:sparkles:]Nitro emotikony bez nitra\n[:money_with_wings:]Serverovou ekonomiku\n[:grinning:]Politické i klasické emotikony**\n\nTak na co ještě čekáš, **pozvánku máš tady!** https://discord.gg/QMU9gDW9b3 \n https://giphy.com/gifs/lSsuB8fjheR2wFCVto`";
                await UserExtensions.SendMessageAsync(u, msg);
            }
            else
            {
                return;
            }
            ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
            await cons.SendMessageAsync("invite: " + Context.User);
        }
    }
}