using Microsoft.AspNetCore.Mvc;
using Organization.Business.Services;
using Organization.Business.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrgnizationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _EmployeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _EmployeeService = employeeService;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeVM>> Get()
        {
            return Ok(_EmployeeService.GetAllEmployees());
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public ActionResult<string> Post([FromBody] EmployeeVM employeeVM)
        {
            _EmployeeService.AddNewEmployee(employeeVM);

            return Ok("success");
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
