using System;

namespace Lab_2_zadanie
{
    class Meat: Product
    {
        protected double weight;
        public double Weight { get => weight; set => weight = value; }

        public Meat(string name, double weight) : base(name) 
            => this.weight = weight;
        public override void Print(string prefix)
        {
            base.Print(prefix);
            Console.Write($"{prefix}({this.Weight} kg)\n");
        }
    }
}
