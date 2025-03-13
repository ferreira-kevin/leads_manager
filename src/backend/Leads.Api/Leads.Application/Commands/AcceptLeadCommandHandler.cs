using FluentValidation;
using MediatR;

namespace Leads.Application.Commands
{
    internal class AcceptLeadCommandHandler : IRequestHandler<AcceptLeadCommand, Unit>
    {
        private readonly IValidator<AcceptLeadCommand> _validator;

        public AcceptLeadCommandHandler(IValidator<AcceptLeadCommand> validator)
        {
            _validator = validator;
        }

        public async Task<Unit> Handle(AcceptLeadCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            return Unit.Value;
        }
    }
}
