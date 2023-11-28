using Organization.Business.ViewModels;

namespace Organization.Business.Services
{
    public interface IEmployeeService
    {
        void AddNewEmployee(EmployeeVM employeeVM);
        List<EmployeeVM> GetAllEmployees();
    }
}