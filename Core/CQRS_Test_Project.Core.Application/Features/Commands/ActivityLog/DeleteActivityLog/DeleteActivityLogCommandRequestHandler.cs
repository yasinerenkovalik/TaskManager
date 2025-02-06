using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.ActivityLog.DeleteActivityLog;

public class DeleteActivityLogCommandRequestHandler:IRequestHandler<DeleteActivityLogCommandRequest, GeneralResponse<DeleteActivityLogCommandResponse>>
{
    private readonly IActivityLogRepository _repository;

    public DeleteActivityLogCommandRequestHandler( IActivityLogRepository repository)
    {
        _repository = repository;
    }

    public async Task<GeneralResponse<DeleteActivityLogCommandResponse>> Handle(DeleteActivityLogCommandRequest request, CancellationToken cancellationToken)
    {
        var activityLog = await _repository.GetByIdAsync(request.Id);

        if (activityLog == null)
        {
            return new GeneralResponse<DeleteActivityLogCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }

        await _repository.DeleteAsync(activityLog.BaseID);

        return new GeneralResponse<DeleteActivityLogCommandResponse>
        {
            Data = new DeleteActivityLogCommandResponse
            {
                Id = activityLog.BaseID,
            },
            Errors = null,
            isSuccess = true
        };
    }
}