namespace BillingSystem
{
    partial class frmChangePassword
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
            lblChangePassword = new Label();
            lblNewPassword = new Label();
            label2 = new Label();
            lblRetypePassword = new Label();
            txtRetypePassword = new TextBox();
            txtNewPassword = new TextBox();
            txtCurrentPassword = new TextBox();
            btnSavePassword = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblChangePassword
            // 
            lblChangePassword.AutoSize = true;
            lblChangePassword.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChangePassword.Location = new Point(181, 40);
            lblChangePassword.Name = "lblChangePassword";
            lblChangePassword.Size = new Size(161, 25);
            lblChangePassword.TabIndex = 0;
            lblChangePassword.Text = "Change Password";
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new Point(68, 146);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(87, 15);
            lblNewPassword.TabIndex = 1;
            lblNewPassword.Text = "New Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 100);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 2;
            label2.Text = "Current Password:";
            // 
            // lblRetypePassword
            // 
            lblRetypePassword.AutoSize = true;
            lblRetypePassword.Location = new Point(68, 196);
            lblRetypePassword.Name = "lblRetypePassword";
            lblRetypePassword.Size = new Size(99, 15);
            lblRetypePassword.TabIndex = 3;
            lblRetypePassword.Text = "Retype Password:";
            // 
            // txtRetypePassword
            // 
            txtRetypePassword.Location = new Point(206, 196);
            txtRetypePassword.Name = "txtRetypePassword";
            txtRetypePassword.Size = new Size(252, 23);
            txtRetypePassword.TabIndex = 4;
            txtRetypePassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(206, 143);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(252, 23);
            txtNewPassword.TabIndex = 5;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(206, 97);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(252, 23);
            txtCurrentPassword.TabIndex = 6;
            txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // btnSavePassword
            // 
            btnSavePassword.Location = new Point(116, 287);
            btnSavePassword.Name = "btnSavePassword";
            btnSavePassword.Size = new Size(135, 23);
            btnSavePassword.TabIndex = 7;
            btnSavePassword.Text = "Save Password";
            btnSavePassword.UseVisualStyleBackColor = true;
            btnSavePassword.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(312, 287);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(516, 381);
            Controls.Add(btnCancel);
            Controls.Add(btnSavePassword);
            Controls.Add(txtCurrentPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(txtRetypePassword);
            Controls.Add(lblRetypePassword);
            Controls.Add(label2);
            Controls.Add(lblNewPassword);
            Controls.Add(lblChangePassword);
            Name = "frmChangePassword";
            Text = "frmChangePassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblChangePassword;
        private Label lblNewPassword;
        private Label label2;
        private Label lblRetypePassword;
        private TextBox txtRetypePassword;
        private TextBox txtNewPassword;
        private TextBox txtCurrentPassword;
        private Button btnSavePassword;
        private Button btnCancel;
    }
}