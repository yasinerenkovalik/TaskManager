namespace CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Domain.Entities;


public interface ITaskRepository:IGenericRepository<Task>
{
    Task<List<Task>> GetByProject(Guid projectId);
}