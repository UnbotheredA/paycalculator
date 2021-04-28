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

        public abstract decimal HourlyPay();

    }

}