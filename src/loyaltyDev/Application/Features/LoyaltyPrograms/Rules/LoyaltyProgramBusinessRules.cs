using Application.Features.LoyaltyPrograms.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.LoyaltyPrograms.Rules;

public class LoyaltyProgramBusinessRules : BaseBusinessRules
{
    private readonly ILoyaltyProgramRepository _loyaltyProgramRepository;

    public LoyaltyProgramBusinessRules(ILoyaltyProgramRepository loyaltyProgramRepository)
    {
        _loyaltyProgramRepository = loyaltyProgramRepository;
    }

    public Task LoyaltyProgramShouldExistWhenSelected(LoyaltyProgram? loyaltyProgram)
    {
        if (loyaltyProgram == null)
            throw new BusinessException(LoyaltyProgramsBusinessMessages.LoyaltyProgramNotExists);
        return Task.CompletedTask;
    }

    public async Task LoyaltyProgramIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        LoyaltyProgram? loyaltyProgram = await _loyaltyProgramRepository.GetAsync(
            predicate: lp => lp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LoyaltyProgramShouldExistWhenSelected(loyaltyProgram);
    }
}