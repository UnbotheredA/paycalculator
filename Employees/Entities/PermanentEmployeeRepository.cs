namespace Employees.Entities
{
    public class PermanentEmployeeRepository
    {
        private FindJSONFiles _findJsonFiles;
        public PermanentEmployeeRepository(FindJSONFiles findJsonFiles)
        {
            _findJsonFiles = findJsonFiles;
        }
        public string GetPermanentEmployees() => _findJsonFiles.PermanentEmployeeJSONLocation();
    }
}
