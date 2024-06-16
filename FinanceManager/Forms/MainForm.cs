using System.Drawing.Drawing2D;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using PersonalFinanceManager.Models;
using System.Windows.Forms;
using PersonalFinanceManager.Controllers;
using System.Windows.Forms.DataVisualization.Charting;
using MongoDB.Driver;
using PersonalFinanceManager.Utils;


namespace PersonalFinanceManager.Forms
{
    public partial class MainForm : Form
    {
        private readonly string _username;
        private AccountController _accountController;
        private BudgetController _budgetController;
        private TransactionController _transactionController;

        public MainForm(string username)
        {
            InitializeComponent();
            _username = username;
            _accountController = new AccountController();
            _budgetController = new BudgetController();
            _transactionController = new TransactionController();
            LoadBudgetCharts();
            PopulateAccountCards();
            ApplyCustomTheme();
            this.BackColor = Color.LightBlue; 
            this.Font = new Font("Segoe UI", 10);
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {

        }


        private void LoadBudgetCharts()
        {
            var totalBudgets = _budgetController.GetTotalBudgetsByCategory(_username);
            var spentAmounts = _budgetController.GetSpentAmountsByCategory(_username);

            // Load Remaining Budgets Chart
            var remainingBudgets = totalBudgets.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value - (spentAmounts.ContainsKey(kvp.Key) ? spentAmounts[kvp.Key] : 0)
            );

            chartRemainingBudgets.Series.Clear();
            var seriesRemaining = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "RemainingBudgets",
                IsValueShownAsLabel = true,
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
            };
            chartRemainingBudgets.Series.Add(seriesRemaining);
            foreach (var item in remainingBudgets)
            {
                seriesRemaining.Points.AddXY(item.Key, item.Value);
            }

            // Load Spent Budgets Chart
            chartSpentBudgets.Series.Clear();
            var seriesSpent = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "SpentBudgets",
                IsValueShownAsLabel = true,
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
            };
            chartSpentBudgets.Series.Add(seriesSpent);
            foreach (var item in spentAmounts)
            {
                seriesSpent.Points.AddXY(item.Key, item.Value);
            }
            chartRemainingBudgets.Invalidate();
            chartSpentBudgets.Invalidate();
        }

        private void PopulateAccountCards()
        {
            var accounts = _accountController.GetAccountsByUserId(_username);

            this.panelAccounts.Controls.Clear();

            int yOffset = 10;
            foreach (var account in accounts)
            {
                Panel card = new Panel
                {
                    Size = new Size(250, 100),
                    Location = new Point(10, yOffset),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.LightGray // You can customize the style
                };

                Label lblAccountType = new Label
                {
                    Text = $"Type: {account.Type}",
                    Location = new Point(10, 10)
                };
                card.Controls.Add(lblAccountType);

                Label lblAccountBalance = new Label
                {
                    Text = $"Balance: {account.Balance}",
                    Location = new Point(10, 40)
                };
                card.Controls.Add(lblAccountBalance);

                this.panelAccounts.Controls.Add(card);
                yOffset += 110; // Adjust offset for the next card
            }
        }

        

        private void ApplyCustomTheme()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    Button button = control as Button;
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = Color.CornflowerBlue;
                    button.ForeColor = Color.White;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseOverBackColor = Color.RoyalBlue;
                    button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
                else if (control is ComboBox)
                {
                    ComboBox comboBox = control as ComboBox;
                    comboBox.BackColor = Color.White;
                    comboBox.ForeColor = Color.DarkBlue;
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
                else if (control is TextBox)
                {
                    TextBox textBox = control as TextBox;
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Color.DarkBlue;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.DarkBlue, 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void chartBudgetProgress_Click(object sender, System.EventArgs e)
        {

        }

        private void chartRemainingBudgets_Click(object sender, EventArgs e)
        {

        }
    }
}
