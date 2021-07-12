using Employees.Entites;
using Employees.Entities.JSON;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using System.Collections.Generic;

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
        [HttpGet]
        public ActionResult<List<T>> Get(EmployeeType employeeType)
        {
            var permanentEmployees = _permanentJSONFormatter.ReadFromList();
            var tempEmployees = _tempJSONFormatter.ReadFromList();

            if (employeeType == EmployeeType.Permanent)
            {
                return Ok(permanentEmployees);
            }
            else if (employeeType == EmployeeType.Temp)
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
        [HttpDelete]
        public IActionResult Delete(string removeEmployee)
        {
            bool findInputtedUser = _permanentJSONFormatter.RemoveEmployee(removeEmployee);
            if (findInputtedUser)
            {
                return Ok("removed employee: " + findInputtedUser);
            }
            else
            {
                return BadRequest("could not find user");
            }
        }
    }
}
