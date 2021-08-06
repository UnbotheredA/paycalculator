using Employees.Services;
using Serilog;
using System;
using System.IO;

namespace Employees.Entities
{
    public class CrashLog : ILog
    {
        public string FullCrashLogPath { get; set; }
        public CrashLog(string crashLogFile)
        {
            FullCrashLogPath = crashLogFile;
        }
        public bool CanLog(LogType logType) => logType == LogType.Crash;
        public void Log(string message)
        {
            string finalCrashLogPath = Path.GetFullPath(Path.Combine(FullCrashLogPath, "CrashLogs.txt"));
            using (var log = new LoggerConfiguration()
                        .WriteTo.File(finalCrashLogPath, rollingInterval: RollingInterval.Day)
                        .CreateLogger())
            {
                log.Error($"{message}", DateTime.Now);
            }
        }
    }
}
