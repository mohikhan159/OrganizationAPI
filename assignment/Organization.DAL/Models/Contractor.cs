using System;
using System.Collections.Generic;

namespace Organization.DAL.Models
{
    public partial class Contractor
    {
        public int ContractorId { get; set; }
        public decimal PayPerHour { get; set; }

        public virtual Employee ContractorNavigation { get; set; } = null!;
    }
}
