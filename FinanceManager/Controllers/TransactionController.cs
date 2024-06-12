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
        private readonly IMongoCollection<Account> _accounts;
        private readonly BudgetController _budgetController;
        private readonly AccountController _accountController;

        public TransactionController()
        {
            _transactions = DatabaseHelper.GetCollection<Transaction>("Transactions");
            _users = DatabaseHelper.GetCollection<User>("Users");
            _budgetController = new BudgetController();
            _accounts = DatabaseHelper.GetCollection<Account>("Accounts");
            _accountController = new AccountController();
        }

        public Account GetAccountById(string accountId)
        {
            return _accounts.Find(a => a.Id == accountId).FirstOrDefault();
        }

        public void UpdateAccountBalance(string accountId, double newBalance)
        {
            var filter = Builders<Account>.Filter.Eq(a => a.Id, accountId);
            var update = Builders<Account>.Update.Set(a => a.Balance, newBalance);
            _accounts.UpdateOne(filter, update);
        }


        public bool AddTransaction(string username, string accountId, string type, double amount, string category, string payee, DateTime date)
        {
            try
            {
                // Check account balance
                var account = GetAccountById(accountId);
                if (account == null)
                {
                    throw new InvalidOperationException("Account not found.");
                }
                if (type == "Expense" && account.Balance < amount)
                {
                    throw new InvalidOperationException("Insufficient account balance.");
                }

                // Check if transaction exceeds the budget
                var budget = _budgetController.GetBudgetByCategory(category);
                if (budget != null && _budgetController.CalculateRemainingBudget(budget) < amount)
                {
                    throw new InvalidOperationException("Transaction exceeds the budget limit.");
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

                // Update the account balance
                if (transaction.Type == "Expense")
                {
                    account.Balance -= transaction.Amount;
                }
                else if (transaction.Type == "Income")
                {
                    account.Balance += transaction.Amount;
                }
                _accountController.UpdateAccountBalance(transaction.AccountId.ToString(), account.Balance);

                return true; // Indicate that the transaction was successful
            }
            catch (InvalidOperationException ex)
            {
                // Show a message box when the budget limit is exceeded
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
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
