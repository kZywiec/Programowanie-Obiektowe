using System;
using System.Collections.Generic;

namespace Lab_2
{
    class Student: Person, IEquatable<Student>
    {
        protected string group;
        protected List<Task> tasks;

        public string Group { get => group; set => group = value; }

        public Student(string name, int age, string group) : base(name, age)
            => (this.group, this.tasks) = (group, new List<Task>());

        public Student(string name, int age, string group, List<Task> tasks) : base(name, age)
            => (this.group, this.tasks) = (group, tasks);

        public void AddTask(string task, TaskStatus status) 
            => this.tasks.Add(new Task(task, status));

        public void RemoveTask(int index) 
            => this.tasks.RemoveAt(index);

        public void UpdateTask(int index, TaskStatus taskStatus)
        {
            if (index < tasks.Count)
                tasks[index].Status = taskStatus;
        }

        public string RenderTasks(string prefix = "\t")
        {
            string resoult = "";
            for ( int i = 0; i < tasks.Count; i++)
                resoult += $"{prefix} {i + 1}. {tasks[i].Name} [{ tasks[i].Status}]\n";
            return resoult;
        }

        public override string ToString()
        {
            return $"Student: {this.Name} ({this.Age} y.o.)\n" +
                   $"Group: {this.Group}\n" +
                   $"Tasks:\n" +
                   RenderTasks();  
        }

        public bool Equals(Student other)
        {
            if (this.name == other.name &&
                this.age == other.age &&
                this.group == other.group &&
                SequenceEqual(this.tasks, other.tasks))
                return true;

            return false;
        }
        public bool SequenceEqual(List<Task> a, List<Task> b)
        {
            if (a.Count != b.Count) return false;

            for (int i = 0; i < a.Count; i++)
                if (!a[i].Equals(b[i]))
                    return false;

            return true;
        }
    }
}
