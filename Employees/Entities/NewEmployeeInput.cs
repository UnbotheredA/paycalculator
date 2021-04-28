using Employees.Entites;
using System;

namespace Employees.Entities
{
    public static class NewEmployeeInput
    {
        private static string nameInput;
        private static decimal convertedSalary;
        private static decimal convertedBonus;
        private static int convertedholidayvalue;
        private static decimal dayRateConverted;
        private static int weeksWorkedConverted;

        public static PermanentEmployee UserInputPermanentEmployee()
        {
            Console.WriteLine("Write your name");
            nameInput = Console.ReadLine();
            Console.WriteLine("Type your salary");
            var annualSalaryInput = Console.ReadLine();
            decimal.TryParse(annualSalaryInput, out convertedSalary);
            Console.WriteLine("enter bonus");
            var bonusInput = Console.ReadLine();
            decimal.TryParse(bonusInput, out convertedBonus);
            Console.WriteLine("enter allowance");
            var holidayAllowanceInput = Console.ReadLine();
            int.TryParse(holidayAllowanceInput, out convertedholidayvalue);
            return new PermanentEmployee(nameInput, convertedSalary, convertedBonus, convertedholidayvalue);
        }

        public static TempEmployee UserInputTempEmployee()
        {
            Console.WriteLine("Write your name");
            nameInput = Console.ReadLine();
            Console.WriteLine("Enter day rate");
            var dayRateInput = Console.ReadLine();
            decimal.TryParse(dayRateInput, out dayRateConverted);
            Console.WriteLine("How many weeks worked");
            var weeksWorkedInput = Console.ReadLine();
            int.TryParse(weeksWorkedInput, out weeksWorkedConverted);
            return new TempEmployee(nameInput, dayRateConverted, weeksWorkedConverted);
        }

    }
}
