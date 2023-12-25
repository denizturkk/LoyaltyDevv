using Core.Application.Dtos;

namespace Application.Features.LoyaltyProgramSubscriptions.Queries.GetList;

public class GetListLoyaltyProgramSubscriptionListItemDto : IDto
{
    public int Id { get; set; }
    public int IndividualCustomerId { get; set; }
    public int? LoyaltyProgramId { get; set; }
    public int? Points { get; set; }
    public int? ProductQuantity { get; set; }
}