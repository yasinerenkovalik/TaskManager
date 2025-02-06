using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.ActivityLog.GetAllActivityLog;

public class GetAllActivityLogQueryRequestHandler:IRequestHandler<GetAllActivityLogQueryRequest, GeneralResponse<List<GetAllActivityLogQueryResponse>>>
{
    private readonly IActivityLogRepository _repository;
    private readonly IMapper _mapper;
    public GetAllActivityLogQueryRequestHandler(IActivityLogRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<GeneralResponse<List<GetAllActivityLogQueryResponse>>> Handle(GetAllActivityLogQueryRequest request, CancellationToken cancellationToken)
    {
        var userEntities = await _repository.GetAllAysnc();

        if (userEntities == null || !userEntities.Any())
        {
            return new GeneralResponse<List<GetAllActivityLogQueryResponse>>
            {
                Data = null,
                Errors = new List<string> { "Log bulunamadı." },
                isSuccess = false
            };
        }
        
        var result = await _repository.GetAllAysnc();
        var mappedResult = _mapper.Map<List<GetAllActivityLogQueryResponse>>(result);
        return new GeneralResponse<List<GetAllActivityLogQueryResponse>>
        {
            Data = mappedResult,
            isSuccess = true,
        };
    }
}