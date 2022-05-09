using System;

namespace Lab_2_zadanie
{
    class Person : IThing
    {
        protected string name;
        protected int age;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        protected Person(string name, int age) 
            => (this.name, this.age) = (name, age);

        public virtual void Print(string prefix)
            => Console.Write($"{this.Name} ({this.Age} y.o.)\n");
    }
}
