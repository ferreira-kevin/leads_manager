using Leads.Domain.ReadModels;

namespace Leads.Api.Controllers
{
    public static class LeadsMock
    {
        public static List<LeadDto> GetMock()
        {
            return new List<LeadDto>
            {
                new LeadDto
                {
                    LeadId = Guid.NewGuid(),
                    ContactFirstName = "Oliver",
                    ContactLastName = "Garcia",
                    DateCreated = DateTime.Now.AddDays(-10),
                    Suburb = "Dallas",
                    Category = "Real Estate",
                    Description = "Ut enim ad minim veniam.",
                    Price = 20403.04m,
                    ContactPhoneNumber = "+1-800-555-0156",
                    ContactEmail = "alex.williams@example.com"
                },
                new LeadDto
                {
                    LeadId = Guid.NewGuid(),
                    ContactFirstName = "Katie",
                    ContactLastName = "Garcia",
                    DateCreated = DateTime.Now.AddDays(-20),
                    Suburb = "Chicago",
                    Category = "Technology",
                    Description = "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                    Price = 45357.48m,
                    ContactPhoneNumber = "+1-800-555-0123",
                    ContactEmail = "sophia.miller@example.com"
                },
                new LeadDto
                {
                    LeadId = Guid.NewGuid(),
                    ContactFirstName = "Alex",
                    ContactLastName = "Garcia",
                    DateCreated = DateTime.Now.AddDays(-5),
                    Suburb = "Phoenix",
                    Category = "Consulting",
                    Description = "Excepteur sint occaecat cupidatat non proident.",
                    Price = 32162.12m,
                    ContactPhoneNumber = "+1-800-555-0100",
                    ContactEmail = "jane.smith@example.com"
                },
                new LeadDto
                {
                    LeadId = Guid.NewGuid(),
                    ContactFirstName = "Chris",
                    ContactLastName = "Brown",
                    DateCreated = DateTime.Now.AddDays(-18),
                    Suburb = "Chicago",
                    Category = "Finance",
                    Description = "Consectetur adipiscing elit.",
                    Price = 47401.78m,
                    ContactPhoneNumber = "+1-800-555-0123",
                    ContactEmail = "katie.brown@example.com"
                },
                new LeadDto
                {
                    LeadId = Guid.NewGuid(),
                    ContactFirstName = "Katie",
                    ContactLastName = "Garcia",
                    DateCreated = DateTime.Now.AddDays(-15),
                    Suburb = "New York",
                    Category = "Consulting",
                    Description = "Quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    Price = 49372.14m,
                    ContactPhoneNumber = "+1-800-555-0167",
                    ContactEmail = "lucas.davis@example.com"
                },
                new LeadDto
                {
                    LeadId = Guid.NewGuid(),
                    ContactFirstName = "Emma",
                    ContactLastName = "Jones",
                    DateCreated = DateTime.Now.AddDays(-8),
                    Suburb = "New York",
                    Category = "Finance",
                    Description = "Quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    Price = 6172.81m,
                    ContactPhoneNumber = "+1-800-555-0189",
                    ContactEmail = "sam.jones@example.com"
                },
                new LeadDto
                {
                    LeadId = Guid.NewGuid(),
                    ContactFirstName = "Emma",
                    ContactLastName = "Davis",
                    DateCreated = DateTime.Now.AddDays(-3),
                    Suburb = "San Jose",
                    Category = "Real Estate",
                    Description = "Ut enim ad minim veniam.",
                    Price = 35580.25m,
                    ContactPhoneNumber = "+1-800-555-0189",
                    ContactEmail = "sophia.miller@example.com"
                },
                new LeadDto
                {
                    LeadId = Guid.NewGuid(),
                    ContactFirstName = "Chris",
                    ContactLastName = "Jones",
                    DateCreated = DateTime.Now.AddDays(-1),
                    Suburb = "San Diego",
                    Category = "Retail",
                    Description = "Sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Price = 27964.39m,
                    ContactPhoneNumber = "+1-800-555-0167",
                    ContactEmail = "emma.martinez@example.com"
                },
                new LeadDto
                {
                    LeadId = Guid.NewGuid(),
                    ContactFirstName = "John",
                    ContactLastName = "Smith",
                    DateCreated = DateTime.Now.AddDays(-2),
                    Suburb = "Los Angeles",
                    Category = "Marketing",
                    Description = "Consectetur adipiscing elit.",
                    Price = 15744.71m,
                    ContactPhoneNumber = "+1-800-555-0134",
                    ContactEmail = "jane.smith@example.com"
                },
                new LeadDto
                {
                    LeadId = Guid.NewGuid(),
                    ContactFirstName = "Sophia",
                    ContactLastName = "Miller",
                    DateCreated = DateTime.Now.AddDays(-25),
                    Suburb = "San Francisco",
                    Category = "Marketing",
                    Description = "Ut enim ad minim veniam.",
                    Price = 31256.09m,
                    ContactPhoneNumber = "+1-800-555-0145",
                    ContactEmail = "olivia.johnson@example.com"
                }
            };
        }
    }
}
