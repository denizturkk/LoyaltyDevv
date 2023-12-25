using Core.Application.Responses;

namespace Application.Features.LoyaltyPrograms.Commands.Delete;

public class DeletedLoyaltyProgramResponse : IResponse
{
    public int Id { get; set; }
}