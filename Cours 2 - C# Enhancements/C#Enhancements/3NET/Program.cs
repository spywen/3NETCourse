using System;
using System.Collections.Generic;
using Dynamic;
using Lazy;
using Linq;
using Mmf;

namespace _3NET
{
    class Program
    {
        delegate int Square(int i);

        
        static void Main(string[] args)
        {
            //--- Extension method ---
            //Console.WriteLine(" test test ".LengthWithoutSpace());

            //--- Lambda ---
            //LambdaExpressions.FindSmallNumbers();
            //LambdaExpressions.SortFromLittleToBig();
            
            //--- Event Handler ---
            //EventHandler.CreateNewEmployeeAndIncreaseSalary();

            //--- Action and Func ---
            //ActionAndFunc.BaseMethod();

            //--- Dynamic keyword ---
            //DynamicMain.TryDynamic();

            //--- Expando object ---
            //var myExpando = ExpandoObject.CreateExpandoObject();
            //myExpando.Display("Expando test" + myExpando.Name);

            //--- Dynamic object ---
            //dynamic person = new DynamicDictionary();
            //person.FirstName = "Ellen";
            //Console.WriteLine(person.firstname);

            //--- Linq ---
            //LinqMain.Run();
            //LinqExo.Run();
            //Console.WriteLine(LinqExo.Average(new []{1, 2}));

            //--- Lazy<T> singleton ---
            //Console.WriteLine(MySingleton._instanceLazy.IsValueCreated);
            //var singleton = MySingleton.Instance;
            //Console.WriteLine(MySingleton._instanceLazy.IsValueCreated);
            //var singleton2 = MySingleton.Instance;

            //--- deleguate ---
            //Square square = x => x*x;
            //Console.WriteLine(square(2));

            //--- Memory Mapped File ---
            //MmfMain.ShareMemory();
            
            Console.ReadLine();
        }
    }
}
