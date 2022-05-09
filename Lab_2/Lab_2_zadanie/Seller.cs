using System;

namespace Lab_2_zadanie
{
    class Seller: Person
    {
        public Seller(string name, int age) : base(name, age) { }
        public override void Print(string prefix)
        {
            Console.Write($"{prefix}Seller: ");
            base.Print(prefix);
        }
    }
}
