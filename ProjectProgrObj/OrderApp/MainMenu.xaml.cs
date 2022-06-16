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
        public OrderList _orderList { get; set; }
        public MainMenu()
        {
            InitializeComponent();
            _orderList = new OrderList();
            User_Info.Text = $"Loged as {Authenticator.CurrentUser.Name}_{Authenticator.CurrentUser.Second_name}";
            User_Info.Text += Authenticator.CurrentUser.Role_id == 1 ? $" (Admin)" : "";
            MenageUsers_Button.Visibility = Authenticator.CurrentUser.Role_id == 1 ? Visibility.Visible : Visibility.Hidden;
            MenageOrders_Button.Visibility = Authenticator.CurrentUser.Role_id == 1 ? Visibility.Visible : Visibility.Hidden;
            OrderListView.ItemsSource = _orderList.CurrentlyFoodItemsInOrder;
        }

        //refresh of current page
        public void Refresh()
        {
            this.NavigationService.Refresh();
            OrderSum.Content = _orderList.PriceSum();
            OrderListView.Items.Refresh();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            OrderSysLogin orderSysLogin = new OrderSysLogin();
            this.NavigationService.Navigate(orderSysLogin);
            this._orderList.ClearList();
            Authenticator.Logout();
        }

        private void MenageUsers_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddNewUser());
        }
        private void MenageOrders_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenageOrders());
        }
        private void Order_Click(object sender, RoutedEventArgs e)
        {
            _orderList.ConfirmOrder();
            Refresh();
        }
        private void NavigateFood_Appetizers_Click(object sender, RoutedEventArgs e)
        {
            FoodMenuNavigator.Content = new AppetizersUI(this);
        }
        private void NavigateFood_Desserts_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Refresh();
            FoodMenuNavigator.Content = new DessertsUI(this);
        }
        private void NavigateFood_Cafe_Click(object sender, RoutedEventArgs e)
        {
            FoodMenuNavigator.Content = new CaffeUI(this);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (OrderListView.SelectedItem == null) return;
            FoodItems ToDelete = (FoodItems)OrderListView.SelectedItem;
            _orderList.Remove(ToDelete);
            this.Refresh();
        }
    }
}

