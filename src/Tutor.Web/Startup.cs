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
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.Course;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.InstructorModel.Instructors;
using Tutor.Core.LearnerModel;
using Tutor.Core.LearnerModel.Workspaces;
using Tutor.Core.ProgressModel.Feedback;
using Tutor.Core.ProgressModel.Submissions;
using Tutor.Infrastructure;
using Tutor.Infrastructure.Database.Repositories.Domain;
using Tutor.Infrastructure.Database.Repositories.Learner;
using Tutor.Infrastructure.Database.Repositories.Progress;
using Tutor.Infrastructure.Security;
using Tutor.Web.Controllers.Domain.Mappers;
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
                options.JsonSerializerOptions.Converters.Add(new LearningObjectJsonConverter());
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

            services.AddScoped<IKCRepository, KCDatabaseRepository>();
            services.AddScoped<IKCService, KCService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IUnitRepository, UnitDatabaseRepository>();
            services.AddScoped<IAssessmentEventRepository, AssessmentEventDatabaseRepository>();

            services.AddScoped<IInstructor, DefaultInstructor>();

            services.AddScoped<ILearnerService, LearnerService>();
            services.Configure<WorkspaceOptions>(Configuration.GetSection(WorkspaceOptions.ConfigKey));
            services.AddScoped<IWorkspaceCreator, NoWorkspaceCreator>();
            services.AddScoped<ILearnerRepository, LearnerDatabaseRepository>();

            services.AddScoped<ISubmissionService, SubmissionService>();
            services.AddScoped<ISubmissionRepository, SubmissionDatabaseRepository>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IFeedbackRepository, FeedbackDatabaseRepository>();

            services.AddScoped<IAuthProvider, KeycloakAuthProvider>();

            if (!bool.Parse(Environment.GetEnvironmentVariable("KEYCLOAK_ON") ?? "false")) return;
            AuthenticationConfig(services);
            AuthorizationConfig(services);
        }

        private static void AuthorizationConfig(IServiceCollection services)
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

        private void AuthenticationConfig(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = Environment.GetEnvironmentVariable("AUTHORITY") ?? "http://localhost:8080/auth/realms/master";
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

                        return failedContext.Response.WriteAsync(Env.IsDevelopment() ? 
                            failedContext.Exception.ToString() : 
                            "An error occured processing your authentication.");
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
            var corsOrigins = new [] { "http://localhost:4200" };
            var corsOriginsPath = EnvironmentConnection.GetSecret("SMART_TUTOR_CORS_ORIGINS");
            if (File.Exists(corsOriginsPath))
            {
                corsOrigins = File.ReadAllLines(corsOriginsPath);
            }

            return corsOrigins;
        }
    }
}