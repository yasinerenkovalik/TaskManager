using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.ActivityLog.CreateActivityLog;
using CQRS_Test_Project.Core.Application.Features.Commands.ActivityLog.UpdateActivityLog;
using CQRS_Test_Project.Core.Application.Features.Queries.ActivityLog.GetAllActivityLog;
using CQRS_Test_Project.Core.Domain.Entities;

namespace CQRS_Test_Project.Core.Application.Mappings;

public class ActivityLogProfile:Profile
{
    public ActivityLogProfile()
    {
        CreateMap<ActivityLog, GetAllActivityLogQueryResponse>().ReverseMap();
        CreateMap<ActivityLog, CreateActivityLogCommandRequest>().ReverseMap();
        CreateMap<ActivityLog, UpdateActivityLogCommandRequest>().ReverseMap();
        
    }
}