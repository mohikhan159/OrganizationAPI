using Organization.DAL.Models;

namespace Organization.DAL.Repositories
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        IEnumerable<Employee> GetAll();
    }
}