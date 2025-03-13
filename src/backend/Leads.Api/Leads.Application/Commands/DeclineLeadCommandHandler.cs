using FluentValidation;
using MediatR;

namespace Leads.Application.Commands
{
    internal class DeclineLeadCommandHandler : IRequestHandler<DeclineLeadCommand, Unit>
    {
        private readonly IValidator<DeclineLeadCommand> _validator;

        public DeclineLeadCommandHandler(IValidator<DeclineLeadCommand> validator)
        {
            _validator = validator;
        }

        public async Task<Unit> Handle(DeclineLeadCommand request, CancellationToken cancellationToken)
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
