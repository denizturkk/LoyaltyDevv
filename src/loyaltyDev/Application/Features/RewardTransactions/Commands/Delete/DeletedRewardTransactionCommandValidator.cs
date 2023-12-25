using FluentValidation;

namespace Application.Features.RewardTransactions.Commands.Delete;

public class DeleteRewardTransactionCommandValidator : AbstractValidator<DeleteRewardTransactionCommand>
{
    public DeleteRewardTransactionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}