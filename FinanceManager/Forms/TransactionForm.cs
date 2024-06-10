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

            _transactionController.AddTransaction(_username, accountId, type, amount, category, payee, date);
            MessageBox.Show("Transaction saved successfully.");
            this.Close();
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
