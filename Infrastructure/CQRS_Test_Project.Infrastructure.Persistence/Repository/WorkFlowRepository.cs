using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Domain.Entities;
using CQRS_Test_Project.Infrastructure.Persistence.Context;

namespace CQRS_Test_Project.Infrastructure.Persistence.Repository;

public class WorkFlowRepository:GenericRepository<Workflow>,IWorkflowRepository
{
    public WorkFlowRepository(CqrsContext appContext) : base(appContext)
    {
    }
}