using Employees.Entites;
using System;

namespace Employees.Entities
{
    public static class NewEmployeeInput
    {
        public static string NameInput;
        private static decimal convertedSalary;
        private static decimal convertedBonus;
        private static int convertedholidayvalue;
        private static decimal convertedDayRate;
        private static int convertedWeeksWorked;


        public static PermanentEmployee UserInputPermanentEmployee()
        {
            Console.WriteLine("Write your name");
            NameInput = Console.ReadLine();
            Console.WriteLine("Type your salary");
            var annualSalaryInput = Console.ReadLine();
            decimal.TryParse(annualSalaryInput, out convertedSalary);
            Console.WriteLine("enter bonus");
            var bonusInput = Console.ReadLine();
            decimal.TryParse(bonusInput, out convertedBonus);
            Console.WriteLine("enter allowance");
            var holidayAllowanceInput = Console.ReadLine();
            int.TryParse(holidayAllowanceInput, out convertedholidayvalue);
            return new PermanentEmployee(NameInput, convertedSalary, convertedBonus, convertedholidayvalue);
        }
        
        public static TempEmployee UserInputTempEmployee()
        {
            Console.WriteLine("Write your name");
            NameInput = Console.ReadLine();
            Console.WriteLine("Enter day rate");
            var dayRateInput = Console.ReadLine();
            decimal.TryParse(dayRateInput, out convertedDayRate);
            Console.WriteLine("How many weeks worked");
            var weeksWorkedInput = Console.ReadLine();
            int.TryParse(weeksWorkedInput, out convertedWeeksWorked);
            return new TempEmployee(NameInput, convertedDayRate, convertedWeeksWorked);
        }                  
    }
}
