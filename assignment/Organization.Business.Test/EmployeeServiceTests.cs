using Moq;
using Organization.Business.Constants;
using Organization.Business.Services;
using Organization.Business.Translators;
using Organization.DAL.Repositories;

namespace Organization.Business.Test
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;
        private readonly Mock<IOrganizationTranslator> _mockOrganizationTranslator;

        public EmployeeServiceTests()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _mockOrganizationTranslator = new Mock<IOrganizationTranslator>();

        }

        [Fact]
        public void EmployeeService_GetAll_Returns_Correct_Data()
        {
            //arrange
            var dummyEmployeeData = TestDataGenerator.GetDummyEmployees();
            _mockEmployeeRepository.Setup(er => er.GetAll()).Returns(dummyEmployeeData);

            var employeeService = new EmployeeService(_mockEmployeeRepository.Object, new OrganizationTranslator());

            //act
            var response = employeeService.GetAllEmployees();

            //assert
            Assert.True(response.Count == 2);
            Assert.Contains(response, r => r.EmployeeType == OrganizationConstant.HourlyContractor);
            Assert.True(response.Any(r => r.EmployeeId == 1));
        }
    }
}