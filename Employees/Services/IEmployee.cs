using Employees.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Services
{
    public interface IEmployee<T>
    {
        string WriteToFile(List<T> newList);
        List<T> ReadFromList();
    }
}
