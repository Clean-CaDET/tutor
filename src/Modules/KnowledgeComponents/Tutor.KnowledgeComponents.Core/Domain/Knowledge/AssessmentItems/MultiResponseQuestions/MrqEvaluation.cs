namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;

public class MrqEvaluation : Evaluation
{
    public List<MrqItemEvaluation> ItemEvaluations { get; }
    public MrqEvaluation(double correctnessLevel, List<MrqItemEvaluation> evaluations) : base(correctnessLevel)
    {
        ItemEvaluations = evaluations;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        return ItemEvaluations;
    }
}