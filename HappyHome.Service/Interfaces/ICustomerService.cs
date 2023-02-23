using HappyHome.Domain.Entities;
using HappyHome.Service.DTOs;
using HappyHome.Service.Helpers;

namespace HappyHome.Service.Interfaces;

public interface ICustomerService
{
    Task<GenericResponse<Customer>> CreateAsync(CustomerDto customerDto);
    Task<GenericResponse<Customer>> DeleteAsync(long id);
    Task<GenericResponse<Customer>> UpdateAsync(long id, CustomerDto customerDto);
    Task<GenericResponse<Customer>> GetAsync(long id);
    Task<GenericResponse<List<Customer>>> GetAllAsync(Predicate<Customer> predicate);
}
