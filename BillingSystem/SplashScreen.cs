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
            this.BackColor = AppTheme.PrimaryColor;
            splashTimer.Start();
        }

        private void splashTimer_Tick(object sender, EventArgs e)
        {
            splashTimer.Stop();

            this.Hide();
            var loginForm = new LoginForm();

            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }
    }
}
