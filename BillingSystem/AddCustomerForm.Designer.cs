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
            lblTitle.Location = new Point(139, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(157, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New Customer";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(88, 70);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(67, 15);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Full Name: ";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(88, 99);
            lblAddress.Name = "lblAddress";
            lblAddress.RightToLeft = RightToLeft.No;
            lblAddress.Size = new Size(52, 15);
            lblAddress.TabIndex = 2;
            lblAddress.Text = "Address:";
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Location = new Point(88, 128);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(99, 15);
            lblContact.TabIndex = 3;
            lblContact.Text = "Contact Number:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(88, 157);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(88, 186);
            lblBalance.Name = "lblBalance";
            lblBalance.RightToLeft = RightToLeft.No;
            lblBalance.Size = new Size(83, 15);
            lblBalance.TabIndex = 5;
            lblBalance.Text = "Initial Balance:";
            // 
            // txtBalance
            // 
            txtBalance.Location = new Point(206, 178);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(141, 23);
            txtBalance.TabIndex = 6;
            txtBalance.Text = "0.00";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(206, 149);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(141, 23);
            txtEmail.TabIndex = 7;
            // 
            // txtContact
            // 
            txtContact.Location = new Point(206, 120);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(141, 23);
            txtContact.TabIndex = 8;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(206, 62);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(141, 23);
            txtFullName.TabIndex = 9;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(206, 91);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(141, 23);
            txtAddress.TabIndex = 10;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(261, 232);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 11;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(180, 232);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 12;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(99, 232);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // AddCustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 381);
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
            MaximizeBox = false;
            Name = "AddCustomerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Billing System v1.0 - Add Customer (V.I.)";
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