using Application.Features.LoyaltyProgramSubscriptions.Rules;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LoyaltyProgramSubscriptions;

public class LoyaltyProgramSubscriptionsManager : ILoyaltyProgramSubscriptionsService
{
    private readonly ILoyaltyProgramSubscriptionRepository _loyaltyProgramSubscriptionRepository;
    private readonly LoyaltyProgramSubscriptionBusinessRules _loyaltyProgramSubscriptionBusinessRules;

    public LoyaltyProgramSubscriptionsManager(ILoyaltyProgramSubscriptionRepository loyaltyProgramSubscriptionRepository, LoyaltyProgramSubscriptionBusinessRules loyaltyProgramSubscriptionBusinessRules)
    {
        _loyaltyProgramSubscriptionRepository = loyaltyProgramSubscriptionRepository;
        _loyaltyProgramSubscriptionBusinessRules = loyaltyProgramSubscriptionBusinessRules;
    }

    public async Task<LoyaltyProgramSubscription?> GetAsync(
        Expression<Func<LoyaltyProgramSubscription, bool>> predicate,
        Func<IQueryable<LoyaltyProgramSubscription>, IIncludableQueryable<LoyaltyProgramSubscription, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        LoyaltyProgramSubscription? loyaltyProgramSubscription = await _loyaltyProgramSubscriptionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return loyaltyProgramSubscription;
    }

    public async Task<IPaginate<LoyaltyProgramSubscription>?> GetListAsync(
        Expression<Func<LoyaltyProgramSubscription, bool>>? predicate = null,
        Func<IQueryable<LoyaltyProgramSubscription>, IOrderedQueryable<LoyaltyProgramSubscription>>? orderBy = null,
        Func<IQueryable<LoyaltyProgramSubscription>, IIncludableQueryable<LoyaltyProgramSubscription, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<LoyaltyProgramSubscription> loyaltyProgramSubscriptionList = await _loyaltyProgramSubscriptionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return loyaltyProgramSubscriptionList;
    }

    public async Task<LoyaltyProgramSubscription> AddAsync(LoyaltyProgramSubscription loyaltyProgramSubscription)
    {
        LoyaltyProgramSubscription addedLoyaltyProgramSubscription = await _loyaltyProgramSubscriptionRepository.AddAsync(loyaltyProgramSubscription);

        return addedLoyaltyProgramSubscription;
    }

    public async Task<LoyaltyProgramSubscription> UpdateAsync(LoyaltyProgramSubscription loyaltyProgramSubscription)
    {
        LoyaltyProgramSubscription updatedLoyaltyProgramSubscription = await _loyaltyProgramSubscriptionRepository.UpdateAsync(loyaltyProgramSubscription);

        return updatedLoyaltyProgramSubscription;
    }

    public async Task<LoyaltyProgramSubscription> DeleteAsync(LoyaltyProgramSubscription loyaltyProgramSubscription, bool permanent = false)
    {
        LoyaltyProgramSubscription deletedLoyaltyProgramSubscription = await _loyaltyProgramSubscriptionRepository.DeleteAsync(loyaltyProgramSubscription);

        return deletedLoyaltyProgramSubscription;
    }



    public async Task<LoyaltyProgramSubscription> GetLoyaltyProgramSubscriptionById(int id)
    {


        LoyaltyProgramSubscription loyaltyProgramSubscription = await _loyaltyProgramSubscriptionRepository.GetAsync(predicate: lps => lps.Id == id);

        if (loyaltyProgramSubscription == null)
            throw new BusinessException("Loyalty Program Subscription do not exists");

        return loyaltyProgramSubscription;
    }


}