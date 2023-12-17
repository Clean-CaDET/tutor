using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;

namespace Tutor.LanguageModelConversations.Core.UseCases.Integration;

public interface ILanguageModelConverter
{
    string ConvertAssessmentItem(AssessmentItemDto assessmentItem);
    string ConvertInstructionalItems(List<InstructionalItemDto> instructionalItems);
}
