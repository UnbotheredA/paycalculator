using Employees.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Services
{
    public interface ILog
    {
         bool CanLog(LogType logType);
         void Log(string message);
    }
}
