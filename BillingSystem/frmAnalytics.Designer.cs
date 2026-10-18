namespace BillingSystem
{
    partial class frmAnalytics
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
            lblTotalCustomers = new Label();
            lblTotalRevenue = new Label();
            lblTotalUnpaid = new Label();
            plotMonthlyRevenue = new ScottPlot.WinForms.FormsPlot();
            plotPaidUnpaid = new ScottPlot.WinForms.FormsPlot();
            lblTop5Title = new Label();
            dgvTop5 = new DataGridView();
            btnCloseAnalytics = new Button();
            FullName = new DataGridViewTextBoxColumn();
            TotalConsumption = new DataGridViewTextBoxColumn();
            TotalBilled = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvTop5).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(383, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(238, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Analytic Dashboard";
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.AutoSize = true;
            lblTotalCustomers.Location = new Point(71, 66);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(124, 20);
            lblTotalCustomers.TabIndex = 1;
            lblTotalCustomers.Text = "Total Customer: 0";
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Location = new Point(428, 66);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(148, 20);
            lblTotalRevenue.TabIndex = 2;
            lblTotalRevenue.Text = "Total Revenue: P 0.00";
            // 
            // lblTotalUnpaid
            // 
            lblTotalUnpaid.AutoSize = true;
            lblTotalUnpaid.Location = new Point(780, 66);
            lblTotalUnpaid.Name = "lblTotalUnpaid";
            lblTotalUnpaid.Size = new Size(140, 20);
            lblTotalUnpaid.TabIndex = 3;
            lblTotalUnpaid.Text = "Total Unpaid: P 0.00";
            // 
            // plotMonthlyRevenue
            // 
            plotMonthlyRevenue.Location = new Point(33, 103);
            plotMonthlyRevenue.Name = "plotMonthlyRevenue";
            plotMonthlyRevenue.Size = new Size(539, 230);
            plotMonthlyRevenue.TabIndex = 4;
            // 
            // plotPaidUnpaid
            // 
            plotPaidUnpaid.Location = new Point(578, 103);
            plotPaidUnpaid.Name = "plotPaidUnpaid";
            plotPaidUnpaid.Size = new Size(342, 216);
            plotPaidUnpaid.TabIndex = 5;
            plotPaidUnpaid.Load += plotPaidUnpaid_Load;
            // 
            // lblTop5Title
            // 
            lblTop5Title.AutoSize = true;
            lblTop5Title.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTop5Title.Location = new Point(71, 336);
            lblTop5Title.Name = "lblTop5Title";
            lblTop5Title.Size = new Size(329, 28);
            lblTop5Title.TabIndex = 6;
            lblTop5Title.Text = "Top 5 Customers by Consumption";
            // 
            // dgvTop5
            // 
            dgvTop5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTop5.Columns.AddRange(new DataGridViewColumn[] { FullName, TotalConsumption, TotalBilled });
            dgvTop5.Location = new Point(71, 371);
            dgvTop5.Name = "dgvTop5";
            dgvTop5.RowHeadersWidth = 51;
            dgvTop5.Size = new Size(849, 185);
            dgvTop5.TabIndex = 7;
            // 
            // btnCloseAnalytics
            // 
            btnCloseAnalytics.Location = new Point(826, 562);
            btnCloseAnalytics.Name = "btnCloseAnalytics";
            btnCloseAnalytics.Size = new Size(94, 29);
            btnCloseAnalytics.TabIndex = 8;
            btnCloseAnalytics.Text = "Close";
            btnCloseAnalytics.UseVisualStyleBackColor = true;
            btnCloseAnalytics.Click += btnCloseAnalytics_Click;
            // 
            // FullName
            // 
            FullName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FullName.HeaderText = "Customer Name";
            FullName.MinimumWidth = 6;
            FullName.Name = "FullName";
            // 
            // TotalConsumption
            // 
            TotalConsumption.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TotalConsumption.HeaderText = "Total Consumption ";
            TotalConsumption.MinimumWidth = 6;
            TotalConsumption.Name = "TotalConsumption";
            // 
            // TotalBilled
            // 
            TotalBilled.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TotalBilled.HeaderText = "Total Billed";
            TotalBilled.MinimumWidth = 6;
            TotalBilled.Name = "TotalBilled";
            // 
            // frmAnalytics
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(btnCloseAnalytics);
            Controls.Add(dgvTop5);
            Controls.Add(lblTop5Title);
            Controls.Add(plotPaidUnpaid);
            Controls.Add(plotMonthlyRevenue);
            Controls.Add(lblTotalUnpaid);
            Controls.Add(lblTotalRevenue);
            Controls.Add(lblTotalCustomers);
            Controls.Add(lblTitle);
            Name = "frmAnalytics";
            Text = "Billing System - Analytics Dashboard";
            Load += frmAnalytics_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTop5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblTotalCustomers;
        private Label lblTotalRevenue;
        private Label lblTotalUnpaid;
        private ScottPlot.WinForms.FormsPlot plotMonthlyRevenue;
        private ScottPlot.WinForms.FormsPlot plotPaidUnpaid;
        private Label lblTop5Title;
        private DataGridView dgvTop5;
        private Button btnCloseAnalytics;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn TotalConsumption;
        private DataGridViewTextBoxColumn TotalBilled;
    }
}