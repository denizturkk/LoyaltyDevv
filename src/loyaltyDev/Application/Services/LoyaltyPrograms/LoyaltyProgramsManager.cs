using Application.Features.LoyaltyPrograms.Rules;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LoyaltyPrograms;

public class LoyaltyProgramsManager : ILoyaltyProgramsService
{
    private readonly ILoyaltyProgramRepository _loyaltyProgramRepository;
    private readonly LoyaltyProgramBusinessRules _loyaltyProgramBusinessRules;

    public LoyaltyProgramsManager(ILoyaltyProgramRepository loyaltyProgramRepository, LoyaltyProgramBusinessRules loyaltyProgramBusinessRules)
    {
        _loyaltyProgramRepository = loyaltyProgramRepository;
        _loyaltyProgramBusinessRules = loyaltyProgramBusinessRules;
    }

    public async Task<LoyaltyProgram?> GetAsync(
        Expression<Func<LoyaltyProgram, bool>> predicate,
        Func<IQueryable<LoyaltyProgram>, IIncludableQueryable<LoyaltyProgram, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        LoyaltyProgram? loyaltyProgram = await _loyaltyProgramRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return loyaltyProgram;
    }

    public async Task<IPaginate<LoyaltyProgram>?> GetListAsync(
        Expression<Func<LoyaltyProgram, bool>>? predicate = null,
        Func<IQueryable<LoyaltyProgram>, IOrderedQueryable<LoyaltyProgram>>? orderBy = null,
        Func<IQueryable<LoyaltyProgram>, IIncludableQueryable<LoyaltyProgram, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<LoyaltyProgram> loyaltyProgramList = await _loyaltyProgramRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return loyaltyProgramList;
    }

    public async Task<LoyaltyProgram> AddAsync(LoyaltyProgram loyaltyProgram)
    {
        LoyaltyProgram addedLoyaltyProgram = await _loyaltyProgramRepository.AddAsync(loyaltyProgram);

        return addedLoyaltyProgram;
    }

    public async Task<LoyaltyProgram> UpdateAsync(LoyaltyProgram loyaltyProgram)
    {
        LoyaltyProgram updatedLoyaltyProgram = await _loyaltyProgramRepository.UpdateAsync(loyaltyProgram);

        return updatedLoyaltyProgram;
    }

    public async Task<LoyaltyProgram> DeleteAsync(LoyaltyProgram loyaltyProgram, bool permanent = false)
    {
        LoyaltyProgram deletedLoyaltyProgram = await _loyaltyProgramRepository.DeleteAsync(loyaltyProgram);

        return deletedLoyaltyProgram;
    }

    public async Task<LoyaltyProgram> GetLoyaltyProgramById(int loyaltyProgramId)
    {
           

        LoyaltyProgram loyaltyProgram = await _loyaltyProgramRepository.GetAsync(predicate: lp => lp.Id == loyaltyProgramId);

        if (loyaltyProgram == null)
            throw new BusinessException("Loyalty Program do not exists");

        return loyaltyProgram;
    }
}
