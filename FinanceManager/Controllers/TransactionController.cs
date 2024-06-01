using MongoDB.Driver;
using PersonalFinanceManager.Models;
using PersonalFinanceManager.Utils;
using System;
using System.Collections.Generic;

namespace PersonalFinanceManager.Controllers
{
    public class TransactionController
    {
        private readonly IMongoCollection<Transaction> _transactions;

        public TransactionController()
        {
            _transactions = DatabaseHelper.GetCollection<Transaction>("Transactions");
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

        public List<Transaction> GetTransactions(string userId)
        {
            return _transactions.Find(t => t.UserId == userId).ToList();
        }
    }
}
