using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PersonalFinanceManager.Controllers;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Forms
{
    public partial class ViewTransactionsForm : Form
    {
        private readonly TransactionController _transactionController;
        private readonly string _userName;

        public ViewTransactionsForm(string userName)
        {
            InitializeComponent();
            _userName = userName;
            _transactionController = new TransactionController();
            ApplyDataGridViewStyles();
        }

        private void ViewTransactionsForm_Load(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void LoadTransactions()
        {
            List<Transaction> transactions = _transactionController.GetTransactions(_userName);
            dgvTransactions.DataSource = transactions;
        }

        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ApplyDataGridViewStyles()
        {
            // Set alternating row styles for better readability
            dgvTransactions.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Set column headers style
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Set default cell style
            dgvTransactions.DefaultCellStyle.BackColor = Color.White;
            dgvTransactions.DefaultCellStyle.ForeColor = Color.DarkBlue;
            dgvTransactions.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue;
            dgvTransactions.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvTransactions.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            // Set row headers style
            dgvTransactions.RowHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;
            dgvTransactions.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTransactions.RowHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10);

            // Set grid color
            dgvTransactions.GridColor = Color.RoyalBlue;

            // Attach custom cell painting event
            this.dgvTransactions.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridViewTransactions_CellPainting);
        }

        private void dataGridViewTransactions_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                using (Brush gridBrush = new SolidBrush(this.dgvTransactions.GridColor),
                              backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        // Erase the cell background
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                        // Draw the grid lines
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                            e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top,
                            e.CellBounds.Right - 1, e.CellBounds.Bottom);

                        // Draw the text content
                        if (e.Value != null)
                        {
                            e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font,
                                Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 2,
                                StringFormat.GenericDefault);
                        }
                        e.Handled = true;
                    }
                }
            }
        }
    }
}
