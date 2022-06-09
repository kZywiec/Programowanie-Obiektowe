using System;
using System.Collections.Generic;
using System.Data.Linq;
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
    /// Logika interakcji dla klasy OrderSysLogin.xaml
    /// </summary>
    public partial class OrderSysLogin : Page
    {
        private string PinTemp = "";
        public OrderSysLogin()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            MainMenu mainMenuPage = new MainMenu();
            this.NavigationService.Navigate(mainMenuPage);
        }
        private delegate bool LoginManipulationHolder();
        private event LoginManipulationHolder ChangePinTemp;

        //Funkcja wywołuje event zmiany na zmiennej LoginTemp
        //sprawdzając czy użytkownik nie wprowadził zadużo znaków
        protected virtual bool OnPinTempChanged()
        {
            if (ChangePinTemp != null)
                ChangePinTemp();   
            else if(PinTemp.Length > 4)
                return true;
            return false;
        }
        //Wprowadzenie znaku do Tymczasowej zmiennej odpowiadającej za Pin
        //Wywołuje event 
        private void AddChar(char x)
        {
            this.PinTemp += x.ToString();
            OnPinTempChanged();
            if (OnPinTempChanged())
                (this.PinTemp, LengthCounter.Content) = ("" + x, "");
            LengthCounter.Content += "* "; //this.LoginTemp;
        }
        private void NumberButton0_Click(object sender, RoutedEventArgs e) => AddChar('0');
        private void NumberButton1_Click(object sender, RoutedEventArgs e) => AddChar('1');
        private void NumberButton2_Click(object sender, RoutedEventArgs e) => AddChar('2');
        private void NumberButton3_Click(object sender, RoutedEventArgs e) => AddChar('3');
        private void NumberButton4_Click(object sender, RoutedEventArgs e) => AddChar('4');
        private void NumberButton5_Click(object sender, RoutedEventArgs e) => AddChar('5');
        private void NumberButton6_Click(object sender, RoutedEventArgs e) => AddChar('6'); 
        private void NumberButton7_Click(object sender, RoutedEventArgs e) => AddChar('7');
        private void NumberButton8_Click(object sender, RoutedEventArgs e) => AddChar('8');
        private void NumberButton9_Click(object sender, RoutedEventArgs e) => AddChar('9');
    }
}