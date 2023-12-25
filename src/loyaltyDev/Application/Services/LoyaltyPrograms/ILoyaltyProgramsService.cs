using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LoyaltyPrograms;

public interface ILoyaltyProgramsService
{
    Task<LoyaltyProgram?> GetAsync(
        Expression<Func<LoyaltyProgram, bool>> predicate,
        Func<IQueryable<LoyaltyProgram>, IIncludableQueryable<LoyaltyProgram, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<LoyaltyProgram>?> GetListAsync(
        Expression<Func<LoyaltyProgram, bool>>? predicate = null,
        Func<IQueryable<LoyaltyProgram>, IOrderedQueryable<LoyaltyProgram>>? orderBy = null,
        Func<IQueryable<LoyaltyProgram>, IIncludableQueryable<LoyaltyProgram, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<LoyaltyProgram> AddAsync(LoyaltyProgram loyaltyProgram);
    Task<LoyaltyProgram> UpdateAsync(LoyaltyProgram loyaltyProgram);
    Task<LoyaltyProgram> DeleteAsync(LoyaltyProgram loyaltyProgram, bool permanent = false);

    Task<LoyaltyProgram> GetLoyaltyProgramById(int loyaltyProgramId );
}
