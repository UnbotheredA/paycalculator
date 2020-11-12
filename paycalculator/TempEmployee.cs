using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace paycalculator
{
    class TempEmployee : Employee
    {
        float dayRate;
        int weeksWorked;
        string employeetypes;
        public string EmployeeTypes { get { return employeetypes; } }

        public TempEmployee(string name, float annualsalary, float annualbonus, float dayRate, int weeksWorked, string employeetypes)
       : base(name)
        {
            this.dayRate = dayRate;
            this.weeksWorked = weeksWorked;
            this.employeetypes = employeetypes;
        }

        public float MoneyMadeInTotal() => dayRate / weeksWorked;
        
          //return dayRate * weeksWorked;  
        
        public override float HourlyPay()
        {
          return  dayRate / 7;
          //Console.WriteLine($"Hourly pay is £ {hourPay:N2}");
        }
    }
}
