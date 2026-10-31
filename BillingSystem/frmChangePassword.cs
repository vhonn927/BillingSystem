using BillingSystem.Database;
using BillingSystem.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BillingSystem
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string current = txtCurrentPassword.Text;
            string newPass = txtNewPassword.Text;
            string retype = txtRetypePassword.Text;

            // 1. Empty fields
            if (current == "" || newPass == "" || retype == "")
            {
                MessageBox.Show("Please fill in all fields.", "Missing Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Current password check (against the database)
            if (!IsCurrentPasswordCorrect(current))
            {
                MessageBox.Show("Current password is incorrect.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrentPassword.Clear();
                txtCurrentPassword.Focus();
                return;
            }

            // 3. New and Retype must match exactly
            if (newPass != retype)
            {
                MessageBox.Show("New Password and Retype Password do not match.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRetypePassword.Clear();
                txtRetypePassword.Focus();
                return;
            }

            // 4. Complexity rules (shows ALL unmet rules at once)
            string problems = GetPasswordProblems(newPass);
            if (problems != "")
            {
                MessageBox.Show("Your new password is missing:\n\n" + problems,
                    "Password Too Weak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            // 5. All checks passed, so save
            if (UpdatePassword(newPass))
            {
                MessageBox.Show("Password changed successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private string GetPasswordProblems(string pw)
        {
            string result = "";
            if (pw.Length < 8)
                result += "• At least 8 characters\n";
            if (!Regex.IsMatch(pw, "[A-Z]"))
                result += "• At least one uppercase letter (A-Z)\n";
            if (!Regex.IsMatch(pw, "[a-z]"))
                result += "• At least one lowercase letter (a-z)\n";
            if (!Regex.IsMatch(pw, "[0-9]"))
                result += "• At least one number (0-9)\n";
            if (!Regex.IsMatch(pw, @"[^a-zA-Z0-9\s]"))
                result += "• At least one special character (e.g. !@#$%^&*)\n";
            return result;
        }

        private bool IsCurrentPasswordCorrect(string typedPassword)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT Password FROM Users WHERE UserID = @UserID;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", AppSession.CurrentUserID);
                        object? result = cmd.ExecuteScalar();

                        if (result == null) return false;

                        // Compared in C# so the check is case-sensitive
                        // (MySQL's default "=" ignores upper/lower case).
                        return string.Equals(result.ToString(), typedPassword,
                                             StringComparison.Ordinal);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool UpdatePassword(string newPassword)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE Users SET Password = @Password WHERE UserID = @UserID;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Password", newPassword);
                        cmd.Parameters.AddWithValue("@UserID", AppSession.CurrentUserID);
                        return cmd.ExecuteNonQuery() == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}