using Application.Features.LoyaltyProgramSubscriptions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.LoyaltyProgramSubscriptions.Commands.Create;

public class CreateLoyaltyProgramSubscriptionCommand : IRequest<CreatedLoyaltyProgramSubscriptionResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int IndividualCustomerId { get; set; }
    public int? LoyaltyProgramId { get; set; }
    public int? Points { get; set; }
    public int? ProductQuantity { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLoyaltyProgramSubscriptions";

    public class CreateLoyaltyProgramSubscriptionCommandHandler : IRequestHandler<CreateLoyaltyProgramSubscriptionCommand, CreatedLoyaltyProgramSubscriptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILoyaltyProgramSubscriptionRepository _loyaltyProgramSubscriptionRepository;
        private readonly LoyaltyProgramSubscriptionBusinessRules _loyaltyProgramSubscriptionBusinessRules;

        public CreateLoyaltyProgramSubscriptionCommandHandler(IMapper mapper, ILoyaltyProgramSubscriptionRepository loyaltyProgramSubscriptionRepository,
                                         LoyaltyProgramSubscriptionBusinessRules loyaltyProgramSubscriptionBusinessRules)
        {
            _mapper = mapper;
            _loyaltyProgramSubscriptionRepository = loyaltyProgramSubscriptionRepository;
            _loyaltyProgramSubscriptionBusinessRules = loyaltyProgramSubscriptionBusinessRules;
        }

        public async Task<CreatedLoyaltyProgramSubscriptionResponse> Handle(CreateLoyaltyProgramSubscriptionCommand request, CancellationToken cancellationToken)
        {
            LoyaltyProgramSubscription loyaltyProgramSubscription = _mapper.Map<LoyaltyProgramSubscription>(request);

            await _loyaltyProgramSubscriptionRepository.AddAsync(loyaltyProgramSubscription);

            CreatedLoyaltyProgramSubscriptionResponse response = _mapper.Map<CreatedLoyaltyProgramSubscriptionResponse>(loyaltyProgramSubscription);
            return response;
        }
    }
}