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
            lblCurrent = new Label();
            txtCurrentPassword = new TextBox();
            txtNewPassword = new TextBox();
            lblNew = new Label();
            lblRetype = new Label();
            txtRetypePassword = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblChangePass = new Label();
            SuspendLayout();
            // 
            // lblCurrent
            // 
            lblCurrent.AutoSize = true;
            lblCurrent.Location = new Point(35, 111);
            lblCurrent.Name = "lblCurrent";
            lblCurrent.Size = new Size(129, 20);
            lblCurrent.TabIndex = 0;
            lblCurrent.Text = "Current Password: ";
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(164, 104);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(233, 27);
            txtCurrentPassword.TabIndex = 1;
            txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(164, 140);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(233, 27);
            txtNewPassword.TabIndex = 2;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // lblNew
            // 
            lblNew.AutoSize = true;
            lblNew.Location = new Point(35, 143);
            lblNew.Name = "lblNew";
            lblNew.Size = new Size(111, 20);
            lblNew.TabIndex = 3;
            lblNew.Text = "New Password: ";
            // 
            // lblRetype
            // 
            lblRetype.AutoSize = true;
            lblRetype.Location = new Point(35, 173);
            lblRetype.Name = "lblRetype";
            lblRetype.Size = new Size(123, 20);
            lblRetype.TabIndex = 4;
            lblRetype.Text = "Retype Password:";
            // 
            // txtRetypePassword
            // 
            txtRetypePassword.Location = new Point(164, 173);
            txtRetypePassword.Name = "txtRetypePassword";
            txtRetypePassword.Size = new Size(233, 27);
            txtRetypePassword.TabIndex = 5;
            txtRetypePassword.UseSystemPasswordChar = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(88, 264);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save Password";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(258, 264);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblChangePass
            // 
            lblChangePass.AutoSize = true;
            lblChangePass.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChangePass.Location = new Point(88, 9);
            lblChangePass.Name = "lblChangePass";
            lblChangePass.Size = new Size(264, 41);
            lblChangePass.TabIndex = 8;
            lblChangePass.Text = "Change Password";
            // 
            // frmChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 348);
            Controls.Add(lblChangePass);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtRetypePassword);
            Controls.Add(lblRetype);
            Controls.Add(lblNew);
            Controls.Add(txtNewPassword);
            Controls.Add(txtCurrentPassword);
            Controls.Add(lblCurrent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmChangePassword";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Change Password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCurrent;
        private TextBox txtCurrentPassword;
        private TextBox txtNewPassword;
        private Label lblNew;
        private Label lblRetype;
        private TextBox txtRetypePassword;
        private Button btnSave;
        private Button btnCancel;
        private Label lblChangePass;
    }
}