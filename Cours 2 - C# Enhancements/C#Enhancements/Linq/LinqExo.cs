using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public class LinqExo
    {
        private static List<Student> Students = new List<Student>
        {
                new Student{BoosterId = 1, Firstname = "toto", Lastname = "toto"},
                new Student{BoosterId = 2, Firstname = "tata", Lastname = "tata"},
                new Student{BoosterId = 3, Firstname = "fred", Lastname = "fred"},
                new Student{BoosterId = 4, Firstname = "k", Lastname = "k"},
                new Student{BoosterId = 5, Firstname = "bernard", Lastname = "bernard"},
        };

        public static void Run()
        {
            var numbers = new List<int>();
            var random = new Random();
            for (var i = 0; i < 10; i++)
            {
                numbers.Add(random.Next(1, 101));
            }

            //Linq queries
            //numbers = numbers.OrderBy(x => x).ToList();
            //numbers = (from n in numbers orderby n select n);

            //numbers = numbers.OrderBy(x => x.ToString()).ToList();
            //numbers = (from n in numbers orderby n.ToString() select n).ToList();

            //numbers = numbers.Where(x => x % 2 == 0).OrderBy(x => x.ToString()).ToList();
            //numbers = (from n in numbers where n % 2 == 0 orderby n.ToString() select n).ToList();

            //Console.WriteLine(string.Join(", ", numbers));


            Console.WriteLine(GetFullname(2));
            Console.WriteLine(String.Join(", ", GetLastThree().Select(x => x.BoosterId)));
            Console.WriteLine(String.Join(", ", Search("a").Select(x => x.BoosterId)));
        }

        public static string GetFullname(int boosterId)
        {
            return Students
                .Where(x => x.BoosterId == boosterId)
                .Select(x => x.Firstname + " " + x.Lastname)
                .SingleOrDefault();
        }

        public static List<Student> GetLastThree()
        {
            return Students
                .OrderBy(x => x.BoosterId)
                .Reverse()
                .Take(3)
                .ToList();
        }

        public static List<Student> Search(string keyword)
        {
            return Students
                .Where(x => x.Firstname.ToLower().Contains(keyword.ToLower()) ||
                    x.Lastname.ToLower().Contains(keyword.ToLower()))
                    .ToList();
        }
    }
}
