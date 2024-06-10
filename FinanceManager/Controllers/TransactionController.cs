using MongoDB.Bson;
using MongoDB.Driver;
using PersonalFinanceManager.Models;
using PersonalFinanceManager.Utils;
using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PersonalFinanceManager.Controllers
{
    public class TransactionController
    {
        private readonly IMongoCollection<Transaction> _transactions;
        private readonly IMongoCollection<User> _users;

        public TransactionController()
        {
            _transactions = DatabaseHelper.GetCollection<Transaction>("Transactions");
            _users = DatabaseHelper.GetCollection<User>("Users");

        }

        public void AddTransaction(string accountId, string type, double amount, string category, string payee, DateTime date)
        {
            var transaction = new Transaction
            {
                AccountId = accountId,
                Type = type,
                Amount = amount,
                Category = category,
                Payee = payee,
                Date = date
            };
            _transactions.InsertOne(transaction);
        }

        public void AddTransaction(string username, string accountId, string type, double amount, string category, string payee, DateTime date)
        {
            // Retrieve the user information based on the username
            var user = _users.Find(u => u.Username == username).FirstOrDefault();
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            // Create a new transaction object
            var transaction = new Transaction
            {
                Id = user.Id, // Assuming the User object has an Id of type ObjectId
                AccountId = accountId,
                Type = type,
                Amount = amount,
                Category = category,
                Payee = payee,
                Date = date
            };

            // Insert the transaction into the MongoDB collection
            _transactions.InsertOne(transaction);
        }

        public List<Transaction> GetTransactions(string username)
        {
            var user = _users.Find(u => u.Username == username).FirstOrDefault();
            string userId = user.Id.ToString();
            // Convert userId to ObjectId
            ObjectId objectId;
            if (!ObjectId.TryParse(userId, out objectId))
            {
                throw new ArgumentException("Invalid user ID format");
            }

            return _transactions.Find(t => t.Id == objectId).ToList();
        }

    }
}
