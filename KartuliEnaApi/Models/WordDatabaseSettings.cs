namespace KartuliEnaApi.Models
{
    public class WordDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string WordsCollectionName { get; set; } = null!;
    }
}
