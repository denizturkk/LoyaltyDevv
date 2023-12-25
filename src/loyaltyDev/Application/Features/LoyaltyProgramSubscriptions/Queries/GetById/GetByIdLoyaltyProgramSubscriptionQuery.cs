using Application.Features.LoyaltyProgramSubscriptions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LoyaltyProgramSubscriptions.Queries.GetById;

public class GetByIdLoyaltyProgramSubscriptionQuery : IRequest<GetByIdLoyaltyProgramSubscriptionResponse>
{
    public int Id { get; set; }

    public class GetByIdLoyaltyProgramSubscriptionQueryHandler : IRequestHandler<GetByIdLoyaltyProgramSubscriptionQuery, GetByIdLoyaltyProgramSubscriptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILoyaltyProgramSubscriptionRepository _loyaltyProgramSubscriptionRepository;
        private readonly LoyaltyProgramSubscriptionBusinessRules _loyaltyProgramSubscriptionBusinessRules;

        public GetByIdLoyaltyProgramSubscriptionQueryHandler(IMapper mapper, ILoyaltyProgramSubscriptionRepository loyaltyProgramSubscriptionRepository, LoyaltyProgramSubscriptionBusinessRules loyaltyProgramSubscriptionBusinessRules)
        {
            _mapper = mapper;
            _loyaltyProgramSubscriptionRepository = loyaltyProgramSubscriptionRepository;
            _loyaltyProgramSubscriptionBusinessRules = loyaltyProgramSubscriptionBusinessRules;
        }

        public async Task<GetByIdLoyaltyProgramSubscriptionResponse> Handle(GetByIdLoyaltyProgramSubscriptionQuery request, CancellationToken cancellationToken)
        {
            LoyaltyProgramSubscription? loyaltyProgramSubscription = await _loyaltyProgramSubscriptionRepository.GetAsync(predicate: lps => lps.Id == request.Id, cancellationToken: cancellationToken);
            await _loyaltyProgramSubscriptionBusinessRules.LoyaltyProgramSubscriptionShouldExistWhenSelected(loyaltyProgramSubscription);

            GetByIdLoyaltyProgramSubscriptionResponse response = _mapper.Map<GetByIdLoyaltyProgramSubscriptionResponse>(loyaltyProgramSubscription);
            return response;
        }
    }
}