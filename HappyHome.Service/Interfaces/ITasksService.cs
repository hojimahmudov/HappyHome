using HappyHome.Domain.Entities;
using HappyHome.Service.DTOs;
using HappyHome.Service.Helpers;

namespace HappyHome.Service.Interfaces;

public interface ITasksService
{
    Task<GenericResponse<Tasks>> CreateAsync(TasksDto tasksDto);
    Task<GenericResponse<Tasks>> DeleteAsync(long id);
    Task<GenericResponse<Tasks>> UpdateAsync(long id, TasksDto tasksDto);
    Task<GenericResponse<Tasks>> GetAsync(long id);
    Task<GenericResponse<List<Tasks>>> GetAllAsync(Predicate<Tasks> predicate);
}
