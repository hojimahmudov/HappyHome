using HappyHome.Data.IRepositories;
using HappyHome.Data.Repositories;
using HappyHome.Domain.Entities;
using HappyHome.Service.DTOs;
using HappyHome.Service.Helpers;
using HappyHome.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHome.Service.Servicess
{
    public class EmployeeService : IEmployeeService
    {
        private IGenericRepo<Employee> employeeRepository;
        public EmployeeService()
        {
            employeeRepository = new GenericRepo<Employee>();
        }
        public async Task<GenericResponse<Employee>> CreateAsync(EmployeeDto employeeDto)
        {
            var user = (await employeeRepository.GetAllAsync()).FirstOrDefault(u => u.FirstName == employeeDto.FirstName);

            if (user is not null)
            {
                return new GenericResponse<Employee>
                {
                    StatusCode = 405,
                    Message = "Employee is already created",
                    Value = null
                };
            }

            var newEmployee = new Employee
            {
                CreatedAt = DateTime.Now,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Phone = employeeDto.Phone,
                Email = employeeDto.Email,
                Address = employeeDto.Address,
                HourlyRate = employeeDto.HourlyRate
            };

            var result = await employeeRepository.CreateAsync(newEmployee);

            return new GenericResponse<Employee>
            {
                StatusCode = 200,
                Message = "Succes created",
                Value = result
            };
        }

        public async Task<GenericResponse<Employee>> DeleteAsync(long id)
        {
            var model = await this.employeeRepository.GetAsync(id);
            if (model is null)
                return new GenericResponse<Employee>()
                {
                    StatusCode = 404,
                    Message = "Employee is not found",
                    Value = null
                };

            await this.employeeRepository.DeleteAsync(id);
            return new GenericResponse<Employee>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = model
            };
        }
        public async Task<GenericResponse<List<Employee>>> GetAllAsync(Predicate<Employee> predicate)
        {
            var result = await this.employeeRepository.GetAllAsync(predicate);
            return new GenericResponse<List<Employee>>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = result
            };
        }

        public async Task<GenericResponse<Employee>> GetAsync(long id)
        {
            var model = await this.employeeRepository.GetAsync(id);
            if (model is null)
                return new GenericResponse<Employee>()
                {
                    StatusCode = 404,
                    Message = "Employee is not found",
                    Value = null
                };

            return new GenericResponse<Employee>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = model
            };
        }

        public async Task<GenericResponse<Employee>> UpdateAsync(long id, EmployeeDto employeeDto)
        {
            var users = await employeeRepository.GetAllAsync();
            var user = users.FirstOrDefault(c => c.Id == id);

            if (user is null)
                return new GenericResponse<Employee>
                {
                    StatusCode = 404,
                    Message = "Employee is not found",
                    Value = null
                };

            if (user.Email != employeeDto.Email)
            {
                var userWithEmail = users.FirstOrDefault(c => c.Email == employeeDto.Email);

                if (userWithEmail is not null)
                    return new GenericResponse<Employee>
                    {
                        StatusCode = 405,
                        Message = "Email is taken",
                        Value = null
                    };
            }

            user.FirstName = employeeDto.FirstName;
            user.LastName = employeeDto.LastName;
            user.Phone = employeeDto.Phone;
            user.Email = employeeDto.Email;
            user.UpdatedAt = DateTime.Now;
            user.Address = employeeDto.Address;
            user.HourlyRate = employeeDto.HourlyRate;
            var result = await employeeRepository.UpdateAsync(user);

            return new GenericResponse<Employee>
            {
                StatusCode = 200,
                Message = "Succes",
                Value = result
            };
        }
    }
}
