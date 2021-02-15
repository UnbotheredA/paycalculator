using Employees.Entites;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Employees
{
    public class PermanentEmployeeJSON
    {
        public string path = @"..\..\..\..\Employees\Data\PermanentEmployee.json";
        public PermanentEmployee PermanentEmployee5 = new PermanentEmployee("Alice surname", 50000, 5000, holidayAllowance: 19);
        public PermanentEmployee PermanentEmployee6 = new PermanentEmployee("Jess", 2700, 400, 17);

        public void WriteToEmployeeFile(PermanentEmployee pe)
        {
            if (!File.Exists(path))
            {
                File.Create(@"..\..\..\..\Employees\Data\ContingencyPermanentEmployee.json");
            }
            else
            {
                var allEmployeeList = ReadFromEmployeeFile();
                allEmployeeList.Add(pe);
                string convertJsonFile = JsonConvert.SerializeObject(allEmployeeList, Formatting.Indented);//turned to JSON   
                File.WriteAllText(path, convertJsonFile);
            }
        }
        public List<PermanentEmployee> ReadFromEmployeeFile()
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"This file was not found: {path} on Permanent Employee JSON class");
            }
            else
            {
                string readfile = File.ReadAllText(path);
                var allEmployeeList = JsonConvert.DeserializeObject<List<PermanentEmployee>>(readfile);// turned to C# code 
                return allEmployeeList;
            }
        }
    }
}

