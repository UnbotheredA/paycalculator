using Newtonsoft.Json;
using System;
using Employees.Entites;
using Employees;
using Employees.Services;

namespace paycalculator
{
    class Program
    {

        public static void Main(string[] args)
        {
            PermanentEmployee permanentEmployee1 = new PermanentEmployee(name: "Joe Bloggs", 40000, 5000, holidayAllowance: 21);
            PermanentEmployee permanentEmployee2 = new PermanentEmployee(name: "John Smith", 45000, 2500, 21);
            Console.WriteLine(permanentEmployee1.AllowanceRemaning(4));
            Console.WriteLine($"The total of money made with bouns is £{permanentEmployee1.CalculateAnnualBounsPay()}");
            Console.WriteLine($"Hourly pay for a permanet employee is £{permanentEmployee1.HourlyPay()}");
            TempEmployee tempEmployee1 = new TempEmployee(name: "Clares Jones", annualsalary: 0, annualBonus: 0, dayRate: 350, weeksWorked: 40);
            Console.WriteLine($"The money made in total is £{tempEmployee1.MoneyMadeInTotal()}");
            Console.WriteLine($"The hourly pay for temp is £{tempEmployee1.HourlyPay()}");
            DisplayContent(permanentEmployee1, permanentEmployee2, tempEmployee1);


            PermanentEmployeeJSON peo = new PermanentEmployeeJSON();
            peo.WriteToEmployeeFile(peo.PermanentEmployee6);
            foreach (var readPermanentFile in peo.ReadFromEmployeeFile())
            {
                Console.WriteLine(readPermanentFile);
            }

            TempEmployeeJSON teo = new TempEmployeeJSON();
            Console.WriteLine("The current directory is:" + teo.path);
            teo.WriteToEmployeeFile(teo.TempEmployee2);

            foreach (var readTempEmployeeFile in teo.ReadFromEmployeeFile())
            {
                Console.WriteLine(readTempEmployeeFile);
            }
        }

        static void DisplayContent(PermanentEmployee p1, PermanentEmployee p2, TempEmployee t1)
        {
            Console.WriteLine("   Name " + "   Type Of Employee " + "  Annaul Salary " + "          Bouns       " + "          Day Rate      " + " " + " Weeks Worked ");

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

