using PersonalFinanceManager.Controllers;
using System;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms
{
    public partial class TransactionForm : Form
    {
        private readonly TransactionController _transactionController;
        private readonly string _username;

        public TransactionForm(string username)
        {
            InitializeComponent();
            _username = username;
            _transactionController = new TransactionController();
        }

        private void btnSaveTransaction_Click(object sender, EventArgs e)
        {
            var accountId = txtAccountId.Text;
            var type = cmbType.SelectedItem.ToString();
            var amount = double.Parse(txtAmount.Text);
            var category = cmbCategory.SelectedItem.ToString();
            var payee = txtPayee.Text;
            var date = dtpDate.Value;

            _transactionController.AddTransaction(accountId, type, amount, category, payee, date);
            MessageBox.Show("Transaction saved successfully.");
            this.Close();
        }
    }
}
