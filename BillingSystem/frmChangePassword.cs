using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using MySql.Data.MySqlClient;
using BillingSystem.Database;
using BillingSystem.Utils;

namespace BillingSystem
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            // Apply centralized theme colors
            this.BackColor = AppTheme.BackgroundColor;
            btnSave.BackColor = AppTheme.SuccessColor;
            btnSave.ForeColor = System.Drawing.Color.White;
            btnCancel.BackColor = AppTheme.DangerColor;
            btnCancel.ForeColor = System.Drawing.Color.White;
        }

        private bool VerifyCurrentPassword(string currentPassword)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM Users WHERE UserID = @UserID AND Password = @Password;";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", AppSession.CurrentUserID);
                        cmd.Parameters.AddWithValue("@Password", currentPassword);
                        long count = Convert.ToInt64(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error verifying current password:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string ValidatePasswordComplexity(string password)
        {
            if (password.Length < 8)
                return "Password must be at least 8 characters long.";

            if (!password.Any(char.IsUpper))
                return "Password must contain at least one (1) uppercase letter (A-Z).";

            if (!password.Any(char.IsLower))
                return "Password must contain at least one (1) lowercase letter (a-z).";

            if (!password.Any(char.IsDigit))
                return "Password must contain at least one (1) numeric digit (0-9).";

            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
                return "Password must contain at least one (1) special character (e.g. !@#$%^&*).";

            return string.Empty; // All rules passed
        }

        private bool UpdatePassword(string newPassword)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE Users SET Password = @NewPassword WHERE UserID = @UserID;";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                        cmd.Parameters.AddWithValue("@UserID", AppSession.CurrentUserID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating password:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text.Trim();
            string newPassword = txtNewPassword.Text;
            string retypePassword = txtRetypePassword.Text;

            // 1. Check for empty fields
            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(retypePassword))
            {
                MessageBox.Show("Please fill in all password fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Verify current password against database
            if (!VerifyCurrentPassword(currentPassword))
            {
                MessageBox.Show("The current password you entered is incorrect.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrentPassword.Focus();
                return;
            }

            // 3. Password match check
            if (newPassword != retypePassword)
            {
                MessageBox.Show("New Password and Retype Password do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRetypePassword.Focus();
                return;
            }

            // 4. Password complexity check
            string complexityError = ValidatePasswordComplexity(newPassword);
            if (!string.IsNullOrEmpty(complexityError))
            {
                MessageBox.Show(complexityError, "Password Complexity Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            // 5. Final Save
            if (UpdatePassword(newPassword))
            {
                AuditLogger.Log("CHANGE_PASSWORD", $"Password successfully changed for user '{AppSession.CurrentUsername}'.");
                MessageBox.Show("Your password has been changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
