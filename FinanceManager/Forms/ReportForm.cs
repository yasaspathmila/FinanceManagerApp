using PersonalFinanceManager.Controllers;
using PersonalFinanceManager.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms
{
    public partial class ReportForm : Form
    {
        private readonly TransactionController _transactionController;
        private readonly string _username;

        public ReportForm(string username)
        {
            InitializeComponent();
            _username = username;
            _transactionController = new TransactionController();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            List<Transaction> transactions = _transactionController.GetTransactions(_username);
            // Logic to display the report
        }
    }
}
