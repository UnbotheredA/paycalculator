using Employees.Services;

namespace Employees.Entites
{
    public abstract class Employee 
    {
        public string Name;
        public EmployeeType EmployeeType;

        public Employee(string name, EmployeeType employeetype)
        {
            Name = name;
            EmployeeType = employeetype;
        }

        public virtual string GetEmployeeTextLine()
        {
            throw new System.NotImplementedException();
        }

        public abstract decimal HourlyPay();

        public virtual Employee readEmployeeTextLine(string employeeData)
        {
            throw new System.NotImplementedException();
        }

    }
}