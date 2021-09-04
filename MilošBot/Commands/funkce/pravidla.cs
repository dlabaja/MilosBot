using Discord.Commands;
using System.Threading.Tasks;

namespace MilošBot.Commands
{
    public class pragoijsd : ModuleBase
    {
        [Command("pravidla")]
        [Alias("rules")]
        [Summary("Pravidla serveru")]
        public async Task Coin()
        {
            string msg = @"**Pravidla**
**1. V chatu je zakázáno:**
    - spam
    - **přílišné zmiňování ostatních členů a pingování @everyone a @here**
    - nadávky/urážky
    - žebrání o role (stejně bychom Vám ji nedali)
    - zbytečné psaní** CAPS LOCKem**
    - odkazy na **warez/nevhodné stránky**
    - vydávání se za někoho jiného
    - cokoliv v rozporu se zákony ČR a SR (jakékoliv projevy rasismu/fašismu nebo jiného extremismu nebudou tolerovány!)
    - **pozvánky a reklamy** na různé minecraft/discord servery nebo vaše sociální sítě, kromě kanálu **#📮reklama **. **To platí i v DM!!!**

**2. Zákaz zneužívání děr v pravidlech nebo na serveru - Při nalezení chyby máte povinost ji nahlásit do **#📣feedback
**3. Neznalost pravidel neomlouvá!**

Za porušení pravidel hrozí podle závažnosti @Muted  nebo ban.
Za obcházení @Muted  (odpojení se a znovupřipojení) je bezpodmínečně ban.

Se servery typu DBL gaming kopie, DBL gaminq1, atd **NEMÁME** nic společného!

A-TEAM si vyhrazuje právo na jakoukoliv změnu pravidel
A-TEAM má právo udělovat tresty podle vlastního uvážení
A-TEAM nenese zodpovědnost za chování ostatních
A-TEAM má vždy pravdu
Je zakázáno se vydávat za kohokoliv ze serveru, hlavně kohokoliv z A-teamu.";
            await Discord.UserExtensions.SendMessageAsync(Context.User, msg);
            await ReplyAsync("Poslal jsem ti pravidla do DM");
        }
    }
}