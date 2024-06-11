using MongoDB.Bson;
using MongoDB.Driver;
using PersonalFinanceManager.Models;
using PersonalFinanceManager.Utils;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
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


        public bool AddTransaction(string username, string accountId, string type, double amount, string category, string payee, DateTime date)
        {
            try
            {
                var budgetController = new BudgetController();

                if (!budgetController.IsWithinBudget(username, category, amount))
                {
                    MessageBox.Show("This transaction exceeds your budget for the specified category.");
                }

                // Retrieve the user information based on the username
                var user = _users.Find(u => u.Username == username).FirstOrDefault();
                if (user == null)
                {
                    throw new ArgumentException("User not found");
                }

                // Create a new transaction object
                var transaction = new Transaction
                {
                    Id = ObjectId.GenerateNewId(),
                    UserId = user.Id,
                    AccountId = accountId,
                    Type = type,
                    Amount = amount,
                    Category = category,
                    Payee = payee,
                    Date = date
                };

                // Insert the transaction into the MongoDB collection
                _transactions.InsertOne(transaction);
                return true; // Indicate that the transaction was successful
            }
            catch (InvalidOperationException ex)
            {
                // Show a message box when the budget limit is exceeded
                System.Windows.Forms.MessageBox.Show(ex.Message, "Budget Limit Exceeded", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false; // Indicate that the transaction was not successful
            }
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

            return _transactions.Find(t => t.UserId == objectId).ToList();
        }

        public List<Transaction> GetTransactionsByCategory(string username, string category, DateTime startDate, DateTime endDate)
        {
            var user = _users.Find(u => u.Username == username).FirstOrDefault();
            string userId = user.Id.ToString();
            ObjectId objectId;
            if (!ObjectId.TryParse(userId, out objectId))
            {
                throw new ArgumentException("Invalid user ID format");
            }
            return _transactions.Find(t => t.UserId == objectId && t.Category == category && t.Date >= startDate && t.Date <= endDate).ToList();
        }

    }
}
