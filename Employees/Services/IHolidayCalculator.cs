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
// services are classess that only have functionality and does a lot of calculation