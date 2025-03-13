using Leads.EventSourcing.Core;

namespace Leads.Domain.Events
{
    public class LeadCreated : ModelEventBase
    {
        public Guid LeadId { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }

        public LeadCreated(
            Guid modelId,
            Guid leadId,
            string contactFirstName,
            string contactLastName,
            DateTime dateCreated,
            string suburb,
            string category,
            string description,
            decimal price,
            string contactPhoneNumber,
            string contactEmail)
            : base(modelId, 1)
        {
            LeadId = leadId;
            ContactFirstName = contactFirstName;
            ContactLastName = contactLastName;
            DateCreated = dateCreated;
            Suburb = suburb;
            Category = category;
            Description = description;
            Price = price;
            ContactPhoneNumber = contactPhoneNumber;
            ContactEmail = contactEmail;
        }
    }
}
