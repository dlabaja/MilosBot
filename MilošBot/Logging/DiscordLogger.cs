using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using System;

namespace MilošBot.Logging
{
    class DiscordLogger : ILogger
    {
        private readonly DiscordSocketClient _client;
        private readonly ulong _logChannelId;
        private SocketTextChannel? _logChannel;

        private readonly string _name;

        public DiscordLogger(string name, DiscordSocketClient client, ulong logChannelId)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logChannelId = logChannelId;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None && _client.ConnectionState == ConnectionState.Connected;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
            if (formatter is null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }
            _logChannel ??= NewMethod();
            if (_logChannel is null)
                return;
            if (state is EmbedBuilder eb)
            {
                eb.WithFooter(_name);
                _logChannel.SendMessageAsync(embed: eb.Build());
            }
            else
                _logChannel.SendMessageAsync(formatter(state, exception));
        }

        private SocketTextChannel? NewMethod()
        {
            foreach (var item in _client.Guilds)
            {
                foreach (var item2 in item.Channels)
                {
                    if (item2.Id == _logChannelId)
                        if (item2 is SocketTextChannel textChannel)
                            return textChannel;
                }
            }
            return null;
        }
    }
}
