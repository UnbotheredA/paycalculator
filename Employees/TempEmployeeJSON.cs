using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Employees.Entites;
using System.Reflection;

namespace Employees
{
    public class TempEmployeeJSON
    {
        public TempEmployee TempEmployee2 = new TempEmployee("Kelly", 45000, 5000, 70, 45);
        public string path = @"..\..\..\..\Employees\Data\TempEmployee.json";

        public void WriteToEmployeeFile(TempEmployee te)
        {
            if (!File.Exists(path))
            {
                File.Create(@"..\..\..\..\Employees\Data\ContingencyTempEmployee.json");
            }
            else
            {
                var allEmployeeList = ReadFromEmployeeFile();
                allEmployeeList.Add(te);
                string convertJsonFile = JsonConvert.SerializeObject(allEmployeeList, Formatting.Indented);//turned to JSON   
                File.WriteAllText(path, convertJsonFile);
            }
        }

        public List<TempEmployee> ReadFromEmployeeFile()
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"This file was not found: {path} on Permanent Employee JSON class");
            }
            else
            {
                string readfile = File.ReadAllText(path);// reads the  JSON file and stores it in a string
                var allEmployeeList = JsonConvert.DeserializeObject<List<TempEmployee>>(readfile);// turned to C# code

                return allEmployeeList;
            }
        }
    }
}


