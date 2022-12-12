using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Tutor.Core.Domain.Knowledge.AssessmentItems.ArrangeTasks;
using Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges;
using Tutor.Core.Domain.Knowledge.AssessmentItems.MultiChoiceQuestions;
using Tutor.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.Core.Domain.Knowledge.AssessmentItems.ShortAnswerQuestions;
using Tutor.Core.Domain.KnowledgeMastery.Events.AssessmentItemEvents;
using Tutor.Core.Domain.KnowledgeMastery.Events.KnowledgeComponentEvents;
using Tutor.Core.Domain.KnowledgeMastery.Events.SessionLifecycleEvents;

namespace Tutor.Infrastructure.Database.EventStore;

public static class EventSerializationConfiguration
{
    public static readonly IImmutableDictionary<Type, string> EventRelatedTypes = new Dictionary<Type, string>
    {
        { typeof(AssessmentItemAnswered), "AssessmentItemAnswered" },
        { typeof(HintsRequested), "HintsRequested" },
        { typeof(SolutionRequested), "SolutionRequested" },
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