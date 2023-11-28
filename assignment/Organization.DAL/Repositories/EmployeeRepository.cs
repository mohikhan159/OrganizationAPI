using Microsoft.EntityFrameworkCore;
using Organization.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly OrganizationContext _OrganizationContext;
        public EmployeeRepository(OrganizationContext organizationContext)
        {

            _OrganizationContext = organizationContext;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _OrganizationContext.Employees.Include("Contractor").Include("Manager").Include("Supervisor").ToList();
        }

        public void Add(Employee employee)
        {
            _OrganizationContext.Employees.Add(employee);
            _OrganizationContext.SaveChanges();
        }

    }
}
