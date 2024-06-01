using MongoDB.Driver;

namespace PersonalFinanceManager.Utils
{
    public static class DatabaseHelper
    {
        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static DatabaseHelper()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MongoDbConnectionString"].ConnectionString;
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase("PersonalFinanceManagerDB");
        }

        public static IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }
}
