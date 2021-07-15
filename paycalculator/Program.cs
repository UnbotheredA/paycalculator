using Employees;
using Employees.Entites;
using Employees.Entities;
using Employees.Entities.JSON;
using Employees.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace paycalculator
{
    class Program
    {
        private static NewEmployeeInput _newEmployeeInput = new NewEmployeeInput();
        private static ILog iLogs;
        private static List<ILog> _Logs = new List<ILog>();

        static void Main(string[] args)
        {
            DisplayEmployees displayEmployees = new DisplayEmployees();
            displayEmployees.DisplayContent(displayEmployees.permanentEmployee1, displayEmployees.PermanentEmployee2, displayEmployees.TempEmployee1);
            FindLogFiles findLogs = new FindLogFiles();
            iLogs = new EmployeeCreatedLog(findLogs.EmployeeCreatedLogsEndPath);
            _Logs.Add(iLogs);
            iLogs = new CrashLog(findLogs.CrashCreatedLogsEndPath);
            _Logs.Add(iLogs);
            EmployeeAction();
        }

        private static void EmployeeAction()
        {
            Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type rp to remove permanent employee. Type t1 to add temp employee, rt2 to read all temp employees and type rt to remove temp employee. Type done to exit application");
            bool isDone = false;
            IConfiguration config = new ConfigurationBuilder().AddJsonFile(@"appsettings.json", false, true).Build();
            IFileLocator ifileLocator = new FileLocator();
            FindJSONFiles findJSONFile = new FindJSONFiles(config["PermanentPath"], config["TempPath"], ifileLocator);
            WriteEmployeeInputtedDataToJSONFile writeEmployeeInputtedDataToJSON = new WriteEmployeeInputtedDataToJSONFile(_newEmployeeInput);
            writeEmployeeInputtedDataToJSON.PermanentEmployeeJSONFormatter.JSONFilePath = findJSONFile.PermanentEmployeeJSONLocation();
            writeEmployeeInputtedDataToJSON.TempEmployeeJSONFormatter.JSONFilePath = findJSONFile.TempEmployeeJSONLocation();
            while (!isDone)
            {
                string action = Console.ReadLine();
                switch (action)
                {
                    case "p1":
                        try
                        {
                            writeEmployeeInputtedDataToJSON.AddPermanentEmployeeToJson(writeEmployeeInputtedDataToJSON.PermanentEmployeeJSONFormatter);
                            Console.WriteLine("New employee added " + _newEmployeeInput.NameInput);
                            Log(LogType.EmployeeCreated, $" Permanent employee created {_newEmployeeInput.NameInput} ");
                            Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type rp to remove permanent employee. Type t1 to add temp employee, rt2 to read all temp employees and type rt to remove temp employee. Type done to exit application");
                        }
                        catch (Exception ex)
                        {
                            Log(LogType.Crash, $" {AppDomain.CurrentDomain.FriendlyName}, the error is: {ex.Message}");
                            Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type rp to remove permanent employee. Type t1 to add temp employee, rt2 to read all temp employees and type rt to remove temp employee. Type done to exit application");
                        }
                        break;
                    case "rp2":
                        EmployeeList<PermanentEmployee> employeeListPermanent = new EmployeeList<PermanentEmployee>();
                        var list = employeeListPermanent.ReadEmployeeList(writeEmployeeInputtedDataToJSON.PermanentEmployeeJSONFormatter.GetEmployeesName());
                        foreach (var emp in list)
                        {
                            Console.WriteLine("permanent employees name: " + emp.Name);

                        }
                        Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type rp to remove permanent employee. Type t1 to add temp employee,  rt2 to read all temp employees and type rt to remove temp employee. Type done to exit application");
                        break;
                    case "rp":
                        EmployeeJSONFormatter<PermanentEmployee> permanentJsonFormatter = new EmployeeJSONFormatter<PermanentEmployee>(findJSONFile.PermanentEmployeeJSONLocation());
                        Console.WriteLine("Enter name of employee to remove: \n");
                        foreach (var employeeName in permanentJsonFormatter.GetEmployeesName())
                        {
                            Console.WriteLine(employeeName.Name);
                        }
                        string removePermanentEmployee = Console.ReadLine();
                        Console.WriteLine(permanentJsonFormatter.RemoveEmployee(removePermanentEmployee) + "\n");
                        Console.WriteLine($"Employee removed {removePermanentEmployee}");
                        Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type rp to remove permanent employee. Type t1 to add temp employee, rt2 to read all temp employees and type rt to remove temp employee. Type done to exit application");
                        break;
                    case "t1":
                        try
                        {
                            writeEmployeeInputtedDataToJSON.AddTempEmployeeToJson(writeEmployeeInputtedDataToJSON.TempEmployeeJSONFormatter);
                            Console.WriteLine("New employee added " + _newEmployeeInput.NameInput);
                            Log(LogType.EmployeeCreated, $" Temp employee created {_newEmployeeInput.NameInput} ");
                            Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type rp to remove permanent employee. Type t1 to add temp employee, rt2 to read all temp employees and type rt to remove temp employee. Type done to exit application");
                        }
                        catch(Exception ex)
                        {
                            Log(LogType.Crash, $" {AppDomain.CurrentDomain.FriendlyName}, the error is: {ex.Message}");
                            Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type rp to remove permanent employee. Type t1 to add temp employee, rt2 to read all temp employees and type rt to remove temp employee. Type done to exit application");
                        }
                        break;
                    case "rt2":
                        EmployeeList<TempEmployee> employeeListTemp = new EmployeeList<TempEmployee>();
                        var allTempEmployees = employeeListTemp.ReadEmployeeList(writeEmployeeInputtedDataToJSON.TempEmployeeJSONFormatter.GetEmployeesName());
                        foreach (var employeeName in allTempEmployees)
                        {
                            Console.WriteLine("temp employees: " + employeeName.Name);
                        }
                        Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type rp to remove permanent employee. Type t1 to add temp employee, rt2 to read all temp employees and type rt to remove temp employee. Type done to exit application");
                        break;
                    case "rt":
                        EmployeeJSONFormatter<TempEmployee> tempJsonFormatter = new EmployeeJSONFormatter<TempEmployee>(findJSONFile.TempEmployeeJSONLocation());
                        Console.WriteLine("Enter name of employee to remove: \n");
                        foreach (var employeeNames in tempJsonFormatter.GetEmployeesName())
                        {
                            Console.WriteLine(employeeNames.Name);
                        }
                        string removeTempEmployee = Console.ReadLine();
                        Console.WriteLine(tempJsonFormatter.RemoveEmployee(removeTempEmployee) + "\n");
                        Console.WriteLine($"Employee removed {removeTempEmployee}");
                        Console.WriteLine("Type p1 to add  permanent employee, rp2 to read permanent employee and type rp to remove permanent employee. Type t1 to add temp employee, rt2 to read all temp employees and type rt to remove temp employee. Type done to exit application");
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

        public static void Log(LogType loggerType, string message)
        {
            foreach (ILog iLog in _Logs)
            {
                if (iLog.CanLog(loggerType))
                {
                    iLog.Log(message);
                }
            }
        }
    }
}



