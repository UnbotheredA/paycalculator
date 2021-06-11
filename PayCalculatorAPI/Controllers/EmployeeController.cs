using Employees.Entites;
using Employees.Entities.JSON;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using System.Collections.Generic;
using System.Diagnostics;

namespace PayCalculatorAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeJSONFormatter<PermanentEmployee> _permanentJSONFormatter;
        private readonly EmployeeJSONFormatter<TempEmployee> _tempJSONFormatter;
        public EmployeeController(EmployeeJSONFormatter<PermanentEmployee> permanentJSONFormatter, EmployeeJSONFormatter<TempEmployee> tempJSONFormatter)
        {
            _permanentJSONFormatter = permanentJSONFormatter;
            _tempJSONFormatter = tempJSONFormatter;
        }
        // fancy way is attrubite routing asp . net core attrubuite routing
        [HttpGet]
        public ActionResult<List<T>> Get(EmployeeType employeeTypeEnum)
        {
            var permanentEmployees = _permanentJSONFormatter.ReadFromList();
            var tempEmployees = _tempJSONFormatter.ReadFromList();

            if (employeeTypeEnum == EmployeeType.Permanent)
            {
                return Ok(permanentEmployees);
            }
            else if (employeeTypeEnum == EmployeeType.Temp)
            {
                return Ok(tempEmployees);
            }
            else
            {
                List<Employee> employees = new List<Employee>();
                employees.AddRange(permanentEmployees);
                employees.AddRange(tempEmployees);
                List<ViewModel> viewModels = new List<ViewModel>();
                foreach (var employee in employees)
                {
                    ViewModel viewModel = new ViewModel();
                    viewModel.EmployeeName = employee.Name;
                    viewModel.EmployeeType = employee.EmployeeType;
                    if (employee is PermanentEmployee)
                    {
                        var permanentEmployee = (PermanentEmployee)employee;
                        viewModel.AnnualSalary = permanentEmployee.AnnualSalary;
                        viewModel.AnnualBonus = permanentEmployee.AnnualBonus;
                        viewModel.Holiday = permanentEmployee.HolidayAllowance;
                    }
                    else if (employee is TempEmployee)
                    {
                        var tempEmployee = (TempEmployee)employee;
                        viewModel.DayRate = tempEmployee.DayRate;
                        viewModel.WeeksWorked = tempEmployee.WeeksWorked;
                    }
                    viewModels.Add(viewModel);
                }
                return Ok(viewModels);
            }
        }
    }
}
// it's fine as long as it says the truth
// passing back a string  with string builder 
// JSON Serialztion attributes on how it is serialized if this is empty ignore it.
//elgnace solution something simple and neat and uses establish stuff
//non nullble for value type
// rendering something to null means reppear 