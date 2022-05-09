using System;

namespace Lab_2_zadanie
{
    public class Program
    {
        public static void Main()
        {
            Seller treacher = new ("Jan Kowalski", 50);

            Buyer buyer1 = new ("Jaś Fasola 1", 25);
            Buyer buyer2 = new ("Jaś Fasola 2", 21);
            Buyer buyer3 = new ("Jaś Fasola 3", 23);

            buyer1.AddProduct(new Fruit("Apple", 6));
            buyer1.AddProduct(new Meat("Fish", 0.5));

            Person[] persons = { treacher, buyer1, buyer2, buyer3 };

            Product[] products = {
                new Fruit("Apple", 1000),
                new Fruit("Banana", 700),
                new Fruit("Orange", 500),
                new Meat("Fish", 100.0),
                new Meat("Beef", 75.0)
            };

            Shop shop = new ("Super Market", persons, products);

            shop.Print();
        }
    }
}
