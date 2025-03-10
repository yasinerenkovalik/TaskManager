using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Queries.File.GetAllFile;
using CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetAllSubTask;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.Tag.GetAllTag;

public class GeAllTagQueryRequestHandler(ITagRepository tagRepository, IMapper mapper):IRequestHandler<GetAllTagQueryRequest, GeneralResponse<List<GetAllTagQueryResponse>>>
{
    private readonly ITagRepository _tagRepository = tagRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<GeneralResponse<List<GetAllTagQueryResponse>>> Handle(GetAllTagQueryRequest request, CancellationToken cancellationToken)
    {
        var tagEntity = await _tagRepository.GetAllAysnc();

        if (tagEntity == null)
        {
            return new GeneralResponse<List<GetAllTagQueryResponse>>
            {
                Data = null,
                Errors = new List<string> { "Project bulunamadı." },
                isSuccess = false
            };
        }
        
        var getAllProjectQueryResponse = _mapper.Map<List<GetAllTagQueryResponse>>(tagEntity);

        return new GeneralResponse<List<GetAllTagQueryResponse>>
        {
            Data = getAllProjectQueryResponse,
            Errors = null,
            isSuccess = true
        };
    }
}