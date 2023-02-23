using HappyHome.Domain.Entities;
using HappyHome.Service.DTOs;
using HappyHome.Service.Helpers;

namespace HappyHome.Service.Interfaces;

public interface IEmployeeService
{
    Task<GenericResponse<Employee>> CreateAsync(EmployeeDto employeeDto);
    Task<GenericResponse<Employee>> DeleteAsync(long id);
    Task<GenericResponse<Employee>> UpdateAsync(long id, EmployeeDto employeeDto);
    Task<GenericResponse<Employee>> GetAsync(long id);
    Task<GenericResponse<List<Employee>>> GetAllAsync(Predicate<Employee> predicate);
}
