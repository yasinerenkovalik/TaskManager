using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.User.CreateUser;
using CQRS_Test_Project.Core.Application.Features.Commands.User.UpdateUser;
using CQRS_Test_Project.Core.Application.Features.Queries.User.GetAllUser;
using CQRS_Test_Project.Core.Application.Features.Queries.User.GetByIdUser;
using CQRS_Test_Project.Core.Domain.Entities;
namespace CQRS_Test_Project.Core.Application.Mappings
{
    public class UserMapProfile : Profile
    {

        public UserMapProfile()
        {
            CreateMap<CreateUserCommandRequest, User>();
            CreateMap<GetByIdUserQueryRequest, User>();
            CreateMap<UpdateUserCommandRequest, User>();

            CreateMap<User, GetAllUserQueryResponse>();
            CreateMap<User, GetByIdUserQueryResponse>();
            CreateMap<User, UpdateUserCommandResponse>();


        }
    }
}
