using GM.Mapper;
using GM.Mapper.Sample.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGMMapper();     // registers Mapster's IMapper (from the GM.Mapper package)
builder.Services.AddApplication();  // registers the mappings + people service

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

// Exposed so the integration test project can bootstrap the app via WebApplicationFactory.
public partial class Program;
