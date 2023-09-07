using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.CodeCompletionQuestions;

public class CcqItem : ValueObject
{
    public int Order { get; private set; }
    public string Answer { get; private set; }
    public int Length { get; private set; }
    public bool IgnoreSpace {get; private set; }

    [JsonConstructor]
    public CcqItem(int order, string answer, int length, bool ignoreSpace)
    {
        Order = order;
        Answer = answer;
        Length = length;
        IgnoreSpace = ignoreSpace;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Answer;
        yield return Order;
        yield return Length;
        yield return IgnoreSpace;
    }

    public void HideAnswer()
    {
        Answer = string.Empty;
    }

    public bool IsCorrect(string submission)
    {
        if (!IgnoreSpace) return submission.Equals(Answer);

        submission = Regex.Replace(submission, @"\s", "");
        var answer= Regex.Replace(Answer, @"\s", "");
        return submission.Equals(answer);
    }
}