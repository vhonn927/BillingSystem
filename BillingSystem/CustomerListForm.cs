using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;



namespace BillingSystem
{
    public partial class CustomerListForm : Form
    {


        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            // If no row is selected, do nothing
            if (dgvCustomers.CurrentRow == null) return;

            // Read the CustomerID value from the selected row
            var idCell = dgvCustomers.CurrentRow.Cells["CustomerID"].Value;
            if (idCell != null && int.TryParse(idCell.ToString(), out int id))
            {
                _selectedCustomerId = id;
            }
        }

        public CustomerListForm()
        {
            InitializeComponent();
            ConfigureDataGridView();
        }

        // Stores the CustomerID of the currently selected row.
        // 0 means no customer is currently selected.
        private int _selectedCustomerId = 0;



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

                    // SELECT all customers, most recently added first
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

                        // Bind the DataTable to the grid
                        dgvCustomers.DataSource = dt;

                        // Improve column headers for readability
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

                    // Parameterized SELECT with WHERE... LIKE
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
                        // %keywords matches the search text anywhere in the column
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
                // Empty search box show all customers again
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
            // e.RowIndex is -1 when the header row is double-clicked — ignore it
            if (e.RowIndex < 0) return;
            OpenEditForm();
        }

        private void OpenEditForm()
        {
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
    }
}