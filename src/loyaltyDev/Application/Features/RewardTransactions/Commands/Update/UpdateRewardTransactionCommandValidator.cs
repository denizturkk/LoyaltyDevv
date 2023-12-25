using FluentValidation;

namespace Application.Features.RewardTransactions.Commands.Update;

public class UpdateRewardTransactionCommandValidator : AbstractValidator<UpdateRewardTransactionCommand>
{
    public UpdateRewardTransactionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.LoyaltyProgramSubscriptionId).NotEmpty();
        RuleFor(c => c.IsReward).NotEmpty();
        RuleFor(c => c.IsPoint).NotEmpty();
        RuleFor(c => c.PointSpentAmount).NotEmpty();
        RuleFor(c => c.ProductSpentAmount).NotEmpty();
    }
}