using System;

namespace ThreadsAndTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Threads
            //Threads.StartSimpleThreads();

            //Threads.StartThreadsWithLockResourceAccess();

            //Threads.StartThreadsWithLockResourceAccessByMutex();
            #endregion

            #region Tasks
            //Tasks.ImplicitTasks();

            //Tasks.ImplicitTasksPossibilities();

            //Tasks.ExplicitTasks();

            //Tasks.ExplicitTasksPassingAndReturnValues();

            //Tasks.DataParallelism();

            //Tasks.CancelTask();
            #endregion

            #region exo
            /*Exo.ParallelSol();
            Exo.TaskSol();
            Console.Read();*/
            #endregion

            #region plink

            //Plinq.PlinkExoMethod();

            #endregion

            #region async
            //Async.ReadAsyncContentWithAwait();
            //Async.CallCustomMethod();
            Async.CallCustomReaderAsync();
            Console.Read();
            #endregion
        }

        
    }
}
