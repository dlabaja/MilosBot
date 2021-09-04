using Discord;
using Discord.Commands;
using MilošBot.Commands.Attributes;
using MilošBot.Services;
using System;
using System.Threading.Tasks;

namespace MilošBot.Commands.at
{
    //premier, hlavní poradce premiera
    [RequiredRole(719259714701230140, 757979887255683223)]
    [Group("WordFilter "), Alias("wf", "fw")]
    public class ForbiddenWordModule : ModuleBase<SocketCommandContext>
    {
        readonly ForbidenWordService _forbidenWordService;
        public ForbiddenWordModule(ForbidenWordService forbidenWordService)
        {
            _forbidenWordService = forbidenWordService;
        }

        [Command("Get")]
        [Summary("Zobrazí seznam zakázanýc slov.")]
        public async Task GetAsync()
        {
            var eb = new EmbedBuilder()
            {
                Title = "Seznam zakázaných slov."
            };
            foreach (var item in _forbidenWordService.ForbiddenWords)
            {
                eb.Description += $"Url: *{item.Word}*, Závažnost: *{item.Severity}*\n";
            }
            await ReplyAsync(embed: eb.Build());
        }

        [Command("Add")]
        [Summary("Přidá další zakázané slovo.")]
        public async Task AddAsync([Summary("Slovo které se zakáže.")]string word, [Summary("Trest")]ForbiddenWordSeverity severity = ForbiddenWordSeverity.None, TimeSpan? delay = null)
        {
            var fWord = new ForbiddenWord() { Word = word, Severity = severity };
            await _forbidenWordService.AddWordAsync(fWord);
            var eb = new EmbedBuilder()
            {
                Title = "Nové zakázané slovo."
            }
                .AddField("Url", fWord.Word)
                .AddField("Závažnost", fWord.Severity).
                WithFooter("Cenzura by Miloš");
            await ReplyAsync(embed: eb.Build());
        }

        [Command("Reload")]
        [Summary("Nahraje znovu seznam zakázaných slov z databáze.")]
        public async Task ReloadAsync()
        {
            await _forbidenWordService.ReloadAsync();
            await ReplyAsync("Aktualizován seznam zakázaných slov.");
        }

        [Command("Remove")]
        [Summary("Odebere zakázané slovo.")]
        public async Task RemoveAsync(string word)
        {
            if(await _forbidenWordService.RemoveWordAśync(word))
            {
                await ReplyAsync($"Super, slovo \"*{word}*\" už není zakázané.");
            }
            else
            {
                await ReplyAsync("Tohle slovo není zakázanéa tak nešlo odebrat.");
            }
        }

    }
}
