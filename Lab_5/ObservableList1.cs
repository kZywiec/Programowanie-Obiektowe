using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    class ObservableList1 <T>
    {
        //*****Properties*****
        public int Length => list.Count();
        private List<T> list = new List<T>();

        //*****Constructors*****
        public ObservableList1() { }
        public ObservableList1(List<T> list) => this.list = list;


        //*****Events*****
        public event Action Added;
        public event Action Updated;
        public event Action Removed;

        //*****Metchods*****
        public void Add(T ToAdd)
        { 
            list.Add(ToAdd);
            Added?.Invoke();
            Updated?.Invoke();
        }

        public T Get(int index) => list[index];

        public void Set(int index, T ToAdd)
        {
            list[index] = ToAdd;
            Updated?.Invoke();
        }

        public void RemoveAt(int index) 
        { 
            list.RemoveAt(index);
            Removed?.Invoke();
            Updated?.Invoke();
        }

        public T this[int index]
        {
            get => list[index];
            set
            {
                list[index] = value;
                Updated?.Invoke();
            }
        }
    }
}
