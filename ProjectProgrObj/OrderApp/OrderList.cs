using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    public class OrderList
    {
        private static FoodItemsDataDataContext dcFI = new FoodItemsDataDataContext(
        Properties.Settings.Default.FastFood_SysConnectionString);

        private static OrdersDataDataContext dcO = new OrdersDataDataContext(
        Properties.Settings.Default.FastFood_SysConnectionString);

        /// <summary>
        /// List of products in the currnet order
        /// </summary>
        public List<FoodItems> CurrentlyFoodItemsInOrder = new List<FoodItems>();
        private int _number = dcO.Orders.Any() ? dcO.Orders.Max(e => e.Number) + 1 : 1;

        /// <summary>
        /// Finds the product with same name as that on button and ads it to the list
        /// </summary>
        /// <param name="_name"></param>
        public void Add(string _name)
        {
            FoodItems x = dcFI.FoodItems.FirstOrDefault(e => e.Name.Equals(_name));
            CurrentlyFoodItemsInOrder.Add(x);
        }
        /// <summary>
        /// Removes the product from the list with same name as a Source 
        /// </summary>
        /// <param name="_name"></param>
        public void Remove(FoodItems item)
            => CurrentlyFoodItemsInOrder.Remove(item);
        /// <summary>
        /// Make a sum of all items in list (To write it on info for user)
        /// </summary>
        public string PriceSum()
        {
            decimal resoult = 0;
            foreach(FoodItems item in CurrentlyFoodItemsInOrder)
                resoult += item.Price;
            return resoult.ToString("0.00") +" €";
        }
        /// <summary>
        /// Taking all items from list and adding them to the DB witch the currently number of order
        /// </summary>
        public void ConfirmOrder()
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

        /// <summary>
        /// clearing the list
        /// </summary>
        public void ClearList() 
            => CurrentlyFoodItemsInOrder.Clear();

    }
}
