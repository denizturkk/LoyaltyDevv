using FluentValidation;

namespace Application.Features.LoyaltyProgramSubscriptions.Commands.Create;

public class CreateLoyaltyProgramSubscriptionCommandValidator : AbstractValidator<CreateLoyaltyProgramSubscriptionCommand>
{
    public CreateLoyaltyProgramSubscriptionCommandValidator()
    {
        RuleFor(c => c.IndividualCustomerId).NotEmpty();
        RuleFor(c => c.LoyaltyProgramId).NotEmpty();
        RuleFor(c => c.Points).NotEmpty();
        RuleFor(c => c.ProductQuantity).NotEmpty();
    }
}