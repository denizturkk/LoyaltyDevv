using Application.Features.LoyaltyPrograms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.LoyaltyPrograms.Commands.Create;

public class CreateLoyaltyProgramCommand : IRequest<CreatedLoyaltyProgramResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int CorporateCustomerId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool Type { get; set; }
    public int? PointExchangeRate { get; set; }
    public int? ProductExchangeRate { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLoyaltyPrograms";

    public class CreateLoyaltyProgramCommandHandler : IRequestHandler<CreateLoyaltyProgramCommand, CreatedLoyaltyProgramResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILoyaltyProgramRepository _loyaltyProgramRepository;
        private readonly LoyaltyProgramBusinessRules _loyaltyProgramBusinessRules;

        public CreateLoyaltyProgramCommandHandler(IMapper mapper, ILoyaltyProgramRepository loyaltyProgramRepository,
                                         LoyaltyProgramBusinessRules loyaltyProgramBusinessRules)
        {
            _mapper = mapper;
            _loyaltyProgramRepository = loyaltyProgramRepository;
            _loyaltyProgramBusinessRules = loyaltyProgramBusinessRules;
        }

        public async Task<CreatedLoyaltyProgramResponse> Handle(CreateLoyaltyProgramCommand request, CancellationToken cancellationToken)
        {
            LoyaltyProgram loyaltyProgram = _mapper.Map<LoyaltyProgram>(request);

            await _loyaltyProgramRepository.AddAsync(loyaltyProgram);

            CreatedLoyaltyProgramResponse response = _mapper.Map<CreatedLoyaltyProgramResponse>(loyaltyProgram);
            return response;
        }
    }
}