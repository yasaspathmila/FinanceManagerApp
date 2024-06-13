using System;
using System.Drawing.Drawing2D;
using System.Drawing;
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
            ApplyCustomTheme();
            this.BackColor = Color.LawnGreen; 
            this.Font = new Font("Segoe UI", 9);
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

        private void ApplyCustomTheme()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    Button button = control as Button;
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = Color.DarkGreen;
                    button.ForeColor = Color.White;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseOverBackColor = Color.ForestGreen;
                    button.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
                else if (control is ComboBox)
                {
                    ComboBox comboBox = control as ComboBox;
                    comboBox.BackColor = Color.White;
                    comboBox.ForeColor = Color.Green;
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
                else if (control is TextBox)
                {
                    TextBox textBox = control as TextBox;
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Color.Green;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.LightGreen, Color.DarkOliveGreen, 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
