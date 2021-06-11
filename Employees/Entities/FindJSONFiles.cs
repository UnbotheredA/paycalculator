using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Entities
{
    public class FindJSONFiles
    {
        public FindJSONFiles(string permanentEmployeeJSONFileLocation, string tempEmployeeJSONFileLocation)
        {
            dirForPermanentEmployeeJSONFile = permanentEmployeeJSONFileLocation;
            dirForTempJSONFile = tempEmployeeJSONFileLocation;
        }
         FileLocator FileLocator = new FileLocator();

        private string dirForPermanentEmployeeJSONFile;
        private string dirForTempJSONFile;
       

        public string PermanentEmployeeJSONLocation() =>  FileLocator.FindFile(dirForPermanentEmployeeJSONFile);
        public string TempEmployeeJSONLocation() =>  FileLocator.FindFile(dirForTempJSONFile);
    }
}
