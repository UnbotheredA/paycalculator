using Employees.Entites;
using System;

namespace Employees.Entities
{
    public class NewEmployeeInput
    {
        public string NameInput;
        private decimal convertedSalary;
        private decimal convertedBonus;
        private int convertedholidayvalue;
        private decimal convertedDayRate;
        private int convertedWeeksWorked;

        public PermanentEmployee UserInputPermanentEmployee()
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

        public TempEmployee UserInputTempEmployee()
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
