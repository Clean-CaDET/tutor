using Serilog;
using Tutor.API.Startup;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.KnowledgeComponents.Core.Domain.EventSourcing;
using Tutor.KnowledgeComponents.Infrastructure.Database.EventStore.Postgres;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

builder.Services.ConfigureInterceptors();
builder.Services.AddControllers();
builder.Services.ConfigureSwagger(builder.Configuration);
const string corsPolicy = "_corsPolicy";
builder.Services.ConfigureCors(corsPolicy);
builder.Services.ConfigureAuth();
builder.Services.AddScoped<IKnowledgeComponentEventStore, PostgresStore>();

builder.Services.RegisterModules();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseRouting();
app.UseCors(corsPolicy);
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();

// Required for automated tests
namespace Tutor.API
{
    public partial class Program { }
}