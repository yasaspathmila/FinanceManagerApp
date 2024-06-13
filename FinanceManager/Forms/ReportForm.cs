using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PersonalFinanceManager.Models;
using OfficeOpenXml;
using System.IO;
using PersonalFinanceManager.Controllers;

namespace PersonalFinanceManager.Forms
{
    public partial class ReportForm : Form
    {
        private List<Transaction> _transactions;
        private List<Account> _accounts;
        private AccountController _accountController;
        private TransactionController _transactionController;
        private readonly string _userName;

        public ReportForm(string userName,List<Transaction> transactions, List<Account> accounts)
        {
            _userName  = userName;
            _transactions = transactions;
            _accounts = accounts;
            _accountController = new AccountController();
            _transactionController = new TransactionController();
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            // Combine transactions and accounts data into a DataTable 
            var transactionsTable = new DataTable();
            transactionsTable.Columns.Add("Date");
            transactionsTable.Columns.Add("Category");
            transactionsTable.Columns.Add("Amount");
            transactionsTable.Columns.Add("Type");
            transactionsTable.Columns.Add("Account No");
            transactionsTable.Columns.Add("Payee");

            foreach (var transaction in _transactions)
            {
                var account = _accounts.FirstOrDefault(a => a.Id == transaction.AccountId);
                if (account != null)
                {
                    transactionsTable.Rows.Add(transaction.Date, transaction.Category, transaction.Amount, transaction.Type, transaction.AccountId, transaction.Payee);
                }
            }

            dgvTransactions.DataSource = transactionsTable;

            // Load accounts into dgvAccounts
            var accountsTable = new DataTable();
            accountsTable.Columns.Add("Account Type");
            accountsTable.Columns.Add("Balance");

            foreach (var account in _accounts)
            {
                accountsTable.Rows.Add(account.Type, account.Balance);
            }

            dgvAccounts.DataSource = accountsTable;
        }

        private void ExportToExcel()
        {
            
            var userAccounts = _accountController.GetAccountsByUserId(_userName);
            var userTransactions = _transactionController.GetTransactions(_userName);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                // Add a worksheet for accounts
                var accountsSheet = package.Workbook.Worksheets.Add("Accounts");
                accountsSheet.Cells[1, 1].Value = "Type";
                accountsSheet.Cells[1, 2].Value = "Balance";

                for (int i = 0; i < userAccounts.Count; i++)
                {
                    accountsSheet.Cells[i + 2, 1].Value = userAccounts[i].Type;
                    accountsSheet.Cells[i + 2, 2].Value = userAccounts[i].Balance;
                }

                // Add a worksheet for transactions
                var transactionsSheet = package.Workbook.Worksheets.Add("Transactions");
                transactionsSheet.Cells[1, 1].Value = "Date";
                transactionsSheet.Cells[1, 2].Value = "Category";
                transactionsSheet.Cells[1, 3].Value = "Amount";
                transactionsSheet.Cells[1, 4].Value = "Type";

                for (int i = 0; i < userTransactions.Count; i++)
                {
                    transactionsSheet.Cells[i + 2, 1].Value = userTransactions[i].Date;
                    transactionsSheet.Cells[i + 2, 1].Style.Numberformat.Format = "yyyy-mm-dd";
                    transactionsSheet.Cells[i + 2, 2].Value = userTransactions[i].Category;
                    transactionsSheet.Cells[i + 2, 3].Value = userTransactions[i].Amount;
                    transactionsSheet.Cells[i + 2, 4].Value = userTransactions[i].Type;
                }

                // Save the Excel file
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "FinancialReport.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                    package.SaveAs(fileInfo);
                }
            }
        }

        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void ReportForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}
