using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonalFinanceManager.Models
{
    public class Budget
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
