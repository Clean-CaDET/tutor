using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.MultiChoiceQuestions;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.ShortAnswerQuestions;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.AssessmentItemEvents;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.KnowledgeComponentEvents;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.SessionLifecycleEvents;

namespace Tutor.KnowledgeComponents.Infrastructure.Database.EventStore;

public class EventSerializationConfiguration : DefaultJsonTypeInfoResolver
{
    public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
    {
        var jsonTypeInfo = base.GetTypeInfo(type, options);

        var baseType = typeof(DomainEvent);
        if (jsonTypeInfo.Type == baseType)
        {
            jsonTypeInfo.PolymorphismOptions = new JsonPolymorphismOptions
            {
                TypeDiscriminatorPropertyName = "$type",
                IgnoreUnrecognizedTypeDiscriminators = true,
                UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization,
                DerivedTypes =
                {
                    new JsonDerivedType(typeof(AssessmentItemAnswered), "AssessmentItemAnswered"),
                    new JsonDerivedType(typeof(HintsRequested), "HintsRequested"),
                    new JsonDerivedType(typeof(SolutionRequested), "SolutionRequested"),
                    new JsonDerivedType(typeof(KnowledgeComponentStarted), "KnowledgeComponentStarted"),
                    new JsonDerivedType(typeof(KnowledgeComponentPassed), "KnowledgeComponentPassed"),
                    new JsonDerivedType(typeof(KnowledgeComponentCompleted), "KnowledgeComponentCompleted"),
                    new JsonDerivedType(typeof(KnowledgeComponentSatisfied), "KnowledgeComponentSatisfied"),
                    new JsonDerivedType(typeof(SessionLaunched), "SessionLaunched"),
                    new JsonDerivedType(typeof(SessionTerminated), "SessionTerminated"),
                    new JsonDerivedType(typeof(SessionAbandoned), "SessionAbandoned"),
                    new JsonDerivedType(typeof(SessionPaused), "SessionPaused"),
                    new JsonDerivedType(typeof(SessionContinued), "SessionContinued"),
                    new JsonDerivedType(typeof(InstructionalItemsSelected), "InstructionalItemsSelected"),
                    new JsonDerivedType(typeof(EncouragingMessageSent), "EncouragingMessageSent"),
                    #region Submissions
                    new JsonDerivedType(typeof(MrqSubmission), "MrqSubmission"),
                    new JsonDerivedType(typeof(SaqSubmission), "SaqSubmission"),
                    new JsonDerivedType(typeof(McqSubmission), "McqSubmission"),
                    #endregion
                    #region Evaluations
                    new JsonDerivedType(typeof(MrqEvaluation), "MrqEvaluation"),
                    new JsonDerivedType(typeof(SaqEvaluation), "SaqEvaluation"),
                    new JsonDerivedType(typeof(McqEvaluation), "McqEvaluation")
                    #endregion
                }
            };
        }

        return jsonTypeInfo;
    }
}