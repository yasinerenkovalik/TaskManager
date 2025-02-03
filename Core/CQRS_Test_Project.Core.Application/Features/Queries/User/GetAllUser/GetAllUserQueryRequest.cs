
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;
using System;

namespace CQRS_Test_Project.Core.Application.Features.Queries.User.GetAllUser
{
    public class GetAllUserQueryRequest : IRequest<GeneralResponse<List<GetAllUserQueryResponse>>>
    {
    }
}
