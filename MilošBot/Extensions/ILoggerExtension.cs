using Discord;
using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace MilošBot.Extensions
{
    static class ILoggerExtension
    {
        static string Format(EmbedBuilder eb, Exception exception) 
        {
            var sb = new StringBuilder();
            if (eb.Author?.Name is object)
            {
                sb.Append("Author:");
                sb.Append(eb.Author.Name);
                sb.Append(", ");
            }
            if (eb.Title is object)
            {
                sb.Append("Title:");
                sb.Append(eb.Title);
                sb.Append(", ");
            }
            if (eb.Description is object)
            {
                sb.Append("Description:");
                sb.Append(eb.Description);
                sb.Append(", ");
            }
            if (eb.Fields?.Count > 0)
            {
                sb.Append("Fields:");
                foreach (var item in eb.Fields)
                {
                    sb.Append(item.Name);
                    sb.Append(":");
                    sb.Append(item.Value);
                    sb.Append(" ");
                }
                sb.Append(", ");
            }
            if (eb.Footer?.Text is object)
            {
                sb.Append("Footer:");
                sb.Append(eb.Footer.Text);
            }
            return sb.ToString(); 
        }
        public static void LogEmbed(this ILogger logger, LogLevel logLevel, EmbedBuilder embedBuilder)
        {
            embedBuilder.Color ??= logLevel.ToColor();
            logger.Log(logLevel, 0, embedBuilder, null, Format);
        }
        public static Color ToColor(this LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Trace => Color.LightGrey,
                LogLevel.Debug => Color.DarkGrey,
                LogLevel.Information => Color.Green,
                LogLevel.Warning => Color.Gold,
                LogLevel.Error => Color.Red,
                LogLevel.Critical => Color.DarkRed,
                LogLevel.None => Color.Default,
                _ => throw new NotImplementedException(),
            };
        }

    }
}
