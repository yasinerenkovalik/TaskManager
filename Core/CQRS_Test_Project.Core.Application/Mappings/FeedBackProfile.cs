using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.FeedBack.CreateFeedBack;
using CQRS_Test_Project.Core.Domain.Entities;

namespace CQRS_Test_Project.Core.Application.Mappings;

public class FeedBackProfile:Profile
{
    public FeedBackProfile()
    {
        CreateMap<Feedback, CreateFeedBackCommandRequest>().ReverseMap();
    }
}