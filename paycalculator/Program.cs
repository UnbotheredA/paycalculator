using System;
using System.Globalization;
using System.Linq.Expressions;

namespace paycalculator
{
    class Program
    {
         static void Main(string[] args)
        {
            EmployeePayInfo eo = new EmployeePayInfo("Aala", 22.000, 4.000);
            eo.calculateTotalAnnualandBounsPay();
            Console.WriteLine(eo.AnnualSalary);
        }
    }
}
