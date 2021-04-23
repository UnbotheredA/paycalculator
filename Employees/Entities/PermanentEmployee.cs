using Employees.PayCalculator.Utilities;
using Employees.Services;
using System;
using System.Diagnostics;

namespace Employees.Entites
{
    public class PermanentEmployee : Employee, IHolidayCalculator
    {
        decimal annualSalary;
        public decimal AnnualBonus;
        public decimal AnnualSalary { get { return annualSalary; } }
        public int HolidayAllowance; 

        public PermanentEmployee(string name, decimal annualSalary, decimal annualBonus, int holidayAllowance) : base(name, EmployeeType.Permanent)
        {
            if (annualSalary > 0 && annualBonus > 0)
            {
                this.annualSalary = annualSalary;
                AnnualBonus = annualBonus;
                HolidayAllowance = holidayAllowance;
            }
            else
            {
                throw new NegativeSalaryException("Annaul salary and bonus cannot be zero or less");
            }
        }
        public decimal CalculateAnnualBounsPay()
        {
            decimal annual = annualSalary;
            decimal bonus = AnnualBonus;
            decimal totalIncome = annual + bonus;
            return totalIncome;
        }
        public override decimal HourlyPay()
        {
            decimal hoursInAYear = 35 * 52;
            decimal hourSalary = annualSalary / hoursInAYear;
            decimal formatHourSalary = decimal.ToInt32(hourSalary);
            return formatHourSalary;
        }

        public int AllowanceRemaning(int hoursOff)
        {
            if (hoursOff <= HolidayAllowance)
            {
                Debug.WriteLine("Accepted");
                HolidayAllowance = HolidayAllowance - hoursOff;
                return HolidayAllowance;
            }
            else
            {
                Debug.WriteLine("User is requesting more days off than possible");
                throw new Exception("User is requesting more days off than possible");
            }
        }
    }
}
