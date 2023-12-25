using Core.Application.Responses;

namespace Application.Features.LoyaltyProgramSubscriptions.Queries.GetById;

public class GetByIdLoyaltyProgramSubscriptionResponse : IResponse
{
    public int Id { get; set; }
    public int IndividualCustomerId { get; set; }
    public int? LoyaltyProgramId { get; set; }
    public int? Points { get; set; }
    public int? ProductQuantity { get; set; }
}