using System;
using System.Collections.Generic;
using System.Linq;

namespace Tutor.Core.DomainModel.AssessmentItems.MultiResponseQuestions
{
    public class Mrq : AssessmentItem
    {
        public string Text { get; private set; }
        public List<MrqItem> Items { get; private set; }

        public override Evaluation Evaluate(Submission submission)
        {
            if (submission is MrqSubmission mrqSubmission) return EvaluateMrq(mrqSubmission);
            throw new ArgumentException("Incorrect submission supplied to MRQ with ID " + Id);
        }

        private MrqEvaluation EvaluateMrq(MrqSubmission mrqSubmission)
        {
            var answerEvaluations = CheckAnswers(mrqSubmission.SubmittedAnswerIds);
            var correctness = (double)answerEvaluations.Count(a => a.SubmissionWasCorrect) / answerEvaluations.Count;
            
            return new MrqEvaluation(correctness, answerEvaluations);
        }

        private List<MrqItemEvaluation> CheckAnswers(List<int> submittedAnswerIds)
        {
            var answerEvaluations = new List<MrqItemEvaluation>();
            foreach (var answer in Items)
            {
                var answerWasMarked = submittedAnswerIds.Contains(answer.Id);
                answerEvaluations.Add(new MrqItemEvaluation(answer, answer.IsCorrect ? answerWasMarked : !answerWasMarked));
            }

            return answerEvaluations;
        }
    }
}
