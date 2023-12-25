using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILoyaltyProgramSubscriptionRepository : IAsyncRepository<LoyaltyProgramSubscription, int>, IRepository<LoyaltyProgramSubscription, int>
{
}