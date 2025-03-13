namespace Leads.Api.Validators
{
    using FluentValidation;
    using Leads.Application.Commands;

    public class CreateLeadCommandValidator : AbstractValidator<CreateLeadCommand>
    {
        public CreateLeadCommandValidator()
        {
            RuleFor(command => command.LeadId)
                .NotEmpty().WithMessage("LeadId is required.");

            RuleFor(command => command.ContactFirstName)
                .NotEmpty().WithMessage("Contact first name is required.")
                .Length(1, 100).WithMessage("Contact first name must be between 1 and 100 characters.");

            RuleFor(command => command.ContactLastName)
                .NotEmpty().WithMessage("Contact last name is required.")
                .Length(1, 100).WithMessage("Contact last name must be between 1 and 100 characters.");

            RuleFor(command => command.DateCreated)
                .NotEmpty().WithMessage("Date created is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Date created cannot be in the future.");

            RuleFor(command => command.Suburb)
                .NotEmpty().WithMessage("Suburb is required.")
                .Length(1, 200).WithMessage("Suburb must be between 1 and 200 characters.");

            RuleFor(command => command.Category)
                .NotEmpty().WithMessage("Category is required.")
                .Length(1, 50).WithMessage("Category must be between 1 and 50 characters.");

            RuleFor(command => command.Description)
                .NotEmpty().WithMessage("Description is required.")
                .Length(1, 500).WithMessage("Description must be between 1 and 500 characters.");

            RuleFor(command => command.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(command => command.ContactPhoneNumber)
                .NotEmpty().WithMessage("Contact phone number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Contact phone number must be in a valid format.");

            RuleFor(command => command.ContactEmail)
                .NotEmpty().WithMessage("Contact email is required.")
                .EmailAddress().WithMessage("Contact email must be a valid email address.");
        }
    }

}
