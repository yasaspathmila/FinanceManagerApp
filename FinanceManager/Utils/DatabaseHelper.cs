using MongoDB.Driver;
using System;
using System.Configuration;
using System.IO;


namespace PersonalFinanceManager.Utils
{
    public static class DatabaseHelper
    {
        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static DatabaseHelper()
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["MongoDbConnectionString"].ConnectionString;
                _client = new MongoClient(connectionString);
                _database = _client.GetDatabase("FinanceDB");
                Console.WriteLine("Successfully connected to MongoDB database: " );
            }
            catch (Exception ex)
            {
                // Handle connection error gracefully (log the error, display user message)
                Console.WriteLine("Error connecting to MongoDB: " + ex.Message);
                // You can throw a new exception here to propagate the error if needed
            }
        }

        public static IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }
}
