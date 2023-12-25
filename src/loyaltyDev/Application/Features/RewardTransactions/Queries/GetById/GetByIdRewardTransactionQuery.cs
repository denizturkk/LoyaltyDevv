using Application.Features.RewardTransactions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RewardTransactions.Queries.GetById;

public class GetByIdRewardTransactionQuery : IRequest<GetByIdRewardTransactionResponse>
{
    public int Id { get; set; }

    public class GetByIdRewardTransactionQueryHandler : IRequestHandler<GetByIdRewardTransactionQuery, GetByIdRewardTransactionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRewardTransactionRepository _rewardTransactionRepository;
        private readonly RewardTransactionBusinessRules _rewardTransactionBusinessRules;

        public GetByIdRewardTransactionQueryHandler(IMapper mapper, IRewardTransactionRepository rewardTransactionRepository, RewardTransactionBusinessRules rewardTransactionBusinessRules)
        {
            _mapper = mapper;
            _rewardTransactionRepository = rewardTransactionRepository;
            _rewardTransactionBusinessRules = rewardTransactionBusinessRules;
        }

        public async Task<GetByIdRewardTransactionResponse> Handle(GetByIdRewardTransactionQuery request, CancellationToken cancellationToken)
        {
            RewardTransaction? rewardTransaction = await _rewardTransactionRepository.GetAsync(predicate: rt => rt.Id == request.Id, cancellationToken: cancellationToken);
            await _rewardTransactionBusinessRules.RewardTransactionShouldExistWhenSelected(rewardTransaction);

            GetByIdRewardTransactionResponse response = _mapper.Map<GetByIdRewardTransactionResponse>(rewardTransaction);
            return response;
        }
    }
}