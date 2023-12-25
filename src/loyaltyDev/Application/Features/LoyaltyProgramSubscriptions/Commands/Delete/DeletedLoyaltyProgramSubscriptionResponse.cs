using Core.Application.Responses;

namespace Application.Features.LoyaltyProgramSubscriptions.Commands.Delete;

public class DeletedLoyaltyProgramSubscriptionResponse : IResponse
{
    public int Id { get; set; }
}