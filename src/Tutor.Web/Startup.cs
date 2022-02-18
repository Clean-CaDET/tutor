using Dahomey.Json;
using Dahomey.Json.Serialization.Conventions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel;
using Tutor.Core.LearnerModel.Workspaces;
using Tutor.Infrastructure;
using Tutor.Infrastructure.Database.Repositories.Domain;
using Tutor.Infrastructure.Database.Repositories.Learners;
using Tutor.Infrastructure.Security;
using Tutor.Infrastructure.Security.Authorization;
using Tutor.Infrastructure.Security.Authorization.JWT;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.ArrangeTask;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.Challenge;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentEvents.MultiResponseQuestion;
using Tutor.Web.Controllers.Domain.DTOs.InstructionalEvents;
using Tutor.Web.IAM;
using Tutor.Web.IAM.Keycloak;

namespace Tutor.Web
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
            Env = env;
        }

        private IConfiguration Configuration { get; }
        private IWebHostEnvironment Env { get; }

        private const string CorsPolicy = "_corsPolicy";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(Configuration);

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers().AddJsonOptions(options =>
            {
                var serializerOptions = options.JsonSerializerOptions;
                serializerOptions.SetupExtensions();
                var registry = serializerOptions.GetDiscriminatorConventionRegistry();
                registry.ClearConventions();
                registry.RegisterConvention(
                    new DefaultDiscriminatorConvention<string>(serializerOptions, "typeDiscriminator"));
                registry.RegisterType<ArrangeTaskDto>();
                registry.RegisterType<ChallengeDto>();
                registry.RegisterType<ImageDto>();
                registry.RegisterType<MultiResponseQuestionDto>();
                registry.RegisterType<TextDto>();
                registry.RegisterType<VideoDto>();
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicy,
                    builder =>
                    {
                        builder.WithOrigins(ParseCorsOrigins())
                            .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization, "access_token")
                            .WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS");
                    });
            });

            services.AddScoped<IKCService, KcService>();
            services.AddScoped<IKCRepository, KCDatabaseRepository>();
            services.AddScoped<IAssessmentEventRepository, AssessmentEventDatabaseRepository>();
            services.AddScoped<ISubmissionService, SubmissionService>();
            services.AddScoped<IAssessmentEventSelector, LeastCorrectAssessmentEventSelector>();

            services.AddScoped<ILearnerService, LearnerService>();
            services.Configure<WorkspaceOptions>(Configuration.GetSection(WorkspaceOptions.ConfigKey));
            services.AddScoped<IWorkspaceCreator, NoWorkspaceCreator>();
            services.AddScoped<ILearnerRepository, LearnerDatabaseRepository>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IRefreshTokenValidator, RefreshTokenValidator>();

            services.AddScoped<IAuthProvider, KeycloakAuthProvider>();
            services.AddScoped<IAuthService, AuthService>();

            if (!bool.Parse(Environment.GetEnvironmentVariable("KEYCLOAK_ON") ?? "false"))
            {
                SetupJwtService(services);
            }
            else
            {
                KeycloakAuthenticationConfig(services);
                KeycloakAuthorizationConfig(services);
            }
        }

        private static void SetupJwtService(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("learnerPolicy", policy =>
                    policy.RequireRole("learner"));
            });

            var key = EnvironmentConnection.GetSecret("JWT_KEY") ?? "tutor_secret_key";
            var issuer = EnvironmentConnection.GetSecret("JWT_ISSUER") ?? "tutor_secret_key";
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

        private static void KeycloakAuthorizationConfig(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("learnerPolicy", policy =>
                    policy.Requirements.Add(new KeycloakRole("Learner")));
                options.AddPolicy("professorPolicy", policy =>
                    policy.Requirements.Add(new KeycloakRole("Professor")));
            });
            services.AddSingleton<IAuthorizationHandler, KeycloakRoleHandler>();
        }

        private void KeycloakAuthenticationConfig(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = Environment.GetEnvironmentVariable("AUTHORITY") ??
                                    "http://localhost:8080/auth/realms/master";
                options.Audience = Environment.GetEnvironmentVariable("AUDIENCE") ?? "demo-app";
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.Events = new JwtBearerEvents

                {
                    OnAuthenticationFailed = failedContext =>
                    {
                        failedContext.NoResult();
                        failedContext.Response.StatusCode = 500;
                        failedContext.Response.ContentType = "text/plain";

                        return failedContext.Response.WriteAsync(Env.IsDevelopment()
                            ? failedContext.Exception.ToString()
                            : "An error occured processing your authentication.");
                    }
                };
            });
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(CorsPolicy);

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private static string[] ParseCorsOrigins()
        {
            var corsOrigins = new[] {"http://localhost:4200"};
            var corsOriginsPath = EnvironmentConnection.GetSecret("SMART_TUTOR_CORS_ORIGINS");
            if (File.Exists(corsOriginsPath))
            {
                corsOrigins = File.ReadAllLines(corsOriginsPath);
            }

            return corsOrigins;
        }
    }
}