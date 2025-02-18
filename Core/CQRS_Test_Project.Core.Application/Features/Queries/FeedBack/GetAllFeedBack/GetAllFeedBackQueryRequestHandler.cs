using AutoMapper;
using CQRS_Test_Project.Core.Application.Interface.Repository;
using CQRS_Test_Project.Core.Application.Wrappers;
using MediatR;

namespace CQRS_Test_Project.Core.Application.Features.Queries.FeedBack.GetAllFeedBack;

public class GetAllFeedBackQueryRequestHandler(IFeedBackRepository feedBackRepository, IMapper mapper)
    : IRequestHandler<GetAllFeedBackQueryRequest, GeneralResponse<List<GetAllFeedBackQueryResponse>>>
{
    private readonly IFeedBackRepository _feedBackRepository = feedBackRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<GeneralResponse<List<GetAllFeedBackQueryResponse>>> Handle(GetAllFeedBackQueryRequest request, CancellationToken cancellationToken)
    {
        var feedBackEntities = await _feedBackRepository.GetAllAysnc();

        if (feedBackEntities == null || !feedBackEntities.Any())
        {
            return new GeneralResponse<List<GetAllFeedBackQueryResponse>>
            {
                Data = null,
                Errors = new List<string> { "FeedBack bulunamadı." },
                isSuccess = false
            };
        }

           
        var getAllFeedBackQueryResponse = mapper.Map<List<GetAllFeedBackQueryResponse>>(feedBackEntities);

        return new GeneralResponse<List<GetAllFeedBackQueryResponse>>
        {
            Data = getAllFeedBackQueryResponse,
            Errors = null,
            isSuccess = true
        };
    }
}