using System;

namespace Lab_2_zadanie
{
    class Shop
    {
        protected string name;
        protected Person[] people;
        protected Product[] products;

        public string Name { get => name; set => name = value; }

        public Shop(string name, Person[] people, Product[] products) 
            => (this.name, this.people, this.products) = (name, people, products);
        public void Print()
        {
            Console.WriteLine($"Shop: {Name}");
            Console.WriteLine("--People--");
            for (int i = 0; i < this.people.Length; i++)
                people[i].Print("\t");
            Console.WriteLine("--Products--");
            for (int i = 0; i < this.products.Length; i++)
                products[i].Print("\t");
        }
    }
}
