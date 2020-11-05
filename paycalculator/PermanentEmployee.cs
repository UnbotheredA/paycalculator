using System;
using System.Globalization;
using System.Linq.Expressions;

namespace paycalculator
{
    class PermanentEmployee : Employee
    {
        float annualSalary;
        float annualBonus;
        public float AnnualSalary { get { return annualSalary; } }
      

        public PermanentEmployee(string name, float annualsalary, float annualbonus) : base (name)
        {
            annualSalary = annualsalary;
            annualBonus = annualbonus;
        }
        public virtual void CalculateAnnualBounsPay() 
        {
            float annual = annualSalary;
            float bonus = annualBonus;
            float total = annual + bonus;
            Console.WriteLine(total);
        }
        public override void HourlyPay() 
        { 
            float hoursInAYear = 35 * 52;
            float hourSalary =  annualSalary / hoursInAYear;
            Console.WriteLine($" Hour Salary is £{hourSalary:N2} ");
        }
        
    }
}
