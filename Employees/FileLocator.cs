using Employees.Services;
using System.IO;

namespace Employees
{
    public class FileLocator : IFileLocator
    {
        public string FindFile(string endPath)
        {
            string environment = System.Environment.CurrentDirectory;
            string whereIsThisRunning = Directory.GetParent(environment).Parent.FullName;
            string finalPath = Path.GetFullPath(Path.Combine(whereIsThisRunning, endPath));
            return finalPath;
        }
    }
}

