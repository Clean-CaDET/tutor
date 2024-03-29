﻿namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;

public class Mrq : AssessmentItem
{
    public string Text { get; private set; }
    public List<MrqItem> Items { get; private set; }

    protected override void ClearSolution()
    {
        Items.ForEach(i =>
        {
            i.Feedback = "";
            i.IsCorrect = false;
        });
    }

    public override Evaluation Evaluate(Submission submission)
    {
        if (submission is MrqSubmission mrqSubmission) return EvaluateMrq(mrqSubmission);
        throw new ArgumentException("Incorrect submission supplied to MRQ with ID " + Id);
    }

    private MrqEvaluation EvaluateMrq(MrqSubmission mrqSubmission)
    {
        var answerEvaluations = CheckAnswers(mrqSubmission.SubmittedAnswers);
        var correctness = (double)answerEvaluations.Count(a => a.SubmissionWasCorrect) / answerEvaluations.Count;

        return new MrqEvaluation(correctness, answerEvaluations);
    }

    private List<MrqItemEvaluation> CheckAnswers(List<string> submittedAnswers)
    {
        var answerEvaluations = new List<MrqItemEvaluation>();
        foreach (var answer in Items)
        {
            var answerWasMarked = submittedAnswers.Contains(answer.Text);
            answerEvaluations.Add(new MrqItemEvaluation(answer, answer.IsCorrect ? answerWasMarked : !answerWasMarked));
        }

        return answerEvaluations;
    }

    public override AssessmentItem Clone()
    {
        return new Mrq
        {
            Text = Text,
            Items = Items.Select(i => new MrqItem(i.Text, i.IsCorrect, i.Feedback)).ToList(),
            Order = Order,
            Hints = Hints
        };
    }
}