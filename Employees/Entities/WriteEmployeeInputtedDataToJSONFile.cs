using Employees.Entites;
using Employees.Entities.JSON;
using System;
using System.Collections.Generic;
using System.Text;

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


        public static void AddPermanentEmployeeToJson(EmployeeJSONFormatter<PermanentEmployee> PermanentEmployeeJSON)
        {
            var results = employeeListPermanent.AddToEmployee(employeeListPermanent.PermanentEmployeeList, NewEmployeeInput.UserInputPermanentEmployee());
            PermanentEmployeeJSON.WriteToFile(results);

        }
        public static void AddTempEmployeeToJson(EmployeeJSONFormatter<TempEmployee> TempEmployeeJSON)
        {
            var results = employeeListTemp.AddToEmployee(employeeListTemp.TempEmployeeList, NewEmployeeInput.UserInputTempEmployee());
            TempEmployeeJSON.WriteToFile(results);

        }
    }
}
