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
    public partial class frmAuditLogs : Form
    {
        public frmAuditLogs()
        {
            InitializeComponent();
        }

        private void frmAuditLogs_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;
            LoadAuditLogs(dtpFrom.Value, dtpTo.Value);

            AuditLogger.Log("VIEW_AUDIT_LOG", $"{AppSession.CurrentUsername} viewed the Audit Log Report.");
        }

        private void LoadAuditLogs(DateTime from, DateTime to)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT LogID, Username, Role, Action, Details, LogDate
                                   FROM AuditLogs
                                   WHERE LogDate BETWEEN @From AND @To
                                   ORDER BY LogDate DESC;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@From", from.Date);
                        cmd.Parameters.AddWithValue("@To", to.Date.AddDays(1).AddSeconds(-1));

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvAuditLogs.DataSource = dt;
                            lblTitle.Text = $"Audit Log Report ({dt.Rows.Count} record(s))";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading audit logs:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MessageBox.Show("Start date cannot be later than end date.",
                    "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadAuditLogs(dtpFrom.Value, dtpTo.Value);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
