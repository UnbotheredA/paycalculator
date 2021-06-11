using System;
using System.Diagnostics;
using System.IO;

namespace Employees
{
    public class FileLocator
    {
        public string FindFile(string AbsoluteFilePath)
        {
            string environment = System.Environment.CurrentDirectory;
            string whereIsThisRunning = Directory.GetParent(environment).Parent.FullName;
            string finalPath = Path.GetFullPath(Path.Combine(whereIsThisRunning, AbsoluteFilePath));
            Debug.WriteLine("Where is this running: " + finalPath);
            return finalPath;
        }
    }
}

