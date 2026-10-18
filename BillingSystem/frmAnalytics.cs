using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;
using ScottPlot;

namespace BillingSystem
{
    public partial class frmAnalytics : Form
    {
        public frmAnalytics()
        {
            InitializeComponent();

            dgvTop5.AutoGenerateColumns = false;
            dgvTop5.Columns["FullName"].DataPropertyName = "FullName";
            dgvTop5.Columns["TotalConsumption"].DataPropertyName = "TotalConsumption";
            dgvTop5.Columns["TotalBilled"].DataPropertyName = "TotalBilled";
        }

        private void plotPaidUnpaid_Load(object sender, EventArgs e)
        {
        }

        private void frmAnalytics_Load(object sender, EventArgs e)
        {
            LoadKpiSummary();
            LoadMonthlyRevenueChart();
            LoadPaidUnpaidChart();
            LoadTop5Customers();
        }

        private void LoadKpiSummary()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string sqlCustomers = "SELECT COUNT(*) FROM Customers;";
                    using (var cmd = new MySqlCommand(sqlCustomers, conn))
                    {
                        int totalCustomers = Convert.ToInt32(cmd.ExecuteScalar());
                        lblTotalCustomers.Text = $"Total Customers: {totalCustomers}";
                    }

                    string sqlRevenue = @"SELECT IFNULL(SUM(TotalAmount), 0)
                                          FROM Billing
                                          WHERE Status = 'Paid';";
                    using (var cmd = new MySqlCommand(sqlRevenue, conn))
                    {
                        decimal totalRevenue = Convert.ToDecimal(cmd.ExecuteScalar());
                        lblTotalRevenue.Text = $"Total Revenue: ₱{totalRevenue:N2}";
                    }

                    string sqlUnpaid = @"SELECT IFNULL(SUM(TotalAmount), 0)
                                         FROM Billing
                                         WHERE Status = 'Unpaid';";
                    using (var cmd = new MySqlCommand(sqlUnpaid, conn))
                    {
                        decimal totalUnpaid = Convert.ToDecimal(cmd.ExecuteScalar());
                        lblTotalUnpaid.Text = $"Total Unpaid: ₱{totalUnpaid:N2}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading KPI summary:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMonthlyRevenueChart()
        {
            try
            {
                var months = new List<string>();
                var amounts = new List<double>();

                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT BillingMonth,
                                          SUM(TotalAmount) AS MonthlyTotal
                                   FROM Billing
                                   WHERE Status = 'Paid'
                                   GROUP BY BillingMonth
                                   ORDER BY MIN(BillingDate);";

                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            months.Add(reader.GetString("BillingMonth"));
                            amounts.Add((double)reader.GetDecimal("MonthlyTotal"));
                        }
                    }
                }

                plotMonthlyRevenue.Plot.Clear();

                double[] values = amounts.ToArray();
                var barPlot = plotMonthlyRevenue.Plot.Add.Bars(values);

                double[] positions = new double[months.Count];
                for (int i = 0; i < months.Count; i++) positions[i] = i;
                plotMonthlyRevenue.Plot.Axes.Bottom.SetTicks(positions, months.ToArray());

                plotMonthlyRevenue.Plot.Title("Monthly Revenue (Paid Bills)");
                plotMonthlyRevenue.Plot.YLabel("Revenue (₱)");
                plotMonthlyRevenue.Plot.XLabel("Month");

                plotMonthlyRevenue.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading monthly revenue chart:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPaidUnpaidChart()
        {
            try
            {
                int paidCount = 0;
                int unpaidCount = 0;

                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT Status, COUNT(*) AS StatusCount
                                   FROM Billing
                                   GROUP BY Status;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string status = reader.GetString("Status");
                            int count = reader.GetInt32("StatusCount");

                            if (status == "Paid") paidCount = count;
                            if (status == "Unpaid") unpaidCount = count;
                        }
                    }
                }

                plotPaidUnpaid.Plot.Clear();

                double[] values = { paidCount, unpaidCount };
                string[] labels = { "Paid", "Unpaid" };
                double total = paidCount + unpaidCount;

                var pie = plotPaidUnpaid.Plot.Add.Pie(values);

                for (int i = 0; i < pie.Slices.Count; i++)
                {
                    double percent = total > 0 ? values[i] / total : 0;
                    pie.Slices[i].Label = $"{labels[i]} ({percent:P0})";
                }

                pie.SliceLabelDistance = 0.5;

                plotPaidUnpaid.Plot.Title("Paid vs Unpaid Bills");
                plotPaidUnpaid.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Paid/Unpaid chart:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTop5Customers()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT c.FullName,
                                          SUM(b.Consumption) AS TotalConsumption,
                                          SUM(b.TotalAmount) AS TotalBilled
                                   FROM Customers c
                                   INNER JOIN Billing b ON c.CustomerID = b.CustomerID
                                   GROUP BY c.CustomerID, c.FullName
                                   ORDER BY TotalConsumption DESC
                                   LIMIT 5;";

                    using (var adapter = new MySqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvTop5.DataSource = dt;

                        if (dgvTop5.Columns.Count > 0)
                        {
                            dgvTop5.Columns["FullName"].HeaderText = "Customer Name";
                            dgvTop5.Columns["TotalConsumption"].HeaderText = "Total Consumption (kWh)";
                            dgvTop5.Columns["TotalBilled"].HeaderText = "Total Billed (₱)";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Top 5 customers:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCloseAnalytics_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}