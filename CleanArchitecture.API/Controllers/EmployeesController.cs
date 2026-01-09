using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _service;

        public EmployeesController(EmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeDto dto)
        {
            await _service.AddAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto employeeDto)
        {
            await _service.UpdateAsync(employeeDto);
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _service.GetByIdAsync(id);
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var employee = await _service.GetByIdAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            else
            {
                employee = await _service.DeleteAsync(id);
                return Ok(employee);
            }
        }
    }
}
