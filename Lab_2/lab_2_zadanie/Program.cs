using System;
using System.Collections.Generic;

namespace lab_2_zadanie
{
    public class Program
    {
        public static void Main()
        {
            Seller treacher = new Seller("Jan Kowalski", 50);

            Buyer buyer1 = new Buyer("Jaś Fasola 1", 25);
            Buyer buyer2 = new Buyer("Jaś Fasola 2", 21);
            Buyer buyer3 = new Buyer("Jaś Fasola 3", 23);

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

            Shop shop = new Shop("Super Market", persons, products);

            shop.Print();
        }
    }
    interface IThing
    {
        String Name { get; set; }
    }

    public class Person : IThing
    {
        internal string name;
        internal int age;

        string IThing.Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public Person() { }
        public Person(string _Name, int _Age)
            => (this.name, this.age) = (_Name, _Age);

        public void Print(string prefix)
        {

        }

    }

    public class Buyer : Person
    {
        private List<Product> tasks = new List<Product>();
        public Buyer(string _Name, int _Age) => (this.name, this.age) = (_Name, _Age);

        public void AddProduct(Product product)
            => this.tasks.Add(product);
        public void RemoveProduct(int index)
            => this.tasks.RemoveAt(index - 1);

        public void Print(string prefix)
        {

        }
    }

    public class Seller : Person
    {
        public Seller(string _Name, int _Age) => (this.name, this.age) = (_Name, _Age);

        public void Print(string prefix)
        {

        }
    }

    public class Product : IThing
    {
        internal string name;
        string IThing.Name { get => name; set => name = value; }

        public Product() { }
        public Product(string _Name, int _Age) => (this.name) = (_Name);

        public void Print(string prefix)
        {

        }
    }

    public class Fruit : Product
    {
        private int count;
        public int Count { get => count; set => count = value; }
        public Fruit(string _Name, int _Count) => (this.name, this.count) = (_Name, _Count);

        public void Print(string prefix)
        {

        }
    }
    public class Meat : Product
    {
        private double weight;
        public Meat(string _Name, double _Weight) => (this.name, this.weight) = (_Name, _Weight);

        public void Print(string prefix)
        {

        }
    }

    public class Shop : IThing
    {
        private string name;
        Person[] people;
        Product[] products;

        string IThing.Name { get => name; set => name = value; }

        public Shop(string _Name, Person[] _People, Product[] _Products) => (this.name, this.people, this.products) = (_Name, _People, _Products);
        public void Print()
        {

        }
    }

}
