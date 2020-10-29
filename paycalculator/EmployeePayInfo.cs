using System;
using System.Globalization;
using System.Linq.Expressions;

namespace paycalculator
{
    class EmployeePayInfo
    {
        float annualSalary;  
        float annualBonus;
     
        public float AnnualSalary { get { return annualSalary;} }
        public EmployeePayInfo(string name, float annualsalary, float annualbonus) 
        {
            this.annualSalary = annualsalary;
            this.annualBonus = annualbonus;
        }
        public virtual void CalculateAnnualBounsPay() 
        {
            float annual = annualSalary;
            float bonus = annualBonus;
            float total = annual + bonus;
            //Console.WriteLine(total);
        }
        public virtual void HourlyPay() 
        { 
            float hoursInAYear = 35 * 52;
            float hourSalary =  annualSalary / hoursInAYear;
            //Console.WriteLine($" Hour Salary is £{hourSalary:N2} ");
        }
    }
}
