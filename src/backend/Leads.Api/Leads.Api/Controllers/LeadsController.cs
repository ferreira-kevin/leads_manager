using Leads.Application.Commands;
using Leads.Domain.ReadModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Leads.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeadsController : ControllerBase
    {
        private readonly ILogger<LeadsController> _logger;
        private readonly IMediator _mediator;
        private List<LeadDto> leads = LeadsMock.GetMock();
        public LeadsController(IMediator mediator, ILogger<LeadsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("invited")]
        public async Task<IActionResult> GetInvitedLeads()
        {
            return Ok(leads.Where(l => l.Status == LeadStatus.Invited));
        }

        [HttpGet("accepted")]
        public async Task<IActionResult> GetAcceptedLeads()
        {
            return Ok(leads.Where(l => l.Status == LeadStatus.Accepted));
        }

        [HttpPost("")]
        public async Task<IActionResult> SaveEvent(CreateLeadCommand command)
        {
            await _mediator.Send(command);


            return Ok();
        }

        [HttpPost("accept")]
        public async Task<IActionResult> AcceptEvent(AcceptLeadCommand command)
        {
            await _mediator.Send(command);

            //TODO migrate to domain
            var lead = leads.FirstOrDefault(l => l.LeadId == command.LeadId);
            if (lead == null) return NotFound();

            if (lead.Price > 500) lead.Price *= 0.9m;
            lead.Status = LeadStatus.Accepted;
            return Ok();
        }

        [HttpPost("decline")]
        public async Task<IActionResult> DeclineEvent(DeclineLeadCommand command)
        {
            await _mediator.Send(command);

            //TODO migrate to domain
            var lead = leads.FirstOrDefault(l => l.LeadId == command.LeadId);
            if (lead == null) return NotFound();

            lead.Status = LeadStatus.Declined;

            return Ok();
        }
    }
}
