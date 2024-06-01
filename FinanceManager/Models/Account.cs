using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonalFinanceManager.Models
{
    public class Account
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; } // e.g., Checking, Savings, Credit Card, etc.
        public double Balance { get; set; }
    }
}
