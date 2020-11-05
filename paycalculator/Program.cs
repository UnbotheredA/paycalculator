using System;
using System.Globalization;
using System.Linq.Expressions;

namespace paycalculator
{
    class Program
    {
         static void Main(string[] args)
        {
            EmployeePayInfo eo = new EmployeePayInfo("Aala", 40000, 4000);
            eo.CalculateAnnualBounsPay();
            eo.HourlyPay();
            TempEmployee teo = new TempEmployee("Ruby", 0, 0, 60.20f, 30, "Contract");
            teo.MoneyMadeInTotal();
            Console.WriteLine("The type of employee is:" + teo.EmployeeTypes);
            //Console.WriteLine(eo.AnnualSalary);
        }
    }
}
