using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain.Reflections;

public class Reflection : Entity
{
    public int KnowledgeUnitId { get; private set; }
    public int Order { get; private set; }
    public string Name { get; private set; } = "";
    public List<ReflectionQuestion> Questions { get; private set; } = new();
    public List<ReflectionAnswer> Submissions { get; private set; } = new();

    public void Update(Reflection updatedReflection)
    {
        Name = updatedReflection.Name;
        Order = updatedReflection.Order;
        Questions = updatedReflection.Questions;
    }

    public Reflection Clone(int unitId)
    {
        return new Reflection
        {
            KnowledgeUnitId = unitId,
            Order = Order,
            Name = Name,
            Questions = Questions.Select(q => q.Clone()).ToList(),
        };
    }

    public List<ReflectionQuestion> GetOpenEndedQuestions()
    {
        return Questions.Where(q => q.Type == ReflectionQuestionType.OpenEnded).ToList();
    }

    public ReflectionQuestionAnswer? FindFirstMeaningfulAnswer(ReflectionQuestion question)
    {
        foreach (var submission in Submissions)
        {
            foreach (var a in submission.Answers)
            {
                if (a.QuestionId == question.Id && a.IsMeaningful())
                {
                    return a;
                }
            }
        }
        return null;
    }
}