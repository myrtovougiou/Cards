using CardsApi.Models;
using FluentValidation;

namespace CardsApi.Validators
{
    public class CardValidator : AbstractValidator<Card>
    {
        public CardValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Color).Matches("^#([a-zA-z0-9]){6}$").WithMessage("Color should conform to a '6 alphanumeric characters prefixed with a #' format.");
        }
    }
}
