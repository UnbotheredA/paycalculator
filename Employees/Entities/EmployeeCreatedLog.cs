using Employees.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Employees.Entities
{
    public class EmployeeCreatedLog : ILog
    {
        public string FullEmployeesCreatedLogPath { get; set; }
         public EmployeeCreatedLog(string employeesCreatedLogFile)
        {
            FullEmployeesCreatedLogPath = employeesCreatedLogFile;
        }
        public bool CanLog(LogType logType) => logType == LogType.EmployeeCreated;
      
        public void Log(string message)
        {
            string finalEmployeeLogPath = Path.GetFullPath(Path.Combine(FullEmployeesCreatedLogPath, "EmployeeLogsText.txt"));
            using (var log = new LoggerConfiguration()
                        .WriteTo.File(finalEmployeeLogPath, rollingInterval: RollingInterval.Day)
                        .CreateLogger())
            {
                log.Information($"{message}", DateTime.Now);
            }
        }
    }
}
