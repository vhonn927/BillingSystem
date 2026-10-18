using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BillingSystem.Utils;

namespace BillingSystem
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            // Apply AppTheme colors 
            this.BackColor = AppTheme.PrimaryColor;

            // Start the splash timer 
            splashTimer.Start();
        }

        private void splashTimer_Tick(object sender, EventArgs e)
        {
            splashTimer.Stop();
            // Close the splash and open the Login Form 
            this.Hide();
            var loginForm = new LoginForm();

            // When login form actually closes, close the hidden splash so the app can exit cleanly.
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }
    }
}
