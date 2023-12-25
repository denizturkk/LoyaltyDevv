using Core.Application.Responses;

namespace Application.Features.RewardTransactions.Commands.Delete;

public class DeletedRewardTransactionResponse : IResponse
{
    public int Id { get; set; }
}