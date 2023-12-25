using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRewardTransactionRepository : IAsyncRepository<RewardTransaction, int>, IRepository<RewardTransaction, int>
{
}