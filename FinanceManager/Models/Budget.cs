using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonalFinanceManager.Models
{
    public class Budget
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string UserId { get; set; }
        public string Category { get; set; }
        public double AllocatedAmount { get; set; }
        public double SpentAmount { get; set; }
    }
}
