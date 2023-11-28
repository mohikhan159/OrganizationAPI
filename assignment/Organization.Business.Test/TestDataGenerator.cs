using Organization.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Business.Test
{
    internal static class TestDataGenerator
    {

        public static IEnumerable<Employee> GetDummyEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    EmployeeId = 1,
                    FirstName = "First Test",
                    LastName = "Last Test",
                    Address1 = "Houston, Texas",
                    EmployeeType = "Contractor",
                    Contractor = new Contractor()
                    {
                        ContractorId = 1,
                        PayPerHour = 50
                    }
                },
                new Employee()
                {
                    EmployeeId = 2,
                    FirstName = "FName",
                    LastName = "LName",
                    Address1 = "Downtown",
                    EmployeeType = "Manager",
                    Manager = new Manager()
                    {
                        AnnualSalary = 120000,
                        ManagerId = 2,
                        MaxExpenseAmount = 9500
                    }
                }
            };
        }




    }
}
