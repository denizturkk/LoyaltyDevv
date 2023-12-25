using Application.Features.RewardTransactions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.RewardTransactions.Commands.Update;

public class UpdateRewardTransactionCommand : IRequest<UpdatedRewardTransactionResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }
    public int LoyaltyProgramSubscriptionId { get; set; }
    public bool IsReward { get; set; }
    public bool IsPoint { get; set; }
    public int PointSpentAmount { get; set; }
    public int ProductSpentAmount { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRewardTransactions";

    public class UpdateRewardTransactionCommandHandler : IRequestHandler<UpdateRewardTransactionCommand, UpdatedRewardTransactionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRewardTransactionRepository _rewardTransactionRepository;
        private readonly RewardTransactionBusinessRules _rewardTransactionBusinessRules;

        public UpdateRewardTransactionCommandHandler(IMapper mapper, IRewardTransactionRepository rewardTransactionRepository,
                                         RewardTransactionBusinessRules rewardTransactionBusinessRules)
        {
            _mapper = mapper;
            _rewardTransactionRepository = rewardTransactionRepository;
            _rewardTransactionBusinessRules = rewardTransactionBusinessRules;
        }

        public async Task<UpdatedRewardTransactionResponse> Handle(UpdateRewardTransactionCommand request, CancellationToken cancellationToken)
        {
            RewardTransaction? rewardTransaction = await _rewardTransactionRepository.GetAsync(predicate: rt => rt.Id == request.Id, cancellationToken: cancellationToken);
            await _rewardTransactionBusinessRules.RewardTransactionShouldExistWhenSelected(rewardTransaction);
            rewardTransaction = _mapper.Map(request, rewardTransaction);

            await _rewardTransactionRepository.UpdateAsync(rewardTransaction!);

            UpdatedRewardTransactionResponse response = _mapper.Map<UpdatedRewardTransactionResponse>(rewardTransaction);
            return response;
        }
    }
}