using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PersonalFinanceManager.Controllers;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Forms
{
    public partial class ViewTransactionsForm : Form
    {
        private readonly TransactionController _transactionController;
        private readonly string _userName;

        public ViewTransactionsForm(string userName)
        {
            InitializeComponent();
            _userName = userName;
            _transactionController = new TransactionController();
        }

        private void ViewTransactionsForm_Load(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void LoadTransactions()
        {
            List<Transaction> transactions = _transactionController.GetTransactions(_userName);
            dgvTransactions.DataSource = transactions;
        }

        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
