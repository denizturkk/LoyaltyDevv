using FluentValidation;

namespace Application.Features.LoyaltyPrograms.Commands.Delete;

public class DeleteLoyaltyProgramCommandValidator : AbstractValidator<DeleteLoyaltyProgramCommand>
{
    public DeleteLoyaltyProgramCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}