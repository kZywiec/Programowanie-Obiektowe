using System;
using System.Threading;

namespace Lab_8
{
    class Program
    {
        static void Main(string[] args)
        {

			//zmodyfikuj program tak, aby wykonywać jednocześnie 2 pętle.
			Thread thread = new (() =>
			{
				for (int i = 1; i <= 5; ++i)
				{
					Console.WriteLine("Iteration: " + i);
					Thread.Sleep(1000); // sleeps created thread for 1 second
				}
			});

			Thread thread2 = new (() =>
			{
				for (int i = 1; i <= 5; ++i)
				{
					Console.WriteLine("Iteration xyz: " + i);
					Thread.Sleep(1000); // sleeps created thread for 1 second
				}
			});

			//dodaj nazwy dla wątków i odpowiedz na pytanie:

			thread.Name ="Iteration_sleeper";
			thread2.Name = "Iteration_sleeper_2_xyz";

			thread.Start();
			thread.Join();
			thread2.Start();

			///Czy podczas debugowania kodu coś się zmieniło w Visual Studio?
			///nowe komunikaty:
			///Wątek 0x33b0 zakończył działanie z kodem 0 (0x0).
			///Wątek 0xb74 zakończył działanie z kodem 0(0x0).
			/// 
			///Co robi metoda Thread.Sleep(1000)?
			/// Odczekuje 1000ms (1s)
			///
			///Co robi metoda Thread Join()?
			/// Sprawia że działanie grównego wątku jest wstrzymane do czasu zakończenia wybranego wątku
			///
		}
	}
}
