using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.User.CreateUser;
using CQRS_Test_Project.Core.Application.Features.Queries.User.GetByIdUser;
using CQRS_Test_Project.Core.Domain.Entities;
namespace CQRS_Test_Project.Core.Application.Mappings
{
    public class UserMapProfile : Profile
    {

        public UserMapProfile()
        {
            CreateMap<CreateUserCommandRequest, User>();

            CreateMap<User, GetByIdUserQueryResponse>();
        }
    }
}
