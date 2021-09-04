using Discord;
using Discord.Commands;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands.help
{
    public class HelpCommand : ModuleBase<SocketCommandContext>
    {
        private readonly CommandService _commandService;

        public HelpCommand(CommandService service)
        {
            _commandService = service;
        }

        [Command("Help-Command")]
        [Alias("hcmd", "helpc", "help-cmd")]
        [Summary("Zobrazí nápovědu k commandu.")]
        [Remarks("Pokud existuje víc commandů se stejným jménem tak vypíše všechny.")]
        public async Task HelpCommandAsync([Summary("Jméno nebo alias commandu.")][Remainder] string? command = null)
        {
            if(command is null)
            {
                await ReplyAsync("Zapoměl jsi zadat název komandu");
                return;
            }
            var result = _commandService.Search(Context, command);

            if (!result.IsSuccess)
            {
                await ReplyAsync($"Nápověda ke commandu **{command}** nebyla nalezena.");
                return;
            }
            const string format = "**{0}** - {1}\n";
            foreach (var match in result.Commands)
            {
                var cmd = match.Command;
                var builder = new EmbedBuilder()
                {
                    Title = cmd.Name
                };
                if (cmd.Aliases?.Count > 1)
                    builder.Description += string.Format(format, "Aliasy", string.Join(", ", cmd.Aliases.Where(x => x != cmd.Name)));
                if (cmd.Summary is object)
                    builder.Description += string.Format(format, "Shrnutí", cmd.Summary);
                if (cmd.Remarks is object)
                    builder.Description += string.Format(format, "Poznámka", cmd.Remarks);
                if (cmd.Parameters.Count > 0)
                {
                    builder.Description += $"\n__**Parametry**__\n";
                    foreach (var item in cmd.Parameters)
                    {
                        builder.Description += string.Format(format, item.Name, item.Summary);
                    }
                }
                await ReplyAsync(embed: builder.Build());
            }
        }
    }
}