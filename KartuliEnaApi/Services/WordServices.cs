using KartuliEnaApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace KartuliEnaApi.Services
{
    public class WordServices
    {
        private readonly IMongoCollection<Word> _wordsCollection;

        public WordServices(IOptions<WordDatabaseSettings> wordDatabaseSettings)
        {
            var mongoClient = new MongoClient(wordDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(wordDatabaseSettings.Value.DatabaseName);

            _wordsCollection = mongoDatabase.GetCollection<Word>(wordDatabaseSettings.Value.WordsCollectionName);
        }

        public async Task<List<Word>> GetAsync() =>
            await _wordsCollection.Find(_ => true).ToListAsync();

        public async Task<Word?> GetAsync(string id) =>
            await _wordsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Word newWord) =>
            await _wordsCollection.InsertOneAsync(newWord);

        public async Task UpdateAsync(string id, Word updatedWord) =>
            await _wordsCollection.ReplaceOneAsync(x => x.Id == id, updatedWord);

        public async Task RemoveAsync(string id) =>
            await _wordsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
