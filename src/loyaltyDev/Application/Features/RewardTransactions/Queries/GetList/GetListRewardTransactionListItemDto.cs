using Core.Application.Dtos;

namespace Application.Features.RewardTransactions.Queries.GetList;

public class GetListRewardTransactionListItemDto : IDto
{
    public int Id { get; set; }
    public int LoyaltyProgramSubscriptionId { get; set; }
    public bool IsReward { get; set; }
    public bool IsPoint { get; set; }
    public int PointSpentAmount { get; set; }
    public int ProductSpentAmount { get; set; }
}