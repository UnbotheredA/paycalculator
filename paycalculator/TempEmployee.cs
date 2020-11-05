using System;
using System.Collections.Generic;
using System.Text;

namespace paycalculator
{
    class TempEmployee : EmployeePayInfo
    {
        float dayRate;
        int weeksWorked;
        string employeetypes;
        //public enum employeetypes { Workers, Contracts, tue, Wed, thu, Fri, Sat };

        public string EmployeeTypes { get { return employeetypes; } }

        //calculate how much money they made from dayrate within how many weeks they have worked.
        public TempEmployee(string name, float annualsalary, float annualbonus, float dayRate, int weeksWorked, string employeetypes)
        : base(name, annualsalary, annualbonus)
        {
            this.dayRate = dayRate;
            this.weeksWorked = weeksWorked;
            this.employeetypes = employeetypes;
        }
        //calculate total annaul pay based on how many weeks worked.
        public void MoneyMadeInTotal()
        {// Create a method that can calculate their total salary based on number of weeks worked.
            float totalMoneyMade = dayRate * weeksWorked;
            Console.WriteLine($"Total money made is £{totalMoneyMade:N2}");
        }

        //make another method that can calculate thier hourly pay based on their day rate

        public override void HourlyPay()
        {//  that can calculate their hourly pay based on how many weeks worked.
          //dayRate
           Console.WriteLine();
        }
    }
}
//error https://stackoverflow.com/questions/63957152/error-cs7036-there-is-no-argument-given-that-corresponds-to-the-required-formal