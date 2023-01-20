using KartuliEnaApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Tag = KartuliEnaApi.Models.Tag;

namespace KartuliEnaApi.Services
{
    public class TagServices
    {
        private readonly IMongoCollection<Tag> _tagsCollection;

        public TagServices(IOptions<TagDatabaseSettings> tagDatabaseSettings)
        {
            var mongoClient = new MongoClient(tagDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(tagDatabaseSettings.Value.DatabaseName);

            _tagsCollection = mongoDatabase.GetCollection<Tag>(tagDatabaseSettings.Value.TagsCollectionName);
        }

        public async Task<List<Tag>> GetAsync() =>
            await _tagsCollection.Find(_ => true).ToListAsync();

        public async Task<Tag?> GetAsync(string id) =>
            await _tagsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Tag newTag) =>
            await _tagsCollection.InsertOneAsync(newTag);

        public async Task UpdateAsync(string id, Tag updatedTag) =>
            await _tagsCollection.ReplaceOneAsync(x => x.Id == id, updatedTag);

        public async Task RemoveAsync(string id) =>
            await _tagsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
