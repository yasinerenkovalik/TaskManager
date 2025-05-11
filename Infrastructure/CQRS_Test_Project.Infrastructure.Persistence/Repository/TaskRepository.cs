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

    public async Task<List<Task>> GetByUserTask(Guid Id)
    {
        return await _context.Tasks
            .Where(t => t.UserId == Id)
            .ToListAsync();
    }
}