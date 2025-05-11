using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.Project.GetByIdProject;

public class GetByIdProjectQueryRequestHandler(IProjectRepository projectRepository, IMapper mapper):IRequestHandler<GetByIdProjectQueryRequest, GeneralResponse<GetByIdProjectQueryResponse>>
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<GeneralResponse<GetByIdProjectQueryResponse>> Handle(GetByIdProjectQueryRequest request, CancellationToken cancellationToken)
    {
        var projectEntity = await _projectRepository.GetByIdAsync(request.Id);

        if (projectEntity == null)
        {
            return new GeneralResponse<GetByIdProjectQueryResponse>
            {
                Data = null,
                Errors = new List<string> { "Proje bulunamadı." },
                isSuccess = false
            };
        }
        var getByIdFeedBackQueryResponse = _mapper.Map<GetByIdProjectQueryResponse>(projectEntity);

        return new GeneralResponse<GetByIdProjectQueryResponse>
        {
            Data = getByIdFeedBackQueryResponse,
            Errors = null,
            isSuccess = true
        };
    }
}