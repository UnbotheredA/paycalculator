using System;
using System.Globalization;
using System.Linq.Expressions;

namespace paycalculator
{
    class Program
    {
         static void Main(string[] args)
        {
            PermanentEmployee peo = new PermanentEmployee("Aala", 40000, 4000);
            Console.WriteLine($"The total of money made with bouns is £ {peo.CalculateAnnualBounsPay()}");
            Console.WriteLine($"Hourly pay for a permanet employee is £ {peo.HourlyPay()}");
            TempEmployee teo = new TempEmployee("Ruby", 0, 0, 60.20f, 30, "Contract");  
            Console.WriteLine($"The money made in total is £ {teo.MoneyMadeInTotal()}");
            Console.WriteLine($"The hourly pay is £ {teo.HourlyPay()}");
            Console.WriteLine("The type of employee is:" + teo.EmployeeTypes);
            //Console.WriteLine(eo.AnnualSalary);
        }
        //Generally the program class is the only thing that needs to print values
    }
}
