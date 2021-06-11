using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Entities
{
    public class FindLogFiles
    {
        static FileLocator FileLocator = new FileLocator();
        static IConfiguration config = new ConfigurationBuilder().AddJsonFile(@"appsettings.json", false, true).Build();

        static string dirForEmployeesCreatedLogs = config["EmployeesCreatedLogs"];
        public string EmployeesCreatedLogsAbsPath = FileLocator.FindFile(dirForEmployeesCreatedLogs);

        static string dirForCrashLogFile = config["CrashLogs"];
        public string CrashCreatedLogsAbsPath = FileLocator.FindFile(dirForCrashLogFile);
    }
}
