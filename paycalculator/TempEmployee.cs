using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace paycalculator
{
    class TempEmployee : Employee
    {
        private decimal dayRate;
        private int weeksWorked;

        public TempEmployee(string name, EmployeeType employeeType, decimal annualsalary, decimal annualBonus, decimal dayRate, int weeksWorked)
       : base(name, employeeType)
        {
            this.dayRate = dayRate;
            this.weeksWorked = weeksWorked;
         }

        public decimal MoneyMadeInTotal()
        {
            return dayRate * weeksWorked; 
        }

        public override decimal HourlyPay()
        {
            return dayRate / 7;
            //Console.WriteLine($"Hourly pay is £ {hourPay:N2}");
        }
    }
}
