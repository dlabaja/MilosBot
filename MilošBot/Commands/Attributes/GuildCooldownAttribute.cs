using Discord.Commands;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace MilošBot.Commands.Attributes
{
    /// <summary>
    /// Sílený cooldown mezi všemi uživateli v serveru.
    /// </summary>
    class GuildCommandCooldownAttribute : PreconditionAttribute
    {
        ConcurrentDictionary<ulong, DateTime> _next = new ConcurrentDictionary<ulong, DateTime>();
        readonly TimeSpan _cooldownS;
        public GuildCommandCooldownAttribute(int hod, int min, int sec)
        {
            _cooldownS = new TimeSpan(hod, min, sec);
        }

        public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
            if (context.Guild is null)
                return Task.FromResult(PreconditionResult.FromError("Tento příkaz je použít jen na serveru"));
            if (_next.GetOrAdd(context.Guild.Id, x => DateTime.MinValue) < DateTime.Now)
            {
                _next[context.Guild.Id] = DateTime.Now + _cooldownS;
                return Task.FromResult(PreconditionResult.FromSuccess());
            }
            else
            {
                return Task.FromResult(PreconditionResult.FromError(ErrorMessage ?? $"Příkaz budeš moct použít až za {(_next[context.Guild.Id] - DateTime.Now).TotalMinutes:.00} min"));
            }
        }
    }
}
