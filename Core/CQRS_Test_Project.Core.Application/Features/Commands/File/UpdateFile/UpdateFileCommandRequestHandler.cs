using AutoMapper;
using CQRS_Test_Project.Core.Application.Features.Commands.File.DeleteFile;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.File.UpdateFile;

public class UpdateFileCommandRequestHandler : IRequestHandler<UpdateFileCommandRequest, GeneralResponse<UpdateFileCommandResponse>>
{
    private readonly IFileRepository _fileRepository;
    private readonly IValidator<UpdateFileCommandRequest> _validator;
    private readonly IMapper _mapper;

    public UpdateFileCommandRequestHandler(IFileRepository fileRepository, IValidator<UpdateFileCommandRequest> validator, IMapper mapper)
    {
        _fileRepository = fileRepository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<GeneralResponse<UpdateFileCommandResponse>> Handle(UpdateFileCommandRequest request, CancellationToken cancellationToken)
    {
        
      
        var user = await _fileRepository.GetByIdAsync(request.Id);
        if (user is null)
        {
            return new GeneralResponse<UpdateFileCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }
            
        _mapper.Map(request, user);
        await _fileRepository.UpdateAsync(user);

        return new GeneralResponse<UpdateFileCommandResponse>
        {
            Data = new UpdateFileCommandResponse
            {
                Message = "Kullanıcı başarıyla güncellendi."
            },
            Errors = null,
            isSuccess = true
        };
    }
}