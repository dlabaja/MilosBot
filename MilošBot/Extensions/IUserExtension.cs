using Discord;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace MilošBot.Extensions
{
    static class IUserExtension
    {
        public static Task<bool> TrySendMessageAsync(this IUser user, [NotNullWhen(true)] out IUserMessage? message, string? text = null, Embed? embed = null, AllowedMentions? allowedMentions = null)
        {
            try
            {
                message = user.SendMessageAsync(text, false, embed, null, allowedMentions).GetAwaiter().GetResult();
                return Task.FromResult(true);
            }
            catch
            {
                message = null;
                return Task.FromResult(false);
            }
        }
    }
}
