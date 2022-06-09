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
    /// Logika interakcji dla klasy MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            User_Info.Text = $"Loged as {Authenticator.CurrentUser.Name}_{Authenticator.CurrentUser.Second_name}";
            User_Info.Text += Authenticator.CurrentUser.Role_id == 1 ? $" (Admin)" : "";
            MenageUsers_Button.Visibility = Authenticator.CurrentUser.Role_id == 1 ? Visibility.Visible : Visibility.Hidden;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            OrderSysLogin orderSysLogin = new OrderSysLogin();
            this.NavigationService.Navigate(orderSysLogin);
            Authenticator.Logout();
        }
        private void AddNewUser_Click(object sender, RoutedEventArgs e)
        {
            AddNewUser addNewUser = new AddNewUser();
            this.NavigationService.Navigate(addNewUser);
        }
        private void Order_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void NavigateFood_Appetizers_Click(object sender, RoutedEventArgs e)
        {
            FoodMenuNavigator.Content = new AppetizersUI();
        }
        private void NavigateFood_Desserts_Click(object sender, RoutedEventArgs e)
        {

            FoodMenuNavigator.Content = new DessertsUI();
        }
        private void NavigateFood_Cafe_Click(object sender, RoutedEventArgs e)
        {
            FoodMenuNavigator.Content = new CaffeUI();
        }
    }
}
