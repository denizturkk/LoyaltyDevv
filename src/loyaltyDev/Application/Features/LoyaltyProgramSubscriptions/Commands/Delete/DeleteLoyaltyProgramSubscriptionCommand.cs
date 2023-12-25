using Application.Features.LoyaltyProgramSubscriptions.Constants;
using Application.Features.LoyaltyProgramSubscriptions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.LoyaltyProgramSubscriptions.Commands.Delete;

public class DeleteLoyaltyProgramSubscriptionCommand : IRequest<DeletedLoyaltyProgramSubscriptionResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLoyaltyProgramSubscriptions";

    public class DeleteLoyaltyProgramSubscriptionCommandHandler : IRequestHandler<DeleteLoyaltyProgramSubscriptionCommand, DeletedLoyaltyProgramSubscriptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILoyaltyProgramSubscriptionRepository _loyaltyProgramSubscriptionRepository;
        private readonly LoyaltyProgramSubscriptionBusinessRules _loyaltyProgramSubscriptionBusinessRules;

        public DeleteLoyaltyProgramSubscriptionCommandHandler(IMapper mapper, ILoyaltyProgramSubscriptionRepository loyaltyProgramSubscriptionRepository,
                                         LoyaltyProgramSubscriptionBusinessRules loyaltyProgramSubscriptionBusinessRules)
        {
            _mapper = mapper;
            _loyaltyProgramSubscriptionRepository = loyaltyProgramSubscriptionRepository;
            _loyaltyProgramSubscriptionBusinessRules = loyaltyProgramSubscriptionBusinessRules;
        }

        public async Task<DeletedLoyaltyProgramSubscriptionResponse> Handle(DeleteLoyaltyProgramSubscriptionCommand request, CancellationToken cancellationToken)
        {
            LoyaltyProgramSubscription? loyaltyProgramSubscription = await _loyaltyProgramSubscriptionRepository.GetAsync(predicate: lps => lps.Id == request.Id, cancellationToken: cancellationToken);
            await _loyaltyProgramSubscriptionBusinessRules.LoyaltyProgramSubscriptionShouldExistWhenSelected(loyaltyProgramSubscription);

            await _loyaltyProgramSubscriptionRepository.DeleteAsync(loyaltyProgramSubscription!);

            DeletedLoyaltyProgramSubscriptionResponse response = _mapper.Map<DeletedLoyaltyProgramSubscriptionResponse>(loyaltyProgramSubscription);
            return response;
        }
    }
}