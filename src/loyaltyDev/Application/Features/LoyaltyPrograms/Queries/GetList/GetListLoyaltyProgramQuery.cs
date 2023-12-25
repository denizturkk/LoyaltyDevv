using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.LoyaltyPrograms.Queries.GetList;

public class GetListLoyaltyProgramQuery : IRequest<GetListResponse<GetListLoyaltyProgramListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => $"GetListLoyaltyPrograms({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetLoyaltyPrograms";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListLoyaltyProgramQueryHandler : IRequestHandler<GetListLoyaltyProgramQuery, GetListResponse<GetListLoyaltyProgramListItemDto>>
    {
        private readonly ILoyaltyProgramRepository _loyaltyProgramRepository;
        private readonly IMapper _mapper;

        public GetListLoyaltyProgramQueryHandler(ILoyaltyProgramRepository loyaltyProgramRepository, IMapper mapper)
        {
            _loyaltyProgramRepository = loyaltyProgramRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLoyaltyProgramListItemDto>> Handle(GetListLoyaltyProgramQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LoyaltyProgram> loyaltyPrograms = await _loyaltyProgramRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLoyaltyProgramListItemDto> response = _mapper.Map<GetListResponse<GetListLoyaltyProgramListItemDto>>(loyaltyPrograms);
            return response;
        }
    }
}