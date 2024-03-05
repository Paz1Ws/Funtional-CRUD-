using AutoMapper;
using FinalBackendProject.Models;
using FinalBackendProject.Repository;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore.Migrations;
namespace FinalBackendProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository _employee;
        public EmployeeController(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            try
            {
                var employees = _employee.Get();
                if (employees == null)
                    return NotFound("No correct or no parameters");
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var GetEmployee = _employee.GetById(id);
                if (GetEmployee == null)
                    return BadRequest("Employee Not Found");
                return Ok(GetEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            try
            {
                if (_employee.Register(employee))
                {
                    return Ok("Employee Registered");
                }
                return BadRequest("Employee Not Registered, verify data.");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Employee employee)
        {
            try
            {
                if (_employee.Update(id, employee))
                {
                    return Ok("Employee Updated");
                }
                return BadRequest("Employee Not Updated, verify data");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (_employee.Delete(id))
                {
                    return Ok("Employee Deleted");
                }
                return BadRequest("Employee Not Deleted, verify data.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
