using System;
using System.Collections.Generic;

namespace Organization.DAL.Models
{
    public partial class Supervisor
    {
        public int SupervisorId { get; set; }
        public decimal AnnualSalary { get; set; }

        public virtual Employee SupervisorNavigation { get; set; } = null!;
    }
}
