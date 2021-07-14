using System.Collections.Generic;

namespace Employees.Entities
{
    public class EmployeeList<T>
    {
        public List<T> AddingNewPermanentEmployee = new List<T>();
        public List<T> AddingNewTempEmployee = new List<T>();
        public List<T> AddToEmployee(List<T> addNewEmployeeToList, T newEmployee)
        {
            addNewEmployeeToList.Add(newEmployee);
            return addNewEmployeeToList;
        }

        public List<T> ReadEmployeeList(List<T> readThisList)
        {
            return readThisList;
        }
    }
}


