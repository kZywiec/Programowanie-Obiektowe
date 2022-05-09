using System;

namespace Lab_2_zadanie
{
    class Product: IThing
    {
        protected string name;
        public string Name { get => name; set =>name = value; }

        protected Product(string name) 
            => this.name = name;

        public virtual void Print(string prefix)
            => Console.Write($"{prefix} {this.Name}");
    }
}
