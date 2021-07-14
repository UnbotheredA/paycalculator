using Employees.Entites;
using Employees.PayCalculator.Utilities;
using NUnit.Framework;
using System;

namespace Tests
{

    public class NUnitTestProject1
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Annual_Salary_Is_Zero_Or_Less_Throw_Error()
        {
            //Arrange, Act and Assert 
            Assert.Throws<InvalidSalaryException>(() => new PermanentEmployee("Test", 0m, 400, 5));
        }

        [Test]
        public void Annual_Salary_Must_Be_Over_Zero()
        {
            //Arrange
            PermanentEmployee permanentemployee = new PermanentEmployee("Alex", 1, 400, 21);
            var result = permanentemployee.AnnualSalary;

            //Assert
            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public void Requested_More_Holiday_Than_Possible_Throws_Error()
        {
            //Arrange
            int holidayRequest = 50;
            PermanentEmployee pe1 = new PermanentEmployee("Nancy", 4000, 400, 21);

            //Act and Assert
            Assert.Throws<Exception>(() => pe1.HolidayAllowanceAvailable(holidayRequest));
        }

        [Test]
        public void AllowanceRemaning_Is_Remaning_Holiday_Minus_Days_Requested()
        {
            //Arrange
            var maxHolidayAmonut = 50;
            var holidayRequest = 20;
            PermanentEmployee pe2 = new PermanentEmployee("Aaron", 45000, 300, maxHolidayAmonut);
            var expected = 30;

            //Act
            var actual = pe2.HolidayAllowanceAvailable(holidayRequest);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateAnnualBonus_Method_Returns_The_Expected_Calculation()
        {
            //Arrange
            PermanentEmployee permanentEmployee = new PermanentEmployee("Josh", 40000, 400, 21);
            var expected = 40400;

            //Act
            var actual = permanentEmployee.CalculateAnnualBounsPay();

            //Arrange
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HourlyPay_Method_Does_The_Correct_Calculation() 
        {
            //Arrange
            PermanentEmployee permanentEmployee = new PermanentEmployee("Ruby", 40000, 700, 17);
            var expected = 21;

            //Act
            var actual = permanentEmployee.HourlyPay();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}