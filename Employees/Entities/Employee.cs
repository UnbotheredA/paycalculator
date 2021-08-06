namespace Employees.Entites
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public Employee(string name, EmployeeType employeetype)
        {
            Name = name;
            EmployeeType = employeetype;
        }

        public abstract decimal HourlyPay();
        public override string ToString()
        {
            return $"{Name}, {EmployeeType}";
        }
    }
}