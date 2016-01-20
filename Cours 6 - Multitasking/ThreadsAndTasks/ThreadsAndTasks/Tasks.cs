using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsAndTasks
{
    public class Tasks
    {
        #region implicitly

        public static void ImplicitTasks()
        {
            Parallel.Invoke(
                () => { for(var i= 0; i < 1000; i++) Console.Write("?"); },
                () => { for (var i = 0; i < 1000; i++) Console.Write("#"); }
            );
            Console.Read();
        }


        private static void Method()
        {
            for (var i = 0; i < 100; i++) Console.Write("Method");
        }

        public static void ImplicitTasksPossibilities()
        {
            Action action = () => { for (var i = 0; i < 100; i++) Console.Write("Action"); };
            Parallel.Invoke(
                Method,
                () => { for (var i = 0; i < 100; i++) Console.Write("Lambda"); },
                action
            );
            Console.Read();
        }

        #endregion

        #region explicitly

        public static void ExplicitTasks()
        {
            var task1 = new Task(() => { for (var i = 0; i < 100; i++) Console.Write("#"); });
            task1.Start();
            Task.Factory.StartNew(() => { for (var i = 0; i < 100; i++) Console.Write("?"); });

            Console.Read();
        }

        public static void ExplicitTasksPassingAndReturnValues()
        {
            //Factory
            long n = 15;
            var taskN = Task<long>.Factory.StartNew(p => { 
                var result = Factoriel(Convert.ToInt64(p));
                return result;
            }, n);
            
            //Simple Task
            long m = 10;
            var taskM = new Task<long>(p =>
            {
                var result = Factoriel(Convert.ToInt64(p));
                return result;
            }, m);
            taskM.Start();
            Console.WriteLine(taskN.Result);
            Console.WriteLine(taskM.Result);

            Console.Read();
        }

        private static long Factoriel(long n)
        {
            return n > 1 ? n*Factoriel(n - 1) : 1;
        }
        #endregion

        #region data parallelism !!!

        public static void DataParallelism()
        {
            var stopwatch = Stopwatch.StartNew();
            var numbers = Enumerable.Range(0, 10);

            //Parallel is SYNCHRONE : tasks inside are asynchrone and executed simultaneously

            //foreach (var numb in numbers){LongMethod(numb);}
            Parallel.ForEach(numbers, n => LongMethod(n));

            stopwatch.Stop();

            Console.WriteLine("End Delay: {0}", stopwatch.ElapsedMilliseconds);
            Console.Read();
        }

        private static void LongMethod(int a)
        {
            Thread.Sleep(1000);
        }
        #endregion

        #region cancel task

        public static void CancelTask()
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var task = new Task(() =>
            {
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine("+");
                }
            }, token);

            

            try
            {
                task.Start();
                tokenSource.CancelAfter(2000);
                task.Wait();//Need to wait task because else cancel exception will be not catched !!
            }
            catch (AggregateException e)
            {
                if(e.InnerExceptions[0] is TaskCanceledException)
                    Console.WriteLine("Task cancelled !");
                else 
                    Console.WriteLine("Another kind of error");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR");
            }

            Console.Read();
        }
        #endregion
    }
}
