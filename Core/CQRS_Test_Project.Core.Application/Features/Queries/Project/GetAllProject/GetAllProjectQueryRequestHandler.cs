using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Queries.FeedBack.GetByIdFeedBack;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.Project.GetAllProject;

public class GetAllProjectQueryRequestHandler(IProjectRepository projectRepository, IMapper mapper)
    : IRequestHandler<GetAllProjectQueryRequest, GeneralResponse<List<GetAllProjectQueryResponse>>>
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<GeneralResponse<List<GetAllProjectQueryResponse>>> Handle(GetAllProjectQueryRequest request, CancellationToken cancellationToken)
    {
        var projectEntity = await _projectRepository.GetAllAysnc();

        if (projectEntity == null)
        {
            return new GeneralResponse<List<GetAllProjectQueryResponse>>
            {
                Data = null,
                Errors = new List<string> { "Project bulunamadı." },
                isSuccess = false
            };
        }
        
        var getAllProjectQueryResponse = _mapper.Map<List<GetAllProjectQueryResponse>>(projectEntity);

        return new GeneralResponse<List<GetAllProjectQueryResponse>>
        {
            Data = getAllProjectQueryResponse,
            Errors = null,
            isSuccess = true
        };
    }
}