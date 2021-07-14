using Employees.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Services
{
    public interface IEmployeeRepository<T>
    {
        string WriteTo(List<T> formatData);
        List<T> ReadFromList();
        bool RemoveEmployee(string removeEmployee);

    }
}
