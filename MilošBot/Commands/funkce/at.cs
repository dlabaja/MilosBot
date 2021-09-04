using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class ATHodnoceni : ModuleBase<SocketCommandContext>
    {
        [Command("at")]
        [Summary("Kdo je nejlepší z AT?")]
        public async Task ATAsync()
        {
            using (Context.Channel.EnterTypingState())
            {
                var ovcak = new EmbedBuilder();
                ITextChannel cons = Context.Client.GetChannel(DChannelId.MilosLog) as ITextChannel;
                Random random = new Random();
                int smrt = random.Next(6);
                if (smrt == 0)
                {
                    ovcak.WithTitle("Nejlepší z premiérů je kubak1500");
                    await Context.Channel.SendMessageAsync(embed: ovcak.Build());
                    await cons.SendMessageAsync("hodnoceni at: Kubak1500 " + smrt);
                    await Context.Message.DeleteAsync();
                }
                if (smrt == 1)
                {
                    ovcak.WithTitle("Nejlepší z premiérů je (Ten) dlabaja");
                    await Context.Channel.SendMessageAsync(embed: ovcak.Build());
                    await cons.SendMessageAsync("hodnoceni at: Dlabaja " + smrt);
                    await Context.Message.DeleteAsync();
                }
                if (smrt == 2)
                {
                    ovcak.WithTitle("Nejlepší z premiérů je Your Generic Scunt");
                    await Context.Channel.SendMessageAsync(embed: ovcak.Build());
                    await cons.SendMessageAsync("hodnoceni at: Scunt " + smrt);
                    await Context.Message.DeleteAsync();
                }
                if (smrt == 3)
                {
                    ovcak.WithTitle("Nejlepší z premiérů je Qwer8");
                    await Context.Channel.SendMessageAsync(embed: ovcak.Build());
                    await cons.SendMessageAsync("hodnoceni at: Qwer8 " + smrt);
                    await Context.Message.DeleteAsync();
                }
                if (smrt == 4)
                {
                    ovcak.WithTitle("Všichni premiéři jsou nej");
                    await Context.Channel.SendMessageAsync(embed: ovcak.Build());
                    await cons.SendMessageAsync("Hodnocení at: Všichni jsou nej " + smrt);
                    await Context.Message.DeleteAsync();
                }
                if (smrt == 5)
                {
                    ovcak.WithTitle("Všichni premiéři jsou L");
                    await Context.Channel.SendMessageAsync(embed: ovcak.Build());
                    await cons.SendMessageAsync("hodnoceni at: Všichni jsou LL " + smrt);
                    await Context.Message.DeleteAsync();
                }
            }
        }
    }
}