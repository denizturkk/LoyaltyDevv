using Application.Features.CorporateCustomers.Constants;
using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.CorporateCustomers.Commands.Delete;

public class DeleteCorporateCustomerCommand : IRequest<DeletedCorporateCustomerResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCorporateCustomers";

    public class DeleteCorporateCustomerCommandHandler : IRequestHandler<DeleteCorporateCustomerCommand, DeletedCorporateCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;

        public DeleteCorporateCustomerCommandHandler(IMapper mapper, ICorporateCustomerRepository corporateCustomerRepository,
                                         CorporateCustomerBusinessRules corporateCustomerBusinessRules)
        {
            _mapper = mapper;
            _corporateCustomerRepository = corporateCustomerRepository;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
        }

        public async Task<DeletedCorporateCustomerResponse> Handle(DeleteCorporateCustomerCommand request, CancellationToken cancellationToken)
        {
            CorporateCustomer? corporateCustomer = await _corporateCustomerRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _corporateCustomerBusinessRules.CorporateCustomerShouldExistWhenSelected(corporateCustomer);

            await _corporateCustomerRepository.DeleteAsync(corporateCustomer!);

            DeletedCorporateCustomerResponse response = _mapper.Map<DeletedCorporateCustomerResponse>(corporateCustomer);
            return response;
        }
    }
}