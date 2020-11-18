using System;
using System.Globalization;
using System.Linq.Expressions;

namespace paycalculator
{
    class Program
    {
         static void Main(string[] args)
        {
            PermanentEmployee peo = new PermanentEmployee(annualSalary:40000, annualBonus: 4000, name: "Aala", employeeType: EmployeeType.contract);
            Console.WriteLine($"The total of money made with bouns is £{peo.CalculateAnnualBounsPay()}");
            Console.WriteLine($"Hourly pay for a permanet employee is £{peo.HourlyPay()}");
            TempEmployee teo = new TempEmployee(name:"Ruby", employeeType:EmployeeType.temp, annualsalary:0, annualBonus:0, dayRate:6020,weeksWorked: 30);
            //Console.WriteLine($"The money made in total is £{teo.MoneyMadeInTotal()}");
            Console.WriteLine($"The hourly pay for temp is £{teo.HourlyPay()}");
            //Console.WriteLine("The type of employee is:" + teo.EmployeeTypes);
            //Console.WriteLine(eo.AnnualSalary);
        }
        //Generally the program class is the only thing that needs to print values
    }
}
