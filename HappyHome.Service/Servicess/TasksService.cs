using HappyHome.Data.IRepositories;
using HappyHome.Data.Repositories;
using HappyHome.Domain.Entities;
using HappyHome.Service.DTOs;
using HappyHome.Service.Helpers;
using HappyHome.Service.Interfaces;

namespace HappyHome.Service.Servicess;

public class TasksService : ITasksService
{
    private IGenericRepo<Tasks> genericRepo;
    public TasksService()
    {
        genericRepo = new GenericRepo<Tasks>();
    }
    public async Task<GenericResponse<Tasks>> CreateAsync(TasksDto tasksDto)
    {
        var mappedResult = new Tasks()
        {
            TaskName = tasksDto.TaskName,
            Description = tasksDto.Description,
            CreatedAt = DateTime.Now
        };

        await genericRepo.CreateAsync(mappedResult);

        return new GenericResponse<Tasks>
        {
            StatusCode = 200,
            Message = "New category created",
            Value = mappedResult
        };
    }

    public async Task<GenericResponse<Tasks>> DeleteAsync(long id)
    {
        var result = await this.genericRepo.GetAsync(id);

        if (result is null)
        {
            return new GenericResponse<Tasks>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null
            };
        }

        await this.genericRepo.DeleteAsync(result.Id);

        return new GenericResponse<Tasks>
        {
            StatusCode = 200,
            Message = "Successfully deleted )",
            Value = result,
        };
    }

    public async Task<GenericResponse<List<Tasks>>> GetAllAsync(Predicate<Tasks> predicate)
    {
        var results = await genericRepo.GetAllAsync(predicate);
        if (results is null)
        {
            return new GenericResponse<List<Tasks>>
            {
                StatusCode = 404,
                Message = "Empty",
                Value = null,
            };
        }
        return new GenericResponse<List<Tasks>>
        {
            StatusCode = 200,
            Message = "Ok )",
            Value = results
        };
    }

    public async Task<GenericResponse<Tasks>> GetAsync(long id)
    {
        var result = await this.genericRepo.GetAsync(id);

        if (result is null)
        {
            return new GenericResponse<Tasks>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null,
            };
        }

        return new GenericResponse<Tasks>
        {
            StatusCode = 200,
            Message = "Ok )",
            Value = result,

        };
    }

    public async Task<GenericResponse<Tasks>> UpdateAsync(long id, TasksDto tasksDto)
    {
        var result = await this.genericRepo.GetAsync(id);

        if (result is null)
        {
            return new GenericResponse<Tasks>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null,
            };
        }

        var mappedResult = new Tasks()
        {
            Id = result.Id,
            CreatedAt = result.CreatedAt,
            TaskName = result.TaskName,
            Description = result.Description,
            UpdatedAt = DateTime.Now
        };

        var res = await this.genericRepo.UpdateAsync(mappedResult);

        return new GenericResponse<Tasks>
        {
            StatusCode = 200,
            Message = "Successfully updated )",
            Value = mappedResult,
        };
    }
}
