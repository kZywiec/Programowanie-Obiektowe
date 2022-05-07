namespace Lab_2
{
    class Classroom
    {
        protected string name;
        protected Person[] persons;

        public string Name;
        public Classroom(string name, Person[] persons) 
            => (this.name, this.persons) = (name, persons);

        public override string ToString()
        {
            string resoult = "";
            for (int i = 0; i < this.persons.Length; i++)
                resoult += $"{persons[i]}\n";
            return resoult;
        }
    }
}
