namespace Leads.Domain.ReadModels
{
    public class LeadDto
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
        public LeadStatus Status { get; set; } = LeadStatus.Invited;
    }

    public enum LeadStatus
    {
        Invited,
        Accepted,
        Declined
    }
}
