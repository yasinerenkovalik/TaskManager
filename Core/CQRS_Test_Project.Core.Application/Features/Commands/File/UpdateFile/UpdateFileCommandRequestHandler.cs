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
        
      
        return new GeneralResponse<UpdateFileCommandResponse>
        {
            Data = null,
            Message =  "Kullanıcı bulunamadı." ,
            isSuccess = false
        };
    }
}