using MediatR;

namespace Leads.Application.Commands
{
    public class CreateLeadCommand : IRequest<Unit>
    {
        public Guid LeadId { get; set; }
        public string ContactFirstName { get; set; } = default!;
        public string ContactLastName { get; set; } = default!;
        public DateTime DateCreated { get; set; }
        public string Suburb { get; set; } = default!;
        public string Category { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string ContactPhoneNumber { get; set; } = default!;
        public string ContactEmail { get; set; } = default!;
    }
}
