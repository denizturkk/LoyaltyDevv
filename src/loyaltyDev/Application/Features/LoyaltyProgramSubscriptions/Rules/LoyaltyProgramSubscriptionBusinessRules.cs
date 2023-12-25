using Application.Features.LoyaltyProgramSubscriptions.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.LoyaltyProgramSubscriptions.Rules;

public class LoyaltyProgramSubscriptionBusinessRules : BaseBusinessRules
{
    private readonly ILoyaltyProgramSubscriptionRepository _loyaltyProgramSubscriptionRepository;

    public LoyaltyProgramSubscriptionBusinessRules(ILoyaltyProgramSubscriptionRepository loyaltyProgramSubscriptionRepository)
    {
        _loyaltyProgramSubscriptionRepository = loyaltyProgramSubscriptionRepository;
    }

    public Task LoyaltyProgramSubscriptionShouldExistWhenSelected(LoyaltyProgramSubscription? loyaltyProgramSubscription)
    {
        if (loyaltyProgramSubscription == null)
            throw new BusinessException(LoyaltyProgramSubscriptionsBusinessMessages.LoyaltyProgramSubscriptionNotExists);
        return Task.CompletedTask;
    }

    public async Task LoyaltyProgramSubscriptionIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        LoyaltyProgramSubscription? loyaltyProgramSubscription = await _loyaltyProgramSubscriptionRepository.GetAsync(
            predicate: lps => lps.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LoyaltyProgramSubscriptionShouldExistWhenSelected(loyaltyProgramSubscription);
    }
}