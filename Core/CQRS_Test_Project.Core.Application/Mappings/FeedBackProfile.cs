using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.CreateFeedBack;
using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.DeleteFeedBack;
using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.UpdateFeedBack;
using CQRS_Test_Project.Core.Application.Features.Queries.FeedBack.GetAllFeedBack;
using CQRS_Test_Project.Core.Application.Features.Queries.FeedBack.GetByIdFeedBack;
using CQRS_Test_Project.Core.Application.Features.Queries.User.GetAllUser;
using CQRS_Test_Project.Core.Domain.Entities;

namespace CQRS_Test_Project.Core.Application.Mappings;

public class FeedBackProfile:Profile
{
    public FeedBackProfile()
    {
        CreateMap<Feedback, CreateFeedBackCommandRequest>().ReverseMap();
        CreateMap<Feedback, UpdateFeedBackCommandRequest>().ReverseMap();
        CreateMap<Feedback, DeleteFeedBackCommandRequest>().ReverseMap();
        CreateMap<Feedback, GetAllFeedBackQueryResponse>().ReverseMap();
        CreateMap<Feedback, GetByIdFeedBackQueyResponse>().ReverseMap();
    }
}