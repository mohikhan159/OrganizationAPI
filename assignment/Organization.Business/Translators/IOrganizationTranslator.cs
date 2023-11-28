using Organization.Business.ViewModels;
using Organization.DAL.Models;

namespace Organization.Business.Translators
{
    public interface IOrganizationTranslator
    {
        EmployeeVM EmployeeToEmployeeVM(Employee employee);
        Employee EmployeeVMToEmployee(EmployeeVM employeeVM);
    }
}