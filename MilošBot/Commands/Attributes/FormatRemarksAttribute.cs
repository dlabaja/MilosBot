using Discord.Commands;

namespace MilošBot.Commands.Attributes
{
    class FormatRemarksAttribute : RemarksAttribute
    {
        public FormatRemarksAttribute(string format, params object[] args) : base(string.Format(format, args))
        {

        }
    }
}
