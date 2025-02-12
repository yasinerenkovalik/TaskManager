using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using FluentValidation;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Commands.File.DeleteFile;

public class DeleteFileCommandRequestHandler:IRequestHandler<DeleteFileCommandRequest, GeneralResponse<DeleteFileCommandResponse>>
{
    private readonly IFileRepository _fileRepository;
    private readonly IValidator<DeleteFileCommandRequest> _validator;

    public DeleteFileCommandRequestHandler(IFileRepository fileRepository, IValidator<DeleteFileCommandRequest> validator)
    {
        _fileRepository = fileRepository;
        _validator = validator;
    }

    public async Task<GeneralResponse<DeleteFileCommandResponse>> Handle(DeleteFileCommandRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return new GeneralResponse<DeleteFileCommandResponse>()
            {
                Message = Convert.ToString(validationResult.Errors)
            };
        }
        var file = await _fileRepository.GetByIdAsync(request.Id);

        if (file == null)
        {
            return new GeneralResponse<DeleteFileCommandResponse>
            {
                Data = null,
                Errors = new List<string> { "Kullanıcı bulunamadı." },
                isSuccess = false
            };
        }

        await _fileRepository.DeleteAsync(file.BaseID);

        return new GeneralResponse<DeleteFileCommandResponse>
        {
            Data = new DeleteFileCommandResponse
            {
                UserId = file.BaseID,
            },
            Errors = null,
            isSuccess = true
        };
    }
}