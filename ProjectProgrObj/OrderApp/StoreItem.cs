using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    public class StoreItem
    {
        public event Action<FoodItems> FoodItemCreated;

        public void CreateFoodItem(FoodItems item)
        {
            FoodItemCreated?.Invoke(item);
        }
    }
}