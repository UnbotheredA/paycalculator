using Employees.Entites;
using Employees.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Employees.Entities.JSON
{
    public class EmployeeJSONFormatter<T> : IEmployee<T>
    {
        public List<T> ReadJSONList = new List<T>();
        public string JSONFilePath;
        public EmployeeJSONFormatter(string path)
        {
            JSONFilePath = path;
        }

        public List<T> ReadFromList()
        {
            string contentOfFile = File.ReadAllText(JSONFilePath);
            var convertedToList = JsonConvert.DeserializeObject<List<T>>(contentOfFile);//turned to C#
            return convertedToList;

        }

        public string WriteToFile(List<T> newList)
        {
            ReadJSONList = ReadFromList();//turns a JSON file to C# collection
            ReadJSONList.AddRange(newList);
            string convertToJson = JsonConvert.SerializeObject(ReadJSONList, Formatting.Indented);
            File.WriteAllText(JSONFilePath, convertToJson);
            return convertToJson;
        }
        
        public List<T> ReadList()
        {
            var readlist = ReadFromList();
            return readlist;
        }
    }
}