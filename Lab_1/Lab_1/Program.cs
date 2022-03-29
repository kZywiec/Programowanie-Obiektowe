using System;

namespace Lab_1
{
    //https://dirask.com/posts/WSEI-2021-2022-lato-labN-1-ISN-Programowanie-obiektowe-lab-1-pa3ek1
    class Program
    {
        static void Main(string[] args)
        {
            /*****************************/
            /*int L = 1, M = 1;
            Ulamek a = new Ulamek(L, M);
            L = 4; M = 3;
            Ulamek b = new Ulamek(L, M);
             */

            Ulamek a = new Ulamek(1,2);
            Ulamek b = new Ulamek(5, 4);
            Ulamek c = new Ulamek(4, 10);
            Ulamek d = new Ulamek(a);

            Console.WriteLine($"TEST 2: a= {a}");
            Console.WriteLine($"TEST 3: {a} + {b} = {a + b}");
            Ulamek[] arr1 = { a, b, c, d };

            Console.WriteLine("Nie posortowane: ");
            for (int i = 0; i < arr1.Length; i++){
                    Console.WriteLine($"Ułamek: {arr1[i].licznik}/{arr1[i].mianownik}"); 
            }

            Array.Sort(arr1);

            Console.WriteLine();
            Console.WriteLine("Posortowane rosnąco: ");
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine($"Ułamek: {arr1[i].licznik}/{arr1[i].mianownik}");
            }
            Console.WriteLine();
            Console.WriteLine($"Is {a} same as {c}?" + a.Equals(c));
            Console.WriteLine($"Is {a} same as {d}?" + a.Equals(d));
            Console.WriteLine();

            Console.WriteLine(Ulamek.Dziesietny(a));
            Console.WriteLine(a + " " + Ulamek.ZaokronglonyWGore(a) + " " + b + " " + Ulamek.ZaokronglonyWGore(b) + " "+ c + " " + Ulamek.ZaokronglonyWGore(c));
            /*****************************/
        }
    }
    public class Ulamek : IComparable<Ulamek>
    {
        public int licznik { get; private set; }
        public int mianownik { get; private set; }

        /// <summary>
        /// Tworzy obiekt Ułamek i definuje wartości domyślne.
        /// </summary> 
        public Ulamek()
        {
            this.licznik = 1;
            this.mianownik = 1;
        }
        /// <summary>
        /// Tworzy obiekt Ułamek na podstawie wprowadzonych danych. 
        /// </summary>
        /// <param name="licznik"> Licznik ułamka zywkłego</param>
        /// <param name="mianownik">Mianownik ułamka zywkłego</param>
        public Ulamek(int licznik, int mianownik)
        {
            this.licznik = licznik;
            this.mianownik = mianownik;
        }
        /// <summary>
        /// Tworzy kopie wybranego obiektu Ułamek.
        /// </summary>
        /// <param name="ToCopy"> Obiekt którego kopie chcemy uzyskać</param>
        public Ulamek(Ulamek ToCopy)
        {
            this.licznik = ToCopy.licznik;
            this.mianownik = ToCopy.mianownik;
        }
        /// <summary>
        /// Funkcja definuje w jaki sposób obiekt ma być drukowany w konsoli.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{licznik}/{mianownik}";

        }
        /// <summary>
        /// Przystosowanie operatorów +, -, * oraz / do pracy na ułamkach zwykłych.
        /// </summary>
        /// <param name="a"> Ułamek przed znakiem operacji</param>
        /// <param name="b"> Ułamek po znaku operacji</param>
        /// <returns>Nowy obiekt Ułamek bedący wynikiem działania</returns>
        public static Ulamek operator + (Ulamek a, Ulamek b){
            return new Ulamek(a.licznik * b.mianownik + b.licznik * a.mianownik, a.mianownik * b.mianownik);
            }
        public static Ulamek operator -(Ulamek a, Ulamek b){
            return new Ulamek(a.licznik * b.mianownik - b.licznik * a.mianownik, a.mianownik * b.mianownik);
        }
        public static Ulamek operator *(Ulamek a, Ulamek b){
            return new Ulamek(b.licznik / a.mianownik, b.mianownik * a.licznik);
        }
        public static Ulamek operator /(Ulamek a, Ulamek b)
        {
            return new Ulamek(b.mianownik/a.mianownik,b.licznik/a.licznik);
        }

        /// <summary>
        /// Przystosowanie operatorów ==, !=, <, >, => oraz <= do pracy na ułamkach zwykłych.
        /// </summary>
        /// <param name="other"> Obiekt do którego porównujemy</param>
        /// <returns> true/false </returns>
        public static bool operator == (Ulamek a , Ulamek b){
            return a.Equals(b);
        }
        public static bool operator !=(Ulamek a, Ulamek b){
            return !a.Equals(b);
        }
        public static bool operator <(Ulamek a, Ulamek b){
            if (a.CompareTo(b) == -1) return true;
            return false;
        }
        public static bool operator >(Ulamek a, Ulamek b){
            if (a.CompareTo(b) == 1) return true;
            return false;
        }
        public static bool operator <=(Ulamek a, Ulamek b){
            if (a.CompareTo(b) == -1 || a.CompareTo(b) == 0) return true;
            return false;
        }
        public static bool operator >=(Ulamek a, Ulamek b){
            if (a.CompareTo(b) == 1 || a.CompareTo(b) == 0) return true;
            return false;
        }


        /// <summary>
        /// Funkcja sprawdzająca czy obiekty mają taką samą wartość
        /// </summary>
        /// <param name="other"> Obiekt do którego porównujemy </param>
        /// <returns> TRUE/FALSE </returns>
        public virtual bool Equals(Ulamek? other){
            if (other == null) return false;
            else if ((other.licznik * this.mianownik) == this.licznik * other.mianownik) return true;
            return Object.Equals(this.licznik, other.licznik) && Object.Equals(this.mianownik, other.mianownik);
        }
        /// <summary>
        /// Funkcja pórwnująca wartości obiektów
        /// </summary>
        /// <param name="other"> Obiekt do którego porównujemy </param>
        /// <returns> Porównany obiekt jest:   mniejszy(-1),    wiekszy(1),    równy(0)  </returns>
        public int CompareTo(Ulamek other){
            int a = this.licznik * other.mianownik,
                b = other.licznik * this.mianownik;

            if (other == null || a < b) return -1;
            else if (a > b) return 1;
            else return 0;
        }
        /// <summary>
        /// Funkcja konwertuje ulamek zwykly na dziesietny
        /// </summary>
        /// <param name="x"> Ułamek zwykły</param>
        /// <returns>Forma dzisiętna</returns>
        public static decimal Dziesietny(Ulamek x) {
            decimal a = x.licznik;
            decimal b = x.mianownik;
            return  a/b;
        }
        /// <summary>
        /// Funkcja zaokraglajaca ulamek w góre 
        /// </summary>
        /// <param name="x">Ułamek zwykły</param>
        /// <returns>Liczba całkowita wynikająca z zaokrąglenia ułaka w góre</returns>
        public static decimal ZaokronglonyWGore(Ulamek x) {
            decimal a = x.licznik;
            decimal b = x.mianownik;
            return Math.Round(a/b, MidpointRounding.ToPositiveInfinity);
        }

    }
}
