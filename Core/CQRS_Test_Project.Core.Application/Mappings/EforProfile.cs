using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.Efor.CreateEfor;
using CQRS_Test_Project.Core.Domain.Entities;

namespace CQRS_Test_Project.Core.Application.Mappings;

public class EforProfile:Profile
{
    public EforProfile()
    {
        CreateMap<Efor, CreateEforRequest>().ReverseMap();
    }
}