using FluentValidation;

namespace Application.Features.LoyaltyProgramSubscriptions.Commands.Delete;

public class DeleteLoyaltyProgramSubscriptionCommandValidator : AbstractValidator<DeleteLoyaltyProgramSubscriptionCommand>
{
    public DeleteLoyaltyProgramSubscriptionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}