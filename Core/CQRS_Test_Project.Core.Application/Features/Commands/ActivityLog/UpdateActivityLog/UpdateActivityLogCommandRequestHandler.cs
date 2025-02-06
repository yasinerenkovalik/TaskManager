using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.ActivityLog.UpdateActivityLog;

public class UpdateActivityLogCommandRequestHandler:IRequestHandler<UpdateActivityLogCommandRequest,GeneralResponse<UpdateActivityLogCommandResponse>>
{
    private readonly IActivityLogRepository _repository;
    private readonly IMapper _mapper;

    public UpdateActivityLogCommandRequestHandler(IActivityLogRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GeneralResponse<UpdateActivityLogCommandResponse>> Handle(UpdateActivityLogCommandRequest request, CancellationToken cancellationToken)
    {
       
        var user = await _repository.GetByIdAsync(request.BaseID);
        if (user == null)
        {
            return new GeneralResponse<UpdateActivityLogCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }

          
        _mapper.Map(request, user);

        await _repository.UpdateAsync(user);

        return new GeneralResponse<UpdateActivityLogCommandResponse>
        {
            Data = new UpdateActivityLogCommandResponse
            {
                Message = "Log başarıyla güncellendi."
            },
            Errors = null,
            isSuccess = true
        };
       
    }
}