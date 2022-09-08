using Dahomey.Json;
using Dahomey.Json.Serialization.Conventions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.DomainModel;
using Tutor.Core.LearnerModel;
using Tutor.Core.LearnerModel.DomainOverlay;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.MoveOn;
using Tutor.Core.LearnerModel.Feedback;
using Tutor.Core.LearnerModel.Notes;
using Tutor.Infrastructure;
using Tutor.Infrastructure.Database.EventStore.DefaultEventSerializer;
using Tutor.Infrastructure.Database.Repositories;
using Tutor.Infrastructure.Database.Repositories.Domain;
using Tutor.Infrastructure.Database.Repositories.Learners;
using Tutor.Infrastructure.Security;
using Tutor.Infrastructure.Security.Authentication;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.ArrangeTasks;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.Challenges;
using Tutor.Web.Controllers.Domain.DTOs.AssessmentItems.MultiResponseQuestions;
using Tutor.Web.Controllers.Domain.DTOs.InstructionalItems;

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
                registry.RegisterType<AtDto>();
                registry.RegisterType<ChallengeDto>();
                registry.RegisterType<ImageDto>();
                registry.RegisterType<MrqDto>();
                registry.RegisterType<TextDto>();
                registry.RegisterType<VideoDto>();

                registry.RegisterConvention(new AllowedTypesDiscriminatorConvention<string>(
                    serializerOptions, EventConfiguration.SerializationConfiguration, "$discriminator"));
                foreach (var type in EventConfiguration.SerializationConfiguration.Keys)
                {
                    registry.RegisterType(type);
                }
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

            services.AddScoped<IKnowledgeUnitRepository, KnowledgeUnitDatabaseRepository>();

            services.AddScoped<IKcMasteryService, KcMasteryService>();
            services.AddScoped<IKcMasteryRepository, KcMasteryDatabaseRepository>();
            services.AddScoped<ILearnerAssessmentService, LearnerAssessmentService>();
            services.AddScoped<IAssessmentItemSelector, LeastCorrectAssessmentItemSelector>();

            services.AddScoped<ILearnerService, LearnerService>();
            services.AddScoped<ILearnerRepository, LearnerDatabaseRepository>();

            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IFeedbackRepository, FeedbackDatabaseRepository>();

            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<INoteService, NoteService>();

            SetupAuth(services);

            SetupMoveOn(services);
        }

        private void SetupMoveOn(IServiceCollection services)
        {
            var moveOnCriteria = Configuration.GetValue<string>("MoveOn");
            var moveOnType = MoveOnResolver.ResolveOrDefault(moveOnCriteria);
            services.AddScoped(typeof(IMoveOnCriteria), moveOnType);
        }

        private static void SetupAuth(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserRepository, UserDatabaseRepository>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("administratorPolicy", policy => policy.RequireRole("administrator"));
                options.AddPolicy("instructorPolicy", policy => policy.RequireRole("instructor"));
                options.AddPolicy("learnerPolicy", policy => policy.RequireRole("learner"));
            });

            var key = EnvironmentConnection.GetSecret("JWT_KEY") ?? "tutor_secret_key";
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
            var corsOrigins = new[] { "http://localhost:4200" };
            var corsOriginsPath = EnvironmentConnection.GetSecret("SMART_TUTOR_CORS_ORIGINS");
            if (File.Exists(corsOriginsPath))
            {
                corsOrigins = File.ReadAllLines(corsOriginsPath);
            }

            return corsOrigins;
        }
    }
}