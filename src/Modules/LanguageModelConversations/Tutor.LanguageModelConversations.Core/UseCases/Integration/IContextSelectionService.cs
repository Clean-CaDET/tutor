using FluentResults;

namespace Tutor.LanguageModelConversations.Core.UseCases.Integration;

public interface IContextSelectionService
{
    Result<string> GetContextText(int contextGroup, int contextId, int? taskId, int learnerId);
}
