using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Dynamic
{
    // Example coming from : https://msdn.microsoft.com/fr-fr/library/system.dynamic.dynamicobject(v=vs.110).aspx
    public class DynamicDictionary : DynamicObject
    {
        private Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        // If you try to get a value of a property 
        // not defined in the class, this method is called.
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            string name = binder.Name.ToLower();
            return _dictionary.TryGetValue(name, out result);
        }

        // If you try to set a value of a property that is
        // not defined in the class, this method is called.
        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            _dictionary[binder.Name.ToLower()] = value;
            return true;
        }
    }
}
