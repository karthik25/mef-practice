using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MefPractice
{
    public class EmployeeList
    {
        private readonly List<Employee> _employees;

        public EmployeeList()
        {
            _employees = new List<Employee>();
        }

        public void Add(Employee employee)
        {
            _employees.Add(employee);
            OnEmployeeAdded(EventArgs.Empty);
        }

        public void AddDup(Employee employee)
        {
            _employees.Add(employee);
        }

        // If EmployeeAdded has 5 attached events, if you call OneEmployeeAdded(e) all are called

        // If you use GetInvocationList you get 5 entries, you loop and call 1 by 1, so you can exclude 1 or 2 in this list

        public void Fire()
        {
            foreach (EmployeeHandler handler in EmployeeAdded.GetInvocationList())
            {
                handler(EventArgs.Empty);
            }
        }

        public delegate void EmployeeHandler(EventArgs e);
        public event EmployeeHandler EmployeeAdded;

        public void OnEmployeeAdded(EventArgs eventArgs)
        {
            if (EmployeeAdded != null)
            {
                EmployeeAdded(eventArgs);
            }
        }
    }

    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
    }

    public class CustomEmployeeList : Collection<Employee>
    {
        protected override void InsertItem(int index, Employee item)
        {
            base.InsertItem(index, item);
        }
    }

    public class CustEmployeeList : List<Employee>
    {
        
    }
}