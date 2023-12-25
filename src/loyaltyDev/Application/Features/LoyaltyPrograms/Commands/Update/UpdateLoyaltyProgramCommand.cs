using Application.Features.LoyaltyPrograms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.LoyaltyPrograms.Commands.Update;

public class UpdateLoyaltyProgramCommand : IRequest<UpdatedLoyaltyProgramResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }
    public int CorporateCustomerId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool Type { get; set; }
    public int? PointExchangeRate { get; set; }
    public int? ProductExchangeRate { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLoyaltyPrograms";

    public class UpdateLoyaltyProgramCommandHandler : IRequestHandler<UpdateLoyaltyProgramCommand, UpdatedLoyaltyProgramResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILoyaltyProgramRepository _loyaltyProgramRepository;
        private readonly LoyaltyProgramBusinessRules _loyaltyProgramBusinessRules;

        public UpdateLoyaltyProgramCommandHandler(IMapper mapper, ILoyaltyProgramRepository loyaltyProgramRepository,
                                         LoyaltyProgramBusinessRules loyaltyProgramBusinessRules)
        {
            _mapper = mapper;
            _loyaltyProgramRepository = loyaltyProgramRepository;
            _loyaltyProgramBusinessRules = loyaltyProgramBusinessRules;
        }

        public async Task<UpdatedLoyaltyProgramResponse> Handle(UpdateLoyaltyProgramCommand request, CancellationToken cancellationToken)
        {
            LoyaltyProgram? loyaltyProgram = await _loyaltyProgramRepository.GetAsync(predicate: lp => lp.Id == request.Id, cancellationToken: cancellationToken);
            await _loyaltyProgramBusinessRules.LoyaltyProgramShouldExistWhenSelected(loyaltyProgram);
            loyaltyProgram = _mapper.Map(request, loyaltyProgram);

            await _loyaltyProgramRepository.UpdateAsync(loyaltyProgram!);

            UpdatedLoyaltyProgramResponse response = _mapper.Map<UpdatedLoyaltyProgramResponse>(loyaltyProgram);
            return response;
        }
    }
}