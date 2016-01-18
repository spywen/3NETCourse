using System.Collections.Generic;

namespace Linq
{
    public class LinqMain
    {
        public static void Run()
        {

            var test = new List<Customer>
            {
                new Customer{Name = "c", Age = 14},
                new Customer{Name = "b", Age = 32},
                new Customer{Name = "a", Age = 70}
            };


            //Console.Write(string.Join(",",test.OrderBy(x => x.name).Select(x => x.name)));
            
            /*if (test.Any(x => x.Age < 18))
            {
                
            }*/
            
            /*
            Console.Write(string.Join(", ", test.Select(x => x.Age).Skip(3).FirstOrDefault()));//NULL
            Console.Write(string.Join(", ", test.Select(x => x.Age).Skip(3).First()));//EXCEPTION
            Console.Write(string.Join(", ", test.Select(x => x.Age).Skip(2).Single()));//OK
            Console.Write(string.Join(", ", test.Select(x => x.Age).Skip(1).Single()));//EXCEPTION
            Console.Write(string.Join(", ", test.Select(x => x.Age).Skip(1).SingleOrDefault()));//NULL
            */

        }
    }
}
