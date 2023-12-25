using FluentValidation;

namespace Application.Features.RewardTransactions.Commands.Create;

public class CreateRewardTransactionCommandValidator : AbstractValidator<CreateRewardTransactionCommand>
{
    public CreateRewardTransactionCommandValidator()
    {
        RuleFor(c => c.LoyaltyProgramSubscriptionId).NotEmpty();
        RuleFor(c => c.IsPoint).NotEmpty();
        RuleFor(c => c.PointSpentAmount).NotEmpty();
        RuleFor(c => c.ProductSpentAmount).NotEmpty();
    }
}