using BillingSystem.Database;
using BillingSystem.Utils;
using ClosedXML.Excel;
using MySql.Data.MySqlClient;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BillingSystem
{
    public partial class CustomerListForm : Form
    {
        private int _selectedCustomerId = 0;
        private bool _canEdit = true;

        public CustomerListForm()
        {
            InitializeComponent();
            ConfigureDataGridView();
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;

            var idCell = dgvCustomers.CurrentRow.Cells["CustomerID"].Value;
            if (idCell != null && int.TryParse(idCell.ToString(), out int id))
            {
                _selectedCustomerId = id;
            }
        }

        private void ConfigureDataGridView()
        {
            dgvCustomers.AutoGenerateColumns = false;

            foreach (DataGridViewColumn col in dgvCustomers.Columns)
            {
                switch (col.Name.ToLower())
                {
                    case "id":
                    case "customerid":
                    case "colid":
                        col.DataPropertyName = "CustomerID";
                        break;

                    case "fullname":
                    case "colfullname":
                    case "full name":
                        col.DataPropertyName = "FullName";
                        break;

                    case "address":
                    case "coladdress":
                        col.DataPropertyName = "Address";
                        break;

                    case "contactno":
                    case "contactnumber":
                    case "colcontactnumber":
                    case "contact no.":
                        col.DataPropertyName = "ContactNumber";
                        break;

                    case "email":
                    case "colemail":
                        col.DataPropertyName = "Email";
                        break;

                    case "balance":
                    case "colbalance":
                        col.DataPropertyName = "Balance";
                        break;

                    case "status":
                    case "colstatus":
                        col.DataPropertyName = "Status";
                        break;
                }
            }
        }

        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            ApplyPermissions();
            InitStatusStrip();
        }

        private void InitStatusStrip()
        {
            lblStatusUser.Text = $"Logged in as: {AppSession.CurrentFullName} ({AppSession.CurrentRole})";
            lblStatusTime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblStatusTime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
        }

        private void statusTimer_Tick(object sender, EventArgs e)
        {
            timerClock_Tick(sender, e);
        }

        private void ApplyPermissions()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT PermissionName, IsAllowed
                                   FROM UserPermissions
                                   WHERE Role = @Role;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Role", AppSession.CurrentRole);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string permName = reader.GetString("PermissionName");
                                bool isAllowed = reader.GetBoolean("IsAllowed");

                                switch (permName)
                                {
                                    case "AddCustomer":
                                        btnAdd.Enabled = isAllowed;
                                        break;
                                    case "EditCustomer":
                                        _canEdit = isAllowed;
                                        break;
                                    case "DeleteCustomer":
                                        btnDelete.Enabled = isAllowed;
                                        break;
                                    case "Analytics":
                                        btnAnalytics.Enabled = isAllowed;
                                        break;
                                    case "ExportExcel":
                                        btnExportExcel.Enabled = isAllowed;
                                        break;
                                    case "ExportPdf":
                                        btnExportPdf.Enabled = isAllowed;
                                        break;
                                    case "AuditLogs":
                                        btnAuditLog.Enabled = isAllowed;
                                        break;
                                    case "ManagePermissions":
                                        btnManagePermissions.Enabled = isAllowed;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading permissions:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AuditLogger.Log("LOGOUT", $"{AppSession.CurrentFullName} ({AppSession.CurrentRole}) logged out.");
            AppSession.Clear();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomerForm = new AddCustomerForm();
            addCustomerForm.ShowDialog();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT CustomerID,
                                          FullName,
                                          Address,
                                          ContactNumber,
                                          Email,
                                          Balance,
                                          Status
                                   FROM   Customers
                                   ORDER  BY FullName ASC;";

                    using (var adapter = new MySqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvCustomers.DataSource = dt;

                        if (dgvCustomers.Columns.Count > 0)
                        {
                            if (dgvCustomers.Columns.Contains("CustomerID"))
                                dgvCustomers.Columns["CustomerID"].HeaderText = "ID";

                            if (dgvCustomers.Columns.Contains("FullName"))
                                dgvCustomers.Columns["FullName"].HeaderText = "Full Name";

                            if (dgvCustomers.Columns.Contains("ContactNumber"))
                                dgvCustomers.Columns["ContactNumber"].HeaderText = "Contact No.";

                            if (dgvCustomers.Columns.Contains("Balance"))
                                dgvCustomers.Columns["Balance"].HeaderText = "Balance (₱)";
                        }

                        lblTitle.Text = $"Customer List ({dt.Rows.Count} record(s))";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchCustomers(string keyword)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT CustomerID,
                                          FullName,
                                          Address,
                                          ContactNumber,
                                          Email,
                                          Balance,
                                          Status
                                   FROM   Customers
                                   WHERE  FullName      LIKE @keyword
                                      OR  Address       LIKE @keyword
                                      OR  ContactNumber LIKE @keyword
                                   ORDER  BY FullName ASC;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgvCustomers.DataSource = dt;
                            lblTitle.Text = $"Customer List ({dt.Rows.Count} result(s))";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching customers:\n{ex.Message}",
                    "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadCustomers();
            }
            else
            {
                SearchCustomers(keyword);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!_canEdit) return;
            OpenEditForm();
        }

        private void OpenEditForm()
        {
            if (!_canEdit) return;

            if (_selectedCustomerId == 0)
            {
                MessageBox.Show("Please select a customer to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddCustomerForm editForm = new AddCustomerForm(_selectedCustomerId);
            editForm.FormClosed += (s, args) => LoadCustomers();
            editForm.ShowDialog(this);
        }

        private void DeleteCustomer(int customerId)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM Customers WHERE CustomerID = @CustomerID;";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCustomers();
                            _selectedCustomerId = 0;
                            AuditLogger.Log("DELETE_CUSTOMER", $"Customer ID {customerId} deleted by {AppSession.CurrentUsername}.");
                        }
                        else
                        {
                            MessageBox.Show("Customer could not be deleted. It may no longer exist.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting customer:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCustomerId == 0)
            {
                MessageBox.Show("Please select a customer to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this customer?\nAll billing records for this customer will also be deleted.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                DeleteCustomer(_selectedCustomerId);
            }
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            frmAnalytics analyticsForm = new frmAnalytics();
            AuditLogger.Log("VIEW_ANALYTICS", $"{AppSession.CurrentUsername} opened the Analytics Dashboard.");
            analyticsForm.ShowDialog(this);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.Rows.Count == 0)
            {
                MessageBox.Show("There are no records to export.",
                    "Export to Excel", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                saveDialog.FileName = "CustomerList.xlsx";

                if (saveDialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Customers");

                        for (int col = 0; col < dgvCustomers.Columns.Count; col++)
                        {
                            worksheet.Cell(1, col + 1).Value =
                                dgvCustomers.Columns[col].HeaderText;
                            worksheet.Cell(1, col + 1).Style.Font.Bold = true;
                        }

                        for (int row = 0; row < dgvCustomers.Rows.Count; row++)
                        {
                            for (int col = 0; col < dgvCustomers.Columns.Count; col++)
                            {
                                var cellValue =
                                    dgvCustomers.Rows[row].Cells[col].Value;
                                worksheet.Cell(row + 2, col + 1).Value =
                                    cellValue?.ToString() ?? "";
                            }
                        }

                        worksheet.Columns().AdjustToContents();

                        workbook.SaveAs(saveDialog.FileName);
                    }

                    AuditLogger.Log("EXPORT_EXCEL", $"{AppSession.CurrentUsername} exported customer list to Excel.");

                    MessageBox.Show("Customer list exported successfully to Excel.",
                        "Export Complete", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting to Excel:\n{ex.Message}",
                        "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.Rows.Count == 0)
            {
                MessageBox.Show("There are no records to export.",
                    "Export to PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PDF Document (*.pdf)|*.pdf";
                saveDialog.FileName = "CustomerList.pdf";

                if (saveDialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (PdfDocument document = new PdfDocument())
                    {
                        PdfPage page = document.AddPage();
                        page.Orientation = PdfSharp.PageOrientation.Landscape;

                        XGraphics gfx = XGraphics.FromPdfPage(page);

                        XFont titleFont = new XFont("Arial", 16, XFontStyleEx.Bold);
                        XFont headerFont = new XFont("Arial", 10, XFontStyleEx.Bold);
                        XFont cellFont = new XFont("Arial", 9, XFontStyleEx.Regular);

                        gfx.DrawString("Customer List Report", titleFont,
                            XBrushes.Black,
                            new XRect(0, 20, page.Width.Point, 30),
                            XStringFormats.TopCenter);

                        int columnCount = dgvCustomers.Columns.Count;
                        double margin = 30;
                        double tableWidth = page.Width.Point - (margin * 2);
                        double colWidth = tableWidth / columnCount;
                        double rowHeight = 22;
                        double y = 60;

                        double x = margin;
                        for (int col = 0; col < columnCount; col++)
                        {
                            gfx.DrawString(dgvCustomers.Columns[col].HeaderText,
                                headerFont,
                                XBrushes.Black, new XRect(x, y, colWidth, rowHeight),
                                XStringFormats.CenterLeft);
                            x += colWidth;
                        }

                        y += rowHeight;
                        gfx.DrawLine(XPens.Black, margin, y, page.Width.Point - margin, y);

                        foreach (DataGridViewRow row in dgvCustomers.Rows)
                        {
                            x = margin;
                            y += rowHeight;

                            if (y > page.Height.Point - margin)
                            {
                                page = document.AddPage();
                                page.Orientation = PdfSharp.PageOrientation.Landscape;
                                gfx.Dispose();
                                gfx = XGraphics.FromPdfPage(page);
                                y = 40;
                            }

                            for (int col = 0; col < columnCount; col++)
                            {
                                string text = row.Cells[col].Value?.ToString() ?? "";
                                gfx.DrawString(text, cellFont, XBrushes.Black,
                                    new XRect(x, y, colWidth, rowHeight),
                                    XStringFormats.CenterLeft);
                                x += colWidth;
                            }
                        }

                        gfx.Dispose();
                        document.Save(saveDialog.FileName);
                    }

                    AuditLogger.Log("EXPORT_PDF", $"{AppSession.CurrentUsername} exported customer list to PDF.");

                    MessageBox.Show("Customer list exported successfully to PDF.",
                        "Export Complete", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting to PDF:\n{ex.Message}",
                        "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAuditLog_Click(object sender, EventArgs e)
        {
            frmAuditLogs auditForm = new frmAuditLogs();
            auditForm.ShowDialog(this);
        }

        private void btnManagePermissions_Click(object sender, EventArgs e)
        {
            frmManagePermissions permForm = new frmManagePermissions();
            permForm.ShowDialog(this);
        }

        private void dgvCustomers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCustomers.Rows.Count) return;

            var row = dgvCustomers.Rows[e.RowIndex];

            // Safely locate the Status cell regardless of column name
            DataGridViewCell? statusCell = null;
            if (dgvCustomers.Columns.Contains("Status"))
                statusCell = row.Cells["Status"];
            else if (dgvCustomers.Columns.Contains("colStatus"))
                statusCell = row.Cells["colStatus"];

            if (statusCell == null || statusCell.Value == null) return;

            string status = statusCell.Value.ToString()?.Trim() ?? "";

            // 1. Inactive Customer: Color the entire row Light Red
            if (status.Equals("Inactive", StringComparison.OrdinalIgnoreCase))
            {
                row.DefaultCellStyle.BackColor = Color.MistyRose;
                row.DefaultCellStyle.ForeColor = Color.DarkRed;
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.Empty;
                row.DefaultCellStyle.ForeColor = Color.Empty;
            }

            // 2. Active Customer: Color ONLY the Status cell Light Green
            string columnName = dgvCustomers.Columns[e.ColumnIndex].Name;
            if (columnName.Equals("Status", StringComparison.OrdinalIgnoreCase) ||
                columnName.Equals("colStatus", StringComparison.OrdinalIgnoreCase))
            {
                if (status.Equals("Active", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.ForeColor = Color.DarkGreen;
                    e.CellStyle.Font = new Font(dgvCustomers.Font, FontStyle.Bold);
                }
            }

            // 3. Format Balance column as currency
            if (columnName.Equals("Balance", StringComparison.OrdinalIgnoreCase) ||
                columnName.Equals("colBalance", StringComparison.OrdinalIgnoreCase))
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal balance))
                {
                    e.Value = $"₱{balance:N2}";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}