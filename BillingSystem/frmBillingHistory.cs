using BillingSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BillingSystem
{
    public partial class frmBillingHistory : Form
    {
        // Only the ID is received; the name is verified from the database
        private readonly int _customerId;

        public frmBillingHistory(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
        }

        private void frmBillingHistory_Shown(object? sender, EventArgs e)
        {
            // Requirement 3.4: name comes from the Customers table
            string? customerName = GetCustomerName();

            if (customerName == null)
            {
                MessageBox.Show("The selected customer could not be found.",
                    "Customer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblCustomerName.Text = $"Billing History — {customerName}";

            LoadBillingRecords();
        }

        private string? GetCustomerName()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT FullName FROM Customers WHERE CustomerID = @CustomerID;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", _customerId);
                        return cmd.ExecuteScalar()?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void LoadBillingRecords()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Requirement 3.6: only this customer's rows, parameterized,
                    // ordered oldest to newest by BillingDate
                    string sql = @"SELECT BillingMonth    AS `Billing Month`,
                                          PreviousReading AS `Previous Reading`,
                                          PresentReading  AS `Present Reading`,
                                          Consumption     AS `Consumption`,
                                          RatePerCubic    AS `Rate Per Cubic`,
                                          TotalAmount     AS `Total Amount`,
                                          Status          AS `Status`
                                   FROM   Billing
                                   WHERE  CustomerID = @CustomerID
                                   ORDER  BY BillingDate ASC;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", _customerId);

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvBilling.DataSource = dt;

                            dgvBilling.Columns["Rate Per Cubic"].DefaultCellStyle.Format = "N2";
                            dgvBilling.Columns["Total Amount"].DefaultCellStyle.Format = "N2";

                            // POPUP 2: customer exists but has zero billing records
                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("No billing records were found for this customer.",
                                    "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading billing records:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}