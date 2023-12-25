using Application.Features.RewardTransactions.Constants;
using Application.Features.RewardTransactions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.RewardTransactions.Commands.Delete;

public class DeleteRewardTransactionCommand : IRequest<DeletedRewardTransactionResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRewardTransactions";

    public class DeleteRewardTransactionCommandHandler : IRequestHandler<DeleteRewardTransactionCommand, DeletedRewardTransactionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRewardTransactionRepository _rewardTransactionRepository;
        private readonly RewardTransactionBusinessRules _rewardTransactionBusinessRules;

        public DeleteRewardTransactionCommandHandler(IMapper mapper, IRewardTransactionRepository rewardTransactionRepository,
                                         RewardTransactionBusinessRules rewardTransactionBusinessRules)
        {
            _mapper = mapper;
            _rewardTransactionRepository = rewardTransactionRepository;
            _rewardTransactionBusinessRules = rewardTransactionBusinessRules;
        }

        public async Task<DeletedRewardTransactionResponse> Handle(DeleteRewardTransactionCommand request, CancellationToken cancellationToken)
        {
            RewardTransaction? rewardTransaction = await _rewardTransactionRepository.GetAsync(predicate: rt => rt.Id == request.Id, cancellationToken: cancellationToken);
            await _rewardTransactionBusinessRules.RewardTransactionShouldExistWhenSelected(rewardTransaction);

            await _rewardTransactionRepository.DeleteAsync(rewardTransaction!);

            DeletedRewardTransactionResponse response = _mapper.Map<DeletedRewardTransactionResponse>(rewardTransaction);
            return response;
        }
    }
}