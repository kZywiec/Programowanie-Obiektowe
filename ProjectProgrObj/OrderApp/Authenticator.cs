using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Windows;

namespace OrderApp
{
    class Authenticator
    {
        /// <summary>
        /// Object of user who is actually logedin
        /// </summary>
        public static Users CurrentUser { get; private set; }

        bool IsLoggedIn => CurrentUser != null;

        /// <summary>
        /// Searching for user with same Pin as that typed in login section
        /// </summary>

        public static bool Login(string _Pin)
        {
            UsersDataDataContext dc = new UsersDataDataContext(
            Properties.Settings.Default.FastFood_SysConnectionString);
            try
            {
                CurrentUser = dc.Users.FirstOrDefault(e => e.Pin.Equals(_Pin));
                if (CurrentUser == null) throw new Exception("Invalid Pin!");
            }
            catch (Exception ex)
            {
                ExeptionPopUp popUp = new ExeptionPopUp();
                popUp.Error_name.Text = ex.Message;
                popUp.Show();

                return false;
            }
            return true;
        }
        /// <summary>
        /// sets the current user to null
        /// </summary>
        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
