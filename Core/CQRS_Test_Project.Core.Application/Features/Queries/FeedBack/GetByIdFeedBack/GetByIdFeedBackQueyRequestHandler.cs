using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.FeedBack.GetByIdFeedBack;

public class GetByIdFeedBackQueyRequestHandler(IFeedBackRepository feedBackRepository, IMapper mapper)
    : IRequestHandler<GetByIdFeedBackQueyRequest, GeneralResponse<GetByIdFeedBackQueyResponse>>
{
    private readonly IFeedBackRepository _feedBackRepository = feedBackRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<GeneralResponse<GetByIdFeedBackQueyResponse>> Handle(GetByIdFeedBackQueyRequest request, CancellationToken cancellationToken)
    {
        // Repository'den kullanıcıyı getir
        var feedBackEntity = await _feedBackRepository.GetByIdAsync(request.Id);

        if (feedBackEntity == null)
        {
            return new GeneralResponse<GetByIdFeedBackQueyResponse>
            {
                Data = null,
                Errors = new List<string> { "FeedBack bulunamadı." },
                isSuccess = false
            };
        }

        // AutoMapper ile kullanıcı verisini response modeline map et
        var getByIdFeedBackQueryResponse = _mapper.Map<GetByIdFeedBackQueyResponse>(feedBackEntity);

        return new GeneralResponse<GetByIdFeedBackQueyResponse>
        {
            Data = getByIdFeedBackQueryResponse,
            Errors = null,
            isSuccess = true
        };
    }
    
}