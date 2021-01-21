using Employees.Entites;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Employees
{
    class EmployeeJSON
    {

        
        public void WriteToEmoplyee()
        {
            PermanentEmployee p5 = new PermanentEmployee(name: "Alice surname", 50000, 5000, holidayAllowance: 19);
            //string jsonString = JsonConvert.SerializeObject(p5);// converts to json.
            File.WriteAllText(@"C:\Users\osmana\source\repos\paycalculator\Employees\Entities\Data\Employee.json", JsonConvert.SerializeObject(p5));

            //using (StreamWriter file = File.CreateText(@"Employees\Data\Employees.json")) 
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(p1);

            //}
        }

        public void ReadFromEmployeeFile() 
        { 
        
        
        }


        //read the entire file first then add a person
        //adding one person to a file can be problamtic

    }
}
