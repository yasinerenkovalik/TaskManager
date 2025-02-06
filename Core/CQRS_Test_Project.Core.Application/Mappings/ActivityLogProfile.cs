using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Queries.ActivityLog.GetAllActivityLog;
using CQRS_Test_Project.Core.Domain.Entities;

namespace CQRS_Test_Project.Core.Application.Mappings;

public class ActivityLogProfile:Profile
{
    public ActivityLogProfile()
    {
        CreateMap<ActivityLog, GetAllActivityLogQueryResponse>().ReverseMap();
        
    }
}