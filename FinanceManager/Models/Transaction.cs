using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PersonalFinanceManager.Models
{
    public class Transaction
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string AccountId { get; set; }
        public string Type { get; set; } // Income or Expense
        public double Amount { get; set; }
        public string Category { get; set; }
        public string Payee { get; set; }
        public DateTime Date { get; set; }
    }
}
