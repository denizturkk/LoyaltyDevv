using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LoyaltyProgramSubscriptionRepository : EfRepositoryBase<LoyaltyProgramSubscription, int, BaseDbContext>, ILoyaltyProgramSubscriptionRepository
{
    public LoyaltyProgramSubscriptionRepository(BaseDbContext context) : base(context)
    {
    }
}