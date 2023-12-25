using Application.Features.LoyaltyPrograms.Commands.Create;
using Application.Features.LoyaltyPrograms.Commands.Delete;
using Application.Features.LoyaltyPrograms.Commands.Update;
using Application.Features.LoyaltyPrograms.Queries.GetById;
using Application.Features.LoyaltyPrograms.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.LoyaltyPrograms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<LoyaltyProgram, CreateLoyaltyProgramCommand>().ReverseMap();
        CreateMap<LoyaltyProgram, CreatedLoyaltyProgramResponse>().ReverseMap();
        CreateMap<LoyaltyProgram, UpdateLoyaltyProgramCommand>().ReverseMap();
        CreateMap<LoyaltyProgram, UpdatedLoyaltyProgramResponse>().ReverseMap();
        CreateMap<LoyaltyProgram, DeleteLoyaltyProgramCommand>().ReverseMap();
        CreateMap<LoyaltyProgram, DeletedLoyaltyProgramResponse>().ReverseMap();
        CreateMap<LoyaltyProgram, GetByIdLoyaltyProgramResponse>().ReverseMap();
        CreateMap<LoyaltyProgram, GetListLoyaltyProgramListItemDto>().ReverseMap();
        CreateMap<IPaginate<LoyaltyProgram>, GetListResponse<GetListLoyaltyProgramListItemDto>>().ReverseMap();
    }
}