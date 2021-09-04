using Discord;
using Discord.Commands;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MilošBot.Commands.at
{
    public class InfoModule:ModuleBase<SocketCommandContext>
    {
        [Command("UserInfo")]
        public async Task BotStatusAsync(IUser? user = null)
        {
            var str = user is null ? "tobě" : "něm";
            user ??= Context.User;
            var eb = new EmbedBuilder()
            {
                Author = new EmbedAuthorBuilder() { Name = user.ToString(), IconUrl = user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl() },
                Title = $"Co o {str} vím?",
                ThumbnailUrl = user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl(),
                Color = (user.DiscriminatorValue % 5) switch
                {
                    0 => Color.Blue,
                    1 => Color.DarkGrey,
                    2 => Color.Green,
                    3 => Color.Gold,
                    4 => Color.Red,
                    _ => null
                },
                Fields = new System.Collections.Generic.List<EmbedFieldBuilder>()
                {
                    new EmbedFieldBuilder() { Name = "Id", Value = user.Id, IsInline = true },
                    new EmbedFieldBuilder() { Name = "Účet vytvořen", Value = $"{user.CreatedAt:d} {user.CreatedAt:t} ({To(user.CreatedAt)})", IsInline = false }
                },
                Footer = new EmbedFooterBuilder() { Text = "Vlez do soukromí od MilošBota", IconUrl = "https://cdn.discordapp.com/emojis/778284745448357888.png?v=1" }
            };
            if (user is IGuildUser guildUser)
            {
                if (guildUser.Nickname is object)
                    eb.AddField("Přezdívka", guildUser.Nickname, true);
                if (guildUser.JoinedAt is object)
                {
                    eb.AddField("Pripojil se", $"{guildUser.JoinedAt:d} {guildUser.JoinedAt:t} ({To(guildUser.JoinedAt.Value)})", false);
                }
                if (guildUser.PremiumSince is object)
                {
                    eb.AddField("Boost od", $"{guildUser.PremiumSince:d} {guildUser.PremiumSince:t} ({To(guildUser.PremiumSince.Value)})", false);
                }
            }
            await ReplyAsync(embed: eb.Build());
        }

        static string To(DateTimeOffset dateTime)
        {
            var diff = DateTimeOffset.Now - dateTime;
            var year = (int)(diff.TotalDays / 365);
            diff = diff.Subtract(TimeSpan.FromDays(365 * year));
            var month = (int)(diff.TotalDays / 30);
            diff = diff.Subtract(TimeSpan.FromDays(30 * month));
            var sb = new StringBuilder();
            if (year > 0)
                sb.Append(year switch
                {
                    1 => "1 rok ",
                    _ => year > 4 ? $"{year} let " : $"{year} roky "
                });
            if (month > 0)
                sb.Append(month switch
                {
                    1 => "1 měsíc ",
                    _ => month > 4 ? $"{month} měsíců " : $"{month} měsíce "
                });
            if (diff.Days > 0)
                sb.Append(diff.Days switch
                {
                    1 => "1 den",
                    7 => "1 týden",
                    14 => "2 týdny",
                    21 => "3 týdny",
                    28 => "4 týdny",
                    _ => diff.Days > 4 ? $"{diff.Days} dnů" : $"{diff.Days} dny"
                });
            return sb.ToString();
        }
    }
}
