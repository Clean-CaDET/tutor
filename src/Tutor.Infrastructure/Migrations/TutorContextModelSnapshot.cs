﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tutor.Infrastructure.Database;

namespace Tutor.Infrastructure.Migrations
{
    [DbContext(typeof(TutorContext))]
    partial class TutorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks.ArrangeTaskContainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ArrangeTaskId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArrangeTaskId");

                    b.ToTable("ArrangeTaskContainers");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks.ArrangeTaskContainerSubmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ArrangeTaskContainerId")
                        .HasColumnType("integer");

                    b.Property<List<int>>("ElementIds")
                        .HasColumnType("integer[]");

                    b.Property<int>("SubmissionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubmissionId");

                    b.ToTable("ArrangeTaskContainerSubmissions");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks.ArrangeTaskElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ArrangeTaskContainerId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArrangeTaskContainerId");

                    b.ToTable("ArrangeTaskElements");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.AssessmentEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("KnowledgeComponentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("AssessmentEvents");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.Challenges.ChallengeHint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ChallengeHints");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.ChallengeFulfillmentStrategy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ChallengeId")
                        .HasColumnType("integer");

                    b.Property<string>("CodeSnippetId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeId");

                    b.ToTable("ChallengeFulfillmentStrategies");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.MetricChecker.MetricRangeRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("FromValue")
                        .HasColumnType("double precision");

                    b.Property<int?>("HintId")
                        .HasColumnType("integer");

                    b.Property<int?>("MetricCheckerForeignKey")
                        .HasColumnType("integer");

                    b.Property<string>("MetricName")
                        .HasColumnType("text");

                    b.Property<double>("ToValue")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("HintId");

                    b.HasIndex("MetricCheckerForeignKey");

                    b.ToTable("MetricRangeRules");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions.MRQItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Feedback")
                        .HasColumnType("text");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<int>("MRQId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MRQId");

