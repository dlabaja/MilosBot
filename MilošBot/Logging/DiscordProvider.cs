using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;

namespace MilošBot.Logging
{
    class DiscordProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, DiscordLogger> _loggers = new ConcurrentDictionary<string, DiscordLogger>();

        private readonly DiscordSocketClient _client;
        private readonly ulong _logChannelId;

        public DiscordProvider(DiscordSocketClient client, ulong logChannelId)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logChannelId = logChannelId;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, new DiscordLogger(categoryName, _client, _logChannelId));
        }

        public void Dispose()
        {
        }
    }
}
