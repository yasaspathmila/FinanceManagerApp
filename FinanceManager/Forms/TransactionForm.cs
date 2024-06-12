using PersonalFinanceManager.Controllers;
using System;
using System.Windows.Forms;
using PersonalFinanceManager.Models;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;

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
            ApplyCustomTheme();
            this.BackColor = Color.LawnGreen; // Set form background color
            this.Font = new Font("Segoe UI", 9);

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
                // Apply similar styles to other controls as needed
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
