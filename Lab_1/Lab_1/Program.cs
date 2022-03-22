using System;

namespace Lab_1
{
    //https://dirask.com/posts/WSEI-2021-2022-lato-labN-1-ISN-Programowanie-obiektowe-lab-1-pa3ek1
    class Program
    {
        static void Main(string[] args)
        {
            /*****************************/
            Ulamek a = new Ulamek(1,2);
            Ulamek b = new Ulamek(5, 4);
            Ulamek c = new Ulamek(4, 10);
            Ulamek d = new Ulamek(a);

            Ulamek[] arr1 = { a, b, c };

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

        //konstruktor domyślny
        public Ulamek(){
            this.licznik = 1;
            this.mianownik = 1;
        }
        //konstruktor pozwalajacy na wprowadzenie danych 
        public Ulamek(int licznik, int mianownik){
            this.licznik = licznik;
            this.mianownik = mianownik;
        }
        //konstruktor kopiujący
        public Ulamek(Ulamek ToCopy){
            this.licznik = ToCopy.licznik;
            this.mianownik = ToCopy.mianownik;
        }
        public override string ToString(){
            return $"I= {licznik}, M = {mianownik}";

        //Przystosowanie operatorow do pracy na ulamkach zwyklych
        }
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
        //Funkcja sprawdzajaca czy obiekty sa identyczne 
        public bool Equals(Ulamek other)
        {
            if (other == null) return false;
            else if (other == this) return true;
            return Object.Equals(this.licznik, other.licznik) && Object.Equals(this.mianownik, other.mianownik);
        }
        //Funkcja ustalajaca logike sortowania obiektow w tablicach 
        public int CompareTo(Ulamek other)
        {
            int a = this.licznik * other.mianownik,
                b = other.licznik * this.mianownik;

            if (other == null || a < b) return -1;
            else if (a > b) return 1;
            else return 0;
        }
        //Funkcja konwertuje ulamek zwykly na dziesietny
        public static decimal Dziesietny(Ulamek x) {
            decimal a = x.licznik;
            decimal b = x.mianownik;
            return  a/b;
        }
        //Funkcja zaokraglajaca ulamek w gore 
        public static decimal ZaokronglonyWGore(Ulamek x) {
            decimal a = x.licznik;
            decimal b = x.mianownik;
            return Math.Round(a/b, MidpointRounding.ToPositiveInfinity);
        }

    }
}
