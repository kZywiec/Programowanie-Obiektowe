using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Linq;

namespace OrderApp
{
    /// <summary>
    /// Logika interakcji dla klasy AddNewUser.xaml
    /// </summary>
    public partial class AddNewUser : Page
    {
        UsersDataDataContext dc = new UsersDataDataContext(
            Properties.Settings.Default.FastFood_SysConnectionString);
        public AddNewUser()
        {
            InitializeComponent();
            if (dc.DatabaseExists()) UsersDataGrid.ItemsSource = dc.Users;

        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            OrderSysLogin orderSysLogin = new OrderSysLogin();
            this.NavigationService.Navigate(orderSysLogin);
            //Loged = false;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            this.NavigationService.Navigate(mainMenu);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            dc.SubmitChanges();
        }
    }
}
