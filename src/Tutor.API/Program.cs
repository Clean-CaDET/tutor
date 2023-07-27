
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


// TODO: KcRating should be moved from utilities to learning
// TODO: DELETE operations need to be revisited because of modules.

// TODO: Possibly need to configure JSON mapping for controller endpoints
// TODO: Serilog

// Check all usages of methods below
// TODO: Check if CRUD service is being used properly. Up to now it returned tracked entities that could be and saved with UoW. This is no longer true.

//TODO: Check all routes when redesign is near finished

// TODO: Rework FailureCodes to make them extensible
// TODO: Rework BaseApiController to return error subcode with response and to make it extensible (so that each module can introduce failures)

// TODO: Performance gain za enrollment pokazi
// TODO: Pokazi problematiku internal APIa
// TODO: Pokazi secondary db context u testovima