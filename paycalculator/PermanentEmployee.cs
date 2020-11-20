using System;
using System.Globalization;
using System.Linq.Expressions;

namespace paycalculator
{
    class PermanentEmployee : Employee
    {
        decimal annualSalary;
        public decimal AnnualBonus;
        public decimal AnnualSalary { get { return annualSalary; } }
      

        public PermanentEmployee( string name, decimal annualSalary, decimal annualBonus) : base (name, EmployeeType.Permanent)
        {
            this.annualSalary = annualSalary;
            AnnualBonus = annualBonus;
        }
        public virtual decimal CalculateAnnualBounsPay() 
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
            decimal formatHourSalary = decimal.ToInt32(hourSalary);
            return formatHourSalary;
        }
        
    }
}
