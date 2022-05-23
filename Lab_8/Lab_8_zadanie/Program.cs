using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab_8_zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            Object locker = new();
            Dictionary< int, HashSet<int> > Set = new(); 
            bool TimeOut = false;
            int i = 1,Numarator = 0;

            Thread Timer = new(() =>
            {
                Thread.Sleep(10000);
                TimeOut = true;
            });

            Thread First = new(() 
                => { SearchForPrimaryWithJumpOfNumbers(0, 4); });

            Thread Second = new(() 
                => { SearchForPrimaryWithJumpOfNumbers(1, 4); });  

            Thread Third = new(()
                => { SearchForPrimaryWithJumpOfNumbers(2, 4); });

            Thread Forth = new(() 
                => {SearchForPrimaryWithJumpOfNumbers(3, 4);});
            

            Timer.Start();
            StartSearchForPrimares();

            Timer.Join();
            Console.WriteLine(Set.Count);


            void StartSearchForPrimares() 
            {
                First.Start();
                Second.Start();
                Third.Start();
                Forth.Start();
            }

            void SearchForPrimaryWithJumpOfNumbers(int Jump, int NumberOfAllSerchers)
            {
                int x = i + Jump;
                while (!TimeOut)
                {
                    if (isPrimeNumber(x))
                        lock (locker)
                        {
                            ++Numarator;
                            Set.Add(Numarator, new HashSet<int>(x));
                        }
                    x += NumberOfAllSerchers;
                }
            }

            bool isPrimeNumber (int number)  
            {
                    if (number < 2)
                        return false;

                    if (  number == 2 || number == 3)
                        return true;

                    if (number % 2 == 0)
                        return false;

                    int limit = (int)Math.Floor(Math.Sqrt(number));
                    for (int i = 5, d = 4; i <= limit; i += d)
                    {
                        if (number % i == 0)
                            return false;

                        d = 6 - d;
                    }
                    return  true;
            };
        }
    }
}
