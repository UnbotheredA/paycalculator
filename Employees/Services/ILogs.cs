using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Services
{
    public interface ILogs
    {
        void EmployeesCreatedLogs(string NewEmployeeLogged);
        void CrashLogs();
    }
}
