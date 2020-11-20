using System;
using System.Globalization;
using System.Linq.Expressions;

namespace paycalculator
{
    class Program
    {
        

        public static void Main(string[] args)
        {
            PermanentEmployee p1 = new PermanentEmployee(name:"Joe Bloggs", 40000, 5000);
            PermanentEmployee p2 = new PermanentEmployee(name:"John Smith", 45000, 2500);
            Console.WriteLine($"The total of money made with bouns is £{p1.CalculateAnnualBounsPay()}");
            Console.WriteLine($"Hourly pay for a permanet employee is £{p1.HourlyPay()}");
            TempEmployee t1 = new TempEmployee(name:"Clares Jones", annualsalary:0, annualBonus:0, dayRate:350,weeksWorked: 40);
            Console.WriteLine($"The money made in total is £{t1.MoneyMadeInTotal()}");
            Console.WriteLine($"The hourly pay for temp is £{t1.HourlyPay()}");
            Program po = new Program();
            po.DisplayContent(p1,p2, t1);
         }

        public void DisplayContent(PermanentEmployee p1, PermanentEmployee p2, TempEmployee t1)
        {
            Console.WriteLine("   Name " + "   Type Of Employee " + "  Annaul Salary "  +   "          Bouns       " +        "          Day Rate      " + " " + " Weeks Worked ");
                        
            Console.WriteLine("__________|______________|_________________________|___________________|_______________|______________|");
            Console.WriteLine("|         |              |                         |                   |               |              |");
            Console.WriteLine($"{p1.Name}    {p1.EmployeeType}              {p1.AnnualSalary}                   {p1.AnnualBonus}          N/A             N/A");
            Console.WriteLine("__________|______________|_________________________|___________________|_______________|______________|");
            Console.WriteLine("|         |              |                         |                   |               |              |");
            Console.WriteLine($"{p2.Name}    {p2.EmployeeType}              {p2.AnnualSalary}                   {p2.AnnualBonus}          N/A             N/A");
            Console.WriteLine("__________|______________|_________________________|___________________|_______________|______________|");
            Console.WriteLine("|         |              |                         |                   |               |              |");
            Console.WriteLine($"{t1.Name}    {t1.EmployeeType}            N/A                  N/A                       {t1.DayRate}                 {t1.WeeksWorked}      ");
            Console.WriteLine("__________|______________|_________________________|___________________|_______________|______________|");

        }
     }
}
