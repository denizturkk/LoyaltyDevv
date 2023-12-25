using Application.Features.CorporateCustomers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CorporateCustomers.Rules;

public class CorporateCustomerBusinessRules : BaseBusinessRules
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;

    public CorporateCustomerBusinessRules(ICorporateCustomerRepository corporateCustomerRepository)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
    }

    public Task CorporateCustomerShouldExistWhenSelected(CorporateCustomer? corporateCustomer)
    {
        if (corporateCustomer == null)
            throw new BusinessException(CorporateCustomersBusinessMessages.CorporateCustomerNotExists);
        return Task.CompletedTask;
    }

    public async Task CorporateCustomerIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CorporateCustomer? corporateCustomer = await _corporateCustomerRepository.GetAsync(
            predicate: cc => cc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CorporateCustomerShouldExistWhenSelected(corporateCustomer);
    }
}