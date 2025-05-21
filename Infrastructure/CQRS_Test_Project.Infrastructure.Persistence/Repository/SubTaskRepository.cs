using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetByIdSubTask;
using CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetByTaskSubTask;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Domain.Entities;
using CQRS_Test_Project.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Test_Project.Infrastructure.Persistence.Repository;

public class SubTaskRepository:GenericRepository<SubTask>,ISubTaskRepository
{
    private readonly CqrsContext _appContext;
    private readonly IMapper _mapper;
    public SubTaskRepository(CqrsContext appContext, IMapper mapper) : base(appContext)
    {
        _appContext = appContext;
        _mapper = mapper;
    }

    public async Task<GetByTaskSubTaskResponse> GetByIdAsyncUser(Guid id)
    {
        return await _appContext.Set<SubTask>()
            .Where(subTask => subTask.TaskId == id) // Dışarıdan alınan 'id' değerine göre filtreleme
            .Join(
                _appContext.Set<User>(),
                subTask => subTask.UserId,
                user => user.BaseID,
                (subTask, user) => new GetByTaskSubTaskResponse
                {
                    Name = subTask.Title,
                    TaskName = user.Name
                })
            .FirstOrDefaultAsync();
    }

    public async Task<List<GetByTaskSubTaskResponse>> GetByTaskAsync(Guid id)
    {
        var result= await _appContext.Set<SubTask>().Where(x=>x.TaskId==id).ToListAsync();
        return _mapper.Map<List<GetByTaskSubTaskResponse>>(result);
    }
}