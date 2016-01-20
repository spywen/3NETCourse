using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsAndTasks
{
    public static class Async
    {
        #region use
        public static async void ReadAsyncContentWithAwait()
        {
            var sr = new StreamReader("./data/file.txt");
            var task = sr.ReadToEndAsync();

            //... Other code ...
            var test = "TEST";

            //Here : 
            //Task already resolved : take result
            //Task not already resolved : wait until result 
            var result = await task + " " + test;
            Console.WriteLine(result);
        }
        #endregion

        #region custom
        /// <summary>
        /// How to create a asynchronous call
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private static Task<int> CustomMethodAsync(int val)
        {
            var task = new Task<int>(() =>
            {
                Thread.Sleep(2000);
                return val*val;
            });
            task.Start();
            return task;
        }

        public static async void CallCustomMethod()
        {
            var result = await CustomMethodAsync(3);
            Console.WriteLine(result);
        }
        #endregion

        #region exo

        private static Task<string> CustomReaderAsync(string filename)
        {
            var sr = new StreamReader(filename);
            var text = sr.ReadToEndAsync().Result;

            var task = new Task<string>((t) =>
            {
                var te = (string) t;
                te = te.Replace("U", "");
                return te;
            },text);
            task.Start();

            return task;
        }

        public static async void CallCustomReaderAsync()
        {
            var result = await CustomReaderAsync("./data/file.txt");
            Console.WriteLine(result);
        }

        #endregion
    }
}
