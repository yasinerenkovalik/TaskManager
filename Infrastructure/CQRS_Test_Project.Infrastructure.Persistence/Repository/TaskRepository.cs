using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Infrastructure.Persistence.Context;
using Task = CQRS_Test_Project.Core.Domain.Entities.Task;

namespace CQRS_Test_Project.Infrastructure.Persistence.Repository;

public class TaskRepository:GenericRepository<Task>,ITaskRepository
{
    public TaskRepository(CqrsContext appContext) : base(appContext)
    {
    }

}