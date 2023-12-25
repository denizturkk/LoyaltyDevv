using Application.Features.RewardTransactions.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RewardTransactions;

public class RewardTransactionsManager : IRewardTransactionsService
{
    private readonly IRewardTransactionRepository _rewardTransactionRepository;
    private readonly RewardTransactionBusinessRules _rewardTransactionBusinessRules;

    public RewardTransactionsManager(IRewardTransactionRepository rewardTransactionRepository, RewardTransactionBusinessRules rewardTransactionBusinessRules)
    {
        _rewardTransactionRepository = rewardTransactionRepository;
        _rewardTransactionBusinessRules = rewardTransactionBusinessRules;
    }

    public async Task<RewardTransaction?> GetAsync(
        Expression<Func<RewardTransaction, bool>> predicate,
        Func<IQueryable<RewardTransaction>, IIncludableQueryable<RewardTransaction, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RewardTransaction? rewardTransaction = await _rewardTransactionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return rewardTransaction;
    }

    public async Task<IPaginate<RewardTransaction>?> GetListAsync(
        Expression<Func<RewardTransaction, bool>>? predicate = null,
        Func<IQueryable<RewardTransaction>, IOrderedQueryable<RewardTransaction>>? orderBy = null,
        Func<IQueryable<RewardTransaction>, IIncludableQueryable<RewardTransaction, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<RewardTransaction> rewardTransactionList = await _rewardTransactionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return rewardTransactionList;
    }

    public async Task<RewardTransaction> AddAsync(RewardTransaction rewardTransaction)
    {

        RewardTransaction addedRewardTransaction = await _rewardTransactionRepository.AddAsync(rewardTransaction);

        return addedRewardTransaction;
    }

    public async Task<RewardTransaction> UpdateAsync(RewardTransaction rewardTransaction)
    {
        RewardTransaction updatedRewardTransaction = await _rewardTransactionRepository.UpdateAsync(rewardTransaction);

        return updatedRewardTransaction;
    }

    public async Task<RewardTransaction> DeleteAsync(RewardTransaction rewardTransaction, bool permanent = false)
    {
        RewardTransaction deletedRewardTransaction = await _rewardTransactionRepository.DeleteAsync(rewardTransaction);

        return deletedRewardTransaction;
    }
}
