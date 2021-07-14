using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Services
{
    interface IHolidayCalculator
    {
        int HolidayAllowanceAvailable(int hourOff);
    }
}
