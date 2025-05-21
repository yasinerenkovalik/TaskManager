using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.SubTask.GetByTaskSubTask;

public class GetByTaskSubTaskRequestHandler:IRequestHandler<GetByTaskSubTaskRequest, GeneralResponse<List<GetByTaskSubTaskResponse>>>
{
    private readonly IMapper _mapper;
    private readonly ISubTaskRepository _subTaskRepository;
    
    public GetByTaskSubTaskRequestHandler(IMapper mapper, ISubTaskRepository subTaskRepository)
    {
        _mapper = mapper;
        _subTaskRepository = subTaskRepository;
    }
    public async Task<GeneralResponse<List<GetByTaskSubTaskResponse>>> Handle(GetByTaskSubTaskRequest request, CancellationToken cancellationToken)
    {
        var result=  await _subTaskRepository.GetByIdAsyncUser(request.TaskId);
        if (result  == null)
        {
            return new GeneralResponse<List<GetByTaskSubTaskResponse>>
            {
                Data = null,
                Errors = new List<string> { "Sub task bulunamadı." },
                isSuccess = false
            };
        }
        var mapped = _mapper.Map<GetByTaskSubTaskResponse>(result);

        return new GeneralResponse<List<GetByTaskSubTaskResponse>>
        {
            Data = new List<GetByTaskSubTaskResponse> { mapped },
            Errors = new List<string> { "Sub task bulundu." },
            isSuccess = true
        };

    }
}