using System.Collections.Immutable;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.MultiChoiceQuestions;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.ShortAnswerQuestions;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.AssessmentItemEvents;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.KnowledgeComponentEvents;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.SessionLifecycleEvents;

namespace Tutor.KnowledgeComponents.Infrastructure.Database.EventStore;

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
        { typeof(SessionPaused), "SessionPaused"},
        { typeof(SessionContinued), "SessionContinued"},
        { typeof(InstructionalItemsSelected), "InstructionalItemsSelected" },
        { typeof(EncouragingMessageSent), "EncouragingMessageSent" },
        #region Submissions
        { typeof(MrqSubmission), "MrqSubmission" },
        { typeof(SaqSubmission), "SaqSubmission" },
        { typeof(McqSubmission), "McqSubmission"},
        #endregion
        #region Evaluations
        { typeof(MrqEvaluation), "MrqEvaluation" },
        { typeof(SaqEvaluation), "SaqEvaluation" },
        { typeof(McqEvaluation), "McqEvaluation"}
        #endregion
    }.ToImmutableDictionary();
}