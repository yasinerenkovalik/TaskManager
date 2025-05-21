using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Domain.Entities;
using CQRS_Test_Project.Infrastructure.Persistence.Context;

namespace CQRS_Test_Project.Infrastructure.Persistence.Repository;

public class EforRepository:GenericRepository<Efor>,IEforRepository
{
    private readonly CqrsContext _context;
    public EforRepository(CqrsContext appContext) : base(appContext)
    {
        _context = appContext;  
    }

    public async Task<List<Efor>> GetByProjectTask(Guid projectTaskId)
    {
       return _context.Set<Efor>().Where(x=>x.SubTaskId==projectTaskId).ToList();
       
    }
}