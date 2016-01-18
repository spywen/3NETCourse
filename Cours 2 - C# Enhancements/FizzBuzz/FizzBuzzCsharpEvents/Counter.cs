using System;

namespace FizzBuzzCsharpEvents
{
    class Counter
    {
        private int Limit { get; set; }
        private int Total { get; set; }

        public Counter(int limit)
        {
            Limit = limit;
        }

        public void Increment()
        {
            Total++;
            if (Total >= Limit)
            {
                if(End != null) End(this, EventArgs.Empty);
            }
            else if (Total % 3 == 0)
            {
                if (Fizz != null) Fizz(this, EventArgs.Empty);
            }
            else if (Total%5 == 0)
            {
                if (Buzz != null) Buzz(this, EventArgs.Empty);
            }
            else
            {
                if (Other != null) Other(this, new EventArgs<int> { Value = Total });
            }
        }

        public event EventHandler<EventArgs> End;
        public event EventHandler<EventArgs> Fizz;
        public event EventHandler<EventArgs> Buzz;
        public event EventHandler<EventArgs<int>> Other;
    }

    /// <summary>
    /// Generic class : which enable us to create eventargs with single value but with different kind of type
    /// One useless restriction here (just FYI) : constraint applied on generic type => should be comparable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventArgs<T> : EventArgs where T : IComparable<T>
    {
        public T Value { get; set; }
    }
}
