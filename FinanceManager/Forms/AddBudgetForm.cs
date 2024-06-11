using MongoDB.Bson;
using PersonalFinanceManager.Controllers;
using PersonalFinanceManager.Models;
using System.Windows.Forms;
using System;

namespace PersonalFinanceManager.Forms
{
    public partial class AddBudgetForm : Form
    {
        private readonly string _username;
        private readonly BudgetController _budgetController;

        public AddBudgetForm(string username)
        {
            InitializeComponent();
            _username = username;
            _budgetController = new BudgetController();
        }

        private void btnAddBudget_Click(object sender, EventArgs e)
        {
            var amount = double.Parse(txtAmount.Text);
            var category = cmbCategory.SelectedItem.ToString();
            var startDate = dtpStartDate.Value;
            var endDate = dtpEndDate.Value;

            var budget = new Budget
            {
                Id = ObjectId.GenerateNewId(),
                Username = _username,
                Amount = amount,
                Category = category,
                StartDate = startDate,
                EndDate = endDate
            };

            _budgetController.AddBudget(budget);
            MessageBox.Show("Budget added successfully.");
            this.Close();
        }

        private void AddBudgetForm_Load(object sender, EventArgs e)
        {

        }
    }
}
