namespace PersonalFinanceManager.Forms
{
    partial class AddAccountForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtAccNo;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.ComboBox cmbAccountType;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Button btnSaveAccount;
        private System.Windows.Forms.Label lblAccNo;

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
            this.lblAccountType = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.cmbAccountType = new System.Windows.Forms.ComboBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.btnSaveAccount = new System.Windows.Forms.Button();
            this.lblAccNo = new System.Windows.Forms.Label();
            this.txtAccNo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Location = new System.Drawing.Point(29, 72);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(90, 16);
            this.lblAccountType.TabIndex = 0;
            this.lblAccountType.Text = "Account Type";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(29, 113);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(102, 16);
            this.lblBalance.TabIndex = 1;
            this.lblBalance.Text = "Current Balance";
            // 
            // cmbAccountType
            // 
            this.cmbAccountType.FormattingEnabled = true;
            this.cmbAccountType.Location = new System.Drawing.Point(147, 69);
            this.cmbAccountType.Name = "cmbAccountType";
            this.cmbAccountType.Size = new System.Drawing.Size(175, 24);
            this.cmbAccountType.TabIndex = 2;
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(147, 110);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(175, 22);
            this.txtBalance.TabIndex = 3;
            // 
            // btnSaveAccount
            // 
            this.btnSaveAccount.Location = new System.Drawing.Point(147, 151);
            this.btnSaveAccount.Name = "btnSaveAccount";
            this.btnSaveAccount.Size = new System.Drawing.Size(175, 23);
            this.btnSaveAccount.TabIndex = 4;
            this.btnSaveAccount.Text = "Save Account";
            this.btnSaveAccount.UseVisualStyleBackColor = true;
            this.btnSaveAccount.Click += new System.EventHandler(this.btnSaveAccount_Click);
            // 
            // lblAccNo
            // 
            this.lblAccNo.AutoSize = true;
            this.lblAccNo.Location = new System.Drawing.Point(29, 34);
            this.lblAccNo.Name = "lblAccNo";
            this.lblAccNo.Size = new System.Drawing.Size(44, 16);
            this.lblAccNo.TabIndex = 5;
            this.lblAccNo.Text = "Account Number";
            // 
            // txtAccNo
            // 
            this.txtAccNo.Location = new System.Drawing.Point(147, 31);
            this.txtAccNo.Name = "txtAccNo";
            this.txtAccNo.Size = new System.Drawing.Size(175, 22);
            this.txtAccNo.TabIndex = 6;
            // 
            // AddAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 196);
            this.Controls.Add(this.txtAccNo);
            this.Controls.Add(this.lblAccNo);
            this.Controls.Add(this.btnSaveAccount);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.cmbAccountType);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblAccountType);
            this.Name = "AddAccountForm";
            this.Text = "AddAccountForm";
            this.Load += new System.EventHandler(this.AddAccountForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
    }
}
