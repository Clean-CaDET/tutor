using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Tutor.Core.DomainModel.AssessmentItems.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentItems.Challenges;
using Tutor.Core.DomainModel.AssessmentItems.MultiChoiceQuestions;
using Tutor.Core.DomainModel.AssessmentItems.MultiResponseQuestions;
using Tutor.Core.DomainModel.AssessmentItems.ShortAnswerQuestions;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.KnowledgeComponentEvents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.SessionLifecycleEvents;

namespace Tutor.Infrastructure.EventConfiguration
{
    public static class EventSerializationConfiguration
    {
        public static readonly IImmutableDictionary<Type, string> EventRelatedTypes = new Dictionary<Type, string>
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
            { typeof(EncouragingMessageSent), "EncouragingMessageSent" },
            #region Submissions
            { typeof(ArrangeTaskSubmission), "ArrangeTaskSubmission" },
            { typeof(ChallengeSubmission), "ChallengeSubmission" },
            { typeof(MrqSubmission), "MrqSubmission" },
            { typeof(SaqSubmission), "SaqSubmission" },
            { typeof(McqSubmission), "McqSubmission"},
            #endregion
            #region Evaluations
            { typeof(ArrangeTaskEvaluation), "ArrangeTaskEvaluation" },
            { typeof(ChallengeEvaluation), "ChallengeEvaluation" },
            { typeof(MrqEvaluation), "MrqEvaluation" },
            { typeof(SaqEvaluation), "SaqEvaluation" },
            { typeof(McqEvaluation), "McqEvaluation"}
            #endregion
        }.ToImmutableDictionary();
    }
}
