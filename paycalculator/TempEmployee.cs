using System;
using System.Collections.Generic;
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
      
        public void MoneyMadeInTotal()
        {
            float totalMoneyMade = dayRate * weeksWorked;
            Console.WriteLine($"Total money made is £{totalMoneyMade:N2}");
        }
        public override void HourlyPay()
        {
            float hourPay = dayRate / 7;
            Console.WriteLine($"Hourly pay is £ {hourPay:N2}");
        }
    }
}
