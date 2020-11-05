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
            //peo.CalculateAnnualBounsPay();
           // peo.HourlyPay();
            TempEmployee teo = new TempEmployee("Ruby", 0, 0, 50.00f, 30, "Contract");
            //Employee harry = new Employee("harry");
            teo.MoneyMadeInTotal();
            teo.HourlyPay();
            Console.WriteLine("The type of employee is:" + teo.EmployeeTypes);
            //Console.WriteLine(eo.AnnualSalary);
        }
    }
}
