using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace ThreadsAndTasks
{
    public static class Plinq
    {
        public static void PlinkExoMethod()
        {
            //Generate grid with random numbers
            //0 1 2 ... 1999
            //1
            //2     [RANDOM NUMBERS]
            //...
            //1999
            List<List<int>> lli = new List<List<int>>();
            Random r = new Random();
            for (int i = 0; i < 2000; i++)
            {
                List<int> li = new List<int>();
                for (int j = 0; j < 2000; j++)
                {
                    li.Add(r.Next(20, 300));
                }
                lli.Add(li);
            }

            var stopWatchBasic = Stopwatch.StartNew();
            //Basic way
            lli.ForEach(n => n.ForEach(el => Enumerable.Range(1, el).Aggregate((a, b) => a * b)));
            stopWatchBasic.Stop();

            var stopWatchPlink = Stopwatch.StartNew();
            //Plinq way
            lli.AsParallel().ForAll(n => n.AsParallel().ForAll(el => Enumerable.Range(1, el).Aggregate((a, b) => a * b)));
            stopWatchPlink.Stop();

            //Interesting points with AsParallel: 
            //Can choose to manipulate AsOrdered, AsSequential
            //Or with certain degree of parallelism .WithDegreeOfParallelism(1)
            //Or with possibility to cancel with cancelation token .WithCancellation(...)

            Console.WriteLine("End, delay basic way : {0}, delay plinq way : {1}", stopWatchBasic.ElapsedMilliseconds, stopWatchPlink.ElapsedMilliseconds);
            Console.Read();
        }
    }
}
