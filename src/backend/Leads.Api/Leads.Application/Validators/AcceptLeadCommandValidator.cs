using FluentValidation;
using Leads.Application.Commands;

namespace Leads.Application.Validators
{
    public class AcceptLeadCommandValidator : AbstractValidator<AcceptLeadCommand>
    {
        public AcceptLeadCommandValidator()
        {
            // Valida que o UserId não é um Guid vazio
            RuleFor(command => command.UserId)
                .NotEmpty().WithMessage("UserId cannot be empty.")
                .Must(guid => guid != Guid.Empty).WithMessage("UserId must be a valid GUID.");
        }
    }
}
