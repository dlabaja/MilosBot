using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace MilošBot.Commands.Attributes
{
    class CheckUserHierarchyAttribute : ParameterPreconditionAttribute
    {
        public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, ParameterInfo parameter, object value, IServiceProvider services)
        {
            if (!(value is SocketGuildUser target))
            {
                return Task.FromResult(PreconditionResult.FromError($"Parametr {parameter.Name} musí být {"SocketGuildUser"}."));
            }
            if (context.User is SocketGuildUser source && source.Hierarchy > target.Hierarchy)
            {
                return Task.FromResult(PreconditionResult.FromSuccess());
            }
            return Task.FromResult(PreconditionResult.FromError($"Příkaz `{parameter.Command.Name}` lze použít pouze na někoho ke je v Hierarchy níž."));
        }
    }
}
