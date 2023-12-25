using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILoyaltyProgramRepository : IAsyncRepository<LoyaltyProgram, int>, IRepository<LoyaltyProgram, int>
{
}