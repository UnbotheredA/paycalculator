using Employees.Entites;
using Employees.Entities;
using Employees.Entities.JSON;
using System;
using Employees;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Collections.Generic;

namespace paycalculator
{
    class Program
    {
        static JSONFileLocator JSONFileLocator = new JSONFileLocator();
       
        static void Main(string[] args)
        {

            DisplayEmployees displayEmployees = new DisplayEmployees();
            displayEmployees.DisplayContent(displayEmployees.permanentEmployee1,displayEmployees.tempEmployee1);

            IConfiguration config = new ConfigurationBuilder().AddJsonFile(@"appsettings.json", false, true).Build();
            
            string dirForTempJSONFile = config["TempPath"];
            string tempEmployeeAbsoulatePath = JSONFileLocator.FindJsonFile(dirForTempJSONFile);
            WriteEmployeeInputtedDataToFile.TempEmployeeJSONFormatter.JSONFilePath = tempEmployeeAbsoulatePath;
            WriteEmployeeInputtedDataToFile.TempEmployeeAbsoulatePath = tempEmployeeAbsoulatePath;
           
            string dirForPermanentEmployeeJSONFile = config["PermanentPath"];
            string permanentEmployeeAbsoulatePath =  JSONFileLocator.FindJsonFile(dirForPermanentEmployeeJSONFile);
            WriteEmployeeInputtedDataToFile.PermanentEmployeeJSONFormatter.JSONFilePath = permanentEmployeeAbsoulatePath;
            WriteEmployeeInputtedDataToFile.PermanentEmployeeAbsoulatePath = permanentEmployeeAbsoulatePath;
            
            EmployeeAction();
    
        }
        private static void EmployeeAction()
        {
            Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type t1 to add temp employee and rt2 to read all temp employees and type done to exit application");
            bool isDone = false;
    
            while (!isDone)
            {
                string action = Console.ReadLine();
                switch (action)
                {
                    case "p1":
                        WriteEmployeeInputtedDataToFile.AddPermanentEmployeeToJson(WriteEmployeeInputtedDataToFile.PermanentEmployeeJSONFormatter);
                        Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type t1 to add temp employee and rt2 to read all temp employees and type done to exit application");
                        break;
                    case "rp2":
                        EmployeeList<PermanentEmployee> employeeListPermanent = new EmployeeList<PermanentEmployee>();
                        employeeListPermanent.ReadEmployeeList(WriteEmployeeInputtedDataToFile.PermanentEmployeeJSONFormatter.ReadList());
                        Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type t1 to add temp employee and rt2 to read all temp employees and type done to exit application");
                        break;
                    case "t1":
                        WriteEmployeeInputtedDataToFile.AddTempEmployeeToJson(WriteEmployeeInputtedDataToFile.TempEmployeeJSONFormatter);
                        Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type t1 to add temp employee and rt2 to read all temp employees and type done to exit application");
                        break;
                    case "rt2":
                        EmployeeList<TempEmployee> employeeListTemp = new EmployeeList<TempEmployee>();
                        employeeListTemp.ReadEmployeeList(WriteEmployeeInputtedDataToFile.TempEmployeeJSONFormatter.ReadList());
                        Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type t1 to add temp employee and rt2 to read all temp employees and type done to exit application");
                        break;
                    case "remove":
                        break;
                    case "done":
                        isDone = true;
                        break;
                    default:
                        Console.WriteLine("something wrong");
                        isDone = true;
                        break;
                }
            }
        }
    }
}



