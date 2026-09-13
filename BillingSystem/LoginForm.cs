using BillingSystem.Database;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Pqc.Crypto.Lms;
namespace BillingSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter your username.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter your password.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT UserID, FullName, Role FROM Users 
                           WHERE Username = @Username AND Password = @Password;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                CustomerListForm listForm = new CustomerListForm();
                                listForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.\nPlease try again.",
                                                "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtPassword.Clear();
                                txtPassword.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: \n" + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Test the database connection when the form opens.
            // This gives a clear warning if MySQL is not running.
            if (!DatabaseConnection.TestConnection())
            {
                MessageBox.Show(
                    "Cannot connect to the database.\n\n" +
                    "Please make sure:\n" +
                    "  1. MySQL Server is running.\n" +
                    "  2. BillingDB database exists.\n" +
                    "  3. The password in DatabaseConnection.cs is correct.",
                    "Database Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            txtUsername.Focus();


        }
    }
}

