using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.LoyaltyProgramSubscriptions.Queries.GetList;

public class GetListLoyaltyProgramSubscriptionQuery : IRequest<GetListResponse<GetListLoyaltyProgramSubscriptionListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => $"GetListLoyaltyProgramSubscriptions({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetLoyaltyProgramSubscriptions";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListLoyaltyProgramSubscriptionQueryHandler : IRequestHandler<GetListLoyaltyProgramSubscriptionQuery, GetListResponse<GetListLoyaltyProgramSubscriptionListItemDto>>
    {
        private readonly ILoyaltyProgramSubscriptionRepository _loyaltyProgramSubscriptionRepository;
        private readonly IMapper _mapper;

        public GetListLoyaltyProgramSubscriptionQueryHandler(ILoyaltyProgramSubscriptionRepository loyaltyProgramSubscriptionRepository, IMapper mapper)
        {
            _loyaltyProgramSubscriptionRepository = loyaltyProgramSubscriptionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLoyaltyProgramSubscriptionListItemDto>> Handle(GetListLoyaltyProgramSubscriptionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LoyaltyProgramSubscription> loyaltyProgramSubscriptions = await _loyaltyProgramSubscriptionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLoyaltyProgramSubscriptionListItemDto> response = _mapper.Map<GetListResponse<GetListLoyaltyProgramSubscriptionListItemDto>>(loyaltyProgramSubscriptions);
            return response;
        }
    }
}