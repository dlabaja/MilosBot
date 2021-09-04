using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilošBot.Services
{
    public enum ForbiddenWordSeverity
    {
        None, Kick, TempMute, Mute, Ban
    }

    public class ForbiddenWord
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Word { get; set; }
        public ForbiddenWordSeverity Severity { get; set; }
        public TimeSpan? Delay { get; set; }
    }

    public class ForbidenWordService
    {
        public IReadOnlyList<ForbiddenWord> ForbiddenWords { get => _forbiddenWords; }
        List<ForbiddenWord> _forbiddenWords = new List<ForbiddenWord>();
        private readonly IServiceProvider _services;

        IMongoCollection<ForbiddenWord> Table => _services.GetRequiredService<IMongoClient>().GetDatabase("dbl").GetCollection<ForbiddenWord>("ForbiddenWords");

        public ForbidenWordService(IServiceProvider services)
        {
            _services = services;
            ReloadAsync();
        }

        public async Task<ForbiddenWord> AddWordAsync(ForbiddenWord word)
        {
            await Table.InsertOneAsync(word);
            await ReloadAsync();
            return word;
        }

        public async Task<bool> RemoveWordAśync(string word)
        {
            var w = _forbiddenWords.FirstOrDefault(x => x.Word.Equals(word, StringComparison.InvariantCultureIgnoreCase));
            if(w is null)
            {
                return false;
            }
            var res = await Table.DeleteOneAsync(x => x.Id == w.Id);
            if(res.DeletedCount == 1)
            {
                _forbiddenWords.Remove(w);
                return true;
            }
            return false;
        }

        public async Task ReloadAsync()
        {
            _forbiddenWords = (await Table.FindAsync(x => true)).ToList();
        }

        public bool TryGet(string sentence, out ForbiddenWord word)
        {
            word = _forbiddenWords.FirstOrDefault(x => sentence.Contains(x.Word, StringComparison.InvariantCultureIgnoreCase));
            return word is object;
        }
    }
}
