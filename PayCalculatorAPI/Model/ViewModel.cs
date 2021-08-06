using Employees.Entites;
namespace PayCalculatorAPI.Controllers
{
    public class ViewModel
    {
        public string EmployeeName { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public decimal? AnnualSalary { get; set; }
        public decimal? AnnualBonus { get; set; }
        public int? Holiday { get; set; }
        public decimal? DayRate { get; set; }
        public int? WeeksWorked { get; set; }
    }
}