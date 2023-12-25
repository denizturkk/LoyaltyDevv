using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LoyaltyProgramSubscriptions;

public interface ILoyaltyProgramSubscriptionsService
{
    Task<LoyaltyProgramSubscription?> GetAsync(
        Expression<Func<LoyaltyProgramSubscription, bool>> predicate,
        Func<IQueryable<LoyaltyProgramSubscription>, IIncludableQueryable<LoyaltyProgramSubscription, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<LoyaltyProgramSubscription>?> GetListAsync(
        Expression<Func<LoyaltyProgramSubscription, bool>>? predicate = null,
        Func<IQueryable<LoyaltyProgramSubscription>, IOrderedQueryable<LoyaltyProgramSubscription>>? orderBy = null,
        Func<IQueryable<LoyaltyProgramSubscription>, IIncludableQueryable<LoyaltyProgramSubscription, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<LoyaltyProgramSubscription> AddAsync(LoyaltyProgramSubscription loyaltyProgramSubscription);
    Task<LoyaltyProgramSubscription> UpdateAsync(LoyaltyProgramSubscription loyaltyProgramSubscription);
    Task<LoyaltyProgramSubscription> DeleteAsync(LoyaltyProgramSubscription loyaltyProgramSubscription, bool permanent = false);

    Task<LoyaltyProgramSubscription> GetLoyaltyProgramSubscriptionById(int id);
}
