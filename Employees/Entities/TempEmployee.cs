
namespace Employees.Entites
{
    public class TempEmployee : Employee
    {
        public decimal DayRate;
        public int WeeksWorked;

        public TempEmployee(string name, decimal annualsalary, decimal annualBonus, decimal dayRate, int weeksWorked)
       : base(name, EmployeeType.temp)
        {
             DayRate = dayRate;
             WeeksWorked = weeksWorked;
         }

        public decimal MoneyMadeInTotal()
        {
            return DayRate * WeeksWorked; 
        }

        public override decimal HourlyPay()
        {
            return DayRate / 7;
        }
    }
}
