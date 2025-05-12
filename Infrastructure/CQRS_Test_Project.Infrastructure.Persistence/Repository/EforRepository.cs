using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Domain.Entities;
using CQRS_Test_Project.Infrastructure.Persistence.Context;

namespace CQRS_Test_Project.Infrastructure.Persistence.Repository;

public class EforRepository:GenericRepository<Efor>,IEforRepository
{
    public EforRepository(CqrsContext appContext) : base(appContext)
    {
    }
}