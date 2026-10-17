namespace BillingSystem
{
    partial class frmManagePermissions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblRole = new Label();
            cmbRole = new ComboBox();
            chkAddCustomer = new CheckBox();
            chkEditCustomer = new CheckBox();
            chkDeleteCustomer = new CheckBox();
            chkAnalytics = new CheckBox();
            chkExportExcel = new CheckBox();
            chkExportPdf = new CheckBox();
            chkAuditLogs = new CheckBox();
            btnClose = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(130, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(167, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Manage Permissions";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(84, 82);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(67, 15);
            lblRole.TabIndex = 1;
            lblRole.Text = "Select Role:";
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Admin", "Cashier" });
            cmbRole.Location = new Point(157, 79);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(164, 23);
            cmbRole.TabIndex = 2;
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;
            // 
            // chkAddCustomer
            // 
            chkAddCustomer.AutoSize = true;
            chkAddCustomer.Location = new Point(60, 154);
            chkAddCustomer.Name = "chkAddCustomer";
            chkAddCustomer.Size = new Size(103, 19);
            chkAddCustomer.TabIndex = 3;
            chkAddCustomer.Text = "Add Customer";
            chkAddCustomer.UseVisualStyleBackColor = true;
            // 
            // chkEditCustomer
            // 
            chkEditCustomer.AutoSize = true;
            chkEditCustomer.Location = new Point(60, 179);
            chkEditCustomer.Name = "chkEditCustomer";
            chkEditCustomer.Size = new Size(101, 19);
            chkEditCustomer.TabIndex = 4;
            chkEditCustomer.Text = "Edit Customer";
            chkEditCustomer.UseVisualStyleBackColor = true;
            // 
            // chkDeleteCustomer
            // 
            chkDeleteCustomer.AutoSize = true;
            chkDeleteCustomer.Location = new Point(60, 204);
            chkDeleteCustomer.Name = "chkDeleteCustomer";
            chkDeleteCustomer.Size = new Size(114, 19);
            chkDeleteCustomer.TabIndex = 5;
            chkDeleteCustomer.Text = "Delete Customer";
            chkDeleteCustomer.UseVisualStyleBackColor = true;
            // 
            // chkAnalytics
            // 
            chkAnalytics.AutoSize = true;
            chkAnalytics.Location = new Point(60, 229);
            chkAnalytics.Name = "chkAnalytics";
            chkAnalytics.Size = new Size(74, 19);
            chkAnalytics.TabIndex = 6;
            chkAnalytics.Text = "Analytics";
            chkAnalytics.UseVisualStyleBackColor = true;
            // 
            // chkExportExcel
            // 
            chkExportExcel.AutoSize = true;
            chkExportExcel.Location = new Point(60, 254);
            chkExportExcel.Name = "chkExportExcel";
            chkExportExcel.Size = new Size(102, 19);
            chkExportExcel.TabIndex = 7;
            chkExportExcel.Text = "Export to Excel";
            chkExportExcel.UseVisualStyleBackColor = true;
            // 
            // chkExportPdf
            // 
            chkExportPdf.AutoSize = true;
            chkExportPdf.Location = new Point(60, 279);
            chkExportPdf.Name = "chkExportPdf";
            chkExportPdf.Size = new Size(97, 19);
            chkExportPdf.TabIndex = 8;
            chkExportPdf.Text = "Export to PDF";
            chkExportPdf.UseVisualStyleBackColor = true;
            // 
            // chkAuditLogs
            // 
            chkAuditLogs.AutoSize = true;
            chkAuditLogs.Location = new Point(60, 304);
            chkAuditLogs.Name = "chkAuditLogs";
            chkAuditLogs.Size = new Size(83, 19);
            chkAuditLogs.TabIndex = 10;
            chkAuditLogs.Text = "Audit Logs";
            chkAuditLogs.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(246, 344);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 11;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(84, 344);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 23);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save Permissions";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // frmManagePermissions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 421);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(chkAuditLogs);
            Controls.Add(chkExportPdf);
            Controls.Add(chkExportExcel);
            Controls.Add(chkAnalytics);
            Controls.Add(chkDeleteCustomer);
            Controls.Add(chkEditCustomer);
            Controls.Add(chkAddCustomer);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmManagePermissions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Permissions";
            Load += frmManagePermissions_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblRole;
        private ComboBox cmbRole;
        private CheckBox chkAddCustomer;
        private CheckBox chkEditCustomer;
        private CheckBox chkDeleteCustomer;
        private CheckBox chkAnalytics;
        private CheckBox chkExportExcel;
        private CheckBox chkExportPdf;
        private CheckBox chkAuditLogs;
        private Button btnClose;
        private Button btnSave;
    }
}