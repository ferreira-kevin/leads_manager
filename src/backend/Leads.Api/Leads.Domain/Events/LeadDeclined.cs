using Leads.EventSourcing.Core;

namespace Leads.Domain.Events
{
    public class LeadDeclined : ModelEventBase
    {
        public Guid UserId { get; private set; }

        public LeadDeclined(Guid modelId, int modelVersion, Guid userId)
            : base(modelId, modelVersion) =>
                UserId = userId;
    }
}
