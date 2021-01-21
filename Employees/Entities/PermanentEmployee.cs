

using Employees.Services;

namespace Employees.Entites
{
    public class PermanentEmployee : Employee,IHolidayCalculator
    {
        decimal annualSalary;
        public decimal AnnualBonus;
        public decimal AnnualSalary { get { return annualSalary; } }
        public int HolidayAllowance; // is allowed to take off 
      

        public PermanentEmployee( string name, decimal annualSalary, decimal annualBonus,int holidayAllowance) : base (name, EmployeeType.Permanent)
        {
            this.annualSalary = annualSalary;
            AnnualBonus = annualBonus;
            HolidayAllowance = holidayAllowance;
        }
        public decimal CalculateAnnualBounsPay() 
        {
            decimal annual = annualSalary;
            decimal bonus = AnnualBonus;
            decimal total = annual + bonus;
            return total;
        }
        public override decimal HourlyPay()
        {
            decimal hoursInAYear = 35 * 52;
            decimal hourSalary = annualSalary / hoursInAYear;
            //decimal formatHourSalary = decimal.ToInt32(hourSalary);
            return hourSalary;
        }

        public int AllowanceRemaning(int hoursOff)
        {
            HolidayAllowance = HolidayAllowance - hoursOff;
            return HolidayAllowance;
        }
    }
}
