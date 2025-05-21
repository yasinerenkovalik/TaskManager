using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Task = CQRS_Test_Project.Core.Domain.Entities.Task;

namespace CQRS_Test_Project.Infrastructure.Persistence.Repository;

public class TaskRepository:GenericRepository<Task>,ITaskRepository
{
    private readonly CqrsContext _context;
    public TaskRepository(CqrsContext appContext) : base(appContext)
    {
        _context = appContext;
    }


    public Task<List<Task>> GetByProject(Guid projectId)
    {
        return _context.Tasks.Where(x => x.ProjectId == projectId).ToListAsync();
    }
}