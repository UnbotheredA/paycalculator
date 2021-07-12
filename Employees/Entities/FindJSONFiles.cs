using Employees.Services;
using System;

namespace Employees.Entities
{
    public class FindJSONFiles
    {
        private string dirForPermanentEmployeeJSONFile;
        private string dirForTempJSONFile;
        private IFileLocator _iFileLocator;
        public FindJSONFiles(string permanentEmployeeJSONFileLocation, string tempEmployeeJSONFileLocation, IFileLocator iFileLocator)
        {
            dirForPermanentEmployeeJSONFile = permanentEmployeeJSONFileLocation;
            dirForTempJSONFile = tempEmployeeJSONFileLocation;
            if (iFileLocator != null)
            {
                _iFileLocator = iFileLocator;
            }
            else 
            {
                throw new ArgumentNullException(nameof(iFileLocator));
            }
        }
        public string PermanentEmployeeJSONLocation() => _iFileLocator.FindFile(dirForPermanentEmployeeJSONFile);
        public string TempEmployeeJSONLocation() => _iFileLocator.FindFile(dirForTempJSONFile);
    }
}
