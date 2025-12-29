using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi;

namespace Tutor.API.Startup;

public static class SwaggerConfiguration
{
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        var contactAddress = configuration.GetValue<string>("ContactUrl");

        services.AddSwaggerGen(setup =>
        {
            setup.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Clean CaDET Tutor API",
                Version = "v1",
                Description = "An intelligent tutoring system specialized for the clean code analysis and refactoring domain.",
                Contact = new OpenApiContact
                {
                    Name = "Clean CaDET Organization",
                    Url = new Uri(contactAddress)
                }
            });

            // Security scheme (Bearer JWT)
            const string schemeId = JwtBearerDefaults.AuthenticationScheme; // "Bearer"

            setup.AddSecurityDefinition(schemeId, new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Description = "Put **_ONLY_** your JWT Bearer token in the text box below!"
            });

            setup.AddSecurityRequirement(document => new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference(schemeId, document)] = []
            });
        });

        return services;
    }
}