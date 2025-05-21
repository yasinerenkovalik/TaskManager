using CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetByIdSubTask;
using CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetByTaskSubTask;
using CQRS_Test_Project.Core.Domain.Entities;

namespace CQRS_Test_Project.Core.Application.Interface.Repository;

public interface ISubTaskRepository:IGenericRepository<SubTask>
{
    Task<GetByTaskSubTaskResponse> GetByIdAsyncUser(Guid id);
    Task<List<GetByTaskSubTaskResponse>> GetByTaskAsync(Guid id);
}