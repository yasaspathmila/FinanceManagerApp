using FinanceManager.Forms;
using PersonalFinanceManager.Controllers;
using PersonalFinanceManager.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms
{
    public partial class MainForm : Form
    {
        private readonly TransactionController _transactionController;
        private readonly BudgetController _budgetController;
        private readonly string _username;

        public MainForm(string username)
        {
            InitializeComponent();
            _username = username;
            _transactionController = new TransactionController();
            _budgetController = new BudgetController();
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            TransactionForm transactionForm = new TransactionForm(_username);
            transactionForm.Show();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            List<Transaction> transactions = _transactionController.GetTransactions(_username);
            // Generate report logic
        }

        private void btnSetBudget_Click(object sender, EventArgs e)
        {
            // Open form to set budget
        }
    }
}
