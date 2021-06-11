using Employees.Entites;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using System.Text.Json;
namespace PayCalculatorAPI.Controllers
{
    public class ViewModel
    {
        public string EmployeeName { get; internal set; }
        public EmployeeType EmployeeType { get; internal set; }
        public decimal? AnnualSalary { get; internal set; }
        public decimal? AnnualBonus { get; internal set; }
        public int? Holiday { get; internal set; }
        public decimal? DayRate { get; internal set; }
        public int? WeeksWorked { get; internal set; }
       
    }
}