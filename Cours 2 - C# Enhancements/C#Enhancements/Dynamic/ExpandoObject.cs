using System;

namespace Dynamic
{
    public class ExpandoObject
    {
        public static dynamic CreateExpandoObject()
        {
            dynamic bag = new System.Dynamic.ExpandoObject();
            bag.Name = "Eddy";
            bag.Display = (Action<string>) ((text) => Console.WriteLine(text));
            return bag;
        }
    }
}
