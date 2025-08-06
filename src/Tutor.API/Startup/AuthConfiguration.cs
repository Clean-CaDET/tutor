using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tutor.BuildingBlocks.Infrastructure.Security;

namespace Tutor.API.Startup;

public static class AuthConfiguration
{
    public static IServiceCollection ConfigureAuth(this IServiceCollection services)
    {
        ConfigureAuthentication(services);
        ConfigureAuthorizationPolicies(services);
        return services;
    }

    private static void ConfigureAuthentication(IServiceCollection services)
    {
        var key = EnvironmentConnection.GetSecret("JWT_KEY") ?? "tutor_secret_key_32_chars_minimum_for_hmac_sha256_security";
        var issuer = EnvironmentConnection.GetSecret("JWT_ISSUER") ?? "tutor";
        var audience = EnvironmentConnection.GetSecret("JWT_AUDIENCE") ?? "tutor-front.com";

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("AuthenticationTokens-Expired", "true");
                        }

                        return Task.CompletedTask;
                    }
                };
            });
    }

    private static void ConfigureAuthorizationPolicies(IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("administratorPolicy", policy => policy.RequireRole("administrator"));
            options.AddPolicy("instructorPolicy", policy => policy.RequireRole("instructor"));
            options.AddPolicy("monitoringFeedbackPolicy", policy => policy.RequireRole("instructor", "administrator"));
            options.AddPolicy("learnerPolicy", policy => policy.RequireRole("learner", "learnercommercial"));
        });
    }
}