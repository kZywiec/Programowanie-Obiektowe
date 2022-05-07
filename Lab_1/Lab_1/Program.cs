using System;

namespace Lab_1
{
    //https://dirask.com/posts/WSEI-2021-2022-lato-labN-1-ISN-Programowanie-obiektowe-lab-1-pa3ek1
    class Program
    {
        static void Main()
        {
            Ulamek a = new (1,2);
            Ulamek b = new (5, 4);
            Ulamek c = new (4, 10);
            Ulamek d = new (a);
            Ulamek e = new (2,4);

            Console.WriteLine($"TEST 2: a= {a}");
            Console.WriteLine($"TEST 3: {a} + {b} = {a + b}");
            Ulamek[] arr1 = { a, b, c, d, e };

            Console.WriteLine("Nie posortowane: ");
            for (int i = 0; i < arr1.Length; i++)
                    Console.WriteLine($"Ułamek: {arr1[i].Licznik}/{arr1[i].Mianownik}"); 

            Array.Sort(arr1);

            Console.WriteLine();
            Console.WriteLine("Posortowane rosnąco: ");
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine($"Ułamek: {arr1[i].Licznik}/{arr1[i].Mianownik}");
            }
            Console.WriteLine();
            Console.WriteLine($"Is {a} same as {c}?" + (a==c));
            Console.WriteLine($"Is {a} same as {e}?" + a.Equals(e));
            Console.WriteLine();

            Console.WriteLine(Ulamek.Dziesietny(a));
            Console.WriteLine(a + " " + Ulamek.ZaokronglonyWGore(a) + " " + b + " " + Ulamek.ZaokronglonyWGore(b) + " "+ c + " " + Ulamek.ZaokronglonyWGore(c));
            /*****************************/
        }
    }
    public class Ulamek : IEquatable<Ulamek>, IComparable<Ulamek>
    {
        public int Licznik { get; private set; }
        public int Mianownik { get; private set; }


        /// Tworzy obiekt Ułamek i definuje wartości domyślne.
 
        public Ulamek() => (this.Licznik,this.Mianownik) = (1,1) ;
        

        /// Tworzy obiekt Ułamek na podstawie wprowadzonych danych. 

        /// <param name="licznik"> Licznik ułamka zywkłego</param>
        /// <param name="mianownik">Mianownik ułamka zywkłego</param>
        public Ulamek(int licznik, int mianownik) 
            => (this.Licznik, this.Mianownik) = (licznik, mianownik);

        /// Tworzy kopie wybranego obiektu Ułamek.

        /// <param name="ToCopy"> Obiekt którego kopie chcemy uzyskać</param>
        public Ulamek(Ulamek ToCopy)
            => (this.Licznik ,this.Mianownik) = (ToCopy.Licznik,ToCopy.Mianownik);

        /// Funkcja definuje w jaki sposób obiekt ma być drukowany w konsoli.
        public override string ToString()
        {
            return $"{Licznik}/{Mianownik}";
        }

        /// Funkcja sprawdzająca czy obiekty mają taką samą wartość

        /// <param name="other"> Obiekt do którego porównujemy </param>
        /// <returns> TRUE/FALSE </returns>
        public virtual bool Equals(Ulamek other)
        {
            if (other == null) return false;
            if (other == this) return true;
            return Object.Equals(this.Licznik, other.Licznik) && Object.Equals(this.Mianownik, other.Mianownik);
        }

        /// Funkcja pórwnująca wartości obiektów

        /// <param name="other"> Obiekt do którego porównujemy </param>
        /// <returns> Porównany obiekt jest:   mniejszy(-1),    wiekszy(1),    równy(0)  </returns>
        public int CompareTo(Ulamek other)
        {
            int x = (this.Licznik / other.Mianownik) - (other.Licznik / this.Mianownik);

            if (other == null || x < 0) return -1;
            if (x > 0) return 1;
            return 0;
        }


        /// Przystosowanie operatorów +, -, *, /, ==, !=, <, >, => oraz <= do pracy na ułamkach zwykłych.
        /// 
        /// <param name="a"> Ułamek przed znakiem operacji</param>
        /// <param name="b"> Ułamek po znaku operacji</param>
        /// <returns>Nowy obiekt Ułamek bedący wynikiem działania</returns>
        public static Ulamek operator + (Ulamek a, Ulamek b)
        {
            return new Ulamek(a.Licznik * b.Mianownik + b.Licznik * a.Mianownik, a.Mianownik * b.Mianownik);
            }
        public static Ulamek operator -(Ulamek a, Ulamek b)
        {
            return new Ulamek(a.Licznik * b.Mianownik - b.Licznik * a.Mianownik, a.Mianownik * b.Mianownik);
        }
        public static Ulamek operator *(Ulamek a, Ulamek b)
        {
            return new Ulamek(b.Licznik / a.Mianownik, b.Mianownik * a.Licznik);
        }
        public static Ulamek operator /(Ulamek a, Ulamek b)
        {
            return new Ulamek(b.Mianownik/a.Mianownik,b.Licznik/a.Licznik);
        }
        /*
        public static bool operator ==(Ulamek a, Ulamek b)
        {
            return a.Licznik * b.Mianownik == a.Mianownik * b.Licznik;
        }
        public static bool operator !=(Ulamek a, Ulamek b)
        {
            return a.Licznik * b.Mianownik != a.Mianownik * b.Licznik;
        }
        */
        public static bool operator <(Ulamek a, Ulamek b)
        {
            return a.Licznik * b.Mianownik < a.Mianownik * b.Licznik;
        }
        public static bool operator >(Ulamek a, Ulamek b)
        {
            return a.Licznik * b.Mianownik > a.Mianownik * b.Licznik;
        }
        public static bool operator <=(Ulamek a, Ulamek b)
        {
            return a.Licznik * b.Mianownik <= a.Mianownik * b.Licznik;
        }
        public static bool operator >=(Ulamek a, Ulamek b)
        {
            return a.Licznik * b.Mianownik >= a.Mianownik * b.Licznik;
        }
        

        /// Funkcja konwertuje ulamek zwykly na dziesietny

        /// <param name="x"> Ułamek zwykły</param>
        /// <returns>Forma dzisiętna</returns>
        public static decimal Dziesietny(Ulamek x) 
        {
            decimal a = x.Licznik;
            decimal b = x.Mianownik;
            return  a/b;
        }

        /// Funkcja zaokraglajaca ulamek w góre 

        /// <param name="x">Ułamek zwykły</param>
        /// <returns>Liczba całkowita wynikająca z zaokrąglenia ułaka w góre</returns>
        public static decimal ZaokronglonyWGore(Ulamek x) 
        {
            decimal a = x.Licznik;
            decimal b = x.Mianownik;
            return Math.Round(a/b, MidpointRounding.ToPositiveInfinity);
        }
    }
}