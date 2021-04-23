using Employees.Entites;
using Employees.Entities;
using Employees.Entities.JSON;
using NUnit.Framework;

namespace NUnitTestProject1
{
    [TestFixture]
    public class Tests
    {
       //Permanent Employee testing vars
        PermanentEmployee Ptesting1 = new PermanentEmployee("Joss", 40000, 400, 4);
        PermanentEmployee Ptesting2 = new PermanentEmployee("Alice", 35000, 400, 3);
        
        //Temp Employees testing vars
        TempEmployee TempTesting1 = new TempEmployee("Ali", 40, 45);

        //Instances of classess 
        EmployeeList<PermanentEmployee> EmployeeListPermanent = new EmployeeList<PermanentEmployee>();
        EmployeeList<TempEmployee> EmployeeListTemp = new EmployeeList<TempEmployee>();
        
        //Paths to write to JSON file
        public static string TempPath = @"..\..\..\..\Employees\Data\TempEmployee.json";
        public static string PermanentPath = @"..\..\..\..\Employees\Data\PermanentEmployee.json";
        
        //Instances of classess 
        EmployeeJSONFormatter<TempEmployee> TempEmployeeJSON = new EmployeeJSONFormatter<TempEmployee>(TempPath);
        EmployeeJSONFormatter<PermanentEmployee> pos = new EmployeeJSONFormatter<PermanentEmployee>(PermanentPath);

        
       [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void AddPermanentEmployeeToJSONManually() 
        {
            //Act
            var newemployee = EmployeeListPermanent.AddToEmployee(EmployeeListPermanent.PermanentEmployeeList, Ptesting2);
            pos.WriteToFile(newemployee);
            var results = EmployeeListPermanent.ReadEmployeeList(pos.ReadList());
            //Arrange
            Assert.Pass("reading per",results);
        }
        [Test]
        public void AddTempEmployeeToJSONManually()
        {
            var newTempEmployee = EmployeeListTemp.AddToEmployee(EmployeeListTemp.TempEmployeeList, TempTesting1);
            TempEmployeeJSON.WriteToFile(newTempEmployee);
            EmployeeListTemp.ReadEmployeeList(TempEmployeeJSON.ReadList());
            Assert.Pass();
        }
        
        public void InputAddEmployee() 
        { 
        

        }
        public void ReadEmployee() 
        { 
        
        }
    }
}