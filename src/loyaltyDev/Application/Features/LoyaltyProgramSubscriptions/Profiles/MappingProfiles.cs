using Application.Features.LoyaltyProgramSubscriptions.Commands.Create;
using Application.Features.LoyaltyProgramSubscriptions.Commands.Delete;
using Application.Features.LoyaltyProgramSubscriptions.Commands.Update;
using Application.Features.LoyaltyProgramSubscriptions.Queries.GetById;
using Application.Features.LoyaltyProgramSubscriptions.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.LoyaltyProgramSubscriptions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<LoyaltyProgramSubscription, CreateLoyaltyProgramSubscriptionCommand>().ReverseMap();
        CreateMap<LoyaltyProgramSubscription, CreatedLoyaltyProgramSubscriptionResponse>().ReverseMap();
        CreateMap<LoyaltyProgramSubscription, UpdateLoyaltyProgramSubscriptionCommand>().ReverseMap();
        CreateMap<LoyaltyProgramSubscription, UpdatedLoyaltyProgramSubscriptionResponse>().ReverseMap();
        CreateMap<LoyaltyProgramSubscription, DeleteLoyaltyProgramSubscriptionCommand>().ReverseMap();
        CreateMap<LoyaltyProgramSubscription, DeletedLoyaltyProgramSubscriptionResponse>().ReverseMap();
        CreateMap<LoyaltyProgramSubscription, GetByIdLoyaltyProgramSubscriptionResponse>().ReverseMap();
        CreateMap<LoyaltyProgramSubscription, GetListLoyaltyProgramSubscriptionListItemDto>().ReverseMap();
        CreateMap<IPaginate<LoyaltyProgramSubscription>, GetListResponse<GetListLoyaltyProgramSubscriptionListItemDto>>().ReverseMap();
    }
}