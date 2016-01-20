using System;
using System.Threading;

namespace ThreadsAndTasks
{
    public static class Threads
    {
        #region Simple thread
        public static void StartSimpleThreads()
        {
            //Threads "dépendants"
            var at = new Thread(Display);
            var bt = new Thread(Display);

            at.Start("?");
            bt.Start("#");
            Console.Write("-------------------------");

            Console.Read();
        }

        private static void Display(object id)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(id);
            }
            Console.WriteLine("Thread {0} ended.", id);
        }
        #endregion

        #region Lock

        private static readonly object Object = new object();

        public static void StartThreadsWithLockResourceAccess()
        {
            //Threads "indépendants"
            for (int i = 0; i < 10; i++)
                new Thread(GiveTick).Start();

            Console.Read();
        }

        private static void GiveTick()
        {
            lock (Object)
            {
                Thread.Sleep(100);
                Console.WriteLine(Environment.TickCount);
            }
        }
        #endregion

        #region mutex

        private static readonly Mutex Mutex = new Mutex(false, "MyMutex");
        //{0} initialized with waitOne status
        //{1} mutex name

        public static void StartThreadsWithLockResourceAccessByMutex()
        {
            //Threads "indépendants"
            for (int i = 0; i < 10; i++)
                new Thread(GiveTickByMutex).Start();

            Console.Read();
        }

        public static void GiveTickByMutex()
        {
            Mutex.WaitOne();
            Thread.Sleep(100);
            Console.WriteLine(Environment.TickCount);
            Mutex.ReleaseMutex();
        }
        #endregion
    }
}
