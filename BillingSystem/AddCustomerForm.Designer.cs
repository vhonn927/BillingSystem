namespace BillingSystem
{
    partial class AddCustomerForm
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
            lblFullName = new Label();
            lblAddress = new Label();
            lblContact = new Label();
            lblEmail = new Label();
            lblBalance = new Label();
            txtBalance = new TextBox();
            txtEmail = new TextBox();
            txtContact = new TextBox();
            txtFullName = new TextBox();
            txtAddress = new TextBox();
            btnBack = new Button();
            btnClear = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(159, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(195, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New Customer";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(101, 93);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(83, 20);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Full Name: ";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(101, 132);
            lblAddress.Name = "lblAddress";
            lblAddress.RightToLeft = RightToLeft.No;
            lblAddress.Size = new Size(65, 20);
            lblAddress.TabIndex = 2;
            lblAddress.Text = "Address:";
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Location = new Point(101, 171);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(121, 20);
            lblContact.TabIndex = 3;
            lblContact.Text = "Contact Number:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(101, 209);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(101, 248);
            lblBalance.Name = "lblBalance";
            lblBalance.RightToLeft = RightToLeft.No;
            lblBalance.Size = new Size(105, 20);
            lblBalance.TabIndex = 5;
            lblBalance.Text = "Initial Balance:";
            // 
            // txtBalance
            // 
            txtBalance.Location = new Point(235, 237);
            txtBalance.Margin = new Padding(3, 4, 3, 4);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(161, 27);
            txtBalance.TabIndex = 6;
            txtBalance.Text = "0.00";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(235, 199);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(161, 27);
            txtEmail.TabIndex = 7;
            // 
            // txtContact
            // 
            txtContact.Location = new Point(235, 160);
            txtContact.Margin = new Padding(3, 4, 3, 4);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(161, 27);
            txtContact.TabIndex = 8;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(235, 83);
            txtFullName.Margin = new Padding(3, 4, 3, 4);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(161, 27);
            txtFullName.TabIndex = 9;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(235, 121);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(161, 27);
            txtAddress.TabIndex = 10;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(298, 309);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(86, 31);
            btnBack.TabIndex = 11;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(206, 309);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(86, 31);
            btnClear.TabIndex = 12;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(113, 309);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(86, 31);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // AddCustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 508);
            Controls.Add(btnSave);
            Controls.Add(btnClear);
            Controls.Add(btnBack);
            Controls.Add(txtAddress);
            Controls.Add(txtFullName);
            Controls.Add(txtContact);
            Controls.Add(txtEmail);
            Controls.Add(txtBalance);
            Controls.Add(lblBalance);
            Controls.Add(lblEmail);
            Controls.Add(lblContact);
            Controls.Add(lblAddress);
            Controls.Add(lblFullName);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "AddCustomerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Billing System v1.0 - Add Customer (V.I.)";
            Load += AddCustomerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblFullName;
        private Label lblAddress;
        private Label lblContact;
        private Label lblEmail;
        private Label lblBalance;
        private TextBox txtBalance;
        private TextBox txtEmail;
        private TextBox txtContact;
        private TextBox txtFullName;
        private TextBox txtAddress;
        private Button btnBack;
        private Button btnClear;
        private Button btnSave;
    }
}