using Application.Features.LoyaltyPrograms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LoyaltyPrograms.Queries.GetById;

public class GetByIdLoyaltyProgramQuery : IRequest<GetByIdLoyaltyProgramResponse>
{
    public int Id { get; set; }

    public class GetByIdLoyaltyProgramQueryHandler : IRequestHandler<GetByIdLoyaltyProgramQuery, GetByIdLoyaltyProgramResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILoyaltyProgramRepository _loyaltyProgramRepository;
        private readonly LoyaltyProgramBusinessRules _loyaltyProgramBusinessRules;

        public GetByIdLoyaltyProgramQueryHandler(IMapper mapper, ILoyaltyProgramRepository loyaltyProgramRepository, LoyaltyProgramBusinessRules loyaltyProgramBusinessRules)
        {
            _mapper = mapper;
            _loyaltyProgramRepository = loyaltyProgramRepository;
            _loyaltyProgramBusinessRules = loyaltyProgramBusinessRules;
        }

        public async Task<GetByIdLoyaltyProgramResponse> Handle(GetByIdLoyaltyProgramQuery request, CancellationToken cancellationToken)
        {
            LoyaltyProgram? loyaltyProgram = await _loyaltyProgramRepository.GetAsync(predicate: lp => lp.Id == request.Id, cancellationToken: cancellationToken);
            await _loyaltyProgramBusinessRules.LoyaltyProgramShouldExistWhenSelected(loyaltyProgram);

            GetByIdLoyaltyProgramResponse response = _mapper.Map<GetByIdLoyaltyProgramResponse>(loyaltyProgram);
            return response;
        }
    }
}