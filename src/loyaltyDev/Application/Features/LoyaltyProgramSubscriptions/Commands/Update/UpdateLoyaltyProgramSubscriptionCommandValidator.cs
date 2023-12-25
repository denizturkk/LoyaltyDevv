using FluentValidation;

namespace Application.Features.LoyaltyProgramSubscriptions.Commands.Update;

public class UpdateLoyaltyProgramSubscriptionCommandValidator : AbstractValidator<UpdateLoyaltyProgramSubscriptionCommand>
{
    public UpdateLoyaltyProgramSubscriptionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.IndividualCustomerId).NotEmpty();
        RuleFor(c => c.LoyaltyProgramId).NotEmpty();
        RuleFor(c => c.Points).NotEmpty();
        RuleFor(c => c.ProductQuantity).NotEmpty();
    }
}