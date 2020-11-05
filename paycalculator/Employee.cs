namespace paycalculator
{
    public abstract class Employee
    {
        public string Name { get; set; }//properties fields start with capital letter
        public Employee(string name) 
        {
            Name = name;
        
        }
        public abstract void HourlyPay();
    }
}