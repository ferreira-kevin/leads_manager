using Leads.EventSourcing.Core;

namespace Leads.Domain.Events
{
    public class LeadAccepted : ModelEventBase
    {
        public Guid UserId { get; private set; }

        public LeadAccepted(Guid modelId, int modelVersion, Guid userId)
            : base(modelId, modelVersion) =>
                UserId = userId;
    }
}
