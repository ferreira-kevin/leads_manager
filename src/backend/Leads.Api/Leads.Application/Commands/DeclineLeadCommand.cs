using MediatR;

namespace Leads.Application.Commands
{
    public class DeclineLeadCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid LeadId { get; set; }
    }
}
