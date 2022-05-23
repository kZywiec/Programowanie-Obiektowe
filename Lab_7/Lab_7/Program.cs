using System;


namespace Lab_7
{

    class MyProgram
    {
        static void Main(string[] args)
        {

                int index = 6;
                int val = 44;
                int[] a = new int[10];
                try
                {
                    a[index] = val;
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.Write("Index out of bounds ");
                }
                Console.Write("Remaining program");

            Console.WriteLine(a[6]);
        }


    }

}

