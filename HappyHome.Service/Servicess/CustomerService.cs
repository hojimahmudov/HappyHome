using HappyHome.Data.IRepositories;
using HappyHome.Data.Repositories;
using HappyHome.Domain.Entities;
using HappyHome.Service.DTOs;
using HappyHome.Service.Helpers;
using HappyHome.Service.Interfaces;

namespace HappyHome.Service.Servicess;

public class CustomerService : ICustomerService
{
    private readonly IGenericRepo<Customer> customerRepository;
    public CustomerService()
    {
        customerRepository = new GenericRepo<Customer>();
    }
    public async Task<GenericResponse<Customer>> CreateAsync(CustomerDto customerDto)
    {
        var user = (await customerRepository.GetAllAsync()).FirstOrDefault(u => u.FirstName == customerDto.FirstName);

        if (user is not null)
        {
            return new GenericResponse<Customer>
            {
                StatusCode = 405,
                Message = "Customer is already created",
                Value = null
            };
        }

        var newCustomer = new Customer
        {
            CreatedAt = DateTime.Now,
            FirstName = customerDto.FirstName,
            LastName = customerDto.LastName,
            Phone = customerDto.Phone,
            Email = customerDto.Email,
            Address= customerDto.Address
        };

        var result = await customerRepository.CreateAsync(newCustomer);

        return new GenericResponse<Customer>
        {
            StatusCode = 200,
            Message = "Succes created",
            Value = result
        };
    }

    public async Task<GenericResponse<Customer>> DeleteAsync(long id)
    {
        var model = await this.customerRepository.GetAsync(id);
        if (model is null)
            return new GenericResponse<Customer>()
            {
                StatusCode = 404,
                Message = "Customer is not found",
                Value = null
            };

        await this.customerRepository.DeleteAsync(id);
        return new GenericResponse<Customer>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = model
        };
    }

    public async Task<GenericResponse<List<Customer>>> GetAllAsync(Predicate<Customer> predicate)
    {
        var result = await this.customerRepository.GetAllAsync(predicate);
        return new GenericResponse<List<Customer>>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = result
        };
    }

    public async Task<GenericResponse<Customer>> GetAsync(long id)
    {
        var model = await this.customerRepository.GetAsync(id);
        if (model is null)
            return new GenericResponse<Customer>()
            {
                StatusCode = 404,
                Message = "Customer is not found",
                Value = null
            };

        return new GenericResponse<Customer>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = model
        };
    }

    public async Task<GenericResponse<Customer>> UpdateAsync(long id, CustomerDto customerDto)
    {
        var users = await customerRepository.GetAllAsync();
        var user = users.FirstOrDefault(c => c.Id == id);

        if (user is null)
            return new GenericResponse<Customer>
            {
                StatusCode = 404,
                Message = "Customer is not found",
                Value = null
            };

        if (user.Email != customerDto.Email)
        {
            var userWithEmail= users.FirstOrDefault(c => c.Email == customerDto.Email);

            if (userWithEmail is not null)
                return new GenericResponse<Customer>
                {
                    StatusCode = 405,
                    Message = "Email is taken",
                    Value = null
                };
        }

        user.FirstName = customerDto.FirstName;
        user.LastName = customerDto.LastName;
        user.Phone = customerDto.Phone;
        user.Email = customerDto.Email;
        user.UpdatedAt = DateTime.Now;
        user.Address = customerDto.Address;
        var result = await customerRepository.UpdateAsync(user);

        return new GenericResponse<Customer>
        {
            StatusCode = 200,
            Message = "Succes",
            Value = result
        };
    }
}
