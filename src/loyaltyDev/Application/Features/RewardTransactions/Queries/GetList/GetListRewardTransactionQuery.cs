using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.RewardTransactions.Queries.GetList;

public class GetListRewardTransactionQuery : IRequest<GetListResponse<GetListRewardTransactionListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => $"GetListRewardTransactions({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetRewardTransactions";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListRewardTransactionQueryHandler : IRequestHandler<GetListRewardTransactionQuery, GetListResponse<GetListRewardTransactionListItemDto>>
    {
        private readonly IRewardTransactionRepository _rewardTransactionRepository;
        private readonly IMapper _mapper;

        public GetListRewardTransactionQueryHandler(IRewardTransactionRepository rewardTransactionRepository, IMapper mapper)
        {
            _rewardTransactionRepository = rewardTransactionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRewardTransactionListItemDto>> Handle(GetListRewardTransactionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<RewardTransaction> rewardTransactions = await _rewardTransactionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRewardTransactionListItemDto> response = _mapper.Map<GetListResponse<GetListRewardTransactionListItemDto>>(rewardTransactions);
            return response;
        }
    }
}