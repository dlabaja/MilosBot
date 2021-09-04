using Discord.Commands;

namespace MilošBot.Commands.Attributes
{
    class FormatSummaryAttribute : SummaryAttribute
    {
        public FormatSummaryAttribute(string format, params object[] args) : base(string.Format(format, args))
        {

        }
    }
}
