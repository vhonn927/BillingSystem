namespace BillingSystem
{
    partial class frmBillingHistory
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblCustomerName = new Label();
            dgvBilling = new DataGridView();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBilling).BeginInit();
            SuspendLayout();
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerName.Location = new Point(20, 15);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(160, 25);
            lblCustomerName.TabIndex = 0;
            lblCustomerName.Text = "Billing History";
            // 
            // dgvBilling
            // 
            dgvBilling.AllowUserToAddRows = false;
            dgvBilling.AllowUserToDeleteRows = false;
            dgvBilling.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBilling.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBilling.Location = new Point(20, 55);
            dgvBilling.Name = "dgvBilling";
            dgvBilling.ReadOnly = true;
            dgvBilling.RowHeadersVisible = false;
            dgvBilling.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBilling.Size = new Size(740, 300);
            dgvBilling.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(660, 370);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 30);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmBillingHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(784, 421);
            Controls.Add(btnClose);
            Controls.Add(dgvBilling);
            Controls.Add(lblCustomerName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBillingHistory";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Billing History";
            Shown += frmBillingHistory_Shown;
            ((System.ComponentModel.ISupportInitialize)dgvBilling).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCustomerName;
        private DataGridView dgvBilling;
        private Button btnClose;
    }
}