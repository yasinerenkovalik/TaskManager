using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Infrastructure.Persistence.Context;
using File = CQRS_Test_Project.Core.Domain.Entities.File;

namespace CQRS_Test_Project.Infrastructure.Persistence.Repository;

public class FileRepository:GenericRepository<File>,IFileRepository
{
    public FileRepository(CqrsContext appContext) : base(appContext)
    {
    }
}