using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiChoiceQuestions;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.ShortAnswerQuestions;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;
using Tutor.LanguageModelConversations.Core.UseCases;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector;

public class LanguageModelConverter : ILanguageModelConverter
{
    public string ConvertAssessmentItem(AssessmentItemDto assessmentItem)
    {
        if (assessmentItem is SaqDto saq)
        {
            return LanguageModelConsts.TaskTitle + saq.Text +
                LanguageModelConsts.TaskAnswerTitle +
                LanguageModelConsts.TaskAnswer + string.Join(" ", saq.AcceptableAnswers) + 
                LanguageModelConsts.TaskCorrectAnswer + saq.Feedback;
        }
        else if (assessmentItem is McqDto mcq)
        {
            var incorrectAnswers = mcq.PossibleAnswers.Where(a => a != mcq.CorrectAnswer).ToList();
            return LanguageModelConsts.TaskTitle + mcq.Text +
                LanguageModelConsts.TaskAnswerTitle +
                string.Join("\n", incorrectAnswers.Select(a => LanguageModelConsts.TaskAnswer + a + LanguageModelConsts.TaskIncorrectAnswer)) +
                LanguageModelConsts.TaskAnswer + mcq.CorrectAnswer + LanguageModelConsts.TaskCorrectAnswer + mcq.Feedback;
        }
        else if (assessmentItem is MrqDto mrq)
        {
            var mrqItemsMap = mrq.Items.GroupBy(i => i.IsCorrect).ToDictionary(g => g.Key, g => g.ToList());
            return LanguageModelConsts.TaskTitle + mrq.Text +
                LanguageModelConsts.TaskAnswerTitle +
                string.Join("\n", mrqItemsMap[false].Select(item => LanguageModelConsts.TaskAnswer + item.Text + LanguageModelConsts.TaskIncorrectAnswer + item.Feedback)) +
                string.Join("\n", mrqItemsMap[true].Select(item => LanguageModelConsts.TaskAnswer + item.Text + LanguageModelConsts.TaskCorrectAnswer + item.Feedback));
        }
        else
        {
            return null;
        }
    }

    public string ConvertInstructionalItems(List<InstructionalItemDto> instructionalItems)
    {
        // Pitanje: da li ovaj toString ne treba koristiti
        // Ideja iza upotrebe: iskoristiti polimorfizam, svaka klasa naslednica zna na koji nacin da se predstavi
        // Cons: specifican nacin predstavljanja, nije klasican toString
        // (mozda prljamo kod klase necim sto nije njeno zaduzenje)
        // Alternativa: isto kao za AI, proveravati po tipu i za svaki definisati
        return string.Join("\n", instructionalItems.Select(item => item.ToString()));
    }
}
