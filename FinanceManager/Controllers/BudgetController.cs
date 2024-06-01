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

        public void SetBudget(string userId, string category, double amount)
        {
            var budget = _budgets.Find(b => b.UserId == userId && b.Category == category).FirstOrDefault();
            if (budget == null)
            {
                budget = new Budget
                {
                    UserId = userId,
                    Category = category,
                    AllocatedAmount = amount,
                    SpentAmount = 0
                };
                _budgets.InsertOne(budget);
            }
            else
            {
                budget.AllocatedAmount = amount;
                _budgets.ReplaceOne(b => b.Id == budget.Id, budget);
            }
        }

        public void UpdateBudget(string userId, string category, double amount, string type)
        {
            var budget = _budgets.Find(b => b.UserId == userId && b.Category == category).FirstOrDefault();
            if (budget != null)
            {
                if (type == "Income")
                {
                    budget.AllocatedAmount += amount;
                }
                else
                {
                    budget.SpentAmount += amount;
                }
                _budgets.ReplaceOne(b => b.Id == budget.Id, budget);
            }
        }
    }
}
