
using Employees.PayCalculator.Utilities;

namespace Employees.Entites
{
    public class TempEmployee : Employee
    {
        public decimal DayRate { get; set; }
        public int WeeksWorked { get; set; }

        public TempEmployee(string name, decimal dayRate, int weeksWorked) : base(name, EmployeeType.Temp)
        {
            if (dayRate > 1)
            {
                DayRate = dayRate;
                WeeksWorked = weeksWorked;
            }
            else
            {
                throw new InvalidSalaryException("Day rate cannot be 1 or less.");
            }
        }

        public decimal MoneyMadeInTotal()
        {
            return DayRate * WeeksWorked;
        }

        public override decimal HourlyPay()
        {
            return DayRate / 7;
        }

        public override string ToString()
        {
            return $"{DayRate}, {WeeksWorked}";
        }
    }
}
