using Organization.Business.Constants;
using Organization.Business.Translators;
using Organization.Business.ViewModels;
using Organization.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IOrganizationTranslator _OrganizationTranslator;
        public EmployeeService(IEmployeeRepository employeeRepository, IOrganizationTranslator organizationTranslator)
        {
            _EmployeeRepository = employeeRepository;
            _OrganizationTranslator = organizationTranslator;
        }

        public List<EmployeeVM> GetAllEmployees()
        {
            List<EmployeeVM> employees = new List<EmployeeVM>();

            _EmployeeRepository.GetAll().ToList().ForEach(e =>
            {
                employees.Add(_OrganizationTranslator.EmployeeToEmployeeVM(e));
            });

            return employees;
        }

        public void AddNewEmployee(EmployeeVM employeeVM)
        {
            var employee = _OrganizationTranslator.EmployeeVMToEmployee(employeeVM);
            _EmployeeRepository.Add(employee);
        }


    }
}
