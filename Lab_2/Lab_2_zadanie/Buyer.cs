using System;
using System.Collections.Generic;

namespace Lab_2_zadanie
{
    class Buyer: Person
    {
        protected List<Product> tasks = new List<Product>();

        public Buyer(string name, int age) : base(name, age) { }
        
        public void AddProduct(Product product)
            => this.tasks.Add(product);

        public void RemoveProduct(int index) 
            => this.tasks.RemoveAt(index);
        public override void Print(string prefix) 
        {
            Console.Write($"{prefix}Buyer: ");
            base.Print(prefix);
            if (this.tasks.Count > 0)
            {
                Console.WriteLine($"{prefix}{prefix}--Products:--");
                for (int i = 0; i < this.tasks.Count; i++)
                {
                    Console.Write(prefix);
                    tasks[i].Print("\t");
                }
            }
        }
    }
}
