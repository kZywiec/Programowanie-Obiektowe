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
    /// Logika interakcji dla klasy CaffeUI.xaml
    /// </summary>
    public partial class CaffeUI : Page
    {
        MainMenu parent { get; set;}
        public CaffeUI(MainMenu Parent)
        {
            InitializeComponent();
            parent = Parent;
        }

        private void Bt1_Click(object sender, RoutedEventArgs e)
            => AddItem(parent, Bt1.Content.ToString());
        private void Bt2_Click(object sender, RoutedEventArgs e)
            => AddItem(parent, Bt2.Content.ToString());
        private void Bt3_Click(object sender, RoutedEventArgs e)
            => AddItem(parent, Bt3.Content.ToString());
        private void Bt4_Click(object sender, RoutedEventArgs e)
            => AddItem(parent, Bt4.Content.ToString());
        private void Bt5_Click(object sender, RoutedEventArgs e)
            => AddItem(parent, Bt5.Content.ToString());
        private void Bt6_Click(object sender, RoutedEventArgs e)
            => AddItem(parent, Bt6.Content.ToString());
        private void Bt7_Click(object sender, RoutedEventArgs e)
            => AddItem(parent, Bt7.Content.ToString());
        private void Bt8_Click(object sender, RoutedEventArgs e)
            => AddItem(parent, Bt8.Content.ToString());

        private void AddItem(MainMenu Parent, string content)
        {
            Parent._orderList.Add(content);
            Parent.Refresh();
        }
    }
}
