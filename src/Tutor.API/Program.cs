
using Serilog;
using Tutor.API.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();
builder.Services.ConfigureSwagger(builder.Configuration);
const string corsPolicy = "_corsPolicy";
builder.Services.ConfigureCors(corsPolicy);
builder.Services.ConfigureAuth();

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

// TODO: Possibly need to configure JSON mapping for controller endpoints

// TODO: Serilog; Deploy - Eva
// TODO: Front, Testing - Luka, Nikola

// TODO: Performance za read enrollment pokazi
// TODO: Pokazi secondary db context u testovima
// TODO: Pokazi problematiku internal APIa
// TODO: Rework FailureCodes to make them extensible
// TODO: Rework BaseApiController to return error subcode with response and to make it extensible (so that each module can introduce failures)
// TODO: Check all routes when redesign is near finished
// TODO: DELETE operations need to be revisited because of modules.