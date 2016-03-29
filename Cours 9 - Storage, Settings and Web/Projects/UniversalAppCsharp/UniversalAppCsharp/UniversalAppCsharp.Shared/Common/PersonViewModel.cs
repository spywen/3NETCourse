using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UniversalAppCsharp.DataModel;

namespace UniversalAppCsharp.Common
{
    public class PersonViewModel {

        private ObservableCollection<Person> persons = new ObservableCollection<Person>();

        public ObservableCollection<Person> Persons { get { return this.persons; } }
        public string Name { get { return "MyName";  } }

        public PersonViewModel()
        {
            this.persons.Add(new Person { Firstname = "John", Lastname = "Doe" });
            this.persons.Add(new Person { Firstname = "Jack", Lastname = "Harkness" });
        }
    }

}
