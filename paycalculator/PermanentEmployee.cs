using System;
using System.Globalization;
using System.Linq.Expressions;

namespace paycalculator
{
    class PermanentEmployee : Employee
    {
        decimal annualSalary;
        decimal annualBonus;
        public decimal AnnualSalary { get { return annualSalary; } }
      

        public PermanentEmployee( string name, EmployeeType employeeType, decimal annualSalary, decimal annualBonus) : base (name, employeeType)
        {
            this.annualSalary = annualSalary;
            this.annualBonus = annualBonus;
        }
        public virtual decimal CalculateAnnualBounsPay() 
        {
            decimal annual = annualSalary;
            decimal bonus = annualBonus;
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
