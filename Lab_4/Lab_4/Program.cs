using System;

using System.Collections;
//Zawiera interfejsy i klasy definiujące różne kolekcje obiektów,
//takie jak listy, kolejki, tablice bitowe, tabele skrótów i słowniki.

using System.Collections.Generic;
//Zawiera interfejsy i klasy definiujące kolekcje ogólne, które umożliwiają
//użytkownikom tworzenie silnie typicznych kolekcji, które zapewniają lepsze
//bezpieczeństwo i wydajność typów niż kolekcje niegeneryczne silnie typowane.

using System.Collections.Immutable;
//Zawiera interfejsy i klasy, które definiują Niezmienne kolekcje.

using System.Collections.Concurrent;
//Zapewnia kilka klas kolekcji bezpiecznych dla wątków, które powinny być używane
//zamiast odpowiednich typów w System.CollectionsSystem.Collections.Generic
//przestrzeniach nazw i za każdym razem, gdy wiele wątków uzyskuje dostęp do
//kolekcji współbieżnie.

namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // using System.Collections;
            Console.WriteLine("\nusing System.Collections =>\n");
            IList list = new ArrayList();
            IDictionary dictionary1 = new SortedList();
            IDictionary dictionary2 = new Hashtable();
            Queue queue = new Queue();
            Stack stack = new Stack();

            //Kolejka
            foreach (var value in new int[] { 11, 12, 13, 14, 15 })
            {
                queue.Enqueue(value);       //wpisanie wartości Int
            }
            queue.Enqueue("value");         //dopisanie wartości String

            Console.WriteLine("Queue: 'queue' ");
            Console.WriteLine("\tCount: " + queue.Count);   //Sprawdzenie ilosci elementow
            Console.WriteLine("\tReturned and removed: " + queue.Dequeue());             //Pobranie, wypisanie i usunieci
            Console.WriteLine("\tCount: " + queue.Count);   //Sprawdzenie ilosci elementow
            Console.Write("\tValues: ");

            foreach (var item in queue)        // Zastosowanie iteracji
            {
                Console.Write("[" + item + "] ");     //Wypisanie pozostałych wartości
            }

            Console.WriteLine("\n\tCount: " + queue.Count + "\n"); //Sprawdzenie ilosci elementow




            // using System.Collections.Generic;
            Console.WriteLine("\nusing System.Collections.Generic =>\n");
            IList<int> list1 = new List<int>();
            LinkedList<int> list2 = new LinkedList<int>();
            ISet<int> set1 = new HashSet<int>();
            ISet<int> set2 = new SortedSet<int>();
            IDictionary<string, int> dictionary11 = new Dictionary<string, int>();
            IDictionary<string, int> dictionary22 = new SortedList<string, int>();
            IDictionary<string, int> dictionary33 = new SortedDictionary<string, int>();
            Queue<int> queue1 = new Queue<int>();
            Stack<int> stack1 = new Stack<int>();
            // PriorityQueue<int, int> queue2 = new PriorityQueue<int, int>();

            //Kolejka
            foreach (var value in new int[] { 11, 12, 13, 14, 15 })
            {
                queue1.Enqueue(value);       //wpisanie wartości Int
            }                                /*
            
            queue1.Enqueue("value");
                    => dopisanie wartości String
                        w tym przypadku już nie zadziała */ 

            Console.WriteLine("Queue<int>: 'queue1' ");
            Console.WriteLine("\tCount: " + queue1.Count); //Sprawdzenie ilosci elementow
            Console.WriteLine("\tReturned and removed: " + queue1.Dequeue());             //Pobranie, wypisanie i usunieci
            Console.WriteLine("\tCount: " + queue1.Count); //Sprawdzenie ilosci elementow
            Console.Write("\tValues: ");

            foreach (var item in queue1)        // Zastosowanie iteracji
            {
                Console.Write("[" + item + "] ");     //Wypisanie pozostałych wartości
            }

            Console.WriteLine("\n\tCount: " + queue1.Count + "\n"); //Sprawdzenie ilosci elementow


            //Zadanie 4
            //Kolekcja generyczna DynamicArray
            Console.WriteLine("\nMy own collection =>\n"); 
            DynamicArray<int?> Dynamic = new DynamicArray<int?>(5); // Tworzenie

            Dynamic[0] = 1;
            Dynamic[0] = null;
            Dynamic[1] = 2;         //Dopisywanie wartości
            Dynamic[2] = null;
            Dynamic[4] = 4;
            Dynamic[4] = 5;

            Console.WriteLine("DynamicArray: 'Dynamic' ");  
            Console.WriteLine("\tCapacity: " + Dynamic.Capacity());        //Wypisywanie
            Console.Write("\tValues: ");

            foreach (var item in Dynamic)       //Iteracaj 
            {
                Console.Write("[" + item + "] ");   //Wypisanie pozostałych wartości
            }

            Console.WriteLine("\n\tCout: " + Dynamic.Count());
        }
    }

    public class DynamicArray<T>: IEnumerable<T>, IEnumerator<T>
    {
        // Stats
        private int count = 0;
        private int size;

        // var's for IEnumerator
        private int curIndex = -1;
        private T curValue;

        // Array
        private T?[] arr;

        // Indexer
        public T this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }

        // Constructor
        public DynamicArray(int size)
        {
            this.arr = new T[size];
            this.size = size;
        }

        // Number of values in arr 
        public int Count()
        {
            foreach(var value in this.arr)
            {
                if (value != null)
                    this.count++;       
            }
            return this.count;
        }

        // Size of arr
        public int Capacity()
            =>  this.size;

        // IEnumerator Index++
        public bool MoveNext()
        {
            if (++curIndex >= this.size)
                return false;
            
            curValue = this.arr[curIndex];
            return true;
        }

        // IEnumerator Reset to base Index
        public void Reset()
            => curIndex = -1;

        // IEnumerator Value of current cell
        public T Current
            { get => curValue; }
        

        object IEnumerator.Current
        {
            get { return Current; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return Current;
        }
        //?????????????????????????????????????????????
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)arr).GetEnumerator();
        }

        void IDisposable.Dispose() { }
    }

}
