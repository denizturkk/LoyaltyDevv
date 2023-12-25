using Application.Features.RewardTransactions.Commands.Create;
using Application.Features.RewardTransactions.Commands.Delete;
using Application.Features.RewardTransactions.Commands.Update;
using Application.Features.RewardTransactions.Queries.GetById;
using Application.Features.RewardTransactions.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.RewardTransactions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RewardTransaction, CreateRewardTransactionCommand>().ReverseMap();
        CreateMap<RewardTransaction, CreatedRewardTransactionResponse>().ReverseMap();
        CreateMap<RewardTransaction, UpdateRewardTransactionCommand>().ReverseMap();
        CreateMap<RewardTransaction, UpdatedRewardTransactionResponse>().ReverseMap();
        CreateMap<RewardTransaction, DeleteRewardTransactionCommand>().ReverseMap();
        CreateMap<RewardTransaction, DeletedRewardTransactionResponse>().ReverseMap();
        CreateMap<RewardTransaction, GetByIdRewardTransactionResponse>().ReverseMap();
        CreateMap<RewardTransaction, GetListRewardTransactionListItemDto>().ReverseMap();
        CreateMap<IPaginate<RewardTransaction>, GetListResponse<GetListRewardTransactionListItemDto>>().ReverseMap();
    }
}