using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Business.ViewModels
{
    public class EmployeeVM
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Address1 { get; set; }
        public decimal PayPerHour { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal? MaxExpenseAmount { get; set; }
        public string EmployeeType { get; set; } = null;
    }
}
