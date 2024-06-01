namespace PersonalFinanceManager.Forms
{
    partial class TransactionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtAccountId;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtPayee;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnSaveTransaction;

        private void InitializeComponent()
        {
            this.txtAccountId = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnSaveTransaction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAccountId
            // 
            this.txtAccountId.Location = new System.Drawing.Point(120, 30);
            this.txtAccountId.Name = "txtAccountId";
            this.txtAccountId.Size = new System.Drawing.Size(100, 20);
            this.txtAccountId.TabIndex = 0;
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(120, 60);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 21);
            this.cmbType.TabIndex = 1;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(120, 90);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 2;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(120, 120);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 21);
            this.cmbCategory.TabIndex = 3;
            // 
            // txtPayee
            // 
            this.txtPayee.Location = new System.Drawing.Point(120, 150);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.Size = new System.Drawing.Size(100, 20);
            this.txtPayee.TabIndex = 4;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(120, 180);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 5;
            // 
            // btnSaveTransaction
            // 
            this.btnSaveTransaction.Location = new System.Drawing.Point(120, 210);
            this.btnSaveTransaction.Name = "btnSaveTransaction";
            this.btnSaveTransaction.Size = new System.Drawing.Size(100, 23);
            this.btnSaveTransaction.TabIndex = 6;
            this.btnSaveTransaction.Text = "Save";
            this.btnSaveTransaction.UseVisualStyleBackColor = true;
            this.btnSaveTransaction.Click += new System.EventHandler(this.btnSaveTransaction_Click);
            // 
            // TransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSaveTransaction);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtPayee);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.txtAccountId);
            this.Name = "TransactionForm";
            this.Text = "TransactionForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
