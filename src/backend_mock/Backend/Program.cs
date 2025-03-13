var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "API Running!");

// Simulação de um banco de dados em memória
var leads = new List<LeadDto>
            {
                new LeadDto
                {
                    Id = 1,
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
                    Id = 2,
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
                    Id = 3,
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
                    Id = 4,
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
                    Id = 5,
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
                    Id = 6,
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
                    Id = 7,
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
                    Id = 8,
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
                    Id = 9,
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
                    Id = 10,
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

// Endpoint para listar leads convidados
app.MapGet("/api/leads/invited", () => leads.Where(l => l.Status == LeadStatus.Invited));
app.MapGet("/api/leads/accepted", () => leads.Where(l => l.Status == LeadStatus.Accepted));

// Endpoint para aceitar um lead
app.MapPost("/api/leads/accept/{id}", (int id) =>
{
    var lead = leads.FirstOrDefault(l => l.Id == id);
    if (lead == null) return Results.NotFound();

    if (lead.Price > 500) lead.Price *= 0.9m; // Aplica 10% de desconto
    lead.Status = LeadStatus.Accepted;

    // Simulação de notificação (escrevendo em um arquivo de texto)
    File.WriteAllText("notification.txt", $"Lead {lead.ContactFirstName} foi aceito!");

    return Results.Ok(lead);
});

// Endpoint para recusar um lead
app.MapPost("/api/leads/decline/{id}", (int id) =>
{
    var lead = leads.FirstOrDefault(l => l.Id == id);
    if (lead == null) return Results.NotFound();

    lead.Status = LeadStatus.Declined;
    return Results.Ok(lead);
});

app.Run();

public class LeadDto
{
    public int Id { get; set; }
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
