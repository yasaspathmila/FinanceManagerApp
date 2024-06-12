using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonalFinanceManager.Models
{
    public class Category
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
    }
}
