using System;
using System.Collections.Generic;

namespace Lab_2
{
    public class Program
    {
        public static void Main()
        {
            Teacher treacher = new Teacher("Maria Skłodowska", 50);

            Student student1 = new Student("Jan Kowaslski", 21, "LAB-01");
            Student student2 = new Student("Jan Kowaslski", 21, "LAB-01");
            Student student3 = new Student("Jaś Fasola", 23, "LAB-02");

            student1.AddTask("Taks A", TaskStatus.Waiting);
            student1.AddTask("Taks B", TaskStatus.Waiting);
            student1.AddTask("Taks C", TaskStatus.Rejected);

            student2.AddTask("Taks A", TaskStatus.Waiting);
            student2.AddTask("Taks B", TaskStatus.Waiting);
            student2.AddTask("Taks C", TaskStatus.Rejected);

            student3.AddTask("Taks D", TaskStatus.Done);
            student3.AddTask("Taks E", TaskStatus.Waiting);
            student3.AddTask("Taks F", TaskStatus.Waiting);

            student3.UpdateTask(1, TaskStatus.Done);
            student3.UpdateTask(2, TaskStatus.Progress);

            Person[] persons = { treacher, student1, student2, student3 };
            Classroom classroom = new Classroom("Sala Komputerowa", persons);

            Console.WriteLine(classroom);

            Console.WriteLine("student1 == student2: " + student1.Equals(student2)); // Output: student1 == student2: true
            Console.WriteLine("student1 == student3: " + student1.Equals(student3)); // Output: student1 == student3: false
        }
    }

    public abstract class Person: IEquatable<Person>
    {
        private string name;
        private int age { get ; set; }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value;}

        internal Person() { }
        public Person(string _Name, int _Age) 
            => (this.name, this.age) = (_Name, _Age);

        public bool Equals(Person? other)
        {
            if (other == null) return false;
            else if (other.name == this.name && other.age == this.age ) return true;
            return Object.Equals(this.name, other.name) && Object.Equals(this.age, other.age);
        }

        public override string ToString() 
            => $"{name} ({age} y.o.)"; 
    }

    public class Teacher : Person
    {
        public Teacher(string _name, int _age) 
            => (this.Name, this.Age) = (_name, _age);


        public override string ToString() 
            => $"Teacher: {Name} ({Age} y.o.)";
    }

    public class Student : Person, IEquatable<Student>
    {
        private string group;
        public string Group { get => group; set => group = value; }
        private List<Task> tasks;

        public Student(string _name, int _age, string _group)
            => (this.Name, this.Age, this.Group) = (_name, _age, _group);
        public Student(string _name, int _age, string _group, List<Task> _tasks)
            => (this.Name, this.Age, this.Group, this.tasks) = (_name, _age, _group, _tasks);

        public void AddTask(string _Name, TaskStatus _TaskStatus)
           => this.tasks.Add(new Task(_Name, _TaskStatus ));

        public void RemoveTask(int _Index)
            => this.tasks.RemoveAt(_Index - 1);

        public void UpdateTask(int _Index, TaskStatus _TaskStatus)
        {
            
        }
        public void RenderTasks(string prefix = "\t" )
        {

        }

        public bool Equals(Student? other)
        {
            if (other == null) return false;
            else if (other.Name == this.Name && other.Age == this.Age && other.Group == this.Group) return true;
            return Object.Equals(this.Name, other.Name) && Object.Equals(this.Age, other.Age) && Object.Equals(this.Group, other.Group);
        }
        //public bool SequenceEquals(List<Task> a, List<Task> b)
        //{
        //    if (other == null) return false;
        //    else if (other.Name == this.Name && other.Age == this.Age && other.Group == this.Group) return true;
        //    return Object.Equals(this.Name, other.Name) && Object.Equals(this.Age, other.Age) && Object.Equals(this.Group, other.Group);
        //}
        public override string ToString()
    => $"Student: {Name} ({Age} y.o.)";
    }

    public class Task: IEquatable<Task>
    {
        private string name;
        private TaskStatus status;

        public string Name { get => name; set => name = value; }
        public TaskStatus Status { get => status; set => status = value; }
        
        public Task(string _Name, TaskStatus _Status) 
            => (this.Name, this.Status) = (_Name, _Status);
        
        public override string ToString() 
            => $"{Name} [{Status}]";

        public bool Equals(Task? other)
        {
            if (other == null) return false;
            else if (other.Name == this.Name && other.Status == this.Status) return true;
            return Object.Equals(this.Name, other.Name) && Object.Equals(this.Status, other.Status);
        }
    }

    public enum TaskStatus
    {
        Waiting,
        Progress,
        Done,
        Rejected
    }
    
    public class Classroom
    {
        private string name;
        public Person[] persons;
        public string Name { get => name; set => name = value; }

        public Classroom(string _name, Person[] _persons)
            => (this.Name, this.persons) = (_name, _persons);
        public override string ToString()
        {
            string temp = $"Classroom: {Name}\n";
            for (int i = 0; i < persons.Length; i++)
            {
                temp += $"\n{persons[i]}";
                temp += "\n";
            }
            return $"{temp}";
        }
    }
}