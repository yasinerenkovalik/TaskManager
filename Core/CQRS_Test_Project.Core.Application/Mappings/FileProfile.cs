using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.CreateFeedBack;
using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.DeleteFeedBack;
using CQRS_Test_Project.Core.Application.Features.Commands.File.CreateFile;
using CQRS_Test_Project.Core.Application.Features.Commands.File.DeleteFile;
using CQRS_Test_Project.Core.Application.Features.Commands.File.UpdateFile;
using CQRS_Test_Project.Core.Application.Features.Queries.File.GetAllFile;

namespace CQRS_Test_Project.Core.Application.Mappings;

public class FileProfile:Profile
{
    public FileProfile()
    {
        CreateMap<Domain.Entities.File, CreateFileCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.File, UpdateFileCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.File, DeleteFileCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.File, GetAllFileQueryResponse>().ReverseMap();
    }
}