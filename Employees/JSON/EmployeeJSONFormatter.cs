using Employees.Entites;
using Employees.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Employees.Entities.JSON
{
    public class EmployeeJSONFormatter<T> : IEmployeeRepository<T> where T : Employee
    {

        private List<T> ReadJSONList = new List<T>();
        public string JSONFilePath;

        public EmployeeJSONFormatter(string fullPath)
        {
            JSONFilePath = fullPath;
        }

        public List<T> ReadFromList()
        {
            string contentOfFile = File.ReadAllText(JSONFilePath);
            var convertedToList = JsonConvert.DeserializeObject<List<T>>(contentOfFile);
            return convertedToList;
        }

        public string AppenedToJsonFile(List<T> newList)
        {
            ReadJSONList = ReadFromList();
            ReadJSONList.AddRange(newList);
            var convertToJson = WriteTo(ReadJSONList);
            return convertToJson;
        }

        public string WriteTo(List<T> turnToJson)
        {
            string convertToJson = JsonConvert.SerializeObject(turnToJson, Formatting.Indented);
            File.WriteAllText(JSONFilePath, convertToJson);
            return convertToJson;
        }

        public List<T> GetEmployeesName()
        {
            return ReadFromList();
        }

        public bool RemoveEmployee(string removeEmployee)
        {
            List<T> allEmployees = ReadFromList();
            if (allEmployees.Exists(e => e.Name.Equals(removeEmployee)))
            {
                var employeeWanted = allEmployees.Find(x => x.Name.Equals(removeEmployee));
                allEmployees.Remove(employeeWanted);
                WriteTo(allEmployees);
                return true;
            }
            return false;
        }
    }
}

