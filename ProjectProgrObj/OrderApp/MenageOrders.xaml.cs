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

namespace OrderApp
{
    /// <summary>
    /// Logika interakcji dla klasy MenageOrders.xaml
    /// </summary>
    public partial class MenageOrders : Page
    {
        private OrdersDataDataContext dc = new OrdersDataDataContext(
            Properties.Settings.Default.FastFood_SysConnectionString);
        public MenageOrders()
        {
            InitializeComponent();
            if (dc.DatabaseExists()) OrdersDataGrid.ItemsSource = dc.Orders;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            OrderSysLogin orderSysLogin = new OrderSysLogin();
            this.NavigationService.Navigate(orderSysLogin);
            Authenticator.Logout();
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