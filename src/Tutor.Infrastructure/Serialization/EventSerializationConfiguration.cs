using Dahomey.Json;
using System;
using System.Collections.Generic;
using System.Text.Json;
using Tutor.Core.DomainModel.AssessmentItems.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentItems.Challenges;
using Tutor.Core.DomainModel.AssessmentItems.MultiResponseQuestions;
using Tutor.Core.DomainModel.AssessmentItems.ShortAnswerQuestions;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.KnowledgeComponentEvents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.SessionLifecycleEvents;

namespace Tutor.Infrastructure.Serialization
{
    public static class EventSerializationConfiguration
    {
        private static readonly IDictionary<Type, string> EventRelatedTypes = new Dictionary<Type, string>
        {
            { typeof(AssessmentItemAnswered), "AssessmentItemAnswered" },
            { typeof(SoughtHints), "SoughtChallengeHints" },
            { typeof(SoughtSolution), "SoughtChallengeSolution" },
            { typeof(KnowledgeComponentStarted), "KnowledgeComponentStarted" },
            { typeof(KnowledgeComponentPassed), "KnowledgeComponentPassed" },
            { typeof(KnowledgeComponentCompleted), "KnowledgeComponentCompleted" },
            { typeof(KnowledgeComponentSatisfied), "KnowledgeComponentSatisfied" },
            { typeof(AssessmentItemSelected), "AssessmentItemSelected" },
            { typeof(SessionLaunched), "SessionLaunched" },
            { typeof(SessionTerminated), "SessionTerminated" },
            { typeof(SessionAbandoned), "SessionAbandoned" },
            { typeof(InstructionalItemsSelected), "InstructionalItemsSelected" },
            { typeof(InstructorMessageEvent), "InstructorMessageEvent" },
            #region Submissions
            { typeof(ArrangeTaskSubmission), "ArrangeTaskSubmission" },
            { typeof(ChallengeSubmission), "ChallengeSubmission" },
            { typeof(MrqSubmission), "MrqSubmission" },
            { typeof(SaqSubmission), "SaqSubmission" },
            #endregion
            #region Evaluations
            { typeof(ArrangeTaskEvaluation), "ArrangeTaskEvaluation" },
            { typeof(ChallengeEvaluation), "ChallengeEvaluation" },
            { typeof(MrqEvaluation), "MrqEvaluation" },
            { typeof(SaqEvaluation), "SaqEvaluation" }
            #endregion
        };

        public static JsonSerializerOptions SetupEvents(this JsonSerializerOptions options)
        {
            var registry = options.GetDiscriminatorConventionRegistry();
            registry.RegisterConvention(new AllowedTypesDiscriminatorConvention<string>(options, EventRelatedTypes, "$discriminator"));

            foreach (var type in EventRelatedTypes.Keys)
            {
                registry.RegisterType(type);
            }

            return options;
        }

        public static JsonSerializerOptions GetEventSerializerOptions()
        {
            var options = new JsonSerializerOptions();
            options.SetupExtensions();
            options.GetDiscriminatorConventionRegistry().ClearConventions();
            options.SetupEvents();

            return options;
        }
    }
}
