using GM.Mapper;
using GM.Mapper.Sample.Application;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGMMapper();     // registers Mapster's IMapper (from the GM.Mapper package)
builder.Services.AddApplication();  // registers the mappings + people service

builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

// Liveness must not depend on downstream dependencies, so it runs no checks; readiness runs
// every registered health check (none here yet). See engineering baseline §11.
app.MapHealthChecks("/health/live", new HealthCheckOptions { Predicate = _ => false });
app.MapHealthChecks("/health/ready");

await app.RunAsync();

// Exposed so the integration test project can bootstrap the app via WebApplicationFactory.
public partial class Program
{
    // Only used as a WebApplicationFactory<Program> marker; never instantiated directly.
    protected Program() { }
}
