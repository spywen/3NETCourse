
using System;

namespace Dynamic
{
    public class DynamicMain
    {
        public static void TryDynamic()
        {
            dynamic myPerson = new Person();
            myPerson.Name = "Doug";

            object myPersonBis = new Person();
            ((Person)myPersonBis).Name = "Tom";

            Console.WriteLine(Sum(2, 3));
            Console.WriteLine(Sum("Cou", "Cou"));
            Console.WriteLine(Sum(2, "Cou"));
        }

        public static dynamic Sum(dynamic a, dynamic b)
        {
            return a + b;
        }
    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
