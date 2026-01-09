using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task AddAsync(Employee employee);
        Task<Employee?> UpdateAsync(Employee employee);
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee?> DeleteAsync(int id);
    }
}
