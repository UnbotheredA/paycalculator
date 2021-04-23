using Employees.Entites;
using Employees.PayCalculator.Utilities;
using NUnit.Framework;

namespace Tests
{
    public class TempEmployeeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MoneyMadeInTotal_Does_The_Calculation_Of_DayRate_Times_WeeksWorked_To_Check_Total_Salary()
        {
            //Arrange
            TempEmployee tempEmployee = new TempEmployee("Kim",25,42);
            var expected = 1050;
            
            //Act
            var actual = tempEmployee.MoneyMadeInTotal();
            
            //Assert
            Assert.AreEqual(expected,actual);
        }
        [Test]
        public void HourlyPay_Takes_DayRate_And_Divdies_It_By_Hours_Worked_In_A_Day_To_Return_Hour_Pay() 
        {
            //Arrange
            TempEmployee tempEmployee2 = new TempEmployee("Rachel",40,47);
            var expected = 5.714285714285714;

            //Act
            var actual = tempEmployee2.HourlyPay();

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DayRate_Less_Or_Equal_To_One_Throw_Error() 
        {
            //Arrange,Act and Assert
            Assert.Throws<NegativeSalaryException>(() => new TempEmployee("Aaron", 1, 44));
        }
    }
}