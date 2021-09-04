using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace MilošBot.Commands.Attributes
{
    class NotAuthorAttribute : ParameterPreconditionAttribute
    {
        public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, ParameterInfo parameter, object value, IServiceProvider services)
        {
            if (!(value is IUser user))
            {
                return Task.FromResult(PreconditionResult.FromError($"Parametr {parameter.Name} musí být {"User"}."));
            }
            if (context.User.Id == user.Id)
            {
                return Task.FromResult(PreconditionResult.FromError($"Příkaz `{parameter.Command.Name}` nelze použít na sebe."));
            }
            return Task.FromResult(PreconditionResult.FromSuccess());
        }
    }
}
