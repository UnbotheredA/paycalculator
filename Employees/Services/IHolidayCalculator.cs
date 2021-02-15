using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Services
{
    interface IHolidayCalculator
    {
        int AllowanceRemaning(int hourOff); 
    }
}
