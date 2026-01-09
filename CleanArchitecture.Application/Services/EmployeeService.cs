using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CleanArchitecture.Application.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();
            return employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                DepartmentId = e.DepartmentId
            }).ToList();
        }

        public async Task AddAsync(EmployeeDto dto)
        {
            var employee = new Employee
            {
                Name = dto.Name,
                Email = dto.Email,
                DepartmentId = dto.DepartmentId
            };

            await _repository.AddAsync(employee);
        }

        public async Task UpdateAsync( EmployeeDto employeeDto)
        {
            var employeeEntity = new Employee
            {
                Id= employeeDto.Id,
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                DepartmentId = employeeDto.DepartmentId
            };
            await _repository.UpdateAsync(employeeEntity);
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee != null)
            {
                var employeeDto = new EmployeeDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    DepartmentId = employee.DepartmentId
                };
                return employeeDto;
            }
            return null;
        }

        public async Task<EmployeeDto?> DeleteAsync(int id)
        {
            var employee = await _repository.DeleteAsync(id);
            if(employee != null)
            {
                var employeeDto = new EmployeeDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    DepartmentId = employee.DepartmentId
                };
                return employeeDto;
            }
            return null;
        }
    }
}
