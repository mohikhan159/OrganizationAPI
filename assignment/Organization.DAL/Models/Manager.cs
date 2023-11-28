using System;
using System.Collections.Generic;

namespace Organization.DAL.Models
{
    public partial class Manager
    {
        public int ManagerId { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal? MaxExpenseAmount { get; set; }

        public virtual Employee ManagerNavigation { get; set; } = null!;
    }
}
