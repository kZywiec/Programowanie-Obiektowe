namespace Lab_2
{
    class Teacher: Person
    {
        public Teacher(string name, int age) : base(name, age) { }

        public override string ToString()
            => $"Teacher: {this.Name} ({this.Age} y.o.)";
    }
}
