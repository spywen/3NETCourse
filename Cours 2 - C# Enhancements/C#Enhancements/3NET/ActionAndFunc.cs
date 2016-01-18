using System;

namespace _3NET
{
    public class ActionAndFunc
    {
        public static void BaseMethod(string myString = "Cou")
        {
            ActionAndFuncMethod(x => x + "Cou", x => Console.WriteLine(x), myString);
        }

        private static void ActionAndFuncMethod(Func<string, string> method1, Action<string> method2, string myString)
        {
            method2(method1(myString));
        }
    }
}
