using FluentValidation;
using Leads.Application.Commands;

namespace Leads.Application.Validators
{
    public class DeclineLeadCommandValidator : AbstractValidator<DeclineLeadCommand>
    {
        public DeclineLeadCommandValidator()
        {
            RuleFor(command => command.UserId)
                .NotEmpty().WithMessage("UserId cannot be empty.")
                .Must(guid => guid != Guid.Empty).WithMessage("UserId must be a valid GUID.");
        }
    }
}
