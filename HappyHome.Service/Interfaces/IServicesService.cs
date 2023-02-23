using HappyHome.Domain.Entities;
using HappyHome.Service.DTOs;
using HappyHome.Service.Helpers;

namespace HappyHome.Service.Interfaces;

public interface IServicesService
{
    Task<GenericResponse<Domain.Entities.Servises>> CreateAsync(ServicesDto servicesDto);
    Task<GenericResponse<Domain.Entities.Servises>> DeleteAsync(long id);
    Task<GenericResponse<Domain.Entities.Servises>> UpdateAsync(long id, ServicesDto servicesDto);
    Task<GenericResponse<Domain.Entities.Servises>> GetAsync(long id);
    Task<GenericResponse<List<Domain.Entities.Servises>>> GetAllAsync(Predicate<Servises> predicate);
}
