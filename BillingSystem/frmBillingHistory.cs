using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;
using BillingSystem.Utils;

namespace BillingSystem
{
    public partial class frmBillingHistory : Form
    {
        private int _customerId;

        // Custom constructor accepting the selected CustomerID
        public frmBillingHistory(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
            ConfigureDataGridView();
        }

        private void frmBillingHistory_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadCustomerInfo();
            LoadBillingRecords();
        }

        private void ApplyTheme()
        {
            this.BackColor = AppTheme.BackgroundColor;

            // Neutral style for close button
            btnClose.UseVisualStyleBackColor = true;
            btnClose.ForeColor = Color.Black;

            // DataGridView Header Styling
            dgvBilling.ColumnHeadersDefaultCellStyle.BackColor = AppTheme.PrimaryColor;
            dgvBilling.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBilling.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvBilling.AlternatingRowsDefaultCellStyle.BackColor = AppTheme.GridRowAlt;
        }

        private void ConfigureDataGridView()
        {
            dgvBilling.AutoGenerateColumns = false;
            dgvBilling.Columns.Clear();

            // Add required columns according to Activity 6.2 spec
            dgvBilling.Columns.Add(new DataGridViewTextBoxColumn { Name = "BillingMonth", DataPropertyName = "BillingMonth", HeaderText = "Billing Month", Width = 110 });
            dgvBilling.Columns.Add(new DataGridViewTextBoxColumn { Name = "PreviousReading", DataPropertyName = "PreviousReading", HeaderText = "Previous Reading", Width = 110 });
            dgvBilling.Columns.Add(new DataGridViewTextBoxColumn { Name = "PresentReading", DataPropertyName = "PresentReading", HeaderText = "Present Reading", Width = 110 });
            dgvBilling.Columns.Add(new DataGridViewTextBoxColumn { Name = "Consumption", DataPropertyName = "Consumption", HeaderText = "Consumption", Width = 100 });
            dgvBilling.Columns.Add(new DataGridViewTextBoxColumn { Name = "RatePerCubic", DataPropertyName = "RatePerCubic", HeaderText = "Rate Per Cubic", Width = 110 });
            dgvBilling.Columns.Add(new DataGridViewTextBoxColumn { Name = "TotalAmount", DataPropertyName = "TotalAmount", HeaderText = "Total Amount", Width = 110 });
            dgvBilling.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", DataPropertyName = "Status", HeaderText = "Status", Width = 90 });
        }

        private void LoadCustomerInfo()
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
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            lblTitle.Text = $"Billing History - {result.ToString()}";
                        }
                        else
                        {
                            lblTitle.Text = "Billing History - Unknown Customer";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer info:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBillingRecords()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT BillingMonth, 
                                  PreviousReading, 
                                  PresentReading, 
                                  Consumption, 
                                  RatePerCubic, 
                                  TotalAmount, 
                                  Status 
                           FROM Billing 
                           WHERE CustomerID = @CustomerID 
                           ORDER BY BillingID DESC;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", _customerId);

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgvBilling.DataSource = dt;

                            // Popup 2 Requirement: Exact matching text & title from screenshot
                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show(
                                    "No billing records were found for this customer.",
                                    "No Records",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading billing records:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
