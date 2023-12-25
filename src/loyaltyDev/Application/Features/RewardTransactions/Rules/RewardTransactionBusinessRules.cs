using Application.Features.RewardTransactions.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.RewardTransactions.Rules;

public class RewardTransactionBusinessRules : BaseBusinessRules
{
    private readonly IRewardTransactionRepository _rewardTransactionRepository;

    public RewardTransactionBusinessRules(IRewardTransactionRepository rewardTransactionRepository)
    {
        _rewardTransactionRepository = rewardTransactionRepository;
    }

    public Task RewardTransactionShouldExistWhenSelected(RewardTransaction? rewardTransaction)
    {
        if (rewardTransaction == null)
            throw new BusinessException(RewardTransactionsBusinessMessages.RewardTransactionNotExists);
        return Task.CompletedTask;
    }

    public async Task RewardTransactionIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        RewardTransaction? rewardTransaction = await _rewardTransactionRepository.GetAsync(
            predicate: rt => rt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RewardTransactionShouldExistWhenSelected(rewardTransaction);
    }
}