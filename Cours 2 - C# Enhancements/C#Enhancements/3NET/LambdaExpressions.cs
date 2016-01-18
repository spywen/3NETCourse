using System;
using System.Collections.Generic;

namespace _3NET
{
    public class LambdaExpressions
    {
        public static void FindSmallNumbers()
        {
            var numbers = new List<int>{1, 2, 6, 8};
            var result = numbers.FindAll((x) => (x) < 5);
            Console.WriteLine(String.Join(", ", result));
        }

        public static void SortFromLittleToBig()
        {
            var words = new List<string>{ "expressions", "love", "I", "lambda" };
            words.Sort((x, y) => x.Length.CompareTo(y.Length));
            Console.WriteLine(String.Join(" ", words));
        }
    }
}
