using System;
using System.Globalization;
using System.Linq.Expressions;

namespace paycalculator
{
    class EmployeePayInfo
    {
        double annualsalary;  
        double annualbonus;
     
        public double AnnualSalary { get { return annualsalary;} }
        public EmployeePayInfo(string name, double annualsalary, double annualbonus) 
        {
            this.annualsalary = annualsalary;
            this.annualbonus = annualbonus;
        }
        public void calculateTotalAnnualandBounsPay() 
        {
            double annual = annualsalary;
            double bonus = annualbonus;
            double total = annual + bonus;  
        }
    }
}
