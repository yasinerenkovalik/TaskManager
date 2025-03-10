using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.File.GetAllFile;

public class GetAllFileQueryRequestHandler(IFileRepository fileRepository, IMapper mapper):IRequestHandler<GetAllFileQueryRequest, GeneralResponse<List<GetAllFileQueryResponse>>>
{
    private readonly IFileRepository _fileRepository = fileRepository;
    private readonly IMapper _mapper = mapper;
    
    public async Task<GeneralResponse<List<GetAllFileQueryResponse>>> Handle(GetAllFileQueryRequest request, CancellationToken cancellationToken)
    {
        var fileEntities = await _fileRepository.GetAllAysnc();

        if (fileEntities == null || !fileEntities.Any())
        {
            return new GeneralResponse<List<GetAllFileQueryResponse>>
            {
                Data = null,
                Errors = new List<string> { "FeedBack bulunamadı." },
                isSuccess = false
            };
        }
        var getAllFileQueryResponse = mapper.Map<List<GetAllFileQueryResponse>>(fileEntities);

        return new GeneralResponse<List<GetAllFileQueryResponse>>
        {
            Data = getAllFileQueryResponse,
            Errors = null,
            isSuccess = true
        };

    }
}