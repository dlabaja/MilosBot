using Discord;
using Discord.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Commands.Attributes
{
    class RequiredRoleAttribute : PreconditionAttribute
    {
        public ulong[] RoleIds { get; }
        public override string ErrorMessage { get; set; } = "Nemáš požadované oprávnění!";

        public RequiredRoleAttribute(params ulong[] roleId)
        {
            RoleIds = roleId;
        }

        public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
            if (context.User is IGuildUser user)
            {
                if (user.RoleIds.Any(x => RoleIds.Contains(x)))
                {
                    return Task.FromResult(PreconditionResult.FromSuccess());

                }
            }
            return Task.FromResult(PreconditionResult.FromError(ErrorMessage));
        }
    }
}
