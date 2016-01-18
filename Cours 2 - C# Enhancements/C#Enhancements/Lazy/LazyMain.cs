using System;

namespace Lazy
{
    public sealed class MySingleton
    {
        public static readonly Lazy<MySingleton> _instanceLazy = new Lazy<MySingleton>(() => new MySingleton("Lazy"));
        public static readonly MySingleton _instanceDirect = new MySingleton("Direct");

        private MySingleton(string value)
        {
            Console.WriteLine("Initialized ! {0}", value);
        }

        public static MySingleton Instance
        {
            get
            {
                Console.WriteLine("Call instance");
                return _instanceLazy.Value;
            }
        }
    }
}
