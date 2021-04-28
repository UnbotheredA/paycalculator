using Employees.Entites;
using System;

namespace Employees.Entities
{
    public class DisplayEmployees
    {
        public PermanentEmployee permanentEmployee1 = new PermanentEmployee(name: "Joe Bloggs", 40000, 5000, holidayAllowance: 21);
        public PermanentEmployee permanentEmployee2 = new PermanentEmployee(name: "John Smith", 45000, 2500, 21);
        public TempEmployee tempEmployee1 = new TempEmployee(name: "Clares Jones", dayRate: 350, weeksWorked: 40);

        public void DisplayContent()
        {
            string[] titles = { "Name", " Type Of Employee", " Annual Salary", "Bonus", "Day Rate ", "Weeks Worked" };
            Console.WriteLine(string.Format("{0} {1} {2} {3} {4} {5}", titles[0].PadLeft(4), titles[1].PadLeft(20), titles[2].PadLeft(18), titles[3].PadLeft(20), titles[4].PadLeft(20), titles[5].PadLeft(16)));
            Console.WriteLine("________________________________________________________________________________________________________");
        }

        public void DisplayContent(params Employee[] allEmployees)
        {
            DisplayContent();
            foreach (var value in allEmployees)
            {
                if (value is PermanentEmployee)
                {
                    PermanentEmployee permanentEmployee = (PermanentEmployee)value;
                    Console.WriteLine("________________________________________________________________________________________________________");
                    Console.WriteLine("|          |              |                         |                   |                |              |");
                    Console.WriteLine($"{value.Name} {value.EmployeeType.ToString().PadLeft(12)} {permanentEmployee.AnnualSalary.ToString().PadLeft(20)} {permanentEmployee.AnnualBonus.ToString().PadLeft(20)}");
                    Console.WriteLine("|__________|_____________ |_________________________|___________________|________________|______________|");
                }
                else if (value is TempEmployee)
                {
                    TempEmployee tempEmployee = (TempEmployee)value;
                    Console.WriteLine("|          |              |                         |                   |                |              |");
                    Console.WriteLine($"{value.Name} {value.EmployeeType.ToString().PadLeft(5)} {tempEmployee.WeeksWorked.ToString().PadLeft(22)} {tempEmployee.DayRate.ToString().PadLeft(22)}");
                    Console.WriteLine("|__________|_____________ |_________________________|___________________|________________|______________|");
                }
                else
                {
                    Console.WriteLine("Not the correct employees");
                }
            }
        }

    }
}
