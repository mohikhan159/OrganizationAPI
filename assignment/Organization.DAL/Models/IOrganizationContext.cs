using Microsoft.EntityFrameworkCore;

namespace Organization.DAL.Models
{
    public interface IOrganizationContext
    {
        DbSet<Contractor> Contractors { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Manager> Managers { get; set; }
        DbSet<Supervisor> Supervisors { get; set; }
    }
}