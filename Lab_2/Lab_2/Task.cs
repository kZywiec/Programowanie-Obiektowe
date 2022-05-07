using System;

namespace Lab_2
{
    class Task: IEquatable<Task>
    {
        protected string name;
        protected TaskStatus status;

        public string Name { get => name; set => name = value; }
        public TaskStatus Status { get => status; set => status = value; }

        public Task(string name, TaskStatus status)
            => (this.name, this.status) = (name, status);

        public override string ToString()
            => $"{Name} [{status}]";

        public bool Equals(Task other)
            => (this.name, this.status) == (other.name, other.status);
    }
}
