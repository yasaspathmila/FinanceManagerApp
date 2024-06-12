using PersonalFinanceManager.Controllers;
using System;
using System.Windows.Forms;
using PersonalFinanceManager.Models;
using System.Data.Common;

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
            try
            {
                var accountId = txtAccountId.Text;
                var type = cmbType.SelectedItem.ToString();
                var amount = double.Parse(txtAmount.Text);
                var category = cmbCategory.SelectedItem.ToString();
                var payee = txtPayee.Text;
                var date = dtpDate.Value;

                
                bool isSuccess = _transactionController.AddTransaction(_username, accountId, type, amount, category, payee, date);
                if (isSuccess)
                {
                    MessageBox.Show("Transaction saved successfully.");
                    this.Close();
                }
                // If not successful, the message box is already shown in the controller
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid data.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
