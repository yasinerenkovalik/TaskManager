using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Domain.Entities;
using CQRS_Test_Project.Infrastructure.Persistence.Context;

namespace CQRS_Test_Project.Infrastructure.Persistence.Repository;

public class SubTaskRepository:GenericRepository<SubTask>,ISubTaskRepository
{
    public SubTaskRepository(CqrsContext appContext) : base(appContext)
    {
    }
}