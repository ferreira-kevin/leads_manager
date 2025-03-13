using FluentValidation;
using Leads.Domain.Events;
using MediatR;

namespace Leads.Application.Commands
{
    public class CreateLeadCommandHandler : IRequestHandler<CreateLeadCommand, Unit>
    {
        private readonly IValidator<CreateLeadCommand> _validator;

        public CreateLeadCommandHandler(IValidator<CreateLeadCommand> validator)
        {
            _validator = validator;
        }

        public async Task<Unit> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var leadCreatedEvent = new LeadCreated(
                modelId: Guid.NewGuid(),
                leadId: request.LeadId,
                contactFirstName: request.ContactFirstName,
                contactLastName: request.ContactLastName,
                dateCreated: request.DateCreated,
                suburb: request.Suburb,
                category: request.Category,
                description: request.Description,
                price: request.Price,
                contactPhoneNumber: request.ContactPhoneNumber,
                contactEmail: request.ContactEmail
            );
            return Unit.Value;
        }
    }
}
