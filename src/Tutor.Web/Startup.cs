using Dahomey.Json;
using Dahomey.Json.Serialization.Conventions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.Domain.KnowledgeMastery.DomainServices;
using Tutor.Core.Domain.KnowledgeMastery.MoveOn;
using Tutor.Core.Domain.LearningUtilities;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;
using Tutor.Core.UseCases.KnowledgeAnalysis;
using Tutor.Core.UseCases.Learning;
using Tutor.Core.UseCases.Learning.Assessment;
using Tutor.Core.UseCases.Learning.Utilities;
using Tutor.Core.UseCases.Management.Courses;
using Tutor.Core.UseCases.Management.Groups;
using Tutor.Core.UseCases.Management.Knowledge;
using Tutor.Core.UseCases.Management.Stakeholders;
using Tutor.Core.UseCases.Monitoring;
using Tutor.Infrastructure;
using Tutor.Infrastructure.Database;
using Tutor.Infrastructure.Database.EventStore;
using Tutor.Infrastructure.Database.EventStore.DefaultEventSerializer;
using Tutor.Infrastructure.Database.Repositories;
using Tutor.Infrastructure.Database.Repositories.CourseIteration;
using Tutor.Infrastructure.Database.Repositories.Knowledge;
using Tutor.Infrastructure.Database.Repositories.LearningUtilities;
using Tutor.Infrastructure.Database.Repositories.Stakeholders;
using Tutor.Infrastructure.Security;
using Tutor.Infrastructure.Security.Authentication;
using Tutor.Web.Extensions;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ArrangeTasks;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.Challenges;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiChoiceQuestions;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiResponseQuestions;
using Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.ShortAnswerQuestions;
using Tutor.Web.Mappings.Knowledge.DTOs.InstructionalItems;

