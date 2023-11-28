using Organization.Business.Constants;
using Organization.Business.ViewModels;
using Organization.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Business.Translators
{
    public class OrganizationTranslator : IOrganizationTranslator
    {
        public EmployeeVM EmployeeToEmployeeVM(Employee employee)
        {
            return new EmployeeVM()
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Address1 = employee.Address1,
                EmployeeType = employee.EmployeeType,
                PayPerHour = employee.Contractor?.PayPerHour ?? 0,
                AnnualSalary = employee.EmployeeType == OrganizationConstant.BusinessManager ?
                                                        employee.Manager?.AnnualSalary ?? 0 :
                                                        employee.Supervisor?.AnnualSalary ?? 0,
                MaxExpenseAmount = employee.Manager?.MaxExpenseAmount
            };
        }
        public Employee EmployeeVMToEmployee(EmployeeVM employeeVM)
        {
            return new Employee()
            {
                EmployeeId = employeeVM.EmployeeId,
                FirstName = employeeVM.FirstName,
                LastName = employeeVM.LastName,
                Address1 = employeeVM.Address1,
                EmployeeType = employeeVM.EmployeeType,
                Contractor = new Contractor()
                {
                    ContractorId = employeeVM.EmployeeId,
                    PayPerHour = employeeVM.PayPerHour
                },
                Supervisor = new Supervisor()
                {
                    SupervisorId = employeeVM.EmployeeId,
                    AnnualSalary = employeeVM.AnnualSalary
                },
                Manager = new Manager()
                {
                    ManagerId = employeeVM.EmployeeId,
                    AnnualSalary = employeeVM.AnnualSalary,
                    MaxExpenseAmount = employeeVM.MaxExpenseAmount
                }
            };
        }
    }
}
