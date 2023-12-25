using Application.Features.IndividualCustomers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.IndividualCustomers.Rules;

public class IndividualCustomerBusinessRules : BaseBusinessRules
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;

    public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository)
    {
        _individualCustomerRepository = individualCustomerRepository;
    }

    public Task IndividualCustomerShouldExistWhenSelected(IndividualCustomer? individualCustomer)
    {
        if (individualCustomer == null)
            throw new BusinessException(IndividualCustomersBusinessMessages.IndividualCustomerNotExists);
        return Task.CompletedTask;
    }

    public async Task IndividualCustomerIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        IndividualCustomer? individualCustomer = await _individualCustomerRepository.GetAsync(
            predicate: ic => ic.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await IndividualCustomerShouldExistWhenSelected(individualCustomer);
    }
}