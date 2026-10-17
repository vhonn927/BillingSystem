namespace BillingSystem
{
    partial class SplashScreen
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
            components = new System.ComponentModel.Container();
            lblAppName = new Label();
            lblTagline = new Label();
            lblLoading = new Label();
            SplashTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(125, 80);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(235, 54);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "BILLING SYSTEM";
            lblAppName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTagline
            // 
            lblTagline.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTagline.ForeColor = Color.FromArgb(189, 215, 238);
            lblTagline.Location = new Point(100, 120);
            lblTagline.Name = "lblTagline";
            lblTagline.Size = new Size(273, 50);
            lblTagline.TabIndex = 1;
            lblTagline.Text = " Electric Billing Management System";
            lblTagline.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLoading
            // 
            lblLoading.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblLoading.ForeColor = Color.LightBlue;
            lblLoading.Location = new Point(190, 170);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(100, 23);
            lblLoading.TabIndex = 2;
            lblLoading.Text = "Loading...";
            lblLoading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SplashTimer
            // 
            SplashTimer.Interval = 2500;
            SplashTimer.Tick += SplashTimer_Tick;
            // 
            // SplashScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 261);
            Controls.Add(lblLoading);
            Controls.Add(lblTagline);
            Controls.Add(lblAppName);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SplashScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SplashScreen";
            Load += SplashScreen_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lblAppName;
        private Label lblTagline;
        private Label lblLoading;
        private System.Windows.Forms.Timer SplashTimer;
    }
}