using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organization.DAL.Models
{
    public partial class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Address1 { get; set; }
        public string EmployeeType { get; set; } = null!;

        public virtual Contractor? Contractor { get; set; }
        public virtual Manager? Manager { get; set; }
        public virtual Supervisor? Supervisor { get; set; }
    }
}
