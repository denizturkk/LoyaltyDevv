using Core.Application.Responses;

namespace Application.Features.LoyaltyPrograms.Commands.Create;

public class CreatedLoyaltyProgramResponse : IResponse
{
    public int Id { get; set; }
    public int CorporateCustomerId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool Type { get; set; }
    public int? PointExchangeRate { get; set; }
    public int? ProductExchangeRate { get; set; }
}