using System;
using System.IO;

namespace Employees
{
    public class JSONFileLocator
    {
        public string FindJsonFile(string jsonAbsoluteFilePath)
        {
            string enviroment = System.Environment.CurrentDirectory;
            string whereIsThisRunning = Directory.GetParent(enviroment).Parent.FullName;
            string finalPath = Path.GetFullPath(Path.Combine(whereIsThisRunning, jsonAbsoluteFilePath));
            Console.WriteLine(whereIsThisRunning);
            return finalPath;
        }
    }
}

