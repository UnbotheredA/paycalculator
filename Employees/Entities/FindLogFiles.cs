using Microsoft.Extensions.Configuration;

namespace Employees.Entities
{
    public class FindLogFiles
    {
        private static FileLocator fileLocator = new FileLocator();
        private static IConfiguration config = new ConfigurationBuilder().AddJsonFile(@"appsettings.json", false, true).Build();

        private static string dirForEmployeesCreatedLogs = config["EmployeesCreatedLogs"];
        public string EmployeeCreatedLogsEndPath = fileLocator.FindFile(dirForEmployeesCreatedLogs);

        private static string dirForCrashLogFile = config["CrashLogs"];
        public string CrashCreatedLogsEndPath = fileLocator.FindFile(dirForCrashLogFile);
    }
}
