using System;
using MongoDB.Bson;

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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.budgetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBudgetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewReports = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
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
            this.menuStrip.Size = new System.Drawing.Size(1067, 28);
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
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem});
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
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
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.accountsToolStripMenuItem.Text = "Accounts";
            // 
            // addAccountToolStripMenuItem
            // 
            this.addAccountToolStripMenuItem.Name = "addAccountToolStripMenuItem";
            this.addAccountToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.addAccountToolStripMenuItem.Text = "Add Account";
            this.addAccountToolStripMenuItem.Click += new System.EventHandler(this.addAccountToolStripMenuItem_Click);
            // 
            // btnViewReports
            // 
            this.btnViewReports.Location = new System.Drawing.Point(166, 43);
            this.btnViewReports.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewReports.Name = "btnViewReports";
            this.btnViewReports.Size = new System.Drawing.Size(100, 28);
            this.btnViewReports.TabIndex = 1;
            this.btnViewReports.Text = "View Reports";
            this.btnViewReports.UseVisualStyleBackColor = true;
            this.btnViewReports.Click += new System.EventHandler(this.btnViewReports_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnViewReports);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
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
            transactionForm.Show();
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            var reportForm = new ReportForm();
            reportForm.Show();
        }

        private void addBudgetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addBudgetForm = new AddBudgetForm(_username);
            addBudgetForm.Show();
        }

        private void addAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addAccountForm = new AddAccountForm(_username);
            addAccountForm.Show();
        }
    }
}
