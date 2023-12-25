using Application.Features.RewardTransactions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using Application.Features.LoyaltyProgramSubscriptions.Queries.GetById;
using SharpCompress.Readers;
using Application.Services.LoyaltyPrograms;
using Application.Services.LoyaltyProgramSubscriptions;
using System.Drawing.Printing;

namespace Application.Features.RewardTransactions.Commands.Create;

public class CreateRewardTransactionCommand : IRequest<CreatedRewardTransactionResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int LoyaltyProgramSubscriptionId { get; set; }
    public bool IsReward { get; set; }
    public bool IsPoint { get; set; }
    public int PointSpentAmount { get; set; }
    public int ProductSpentAmount { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRewardTransactions";

    public class CreateRewardTransactionCommandHandler : IRequestHandler<CreateRewardTransactionCommand, CreatedRewardTransactionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRewardTransactionRepository _rewardTransactionRepository;
        private readonly RewardTransactionBusinessRules _rewardTransactionBusinessRules;
        // private readonly GetByIdLoyaltyProgramSubscriptionQuery _getByIdLoyaltyProgramSubscriptionQuery;
        private readonly ILoyaltyProgramsService _loyaltyProgramService;
        private readonly ILoyaltyProgramSubscriptionsService _loyaltyProgramSubscriptionService;

        public CreateRewardTransactionCommandHandler
            (IMapper mapper, 
            IRewardTransactionRepository rewardTransactionRepository,
            RewardTransactionBusinessRules rewardTransactionBusinessRules,
            ILoyaltyProgramsService loyaltyProgramsService,
            ILoyaltyProgramSubscriptionsService loyaltyProgramSubscriptionsService
            
            )
        {
            _mapper = mapper;
            _rewardTransactionRepository = rewardTransactionRepository;
            _rewardTransactionBusinessRules = rewardTransactionBusinessRules;
            _loyaltyProgramService = loyaltyProgramsService;
            _loyaltyProgramSubscriptionService = loyaltyProgramSubscriptionsService;
        }

        public async Task<CreatedRewardTransactionResponse> Handle(CreateRewardTransactionCommand request, CancellationToken cancellationToken)
        {


            Task<LoyaltyProgramSubscription> loyaltyProgramSubscription = _loyaltyProgramSubscriptionService.GetLoyaltyProgramSubscriptionById(request.LoyaltyProgramSubscriptionId);

            Task<LoyaltyProgram> loyaltyProgram = _loyaltyProgramService.GetLoyaltyProgramById(loyaltyProgramSubscription.Result.LoyaltyProgramId);

            LoyaltyProgramSubscription loyaltyProgramSubscriptionUpdate = loyaltyProgramSubscription.Result;


            if (request.IsPoint==true &&request.IsReward==true)
            {

                loyaltyProgramSubscriptionUpdate.Points -= request.PointSpentAmount;
                await   _loyaltyProgramSubscriptionService.UpdateAsync(loyaltyProgramSubscriptionUpdate);
                

            }
            else if( request.IsPoint==true && request.IsReward==false)
            {
                loyaltyProgramSubscriptionUpdate.Points += request.PointSpentAmount / loyaltyProgram.Result.PointExchangeRate;
               await _loyaltyProgramSubscriptionService.UpdateAsync(loyaltyProgramSubscriptionUpdate);

            }
            else if (request.IsPoint==false && request.IsReward==true)
            {
                loyaltyProgramSubscriptionUpdate.ProductQuantity = 0;
                await _loyaltyProgramSubscriptionService.UpdateAsync(loyaltyProgramSubscriptionUpdate);

            }
            else if (request.IsPoint==false && request.IsReward==false)
            {
                loyaltyProgramSubscriptionUpdate.ProductQuantity += request.ProductSpentAmount;
                await _loyaltyProgramSubscriptionService.UpdateAsync(loyaltyProgramSubscriptionUpdate);

            }


            RewardTransaction rewardTransaction = _mapper.Map<RewardTransaction>(request);

            await _rewardTransactionRepository.AddAsync(rewardTransaction);

            CreatedRewardTransactionResponse response = _mapper.Map<CreatedRewardTransactionResponse>(rewardTransaction);
            return response;
        }
    }
}