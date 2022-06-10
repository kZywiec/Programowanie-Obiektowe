using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    public class OrderList
    {
        static FoodItemsDataDataContext dcFI = new FoodItemsDataDataContext(
        Properties.Settings.Default.FastFood_SysConnectionString);

        static OrdersDataDataContext dcO = new OrdersDataDataContext(
        Properties.Settings.Default.FastFood_SysConnectionString);

        public static List<FoodItems> CurrentlyFoodItemsInOrder = new List<FoodItems>();
        private static int _number = dcO.Orders.Any() ? dcO.Orders.Max(e => e.Number) + 1 : 1;


        public static void Add(string _name)
        {
            FoodItems x = dcFI.FoodItems.FirstOrDefault(e => e.Name.Equals(_name));
            CurrentlyFoodItemsInOrder.Add(x);
        }
        public static void Remove(string _name)
            => CurrentlyFoodItemsInOrder.Remove(new FoodItems { Name = _name });

        public static string PriceSum()
        {
            decimal resoult = 0;
            foreach(FoodItems item in CurrentlyFoodItemsInOrder)
                resoult += item.Price;
            return resoult.ToString() +" €";
        }

        public static void ConfirmOrder()
        {
            
            foreach (var item in CurrentlyFoodItemsInOrder)
            {
                var Order = new Orders();
                Order.UserID = (int)Authenticator.CurrentUser.Id;
                Order.FoodID = item.Id;
                Order.DateOfOrder = DateTime.Now;
                Order.Number = _number;
                dcO.Orders.InsertOnSubmit(Order);
                dcO.SubmitChanges();
            }
            CurrentlyFoodItemsInOrder.Clear();
            _number++;
            //Clear view
        }

        public static void ClearList() 
            => CurrentlyFoodItemsInOrder.Clear();
    }
}
