using System;

namespace _3NET
{
    public class EventHandler
    {
        public static void CreateNewEmployeeAndIncreaseSalary()
        {
            var emp = new EmployeeWithEvents{Name = "toto"};
            //emp.SalaryChanged += delegate(object sender, int e){Console.WriteLine("Salary has changed for : {0}", e);};
            emp.SalaryChanged += (sender, e) => Console.WriteLine("Salary has changed for : {0}", e);

            emp.Salary += 200;
        }
    }

    public class EmployeeWithEvents
    {
        public event EventHandler<int> SalaryChanged;

        public string Name { get; set; }

        private int _salary;
        public int Salary
        {
            get { return _salary; }
            set
            {
                if (SalaryChanged != null) SalaryChanged(this, value);
                _salary = value;
            }
        }
    }
}
