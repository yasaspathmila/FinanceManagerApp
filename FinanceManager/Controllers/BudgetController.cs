using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using PersonalFinanceManager.Models;
using PersonalFinanceManager.Utils;

namespace PersonalFinanceManager.Controllers
{
    public class BudgetController
    {
        private readonly IMongoCollection<Budget> _budgets;

        public BudgetController()
        {
            _budgets = DatabaseHelper.GetCollection<Budget>("Budgets");
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
    }
}
