using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RewardTransactionRepository : EfRepositoryBase<RewardTransaction, int, BaseDbContext>, IRewardTransactionRepository
{
    public RewardTransactionRepository(BaseDbContext context) : base(context)
    {
    }
}