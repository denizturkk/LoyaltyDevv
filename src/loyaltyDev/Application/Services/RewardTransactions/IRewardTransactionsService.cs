using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RewardTransactions;

public interface IRewardTransactionsService
{
    Task<RewardTransaction?> GetAsync(
        Expression<Func<RewardTransaction, bool>> predicate,
        Func<IQueryable<RewardTransaction>, IIncludableQueryable<RewardTransaction, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<RewardTransaction>?> GetListAsync(
        Expression<Func<RewardTransaction, bool>>? predicate = null,
        Func<IQueryable<RewardTransaction>, IOrderedQueryable<RewardTransaction>>? orderBy = null,
        Func<IQueryable<RewardTransaction>, IIncludableQueryable<RewardTransaction, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RewardTransaction> AddAsync(RewardTransaction rewardTransaction);
    Task<RewardTransaction> UpdateAsync(RewardTransaction rewardTransaction);
    Task<RewardTransaction> DeleteAsync(RewardTransaction rewardTransaction, bool permanent = false);
}
