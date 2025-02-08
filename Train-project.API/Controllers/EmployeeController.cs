using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Train_project.API.Models;
using Train_project.Core.Entities;
using Train_project.Core.IServices;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Train_project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;

        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> Get()
        {
            return _employeeService.GetAllEmployees().ToList();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> Get(int id)
        {

            if (id<=0) return BadRequest();
            EmployeeDto? employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult<EmployeeDto> Post([FromBody] EmployeePostModel employee)
        {
            if (employee == null)
                return BadRequest();
            var employeeDto= _mapper.Map<EmployeeDto>(employee);
            employeeDto = _employeeService.AddEmployee(employeeDto);
            if (employeeDto == null)
                return BadRequest();
            return employeeDto;

        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public ActionResult<EmployeeDto> Put(int id, [FromBody] EmployeePostModel employee)
        {
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            employeeDto = _employeeService.UpdateEmployee(id, employeeDto);
            if (employeeDto != null)
            {
                return employeeDto;
            }
            return NotFound();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            bool success = _employeeService.DeleteEmployee(id);
            if (success)
            {
                return id;
            }
            return NotFound();
        }
    }
}
