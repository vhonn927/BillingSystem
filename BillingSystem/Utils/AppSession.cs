using System;
using System.Collections.Generic;
using System.Text;

namespace BillingSystem.Utils
{
    public static class AppSession
    {
        public static int CurrentUserID { get; set; }
        public static string CurrentUsername { get; set; } = string.Empty;
        public static string CurrentFullName { get; set; } = string.Empty;
        public static string CurrentRole { get; set; } = string.Empty;

        public static void Clear()
        {
            CurrentUserID = 0;
            CurrentUsername = string.Empty;
            CurrentFullName = string.Empty;
            CurrentRole = string.Empty;
        }
    }
}
