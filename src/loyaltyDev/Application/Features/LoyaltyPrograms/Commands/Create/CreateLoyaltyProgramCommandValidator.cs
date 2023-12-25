using FluentValidation;

namespace Application.Features.LoyaltyPrograms.Commands.Create;

public class CreateLoyaltyProgramCommandValidator : AbstractValidator<CreateLoyaltyProgramCommand>
{
    public CreateLoyaltyProgramCommandValidator()
    {
        RuleFor(c => c.CorporateCustomerId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.PointExchangeRate).NotEmpty();
        RuleFor(c => c.ProductExchangeRate).NotEmpty();
    }
}