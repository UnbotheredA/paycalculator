using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Employees.Services;
using Serilog;

namespace Employees.Service
{
    public class Log : ILogs
    {
        public string FullCrashLogPath { get; set; }
        public string FullEmployeesCreatedLogPath { get; set; }
        public Log(string crashLogFile, string employeesCreatedLogFile)
        {
            FullCrashLogPath = crashLogFile;
            FullEmployeesCreatedLogPath = employeesCreatedLogFile;
        }
        public void CrashLogs()
        {
            string finalCrashLogPath = Path.GetFullPath(Path.Combine(FullCrashLogPath, "CrashLogs.txt"));
            using (var log = new LoggerConfiguration()
                        .WriteTo.File(finalCrashLogPath, rollingInterval: RollingInterval.Day)
                        .CreateLogger())
            {
                AppDomain.CurrentDomain.FirstChanceException += (sender, EventArgs) =>
                log.Error(" This error: {EventArgs}, {Now}", EventArgs.Exception.ToString(), DateTime.Now); 
            }
        }

        public void EmployeesCreatedLogs(string newEmployeeLogged)
        {
            string finalEmployeeLogPath = Path.GetFullPath(Path.Combine(FullEmployeesCreatedLogPath, "EmployeeLogsText.txt"));
            using (var log = new LoggerConfiguration()
                        .WriteTo.File(finalEmployeeLogPath, rollingInterval: RollingInterval.Day)
                        .CreateLogger())
            {
                log.Information("Employee added {newEmployeeLogged} when {Now}", newEmployeeLogged, DateTime.Now);
            }
        }
    }
}


