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
            lblTitle = new Label();
            lblCurrent = new Label();
            txtCurrentPassword = new TextBox();
            lblNew = new Label();
            txtNewPassword = new TextBox();
            lblRetype = new Label();
            txtRetypePassword = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(107, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(144, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Change Password";
            // 
            // lblCurrent
            // 
            lblCurrent.AutoSize = true;
            lblCurrent.Location = new Point(53, 63);
            lblCurrent.Name = "lblCurrent";
            lblCurrent.Size = new Size(103, 15);
            lblCurrent.TabIndex = 1;
            lblCurrent.Text = "Current Password:";
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(176, 60);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(125, 23);
            txtCurrentPassword.TabIndex = 2;
            txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // lblNew
            // 
            lblNew.AutoSize = true;
            lblNew.Location = new Point(53, 106);
            lblNew.Name = "lblNew";
            lblNew.Size = new Size(87, 15);
            lblNew.TabIndex = 3;
            lblNew.Text = "New Password:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(176, 103);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(125, 23);
            txtNewPassword.TabIndex = 4;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // lblRetype
            // 
            lblRetype.AutoSize = true;
            lblRetype.Location = new Point(53, 149);
            lblRetype.Name = "lblRetype";
            lblRetype.Size = new Size(99, 15);
            lblRetype.TabIndex = 5;
            lblRetype.Text = "Retype Password:";
            // 
            // txtRetypePassword
            // 
            txtRetypePassword.Location = new Point(176, 146);
            txtRetypePassword.Name = "txtRetypePassword";
            txtRetypePassword.Size = new Size(125, 23);
            txtRetypePassword.TabIndex = 6;
            txtRetypePassword.UseSystemPasswordChar = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(81, 195);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save Password";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(191, 195);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // frmChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 240);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtRetypePassword);
            Controls.Add(lblRetype);
            Controls.Add(txtNewPassword);
            Controls.Add(lblNew);
            Controls.Add(txtCurrentPassword);
            Controls.Add(lblCurrent);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmChangePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Change Password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCurrent;
        private TextBox txtCurrentPassword;
        private Label lblNew;
        private TextBox txtNewPassword;
        private Label lblRetype;
        private TextBox txtRetypePassword;
        private Button btnSave;
        private Button btnCancel;
    }
}