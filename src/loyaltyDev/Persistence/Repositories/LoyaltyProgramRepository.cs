using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LoyaltyProgramRepository : EfRepositoryBase<LoyaltyProgram, int, BaseDbContext>, ILoyaltyProgramRepository
{
    public LoyaltyProgramRepository(BaseDbContext context) : base(context)
    {
    }
}