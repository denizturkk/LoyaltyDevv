using Application.Features.LoyaltyPrograms.Constants;
using Application.Features.LoyaltyPrograms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.LoyaltyPrograms.Commands.Delete;

public class DeleteLoyaltyProgramCommand : IRequest<DeletedLoyaltyProgramResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLoyaltyPrograms";

    public class DeleteLoyaltyProgramCommandHandler : IRequestHandler<DeleteLoyaltyProgramCommand, DeletedLoyaltyProgramResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILoyaltyProgramRepository _loyaltyProgramRepository;
        private readonly LoyaltyProgramBusinessRules _loyaltyProgramBusinessRules;

        public DeleteLoyaltyProgramCommandHandler(IMapper mapper, ILoyaltyProgramRepository loyaltyProgramRepository,
                                         LoyaltyProgramBusinessRules loyaltyProgramBusinessRules)
        {
            _mapper = mapper;
            _loyaltyProgramRepository = loyaltyProgramRepository;
            _loyaltyProgramBusinessRules = loyaltyProgramBusinessRules;
        }

        public async Task<DeletedLoyaltyProgramResponse> Handle(DeleteLoyaltyProgramCommand request, CancellationToken cancellationToken)
        {
            LoyaltyProgram? loyaltyProgram = await _loyaltyProgramRepository.GetAsync(predicate: lp => lp.Id == request.Id, cancellationToken: cancellationToken);
            await _loyaltyProgramBusinessRules.LoyaltyProgramShouldExistWhenSelected(loyaltyProgram);

            await _loyaltyProgramRepository.DeleteAsync(loyaltyProgram!);

            DeletedLoyaltyProgramResponse response = _mapper.Map<DeletedLoyaltyProgramResponse>(loyaltyProgram);
            return response;
        }
    }
}