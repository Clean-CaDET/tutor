using System;
using System.Collections.Generic;
using System.Linq;

namespace Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions
{
    public class MRQ : AssessmentEvent
    {
        public string Text { get; private set; }
        public List<MRQItem> Items { get; private set; }

        //TODO: See if we can remove these constructors, as we only have them because of tests.
        private MRQ() {}
        public MRQ(int id, int knowledgeComponentId, string text, List<MRQItem> items): base(id, knowledgeComponentId)
        {
            Text = text;
            Items = items;
        }

        public override Evaluation EvaluateSubmission(Submission submission)
        {
            if (submission is MRQSubmission mrqSubmission) return EvaluateMRQ(mrqSubmission);
            throw new ArgumentException("Incorrect submission supplied to MRQ with ID " + Id);
        }

        private MRQEvaluation EvaluateMRQ(MRQSubmission mrqSubmission)
        {
            var answerEvaluations = CheckAnswers(mrqSubmission.SubmittedAnswerIds);
            var correctness = (double)answerEvaluations.Count(a => a.SubmissionWasCorrect) / answerEvaluations.Count;
            
            return new MRQEvaluation(Id, correctness, answerEvaluations);
        }

        private List<MRQItemEvaluation> CheckAnswers(List<int> submittedAnswerIds)
        {
            var answerEvaluations = new List<MRQItemEvaluation>();
            foreach (var answer in Items)
            {
                var answerWasMarked = submittedAnswerIds.Contains(answer.Id);
                answerEvaluations.Add(new MRQItemEvaluation(answer, answer.IsCorrect ? answerWasMarked : !answerWasMarked));
            }

            return answerEvaluations;
        }
    }
}
