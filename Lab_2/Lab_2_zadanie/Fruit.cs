using System;

namespace Lab_2_zadanie
{
    class Fruit : Product
    {
        protected int count;
        
        public int Count { get => count; set => count = value; }

        public Fruit(string name, int count) : base(name) 
            => this.count = count;

        public override void Print(string prefix)
        {
            base.Print(prefix);
            Console.Write($"{prefix}({count} fruits)\n");
        }
    }
}
