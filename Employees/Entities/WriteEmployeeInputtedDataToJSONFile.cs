using Employees.Entites;
using Employees.Entities.JSON;
using System.Collections.Generic;

namespace Employees.Entities
{
    public class WriteEmployeeInputtedDataToJSONFile
    {
        public static string PermanentEmployeeAbsoulatePath;
        public static string TempEmployeeAbsoulatePath;
        public EmployeeJSONFormatter<PermanentEmployee> PermanentEmployeeJSONFormatter = new EmployeeJSONFormatter<PermanentEmployee>(PermanentEmployeeAbsoulatePath);
        public EmployeeJSONFormatter<TempEmployee> TempEmployeeJSONFormatter = new EmployeeJSONFormatter<TempEmployee>(TempEmployeeAbsoulatePath);
        private NewEmployeeInput _newEmployeeInput;
        public WriteEmployeeInputtedDataToJSONFile(NewEmployeeInput newEmployeeInput)
        {
            _newEmployeeInput = newEmployeeInput;
        }
        public List<PermanentEmployee> AddPermanentEmployeeToJson(EmployeeJSONFormatter<PermanentEmployee> PermanentEmployeeJSON)
        {
            EmployeeList<PermanentEmployee> _employeeListPermanent = new EmployeeList<PermanentEmployee>();
            var results = _employeeListPermanent.AddToEmployee(_employeeListPermanent.AddingNewPermanentEmployee, _newEmployeeInput.UserInputPermanentEmployee());
            PermanentEmployeeJSON.AppenedToJsonFile(results);
            return results;
        }
        public List<TempEmployee> AddTempEmployeeToJson(EmployeeJSONFormatter<TempEmployee> TempEmployeeJSON)
        {

            EmployeeList<TempEmployee> _employeeListTemp = new EmployeeList<TempEmployee>();
            var results = _employeeListTemp.AddToEmployee(_employeeListTemp.AddingNewTempEmployee, _newEmployeeInput.UserInputTempEmployee());
            TempEmployeeJSON.AppenedToJsonFile(results);
            return results;
        }
    }
}
