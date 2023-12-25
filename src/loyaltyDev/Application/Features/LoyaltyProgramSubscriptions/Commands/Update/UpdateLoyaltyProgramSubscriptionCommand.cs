using Application.Features.LoyaltyProgramSubscriptions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.LoyaltyProgramSubscriptions.Commands.Update;

public class UpdateLoyaltyProgramSubscriptionCommand : IRequest<UpdatedLoyaltyProgramSubscriptionResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }
    public int IndividualCustomerId { get; set; }
    public int? LoyaltyProgramId { get; set; }
    public int? Points { get; set; }
    public int? ProductQuantity { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLoyaltyProgramSubscriptions";

    public class UpdateLoyaltyProgramSubscriptionCommandHandler : IRequestHandler<UpdateLoyaltyProgramSubscriptionCommand, UpdatedLoyaltyProgramSubscriptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILoyaltyProgramSubscriptionRepository _loyaltyProgramSubscriptionRepository;
        private readonly LoyaltyProgramSubscriptionBusinessRules _loyaltyProgramSubscriptionBusinessRules;

        public UpdateLoyaltyProgramSubscriptionCommandHandler(IMapper mapper, ILoyaltyProgramSubscriptionRepository loyaltyProgramSubscriptionRepository,
                                         LoyaltyProgramSubscriptionBusinessRules loyaltyProgramSubscriptionBusinessRules)
        {
            _mapper = mapper;
            _loyaltyProgramSubscriptionRepository = loyaltyProgramSubscriptionRepository;
            _loyaltyProgramSubscriptionBusinessRules = loyaltyProgramSubscriptionBusinessRules;
        }

        public async Task<UpdatedLoyaltyProgramSubscriptionResponse> Handle(UpdateLoyaltyProgramSubscriptionCommand request, CancellationToken cancellationToken)
        {
            LoyaltyProgramSubscription? loyaltyProgramSubscription = await _loyaltyProgramSubscriptionRepository.GetAsync(predicate: lps => lps.Id == request.Id, cancellationToken: cancellationToken);
            await _loyaltyProgramSubscriptionBusinessRules.LoyaltyProgramSubscriptionShouldExistWhenSelected(loyaltyProgramSubscription);
            loyaltyProgramSubscription = _mapper.Map(request, loyaltyProgramSubscription);

            await _loyaltyProgramSubscriptionRepository.UpdateAsync(loyaltyProgramSubscription!);

            UpdatedLoyaltyProgramSubscriptionResponse response = _mapper.Map<UpdatedLoyaltyProgramSubscriptionResponse>(loyaltyProgramSubscription);
            return response;
        }
    }
}