namespace Tutor.Web;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    private const string CorsPolicy = "_corsPolicy";

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddInfrastructure(Configuration);

        SetupControllers(services);
        SetupServices(services);
        SetupRepositories(services);
    }

    #region Controller Setup
    private void SetupControllers(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Startup));
        services.AddControllers().AddJsonOptions(SetupJsonOptions);

        SetupOpenApi(services);

        services.AddCors(options =>
        {
            options.AddPolicy(name: CorsPolicy,
                builder =>
                {
                    builder.WithOrigins(ParseCorsOrigins())
                        .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization, "access_token")
                        .WithMethods("GET", "PUT", "POST", "PATCH", "DELETE", "OPTIONS");
                });
        });
        SetupAuth(services);
    }

    private static void SetupJsonOptions(JsonOptions options)
    {
        var serializerOptions = options.JsonSerializerOptions;
        serializerOptions.SetupExtensions();
        var registry = serializerOptions.GetDiscriminatorConventionRegistry();
        registry.ClearConventions();
        registry.RegisterConvention(
            new DefaultDiscriminatorConvention<string>(serializerOptions, "typeDiscriminator"));
        
        #region Assesment Items
        registry.RegisterType<AtDto>();
        registry.RegisterType<ChallengeDto>();
        registry.RegisterType<McqDto>();
        registry.RegisterType<MrqDto>();
        registry.RegisterType<SaqDto>();
        #endregion
        
        #region Assesment Item Submissions
        registry.RegisterType<AtSubmissionDto>();
        registry.RegisterType<ChallengeSubmissionDto>();
        registry.RegisterType<McqSubmissionDto>();
        registry.RegisterType<MrqSubmissionDto>();
        registry.RegisterType<SaqSubmissionDto>();
        #endregion

        #region Instructional Items
        registry.RegisterType<ImageDto>();
        registry.RegisterType<TextDto>();
        registry.RegisterType<VideoDto>();
        #endregion

        registry.RegisterConvention(new AllowedTypesDiscriminatorConvention<string>(
            serializerOptions, EventSerializationConfiguration.EventRelatedTypes, "$discriminator"));
        foreach (var type in EventSerializationConfiguration.EventRelatedTypes.Keys)
        {
            registry.RegisterType(type);
        }
    }

    private void SetupOpenApi(IServiceCollection services)
    {
        var contactAddress = Configuration.GetValue<string>("ContactUrl");
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
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };
            setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { jwtSecurityScheme, Array.Empty<string>() }
            });
        });
    }

    private static void SetupAuth(IServiceCollection services)
    {
        services.AddProxiedScoped<IAuthenticationService, AuthenticationService>();
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
    #endregion

    #region Service Setup
    private void SetupServices(IServiceCollection services)
    {
        SetupLearningServices(services);
        SetupManagementServices(services);

        services.AddProxiedScoped<IUnitAnalysisService, UnitAnalysisService>();
    }

    private void SetupLearningServices(IServiceCollection services)
    {
        services.AddProxiedScoped<ISessionService, SessionService>();
        services.AddProxiedScoped<IStructureService, StructureService>();
        services.AddProxiedScoped<IStatisticsService, StatisticsService>();
        services.AddProxiedScoped<ISelectionService, SelectionService>();
        services.AddProxiedScoped<IEvaluationService, EvaluationService>();
        services.AddProxiedScoped<IHelpService, HelpService>();

        services.AddProxiedScoped<IFeedbackService, FeedbackService>();
        services.AddProxiedScoped<INoteService, NoteService>();

        services.AddProxiedScoped<IGroupMonitoringService, GroupMonitoringService>();
        // The domain services below should be selected from a configuration file or some other configurable mechanism.
        services.AddScoped<IAssessmentItemSelector, LeastCorrectAssessmentItemSelector>();
        services.AddScoped<IAssessmentFeedbackGenerator, RuleAssessmentFeedbackGenerator>();
        SetupMoveOn(services);
    }

    private void SetupMoveOn(IServiceCollection services)
    {
        var moveOnCriteria = Configuration.GetValue<string>("MoveOn");
        var moveOnType = MoveOnResolver.ResolveOrDefault(moveOnCriteria);
        services.AddScoped(typeof(IMoveOnCriteria), moveOnType);
    }

    private static void SetupManagementServices(IServiceCollection services)
    {
        services.AddProxiedScoped<ICourseService, CourseService>();
        services.AddProxiedScoped<IUnitService, UnitService>();
        services.AddProxiedScoped<IKnowledgeComponentService, KnowledgeComponentService>();
        services.AddProxiedScoped<IInstructionService, InstructionService>();
        services.AddProxiedScoped<IAssessmentService, AssessmentService>();

        services.AddProxiedScoped<ICourseOwnershipService, CourseOwnershipService>();
        services.AddProxiedScoped<ILearnerService, LearnerService>();
        services.AddProxiedScoped<IInstructorService, InstructorService>();
        
        services.AddProxiedScoped<ILearnerGroupService, LearnerGroupService>();
        services.AddProxiedScoped<IEnrollmentService, EnrollmentService>();
    }
    #endregion

    #region Repository Setup
    private static void SetupRepositories(IServiceCollection services)
    {
        services.AddScoped(typeof(ICrudRepository<>), typeof(CrudDatabaseRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IKnowledgeComponentRepository, KnowledgeComponentDatabaseRepository>();
        services.AddScoped<IAssessmentItemRepository, AssessmentItemDatabaseRepository>();
        services.AddScoped<IKnowledgeMasteryRepository, KnowledgeMasteryDatabaseRepository>();
        services.AddScoped<IFeedbackRepository, FeedbackDatabaseRepository>();
        services.AddScoped<INoteRepository, NoteRepository>();

        services.AddScoped<ICourseRepository, CourseDatabaseRepository>();
        services.AddScoped<IUnitRepository, UnitDatabaseRepository>();
        services.AddScoped<ILearnerRepository, LearnerDatabaseRepository>();
        services.AddScoped<IOwnedCourseRepository, OwnedCourseDatabaseRepository>();
        services.AddScoped<IGroupRepository, GroupDatabaseRepository>();
        services.AddScoped<IEnrollmentRepository, EnrollmentDatabaseRepository>();

        services.AddSingleton<IEventSerializer>(
            new DefaultEventSerializer(EventSerializationConfiguration.EventRelatedTypes));
    }
    #endregion

    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler("/error");
        }
        app.UseCors(CorsPolicy);
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}