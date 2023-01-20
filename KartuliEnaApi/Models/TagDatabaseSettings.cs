namespace KartuliEnaApi.Models
{
    public class TagDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string TagsCollectionName { get; set; } = null!;
    }
}
