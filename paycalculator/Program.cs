using Employees;
using Employees.Entites;
using Employees.Entities;
using Employees.Entities.JSON;
using Microsoft.Extensions.Configuration;
using System;

namespace paycalculator
{
    class Program
    {
        static FindLogFiles findLogs = new FindLogFiles();
        static Employees.Service.Log log = new Employees.Service.Log(findLogs.CrashCreatedLogsAbsPath, findLogs.EmployeesCreatedLogsAbsPath);
          static  IConfiguration config = new ConfigurationBuilder().AddJsonFile(@"appsettings.json", false, true).Build();
        static void Main(string[] args)
        {
            DisplayEmployees displayEmployees = new DisplayEmployees();
            displayEmployees.DisplayContent(displayEmployees.permanentEmployee1, displayEmployees.PermanentEmployee2, displayEmployees.TempEmployee1);
            log.CrashLogs();
            EmployeeAction();
        }
        private static void EmployeeAction()
        {
            Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type t1 to add temp employee and rt2 to read all temp employees and type done to exit application");
            bool isDone = false;
            FindJSONFiles findJSONFile = new FindJSONFiles(config["PermanentPath"],config["TempPath"]); 
           
            while (!isDone)
            {
                string action = Console.ReadLine();
                switch (action)
                {
                    case "p1":
                        WriteEmployeeInputtedDataToJSONFile.PermanentEmployeeJSONFormatter.JSONFilePath = findJSONFile.PermanentEmployeeJSONLocation(); ;
                        WriteEmployeeInputtedDataToJSONFile.PermanentEmployeeAbsoulatePath = findJSONFile.PermanentEmployeeJSONLocation();
                        WriteEmployeeInputtedDataToJSONFile.AddPermanentEmployeeToJson(WriteEmployeeInputtedDataToJSONFile.PermanentEmployeeJSONFormatter);
                        Console.WriteLine("New employee added " + NewEmployeeInput.NameInput);
                        log.EmployeesCreatedLogs(NewEmployeeInput.NameInput);
                        Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type t1 to add temp employee and rt2 to read all temp employees and type done to exit application");
                        break;
                    case "rp2":
                        EmployeeList<PermanentEmployee> employeeListPermanent = new EmployeeList<PermanentEmployee>();
                        employeeListPermanent.ReadEmployeeList(WriteEmployeeInputtedDataToJSONFile.PermanentEmployeeJSONFormatter.ReadList());
                        Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type t1 to add temp employee and rt2 to read all temp employees and type done to exit application");
                        break;
                    case "rp":
                        Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type t1 to add temp employee and rt2 to read all temp employees and type done to exit application");
                        EmployeeJSONFormatter<PermanentEmployee> permanentJsonFormatter = new EmployeeJSONFormatter<PermanentEmployee>(findJSONFile.PermanentEmployeeJSONLocation());
                        Console.WriteLine("Enter name of employee to remove: \n");
                        foreach (var employeeNames in permanentJsonFormatter.DisplayEmployeesName())
                        {
                            Console.WriteLine(employeeNames.Name);
                        }
                        string removePermanentEmployee = Console.ReadLine();
                        Console.WriteLine(permanentJsonFormatter.RemoveFromList(removePermanentEmployee) + "\n");
                        Console.WriteLine($"Employee removed {removePermanentEmployee}");
                        break;
                    case "t1":
                        WriteEmployeeInputtedDataToJSONFile.TempEmployeeJSONFormatter.JSONFilePath = findJSONFile.TempEmployeeJSONLocation();
                        WriteEmployeeInputtedDataToJSONFile.TempEmployeeAbsoulatePath = findJSONFile.TempEmployeeJSONLocation(); ;
                        WriteEmployeeInputtedDataToJSONFile.AddTempEmployeeToJson(WriteEmployeeInputtedDataToJSONFile.TempEmployeeJSONFormatter);
                        Console.WriteLine("New employee added " + NewEmployeeInput.NameInput);
                        log.EmployeesCreatedLogs(NewEmployeeInput.NameInput);
                        Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type t1 to add temp employee and rt2 to read all temp employees and type done to exit application");
                        break;
                    case "rt2":
                        EmployeeList<TempEmployee> employeeListTemp = new EmployeeList<TempEmployee>();
                        employeeListTemp.ReadEmployeeList(WriteEmployeeInputtedDataToJSONFile.TempEmployeeJSONFormatter.ReadList());
                        Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type t1 to add temp employee and rt2 to read all temp employees and type done to exit application");
                        break;
                    case "rt":
                        Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type t1 to add temp employee and rt2 to read all temp employees and type done to exit application");
                        EmployeeJSONFormatter<TempEmployee> tempJsonFormatter = new EmployeeJSONFormatter<TempEmployee>(findJSONFile.TempEmployeeJSONLocation());
                        Console.WriteLine("Enter name of employee to remove: \n");
                        foreach (var employeeNames in tempJsonFormatter.DisplayEmployeesName())
                        {
                            Console.WriteLine(employeeNames.Name);
                        }
                        string removeTempEmployee = Console.ReadLine();
                        Console.WriteLine(tempJsonFormatter.RemoveFromList(removeTempEmployee) + "\n");
                        Console.WriteLine($"Employee removed {removeTempEmployee}");
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



