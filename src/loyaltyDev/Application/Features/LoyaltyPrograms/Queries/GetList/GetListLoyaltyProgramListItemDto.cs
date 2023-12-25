using Core.Application.Dtos;

namespace Application.Features.LoyaltyPrograms.Queries.GetList;

public class GetListLoyaltyProgramListItemDto : IDto
{
    public int Id { get; set; }
    public int CorporateCustomerId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool Type { get; set; }
    public int? PointExchangeRate { get; set; }
    public int? ProductExchangeRate { get; set; }
}