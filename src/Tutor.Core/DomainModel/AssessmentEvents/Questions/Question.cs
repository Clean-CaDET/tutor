using System.Collections.Generic;
using Tutor.Core.ContentModel.LearningObjects;

namespace Tutor.Core.DomainModel.AssessmentEvents.Questions
{
    public class Question : LearningObject
    {
        public string Text { get; private set; }
        public List<QuestionAnswer> PossibleAnswers { get; private set; }

        private Question() {}
        public Question(int id, int summaryId, string text, List<QuestionAnswer> possibleAnswers): base(id, summaryId)
        {
            Text = text;
            PossibleAnswers = possibleAnswers;
        }

        public List<AnswerEvaluation> EvaluateAnswers(List<int> submittedAnswerIds)
        {
            var evaluations = new List<AnswerEvaluation>();
            foreach (var answer in PossibleAnswers)
            {
                var answerWasMarked = submittedAnswerIds.Contains(answer.Id);
                evaluations.Add(new AnswerEvaluation(answer, answer.IsCorrect ? answerWasMarked : !answerWasMarked));
            }

            return evaluations;
        }
    }
}
