namespace paycalculator
{
    public abstract class Employee
    {
        public string Name { get; set; }//properties fields start with capital letter
        public EmployeeType EmployeeType;
        public Employee(string name, EmployeeType employeetype) 
        {
            Name = name;
            EmployeeType = employeetype;  
        }
        public abstract decimal HourlyPay();
        
        //public abstract void CalculateTotalPay();
      }

}