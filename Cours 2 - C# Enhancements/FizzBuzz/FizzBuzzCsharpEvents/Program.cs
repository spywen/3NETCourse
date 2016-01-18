using System;

namespace FizzBuzzCsharpEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter c = new Counter(30);
            c.Buzz += ((sender,e) => Console.WriteLine("BUZZ"));
            c.Fizz += ((sender, e) => Console.WriteLine("FIZZ"));
            c.End += ((sender, e) => { 
                Console.WriteLine("End !!");
                Console.Read(); 
                Environment.Exit(0);
            });
            c.Other += ((sender,e) => Console.WriteLine(e.Value));

            Console.WriteLine("press 'a'");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                c.Increment();
            }
        }
    }
}
