using System;
using System.Windows.Forms.DataVisualization.Charting;
using MongoDB.Bson;
using PersonalFinanceManager.Models;



namespace PersonalFinanceManager.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewTransactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem budgetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBudgetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAccountToolStripMenuItem;
        private System.Windows.Forms.Panel panelAccounts;
        private System.Windows.Forms.Label lblRemainingBudget;
        private System.Windows.Forms.Label lblTotalSpent;
        private System.Windows.Forms.Label lblAccDetail;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRemainingBudgets;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSpentBudgets;
        private System.Windows.Forms.Button btnViewReports;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.budgetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBudgetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewReports = new System.Windows.Forms.Button();
            this.chartRemainingBudgets = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSpentBudgets = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelAccounts = new System.Windows.Forms.Panel();
            this.lblRemainingBudget = new System.Windows.Forms.Label();
            this.lblTotalSpent = new System.Windows.Forms.Label();
            this.lblAccDetail = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRemainingBudgets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSpentBudgets)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transactionsToolStripMenuItem,
            this.budgetToolStripMenuItem,
            this.accountsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1180, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewTransactionsToolStripMenuItem,
            this.addTransactionToolStripMenuItem});
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            // 
            // viewTransactionsToolStripMenuItem
            // 
            this.viewTransactionsToolStripMenuItem.Name = "viewTransactionsToolStripMenuItem";
            this.viewTransactionsToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.viewTransactionsToolStripMenuItem.Text = "View Transactions";
            this.viewTransactionsToolStripMenuItem.Click += new System.EventHandler(this.viewTransactionsToolStripMenuItem_Click);
            // 
            // addTransactionToolStripMenuItem
            // 
            this.addTransactionToolStripMenuItem.Name = "addTransactionToolStripMenuItem";
            this.addTransactionToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.addTransactionToolStripMenuItem.Text = "Add Transaction";
            this.addTransactionToolStripMenuItem.Click += new System.EventHandler(this.addTransactionToolStripMenuItem_Click);
            // 
            // budgetToolStripMenuItem
            // 
            this.budgetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBudgetToolStripMenuItem});
            this.budgetToolStripMenuItem.Name = "budgetToolStripMenuItem";
            this.budgetToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.budgetToolStripMenuItem.Text = "Budget";
            // 
            // addBudgetToolStripMenuItem
            // 
            this.addBudgetToolStripMenuItem.Name = "addBudgetToolStripMenuItem";
            this.addBudgetToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.addBudgetToolStripMenuItem.Text = "Add Budget";
            this.addBudgetToolStripMenuItem.Click += new System.EventHandler(this.addBudgetToolStripMenuItem_Click);
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAccountToolStripMenuItem});
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.accountsToolStripMenuItem.Text = "Accounts";
            // 
            // addAccountToolStripMenuItem
            // 
            this.addAccountToolStripMenuItem.Name = "addAccountToolStripMenuItem";
            this.addAccountToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.addAccountToolStripMenuItem.Text = "Add Account";
            this.addAccountToolStripMenuItem.Click += new System.EventHandler(this.addAccountToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem});
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // btnViewReports
            // 
            this.btnViewReports.Location = new System.Drawing.Point(528, 436);
            this.btnViewReports.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewReports.Name = "btnViewReports";
            this.btnViewReports.Size = new System.Drawing.Size(173, 36);
            this.btnViewReports.TabIndex = 1;
            this.btnViewReports.Text = "View Reports";
            this.btnViewReports.UseVisualStyleBackColor = true;
            this.btnViewReports.Click += new System.EventHandler(this.btnViewReports_Click);
            // 
            // chartRemainingBudgets
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRemainingBudgets.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartRemainingBudgets.Legends.Add(legend1);
            this.chartRemainingBudgets.Location = new System.Drawing.Point(465, 100);
            this.chartRemainingBudgets.Name = "chartRemainingBudgets";
            this.chartRemainingBudgets.Size = new System.Drawing.Size(300, 300);
            this.chartRemainingBudgets.TabIndex = 1;
            this.chartRemainingBudgets.Text = "Remaining Budgets";
            this.chartRemainingBudgets.Click += new System.EventHandler(this.chartRemainingBudgets_Click);
            // 
            // chartSpentBudgets
            // 
            chartArea2.Name = "ChartArea1";
            this.chartSpentBudgets.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartSpentBudgets.Legends.Add(legend2);
            this.chartSpentBudgets.Location = new System.Drawing.Point(817, 100);
            this.chartSpentBudgets.Name = "chartSpentBudgets";
            this.chartSpentBudgets.Size = new System.Drawing.Size(300, 300);
            this.chartSpentBudgets.TabIndex = 2;
            this.chartSpentBudgets.Text = "Spent Budgets";
            // 
            // panelAccounts
            // 
            this.panelAccounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAccounts.Location = new System.Drawing.Point(50, 118);
            this.panelAccounts.Name = "panelAccounts";
            this.panelAccounts.Size = new System.Drawing.Size(365, 282);
            this.panelAccounts.TabIndex = 3;
            // 
            // lblRemainingBudget
            // 
            this.lblRemainingBudget.AutoSize = true;
            this.lblRemainingBudget.Location = new System.Drawing.Point(555, 366);
            this.lblRemainingBudget.Name = "lblRemainingBudget";
            this.lblRemainingBudget.Size = new System.Drawing.Size(118, 16);
            this.lblRemainingBudget.TabIndex = 4;
            this.lblRemainingBudget.Text = "Remaining Budget";
            // 
            // lblTotalSpent
            // 
            this.lblTotalSpent.AutoSize = true;
            this.lblTotalSpent.Location = new System.Drawing.Point(931, 366);
            this.lblTotalSpent.Name = "lblTotalSpent";
            this.lblTotalSpent.Size = new System.Drawing.Size(124, 16);
            this.lblTotalSpent.TabIndex = 5;
            this.lblTotalSpent.Text = "Total Spent Amount";
            // 
            // lblAccDetail
            // 
            this.lblAccDetail.AutoSize = true;
            this.lblAccDetail.Location = new System.Drawing.Point(150, 99);
            this.lblAccDetail.Name = "lblAccDetail";
            this.lblAccDetail.Size = new System.Drawing.Size(134, 16);
            this.lblAccDetail.TabIndex = 6;
            this.lblAccDetail.Text = "Bank Account Details";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 554);
            this.Controls.Add(this.lblAccDetail);
            this.Controls.Add(this.lblTotalSpent);
            this.Controls.Add(this.lblRemainingBudget);
            this.Controls.Add(this.btnViewReports);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.chartRemainingBudgets);
            this.Controls.Add(this.chartSpentBudgets);
            this.Controls.Add(this.panelAccounts);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRemainingBudgets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSpentBudgets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewTransactionsForm = new ViewTransactionsForm(_username);
            viewTransactionsForm.Show();
        }

        private void addTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var transactionForm = new TransactionForm(_username);
            transactionForm.TransactionSaved += AddTransactionForm_TransactionSaved;
            transactionForm.Show();
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            var accounts = _accountController.GetAccountsByUserId(_username);
            var transactions = _transactionController.GetTransactions(_username);

            var reportForm = new ReportForm(_username,transactions, accounts);
            reportForm.Show();
        }

        private void addBudgetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addBudgetForm = new AddBudgetForm(_username);
            addBudgetForm.budgetSaved += AddBudgetForm_budgetSaved;
            addBudgetForm.Show();
        }

        private void addAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addAccountForm = new AddAccountForm(_username);
            addAccountForm.Show();
        }

        private void AddTransactionForm_TransactionSaved(object sender, EventArgs e)
        {
            LoadBudgetCharts();
        }

        private void AddBudgetForm_budgetSaved(object sender, EventArgs e)
        {
            LoadBudgetCharts();
        }

    }
}
