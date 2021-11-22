using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Tutor.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArrangeTaskSubmissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArrangeTaskId = table.Column<int>(type: "integer", nullable: false),
                    LearnerId = table.Column<int>(type: "integer", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArrangeTaskSubmissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KnowledgeComponentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChallengeHints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeHints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChallengeSubmissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SourceCode = table.Column<string[]>(type: "text[]", nullable: true),
                    ChallengeId = table.Column<int>(type: "integer", nullable: false),
                    LearnerId = table.Column<int>(type: "integer", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeSubmissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstructionalEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KnowledgeComponentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructionalEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KCMastery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Mastery = table.Column<double>(type: "double precision", nullable: false),
                    KnowledgeComponentId = table.Column<int>(type: "integer", nullable: false),
                    LearnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KCMastery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Learners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentIndex = table.Column<string>(type: "text", nullable: true),
                    WorkspacePath = table.Column<string>(type: "text", nullable: true),
                    IamId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Learners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LearningObjectFeedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    LearnerId = table.Column<int>(type: "integer", nullable: false),
                    LearningObjectId = table.Column<int>(type: "integer", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningObjectFeedback", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionSubmissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubmittedAnswerIds = table.Column<List<int>>(type: "integer[]", nullable: true),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    LearnerId = table.Column<int>(type: "integer", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionSubmissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArrangeTaskContainerSubmissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContainerId = table.Column<int>(type: "integer", nullable: false),
                    ElementIds = table.Column<List<int>>(type: "integer[]", nullable: true),
                    ArrangeTaskSubmissionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArrangeTaskContainerSubmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArrangeTaskContainerSubmissions_ArrangeTaskSubmissions_Arra~",
                        column: x => x.ArrangeTaskSubmissionId,
                        principalTable: "ArrangeTaskSubmissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArrangeTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArrangeTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArrangeTasks_AssessmentEvents_Id",
                        column: x => x.Id,
                        principalTable: "AssessmentEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    TestSuiteLocation = table.Column<string>(type: "text", nullable: true),
                    SolutionUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Challenges_AssessmentEvents_Id",
                        column: x => x.Id,
                        principalTable: "AssessmentEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultiResponseQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiResponseQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultiResponseQuestions_AssessmentEvents_Id",
                        column: x => x.Id,
                        principalTable: "AssessmentEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Caption = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_InstructionalEvents_Id",
                        column: x => x.Id,
                        principalTable: "InstructionalEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Texts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Texts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Texts_InstructionalEvents_Id",
                        column: x => x.Id,
                        principalTable: "InstructionalEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_InstructionalEvents_Id",
                        column: x => x.Id,
                        principalTable: "InstructionalEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UnitId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnowledgeComponents_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArrangeTaskContainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArrangeTaskId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArrangeTaskContainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArrangeTaskContainers_ArrangeTasks_ArrangeTaskId",
                        column: x => x.ArrangeTaskId,
                        principalTable: "ArrangeTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChallengeFulfillmentStrategies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodeSnippetId = table.Column<string>(type: "text", nullable: true),
                    ChallengeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeFulfillmentStrategies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChallengeFulfillmentStrategies_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MRQAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    Feedback = table.Column<string>(type: "text", nullable: true),
                    MRQContainerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRQAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MRQAnswers_MultiResponseQuestions_MRQContainerId",
                        column: x => x.MRQContainerId,
                        principalTable: "MultiResponseQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArrangeTaskElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArrangeTaskContainerId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArrangeTaskElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArrangeTaskElements_ArrangeTaskContainers_ArrangeTaskContai~",
                        column: x => x.ArrangeTaskContainerId,
                        principalTable: "ArrangeTaskContainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasicMetricCheckers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicMetricCheckers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasicMetricCheckers_ChallengeFulfillmentStrategies_Id",
                        column: x => x.Id,
                        principalTable: "ChallengeFulfillmentStrategies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasicNameCheckers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BannedWords = table.Column<List<string>>(type: "text[]", nullable: true),
                    RequiredWords = table.Column<List<string>>(type: "text[]", nullable: true),
                    HintId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicNameCheckers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasicNameCheckers_ChallengeFulfillmentStrategies_Id",
                        column: x => x.Id,
                        principalTable: "ChallengeFulfillmentStrategies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasicNameCheckers_ChallengeHints_HintId",
                        column: x => x.HintId,
                        principalTable: "ChallengeHints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MetricRangeRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MetricName = table.Column<string>(type: "text", nullable: true),
                    FromValue = table.Column<double>(type: "double precision", nullable: false),
                    ToValue = table.Column<double>(type: "double precision", nullable: false),
                    HintId = table.Column<int>(type: "integer", nullable: true),
                    MetricCheckerForeignKey = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetricRangeRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetricRangeRules_BasicMetricCheckers_MetricCheckerForeignKey",
                        column: x => x.MetricCheckerForeignKey,
                        principalTable: "BasicMetricCheckers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MetricRangeRules_ChallengeHints_HintId",
                        column: x => x.HintId,
                        principalTable: "ChallengeHints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArrangeTaskContainers_ArrangeTaskId",
                table: "ArrangeTaskContainers",
                column: "ArrangeTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ArrangeTaskContainerSubmissions_ArrangeTaskSubmissionId",
                table: "ArrangeTaskContainerSubmissions",
                column: "ArrangeTaskSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ArrangeTaskElements_ArrangeTaskContainerId",
                table: "ArrangeTaskElements",
                column: "ArrangeTaskContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_BasicNameCheckers_HintId",
                table: "BasicNameCheckers",
                column: "HintId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeFulfillmentStrategies_ChallengeId",
                table: "ChallengeFulfillmentStrategies",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeComponents_UnitId",
                table: "KnowledgeComponents",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MetricRangeRules_HintId",
                table: "MetricRangeRules",
                column: "HintId");

            migrationBuilder.CreateIndex(
                name: "IX_MetricRangeRules_MetricCheckerForeignKey",
                table: "MetricRangeRules",
                column: "MetricCheckerForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_MRQAnswers_MRQContainerId",
                table: "MRQAnswers",
                column: "MRQContainerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArrangeTaskContainerSubmissions");

            migrationBuilder.DropTable(
                name: "ArrangeTaskElements");

            migrationBuilder.DropTable(
                name: "BasicNameCheckers");

            migrationBuilder.DropTable(
                name: "ChallengeSubmissions");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "KCMastery");

            migrationBuilder.DropTable(
                name: "KnowledgeComponents");

            migrationBuilder.DropTable(
                name: "Learners");

            migrationBuilder.DropTable(
                name: "LearningObjectFeedback");

            migrationBuilder.DropTable(
                name: "MetricRangeRules");

            migrationBuilder.DropTable(
                name: "MRQAnswers");

            migrationBuilder.DropTable(
                name: "QuestionSubmissions");

            migrationBuilder.DropTable(
                name: "Texts");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "ArrangeTaskSubmissions");

            migrationBuilder.DropTable(
                name: "ArrangeTaskContainers");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "BasicMetricCheckers");

            migrationBuilder.DropTable(
                name: "ChallengeHints");

            migrationBuilder.DropTable(
                name: "MultiResponseQuestions");

            migrationBuilder.DropTable(
                name: "InstructionalEvents");

            migrationBuilder.DropTable(
                name: "ArrangeTasks");

            migrationBuilder.DropTable(
                name: "ChallengeFulfillmentStrategies");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "AssessmentEvents");
        }
    }
}
