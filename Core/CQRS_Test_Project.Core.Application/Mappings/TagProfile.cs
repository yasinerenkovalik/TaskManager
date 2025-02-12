using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.SubTask.CreateSubTag;
using CQRS_Test_Project.Core.Application.Features.Commands.Tag.CreateTag;
using CQRS_Test_Project.Core.Application.Features.Commands.Tag.DeleteTag;
using CQRS_Test_Project.Core.Application.Features.Commands.Tag.UpdateTag;
using CQRS_Test_Project.Core.Domain.Entities;

namespace CQRS_Test_Project.Core.Application.Mappings;

public class TagProfile:Profile
{
    public TagProfile()
    {
        CreateMap<CreateTagCommandRequest, Tag>().ReverseMap();
        CreateMap<DeleteTagCommandRequest, Tag>().ReverseMap();
        CreateMap<UpdateTagCommandRequest, Tag>().ReverseMap();
    }
}