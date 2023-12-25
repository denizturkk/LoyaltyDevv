using Core.Application.Responses;

namespace Application.Features.RewardTransactions.Commands.Create;

public class CreatedRewardTransactionResponse : IResponse
{
    public int Id { get; set; }
    public int LoyaltyProgramSubscriptionId { get; set; }
    public bool IsReward { get; set; }
    public bool IsPoint { get; set; }
    public int PointSpentAmount { get; set; }
    public int ProductSpentAmount { get; set; }
}