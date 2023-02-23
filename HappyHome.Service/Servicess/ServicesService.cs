using HappyHome.Data.IRepositories;
using HappyHome.Data.Repositories;
using HappyHome.Domain.Entities;
using HappyHome.Service.DTOs;
using HappyHome.Service.Helpers;
using HappyHome.Service.Interfaces;

namespace HappyHome.Service.Servicess;

public class ServicesService : IServicesService
{
    private IGenericRepo<Servises> genericRepo;
    public ServicesService()
    {
        genericRepo = new GenericRepo<Servises>();
    }
    public async Task<GenericResponse<Servises>> CreateAsync(ServicesDto servicesDto)
    {
        
        var mappedResult = new Servises()
        {
            ServiceName = servicesDto.ServiceName,
            Description = servicesDto.Description,
            CreatedAt = DateTime.Now
        };

        await genericRepo.CreateAsync(mappedResult);

        return new GenericResponse<Servises>
        {
            StatusCode = 200,
            Message = "New service created",
            Value = mappedResult
        };
    }

    public async Task<GenericResponse<Servises>> DeleteAsync(long id)
    {
        var result = await this.genericRepo.GetAsync(id);

        if (result is null)
        {
            return new GenericResponse<Servises>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null
            };
        }

        await this.genericRepo.DeleteAsync(result.Id);

        return new GenericResponse<Servises>
        {
            StatusCode = 200,
            Message = "Successfully deleted )",
            Value = result,
        };
    }

    public async Task<GenericResponse<List<Servises>>> GetAllAsync(Predicate<Servises> predicate)
    {
        var results = await genericRepo.GetAllAsync(predicate);
        if (results is null)
        {
            return new GenericResponse<List<Servises>>
            {
                StatusCode = 404,
                Message = "Empty",
                Value = null,
            };
        }
        return new GenericResponse<List<Servises>>
        {
            StatusCode = 200,
            Message = "Ok )",
            Value = results
        };
    }

    public async Task<GenericResponse<Servises>> GetAsync(long id)
    {
        var result = await this.genericRepo.GetAsync(id);

        if (result is null)
        {
            return new GenericResponse<Servises>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null,
            };
        }

        return new GenericResponse<Servises>
        {
            StatusCode = 200,
            Message = "Ok )",
            Value = result,

        };
    }

    public async Task<GenericResponse<Servises>> UpdateAsync(long id, ServicesDto servicesDto)
    {
        var result = await this.genericRepo.GetAsync(id);

        if (result is null)
        {
            return new GenericResponse<Servises>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null,
            };
        }

        var mappedmodel = new Servises()
        {
            Id = result.Id,
            CreatedAt = result.CreatedAt,
            ServiceName = result.ServiceName,
            Description = result.Description,
            UpdatedAt = DateTime.Now
        };

        var res = await this.genericRepo.UpdateAsync(mappedmodel);

        return new GenericResponse<Servises>
        {
            StatusCode = 200,
            Message = "Successfully updated )",
            Value = mappedmodel,
        };
    }
}
