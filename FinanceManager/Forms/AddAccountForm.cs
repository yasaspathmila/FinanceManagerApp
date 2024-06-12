using System;
using System.Windows.Forms;
using MongoDB.Bson;
using PersonalFinanceManager.Controllers;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Forms
{
    public partial class AddAccountForm : Form
    {
        private readonly AccountController _accountController;
        private readonly string _username;

        public AddAccountForm(string username)
        {
            InitializeComponent();
            _username = username;
            _accountController = new AccountController();
            LoadAccountTypeComboBox();
        }

        private void LoadAccountTypeComboBox()
        {
            cmbAccountType.Items.AddRange(new string[] { "Checking", "Saving", "Credit Card", "Debit Card" });
        }

        private void btnSaveAccount_Click(object sender, EventArgs e)
        {
           
            var account = new Account
            
            {
                Id = txtAccNo.Text, 
                UserId = _username,
                Type = cmbAccountType.SelectedItem.ToString(),
                Balance = double.Parse(txtBalance.Text)
            };

            _accountController.AddAccount(account);
            MessageBox.Show("Account added successfully.");
            this.Close();
        }

        private void AddAccountForm_Load(object sender, EventArgs e)
        {

        }
    }
}
