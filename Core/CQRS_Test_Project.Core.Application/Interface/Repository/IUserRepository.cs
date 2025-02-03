using CQRS_Test_Project.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Test_Project.Core.Application.Interface.Repository
{
    public interface IUserRepository:IGenericRepository<User>
    {
    }
}
