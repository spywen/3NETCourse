using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ThreadsAndTasks
{
    public static class Exo
    {
        #region long process
        public static long LongProcess(int n)
        {
            int count = 0;
            long a = 0;
            while (count < n)
            {
                long b = 2;
                int prime = 1;
                while (b*b <= a)
                {
                    if (a%b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                {
                    count++;
                }
                a++;
            }
            return (--a);
        }

        #endregion

        #region thread solution

        public static void TaskSol()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var tasks = new List<Task>();
            foreach (var n in GetNumbers())
            {
                var task = new Task(p => {Console.WriteLine(LongProcess((int)p));}, n);
                task.Start();
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());

            stopwatch.Stop();

            Console.WriteLine("End Delay: {0}", stopwatch.ElapsedMilliseconds);
        }

        #endregion

        #region task solution

        /// <summary>
        /// Parallel foreach, or invoke, ...
        /// </summary>
        public static void ParallelSol()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            Parallel.ForEach(GetNumbers(), n => Console.WriteLine(LongProcess(n)));

            stopwatch.Stop();

            Console.WriteLine("ParallelSol -> End Delay: {0}", stopwatch.ElapsedMilliseconds);
        }

        #endregion

        private static List<int> GetNumbers()
        {
            var random = new Random();
            var numbers = new List<int>();
            while (numbers.Count < 4)
            {
                var number = random.Next(100000, 200000);
                numbers.Add(number);

                Console.Write(numbers.Count == 4 ? "{0}" : "{0}, ", number);
            }
            Console.WriteLine();
            return numbers;
        } 
    }
}
