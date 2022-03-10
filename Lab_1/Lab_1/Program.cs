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
            Ulamek b = new Ulamek(3, 4);
            Ulamek c = new Ulamek(4, 10);
            Ulamek[] arr1 = { a, b, c };

            for (int i = 0; i < arr1.Length; i++){
                    Console.WriteLine($"Ułamek: {arr1[i].licznik}/{arr1[i].mianownik}"); 
            }
            /*****************************/
        }
    }
    public class Ulamek : IComparable<Ulamek>
    {
        /*zapytać o public!!!!!!!!!!!!
         *(prywatne zmienne licznik i mianownik (typu całkowitego ze znakiem) 
         *!=  
         *Zmodyfikuj klasę tak, aby możliwe było, tylko i wyłącznie, odczytywanie licznika i mianownika
         *(wykorzystaj gettery).)
         */
        public int licznik { get; private set; }
        public int mianownik { get; private set; }
        //????????????????????????????????
        public int Equals(int licznik, int mianownik){
            if (licznik == this.licznik && mianownik == this.mianownik)
                return 1;
            else 
                return 0;
        }
        //????????????????????????????????
        public int CompareTo(Ulamek other){
            if (this.licznik / this.mianownik < other.licznik / other.mianownik)
                return 1;
            else if (this.licznik / this.mianownik > other.licznik / other.mianownik)
                return -1;
            else
                return 0;
            }
        //????????????????????????????????
        public Ulamek(){
            this.licznik = 1;
            this.mianownik = 1;
        }

        public Ulamek(int licznik, int mianownik){
            this.licznik = licznik;
            this.mianownik = mianownik;
        }

        public Ulamek(Ulamek ToCopy){
            this.licznik = ToCopy.licznik;
            this.mianownik = ToCopy.mianownik;
        }
        public override string ToString(){
            return $"I= {licznik}, M = {mianownik}";
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
    }
}
