using System.Drawing.Drawing2D;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using PersonalFinanceManager.Models;
using System.Windows.Forms;
using PersonalFinanceManager.Controllers;
using System.Windows.Forms.DataVisualization.Charting;

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
            LoadData();
            ApplyCustomTheme();
            this.BackColor = Color.LightBlue; // Set form background color
            this.Font = new Font("Segoe UI", 10);
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {

        }

        private void LoadData()
        {
            LoadAccountBalances();
            LoadBudgetCharts();
        }

        private void LoadAccountBalances()
        {
            var accounts = _accountController.GetAccountsByUserId(_username);
            dataGridViewAccounts.DataSource = accounts.Select(a => new { a.Type, a.Balance }).ToList();
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
    }
}
