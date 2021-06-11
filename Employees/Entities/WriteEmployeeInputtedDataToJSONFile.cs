using Employees.Entites;
using Employees.Entities.JSON;
using System.Collections.Generic;

namespace Employees.Entities
{
    public static class WriteEmployeeInputtedDataToJSONFile
    {
        public static EmployeeList<PermanentEmployee> employeeListPermanent = new EmployeeList<PermanentEmployee>();
        public static EmployeeList<TempEmployee> employeeListTemp = new EmployeeList<TempEmployee>();

        public static string PermanentEmployeeAbsoulatePath;
        public static string TempEmployeeAbsoulatePath;
        public static EmployeeJSONFormatter<PermanentEmployee> PermanentEmployeeJSONFormatter = new EmployeeJSONFormatter<PermanentEmployee>(PermanentEmployeeAbsoulatePath);
        public static EmployeeJSONFormatter<TempEmployee> TempEmployeeJSONFormatter = new EmployeeJSONFormatter<TempEmployee>(TempEmployeeAbsoulatePath);

        public static List<PermanentEmployee> AddPermanentEmployeeToJson(EmployeeJSONFormatter<PermanentEmployee> PermanentEmployeeJSON)
        {
            var results = employeeListPermanent.AddToEmployee(employeeListPermanent.AddingNewPermanentEmployee, NewEmployeeInput.UserInputPermanentEmployee());
            PermanentEmployeeJSON.AppenedToJsonFile(results);
            return results;
        }
        public static List<TempEmployee> AddTempEmployeeToJson(EmployeeJSONFormatter<TempEmployee> TempEmployeeJSON)
        {
            var results = employeeListTemp.AddToEmployee(employeeListTemp.AddingNewTempEmployee, NewEmployeeInput.UserInputTempEmployee());
            TempEmployeeJSON.AppenedToJsonFile(results);
            return results;
        }
    }
}
