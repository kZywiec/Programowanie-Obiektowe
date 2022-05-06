using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab_6
{
    public class User
    {
        public string Name { get; set; }
        public string Role { get; set; } // ADMIN, MODERATOR, TEACHER, STUDENT
        public int Age { get; set; }
        public int[] Marks { get; set; } // zawsze null gdy ADMIN, MODERATOR lub TEACHER
        public DateTime? CreatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }

        public User() { }
        public User(string name, string role, int age)
        {
            this.Name = name;
            this.Role = role;
            this.Age = age;
            CreatedAt = DateTime.Now;

            if (role == "STUDENT")
            {
                Random r = new Random();
                int x = r.Next(1, 10);
                Marks = new int[x];
                for (int i = 0; i < x; i++)
                    Marks[i] = r.Next(1, 6); 
            }
        }
    }



    enum EnumRoles
    {
        ADMIN,
        MODERATOR,
        TEACHER,
        STUDENT
    }

    class Program
    {

        static List<User> users = new List<User>()
        {
            new User("Karol", "ADMIN", 37),
            new User("Wojtyła", "ADMIN", 67){ RemovedAt = DateTime.Now,},
            new User("Marek", "ADMIN", 47),

            new User("Mario", "MODERATOR", 35),
            new User("Pedro", "MODERATOR" , 19),
            new User("Pablo", "MODERATOR", 25),
            new User("Suarez", "MODERATOR", 23),

            new User("Antonio.V", "TEACHER", 42),
            new User("Ludig.B", "TEACHER", 54),
            new User("Amadeus.M", "TEACHER", 43),
            new User("Sebastian.B", "TEACHER", 66),
            new User("Fryderyk.Ch", "TEACHER", 72),

            new User("Adam", "STUDENT", 22),
            new User("Aleksandra", "STUDENT", 19),
            new User("Beata", "STUDENT", 20),
            new User("Bogdan", "STUDENT", 21),
            new User("Celina", "STUDENT", 23),
            new User("Cezary", "STUDENT", 22),
            new User("Debora", "STUDENT", 21){ CreatedAt = new DateTime(2008,03,21) },
            new User("Daniel", "STUDENT", 24){ CreatedAt = new DateTime(2002,04,24) },
        };
 
        static void Main(string[] args)
        {
            // ZAD 1
            var zad1 = (from u in users select u).Count();
            Console.WriteLine("1. Ilość rekordów w tablicy: " + zad1);

            // ZAD 2
            var zad2 = users.Select(u => u.Name).ToList();
            Console.WriteLine("2. Lista nazw użytkowników:");
            zad2.ToList().ForEach(x => Console.WriteLine("   - " + x));

            // ZAD 3
            var zad3 = from u in users orderby u.Name select u;
            Console.WriteLine("3. Posortowana lista[NAZWA]:");
            zad3.ToList().ForEach(x => Console.WriteLine("   - " + x.Name));

            // ZAD 4
            Console.WriteLine("4. Dostępne role: ");
            foreach (var role in Enum.GetValues(typeof(EnumRoles)))
                Console.WriteLine("   - " + role); 
            
            // ZAD 5
            var zad5 = users.OrderBy(zad5 => zad5.Role);
            List<string> x = (from user in users orderby user.Role select user.Name + "[" + user.Role + "]").ToList();
            Console.WriteLine("5. Posortowana lista[ROLA]:");
            foreach (string user in x)
                Console.WriteLine("   - " + user);

            // ZAD 6
            var zad6 = (from user in users where user.Marks != null && user.Marks.Count() > 0 select user).Count();
            Console.WriteLine("6. Ilość uzytkowników + z ocenami: " + zad6);

            // ZAD 7
            var zad7suma = (from u in users where u.Marks != null select u.Marks.Sum()).Sum();
            Console.WriteLine($"7a. Suma ocen: {zad7suma}");

            var zad7ilosc = (from u in users where u.Marks != null select u.Marks.Length).Sum();
            Console.WriteLine("7b. Ilość ocen: " + zad7ilosc);

            var zad7srednia = zad7suma / zad7ilosc;
            Console.WriteLine("7c. Średnia ocen: " + zad7srednia);

            // ZAD 8
            var zad8 = (from u in users where u.Marks != null orderby u.Marks.Max() descending select u.Marks.Max()).First();
            Console.WriteLine("8. Najwyższa ocena: " + zad8);

            // ZAD 9
            var zad9 = (from u in users where u.Marks != null orderby u.Marks.Min() select u.Marks.Min()).First();
            Console.WriteLine("9. Najmniejsza ocena: " + zad9);

            // ZAD 10
            var zad10 = (from u in users where u.Marks != null orderby u.Marks.Average() descending select u).First();
            Console.WriteLine($"10. Najpilniejszym uczniem jest  *-*| {zad10.Name} |*-*");

            // ZAD 11
            var zad11 = (from u in users where u.Marks != null orderby u.Marks.Length select u).Take(3);
            Console.WriteLine($"11. Studenci z najmniejszą ilością ocen: ");
            zad11.ToList().ForEach(x => Console.WriteLine($"    - {x.Name} ma {x.Marks.Length} ocen"));

            // ZAD 12
            var zad12 = (from u in users where u.Marks != null orderby u.Marks.Length descending select u).Take(3);
            Console.WriteLine($"12. Studenci z największą ilością ocen: ");
            zad12.ToList().ForEach(x => Console.WriteLine($"    - {x.Name} ma {x.Marks.Length} ocen"));


            // ZAD 13
            var zad13 = from u in users where u.Marks != null select new { Name = u.Name, Avg = u.Marks.Average() };
            Console.WriteLine($"13. Wyniki studentów: ");
            zad13.ToList().ForEach(x => Console.WriteLine($"    - {x.Name} Średnia: {x.Avg}"));


            // ZAD 14
            var zad14 = from u in users where u.Marks != null orderby u.Marks.Length descending select u;
            Console.WriteLine("14. Ranking Studentów: ");
            zad14.ToList().ForEach(x => Console.WriteLine($"    - {x.Name} ({x.Marks.Average()})"));


            // ZAD 15
            var zad15 = (from u in users where u.Marks != null select u.Marks.Average()).Sum() / (from u in users where u.Marks != null select u).Count();
            Console.WriteLine($"15. Srednia grupy: {zad15}");


            // ZAD 16



            // ZAD 17



            // ZAD 18
            var zad18 = (from u in users where u.Marks != null orderby u.CreatedAt descending select u).First();
            Console.WriteLine($"18. Ostatnio stworzeone konto: {zad18.Name} [{zad18.CreatedAt}]");
        }
    }
}
