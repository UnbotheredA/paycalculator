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
        public List<T> ReadPermanentList = new List<T>();
        public string Path;
        public EmployeeJSONFormatter(string path)
        {
            Path = path;
        }
        public List<T> ReadFromList()
        {
            string contentOfFile = File.ReadAllText(Path);
            var convertedToList = JsonConvert.DeserializeObject<List<T>>(contentOfFile);//turned to C#
            return convertedToList;

        }
        //This method will merge another list to this list and then serialize the collection to JSON.
        public string WriteToFile(List<T> newList)
        {
            ReadPermanentList = ReadFromList();//turns a JSON file to C# collection
            ReadPermanentList.AddRange(newList);
            string convertToJson = JsonConvert.SerializeObject(ReadPermanentList, Formatting.Indented);
            File.WriteAllText(Path, convertToJson);
            return convertToJson;
        }
        // This method will be passsed as an arugment from ReadEmployeeList method
        public List<T> ReadList()
        {
            var readlist = ReadFromList();
            return readlist;
        }
    }
}