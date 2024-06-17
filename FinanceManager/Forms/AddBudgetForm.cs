using MongoDB.Bson;
using PersonalFinanceManager.Controllers;
using PersonalFinanceManager.Models;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PersonalFinanceManager.Forms
{
    public partial class AddBudgetForm : Form
    {
        private readonly string _username;
        private readonly BudgetController _budgetController;
        public event EventHandler budgetSaved;

        public AddBudgetForm(string username)
        {
            InitializeComponent();
            _username = username;
            _budgetController = new BudgetController();
            ApplyCustomTheme();
            this.BackColor = Color.LawnGreen; 
            this.Font = new Font("Segoe UI", 9);
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
            budgetSaved?.Invoke(this, EventArgs.Empty);
            MessageBox.Show("Budget added successfully.");
            this.Close();
        }

        private void AddBudgetForm_Load(object sender, EventArgs e)
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
