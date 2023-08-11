using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Public.Learning;
using Tutor.KnowledgeComponents.API.Public.Learning.Assessment;
using Tutor.LanguageModelConversations.Core.Domain;

namespace Tutor.LanguageModelConversations.Core.UseCases.Integration;

public class ContextSelectionService : IContextSelectionService
{
    private readonly ISelectionService _taskSelector;
    private readonly IInstructionService _instructionSelector;
    private readonly ILanguageModelConverter _languageModelConverter;

    public ContextSelectionService(ISelectionService taskSelector, IInstructionService instructionSelector, ILanguageModelConverter languageModelConverter)
    {
        _taskSelector = taskSelector;
        _instructionSelector = instructionSelector;
        _languageModelConverter = languageModelConverter;
    }

    public Result<string> GetContextText(int contextGroup, int contextId, int? taskId, int learnerId)
    {
        if ((ContextGroup)contextGroup != ContextGroup.KnowledgeComponent)
            // Expand when LearningTasks are added (e.g. extract _languageModelConverter to base class and create subclasses for each context group)
            return Result.Fail(FailureCode.InvalidArgument);

        if (taskId != null)
        {
            var assessmentResult = _taskSelector.SelectAssessmentItemById(contextId, (int)taskId, learnerId);
            if (assessmentResult.IsFailed) return Result.Fail(assessmentResult.Errors);

            return _languageModelConverter.ConvertAssessmentItem(assessmentResult.Value);
        }

        var instructionResult = _instructionSelector.GetByKc(contextId, learnerId);
        if (instructionResult.IsFailed) return Result.Fail(instructionResult.Errors);

        return _languageModelConverter.ConvertInstructionalItems(instructionResult.Value);
    }
}
