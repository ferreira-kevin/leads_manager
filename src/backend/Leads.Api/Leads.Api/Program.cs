
using FluentValidation;
using Leads.Api.Validators;
using Leads.Application.Commands;
using Leads.Application.Validators;
using Leads.Infrastructure.EventStore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddDbContext<EventStoreDbContext>(options =>
    options.UseInMemoryDatabase("EventStoreDB"));
builder.Services.AddScoped<IEventStore, EFEventStore>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddTransient<IRequestHandler<CreateLeadCommand, Unit>, CreateLeadCommandHandler>();

builder.Services.AddTransient<IValidator<CreateLeadCommand>, CreateLeadCommandValidator>();
builder.Services.AddTransient<IValidator<AcceptLeadCommand>, AcceptLeadCommandValidator>();
builder.Services.AddTransient<IValidator<DeclineLeadCommand>, DeclineLeadCommandValidator>();

var app = builder.Build();
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
