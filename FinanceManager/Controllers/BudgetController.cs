using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using PersonalFinanceManager.Models;
using PersonalFinanceManager.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PersonalFinanceManager.Controllers
{
    public class BudgetController
    {
        private readonly IMongoCollection<Budget> _budgets;
        private readonly IMongoCollection<Transaction> _transactions;
        private readonly IMongoCollection<User> _users;

        public BudgetController()
        {
            _budgets = DatabaseHelper.GetCollection<Budget>("Budgets");
            _transactions = DatabaseHelper.GetCollection<Transaction>("Transactions");
            _users = DatabaseHelper.GetCollection<User>("Users");
        }

        public void AddBudget(Budget budget)
        {
            _budgets.InsertOne(budget);
        }

        public List<Budget> GetBudgets(string username)
        {
            return _budgets.Find(b => b.Username == username).ToList();
        }

        public bool IsWithinBudget(string username, string category, double amount)
        {
            var currentDate = DateTime.Now;
            var budget = _budgets.Find(b => b.Username == username && b.Category == category && b.StartDate <= currentDate && b.EndDate >= currentDate).FirstOrDefault();

            if (budget == null)
            {
                return true; // No budget set for this category, so it's within budget by default
            }

            var totalSpent = GetTotalSpent(username, category, budget.StartDate, budget.EndDate);
            return totalSpent + amount <= budget.Amount;
        }

        private double GetTotalSpent(string username, string category, DateTime startDate, DateTime endDate)
        {
            // This should interact with your transactions collection to get the total spent
            // Assuming you have a TransactionController that can fetch transactions

            var transactionController = new TransactionController();
            var transactions = transactionController.GetTransactionsByCategory(username, category, startDate, endDate);
            double totalSpent = 0;

            foreach (var transaction in transactions)
            {
                totalSpent += transaction.Amount;
            }

            return totalSpent;
        }

        public Budget GetBudgetByCategory(string category)
        {
            return _budgets.Find(b => b.Category == category).FirstOrDefault();
        }

        public double CalculateRemainingBudget(Budget budget)
        {
            var totalSpent = _transactions.Find(t => t.Category == budget.Category && t.Type == "Expense").ToList().Sum(t => t.Amount);
            return budget.Amount - totalSpent;
        }

        public Dictionary<string, double> GetBudgetsByCategory(string userName)
        {
            return _budgets.Find(b => b.Username == userName)
                           .ToEnumerable()
                           .ToDictionary(b => b.Category, b => b.Amount);
        }

        public Dictionary<string, double> GetRemainingBudgetsByCategory(string userName)
        {
            var budgets = GetBudgetsByCategory(userName);
            var remainingBudgets = new Dictionary<string, double>();
            var user = _users.Find(u => u.Username == userName).FirstOrDefault();

            foreach (var category in budgets.Keys)
            {
                var totalExpenses = _transactions.Find(t => t.UserId == user.Id && t.Category == category && t.Type == "Expense")
                                                 .ToEnumerable()
                                                 .Sum(t => t.Amount);
                remainingBudgets[category] = budgets[category] - totalExpenses;
            }

            return remainingBudgets;
        }

        public Dictionary<string, double> GetTotalBudgetsByCategory(string userName)
        {
            return _budgets.Find(b => b.Username == userName)
                           .ToEnumerable()
                           .ToDictionary(b => b.Category, b => b.Amount);
        }

        public Dictionary<string, double> GetSpentAmountsByCategory(string userName)
        {
            var user = _users.Find(u => u.Username == userName).FirstOrDefault();
            var transactions = _transactions.Find(t => t.UserId == user.Id && t.Type == "Expense").ToList();
            return transactions.GroupBy(t => t.Category)
                               .ToDictionary(g => g.Key, g => g.Sum(t => t.Amount));
        }
    }
}
