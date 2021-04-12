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
        public List<T> PermanentEmployeeList = new List<T>();
        public List<T> TempEmployeeList = new List<T>();

        //Read a already existing list from anywhere 
        public List<T> ReadEmployeeList(List<T> outputData)
        {
            //For debugging purposes
            var all = outputData.Count;
            Console.WriteLine(all);
            Console.WriteLine("ReadEmployeeList method called from employee file ");
            return outputData;
            
        }
        public List<T> AddToEmployee(List<T> inputData, T eo)
        {
            inputData.Add(eo);
            return inputData;

        }
    }
}


