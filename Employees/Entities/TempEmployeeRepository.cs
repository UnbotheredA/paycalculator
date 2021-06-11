using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Entities
{
   public  class TempEmployeeRepository
    {
        FindJSONFiles _findJsonFiles;

        public TempEmployeeRepository(FindJSONFiles findJsonFiles)
        {
            _findJsonFiles = findJsonFiles;
        }
        public string GetTempEmployees() => _findJsonFiles.TempEmployeeJSONLocation();
    }
}
