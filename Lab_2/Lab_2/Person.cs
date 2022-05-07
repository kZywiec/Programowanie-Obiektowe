using System;

namespace Lab_2
{
    class Person: IEquatable<Person>
    {
        protected string name;
        protected int age;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public Person(string name, int age)
            => (this.name, this.age) = (name, age);

        public bool Equals(Person other)
            => (this.name, this.age)== (other.name, other.age);

        public override string ToString()
            => $"{Name} ({Age}'y.o)";
    }
}
