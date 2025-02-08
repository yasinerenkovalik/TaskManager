using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Domain.Entities;
using CQRS_Test_Project.Infrastructure.Persistence.Context;

namespace CQRS_Test_Project.Infrastructure.Persistence.Repository;

public class TagRepository:GenericRepository<Tag>,ITagRepository
{
    public TagRepository(CqrsContext appContext) : base(appContext)
    {
    }
}