                    b.ToTable("MRQItems");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.Submission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AssessmentEventId")
                        .HasColumnType("integer");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<int>("LearnerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Submissions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Submission");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.InstructionalEvents.InstructionalEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("KnowledgeComponentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("InstructionalEvents");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.KnowledgeComponents.KnowledgeComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("UnitId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("KnowledgeComponents");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.KnowledgeComponents.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Tutor.Core.LearnerModel.Learners.KnowledgeComponentMastery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("KnowledgeComponentId")
                        .HasColumnType("integer");

                    b.Property<int>("LearnerId")
                        .HasColumnType("integer");

                    b.Property<double>("Mastery")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("KCMastery");
                });

            modelBuilder.Entity("Tutor.Core.LearnerModel.Learners.Learner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("IamId")
                        .HasColumnType("text");

                    b.Property<string>("StudentIndex")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Learners");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks.ArrangeTask", b =>
                {
                    b.HasBaseType("Tutor.Core.DomainModel.AssessmentEvents.AssessmentEvent");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.ToTable("ArrangeTasks");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.Challenges.Challenge", b =>
                {
                    b.HasBaseType("Tutor.Core.DomainModel.AssessmentEvents.AssessmentEvent");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("SolutionUrl")
                        .HasColumnType("text");

                    b.Property<string>("TestSuiteLocation")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions.MRQ", b =>
                {
                    b.HasBaseType("Tutor.Core.DomainModel.AssessmentEvents.AssessmentEvent");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.ToTable("MultiResponseQuestions");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.MetricChecker.BasicMetricChecker", b =>
                {
                    b.HasBaseType("Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.ChallengeFulfillmentStrategy");

                    b.ToTable("BasicMetricCheckers");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.NameChecker.BasicNameChecker", b =>
                {
                    b.HasBaseType("Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.ChallengeFulfillmentStrategy");

                    b.Property<List<string>>("BannedWords")
                        .HasColumnType("text[]");

                    b.Property<int?>("HintId")
                        .HasColumnType("integer");

                    b.Property<List<string>>("RequiredWords")
                        .HasColumnType("text[]");

                    b.HasIndex("HintId");

                    b.ToTable("BasicNameCheckers");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks.ArrangeTaskSubmission", b =>
                {
                    b.HasBaseType("Tutor.Core.DomainModel.AssessmentEvents.Submission");

                    b.HasDiscriminator().HasValue("ArrangeTaskSubmission");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.Challenges.ChallengeSubmission", b =>
                {
                    b.HasBaseType("Tutor.Core.DomainModel.AssessmentEvents.Submission");

                    b.Property<string[]>("SourceCode")
                        .HasColumnType("text[]");

                    b.HasDiscriminator().HasValue("ChallengeSubmission");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions.MRQSubmission", b =>
                {
                    b.HasBaseType("Tutor.Core.DomainModel.AssessmentEvents.Submission");

                    b.Property<List<int>>("SubmittedAnswerIds")
                        .HasColumnType("integer[]");

                    b.HasDiscriminator().HasValue("MRQSubmission");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.InstructionalEvents.Image", b =>
                {
                    b.HasBaseType("Tutor.Core.DomainModel.InstructionalEvents.InstructionalEvent");

                    b.Property<string>("Caption")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.InstructionalEvents.Text", b =>
                {
                    b.HasBaseType("Tutor.Core.DomainModel.InstructionalEvents.InstructionalEvent");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.ToTable("Texts");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.InstructionalEvents.Video", b =>
                {
                    b.HasBaseType("Tutor.Core.DomainModel.InstructionalEvents.InstructionalEvent");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks.ArrangeTaskContainer", b =>
                {
                    b.HasOne("Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks.ArrangeTask", null)
                        .WithMany("Containers")
                        .HasForeignKey("ArrangeTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks.ArrangeTaskContainerSubmission", b =>
                {
                    b.HasOne("Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks.ArrangeTaskSubmission", null)
                        .WithMany("Containers")
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks.ArrangeTaskElement", b =>
                {
                    b.HasOne("Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks.ArrangeTaskContainer", null)
                        .WithMany("Elements")
                        .HasForeignKey("ArrangeTaskContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.ChallengeFulfillmentStrategy", b =>
                {
                    b.HasOne("Tutor.Core.DomainModel.AssessmentEvents.Challenges.Challenge", null)
                        .WithMany("FulfillmentStrategies")
                        .HasForeignKey("ChallengeId");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.MetricChecker.MetricRangeRule", b =>
                {
                    b.HasOne("Tutor.Core.DomainModel.AssessmentEvents.Challenges.ChallengeHint", "Hint")
                        .WithMany()
                        .HasForeignKey("HintId");

                    b.HasOne("Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.MetricChecker.BasicMetricChecker", null)
                        .WithMany("MetricRanges")
                        .HasForeignKey("MetricCheckerForeignKey");

                    b.Navigation("Hint");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions.MRQItem", b =>
                {
                    b.HasOne("Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions.MRQ", null)
                        .WithMany("Items")
                        .HasForeignKey("MRQId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.KnowledgeComponents.KnowledgeComponent", b =>
                {
                    b.HasOne("Tutor.Core.DomainModel.KnowledgeComponents.Unit", null)
                        .WithMany("KnowledgeComponents")
                        .HasForeignKey("UnitId");
                });

            modelBuilder.Entity("Tutor.Core.LearnerModel.Learners.Learner", b =>
                {
                    b.OwnsOne("Tutor.Core.LearnerModel.Workspaces.Workspace", "Workspace", b1 =>
                        {
                            b1.Property<int>("LearnerId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<string>("Path")
                                .HasColumnType("text")
                                .HasColumnName("WorkspacePath");

                            b1.HasKey("LearnerId");

                            b1.ToTable("Learners");

                            b1.WithOwner()
                                .HasForeignKey("LearnerId");
                        });

                    b.Navigation("Workspace");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks.ArrangeTask", b =>
                {
                    b.HasOne("Tutor.Core.DomainModel.AssessmentEvents.AssessmentEvent", null)
                        .WithOne()
                        .HasForeignKey("Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks.ArrangeTask", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.Challenges.Challenge", b =>
                {
                    b.HasOne("Tutor.Core.DomainModel.AssessmentEvents.AssessmentEvent", null)
                        .WithOne()
                        .HasForeignKey("Tutor.Core.DomainModel.AssessmentEvents.Challenges.Challenge", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions.MRQ", b =>
                {
                    b.HasOne("Tutor.Core.DomainModel.AssessmentEvents.AssessmentEvent", null)
                        .WithOne()
                        .HasForeignKey("Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions.MRQ", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.MetricChecker.BasicMetricChecker", b =>
                {
                    b.HasOne("Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.ChallengeFulfillmentStrategy", null)
                        .WithOne()
                        .HasForeignKey("Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.MetricChecker.BasicMetricChecker", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.NameChecker.BasicNameChecker", b =>
                {
                    b.HasOne("Tutor.Core.DomainModel.AssessmentEvents.Challenges.ChallengeHint", "Hint")
                        .WithMany()
                        .HasForeignKey("HintId");

                    b.HasOne("Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.ChallengeFulfillmentStrategy", null)
                        .WithOne()
                        .HasForeignKey("Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.NameChecker.BasicNameChecker", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hint");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.InstructionalEvents.Image", b =>
                {
                    b.HasOne("Tutor.Core.DomainModel.InstructionalEvents.InstructionalEvent", null)
                        .WithOne()
                        .HasForeignKey("Tutor.Core.DomainModel.InstructionalEvents.Image", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.InstructionalEvents.Text", b =>
                {
                    b.HasOne("Tutor.Core.DomainModel.InstructionalEvents.InstructionalEvent", null)
                        .WithOne()
                        .HasForeignKey("Tutor.Core.DomainModel.InstructionalEvents.Text", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.InstructionalEvents.Video", b =>
                {
                    b.HasOne("Tutor.Core.DomainModel.InstructionalEvents.InstructionalEvent", null)
                        .WithOne()
                        .HasForeignKey("Tutor.Core.DomainModel.InstructionalEvents.Video", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks.ArrangeTaskContainer", b =>
                {
                    b.Navigation("Elements");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.KnowledgeComponents.Unit", b =>
                {
                    b.Navigation("KnowledgeComponents");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks.ArrangeTask", b =>
                {
                    b.Navigation("Containers");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.Challenges.Challenge", b =>
                {
                    b.Navigation("FulfillmentStrategies");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions.MRQ", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.MetricChecker.BasicMetricChecker", b =>
                {
                    b.Navigation("MetricRanges");
                });

            modelBuilder.Entity("Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks.ArrangeTaskSubmission", b =>
                {
                    b.Navigation("Containers");
                });
#pragma warning restore 612, 618
        }
    }
}
