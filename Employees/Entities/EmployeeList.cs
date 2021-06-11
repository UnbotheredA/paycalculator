using Employees.Entites;
using Employees.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Employees.Entities
{
    public class EmployeeList<T>
    {
        public List<T> AddingNewPermanentEmployee = new List<T>();
        public List<T> AddingNewTempEmployee = new List<T>();
        public List<T> ReadEmployeeList(List<T> readThisList)
        {
            //For debugging purposes
            var all = readThisList.Count;
            Console.WriteLine(all);
            Console.WriteLine("ReadEmployeeList method called from employee file ");
            return readThisList;
        }
        public List<T> AddToEmployee(List<T> addNewEmployeeToList, T newEmployee)
        {
            addNewEmployeeToList.Add(newEmployee);
            return addNewEmployeeToList;
        }
    }
}


