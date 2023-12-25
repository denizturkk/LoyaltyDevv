using FluentValidation;

namespace Application.Features.LoyaltyPrograms.Commands.Update;

public class UpdateLoyaltyProgramCommandValidator : AbstractValidator<UpdateLoyaltyProgramCommand>
{
    public UpdateLoyaltyProgramCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CorporateCustomerId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.PointExchangeRate).NotEmpty();
        RuleFor(c => c.ProductExchangeRate).NotEmpty();
    }
}