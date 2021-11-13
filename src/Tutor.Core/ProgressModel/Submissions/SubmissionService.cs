using System;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.ContentModel;
using Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges;
using Tutor.Core.DomainModel.AssessmentEvents.Questions;

namespace Tutor.Core.ProgressModel.Submissions
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ILearningObjectRepository _learningObjectRepository;
        private readonly ISubmissionRepository _submissionRepository;

        public SubmissionService(ILearningObjectRepository learningObjectRepository,
            ISubmissionRepository submissionRepository)
        {
            _learningObjectRepository = learningObjectRepository;
            _submissionRepository = submissionRepository;
        }

        public ChallengeEvaluation EvaluateChallenge(ChallengeSubmission submission)
        {
            var challenge = _learningObjectRepository.GetChallenge(submission.ChallengeId);

            if (challenge == null) return null;

            //var tester = new WorkspaceFunctionalityTester(_submissionRepository.GetWorkspacePath(submission.LearnerId));
            var evaluation = challenge.CheckChallengeFulfillment(submission.SourceCode, null);

            if (evaluation.ChallengeCompleted) submission.MarkCorrect();
            _submissionRepository.SaveChallengeSubmission(submission);

            //TODO: Tie in with Instructor and handle learnerId to get suitable LO for LO summaries.
            evaluation.ApplicableLOs =
                _learningObjectRepository.GetFirstLearningObjectsForSummaries(
                    evaluation.ApplicableHints.GetDistinctLearningObjectSummaries());
            evaluation.SolutionLO = _learningObjectRepository.GetLearningObjectForSummary(challenge.Solution.Id);

            return evaluation;
        }

        public List<AnswerEvaluation> EvaluateAnswers(QuestionSubmission submission)
        {
            var question = _learningObjectRepository.GetQuestion(submission.QuestionId);

            var evaluations = question.EvaluateAnswers(submission.SubmittedAnswerIds);

            if (evaluations.Select(a => a.SubmissionWasCorrect).All(c => c)) submission.MarkCorrect();
            _submissionRepository.SaveQuestionSubmission(submission);

            return evaluations;
        }

        public List<ArrangeTaskContainerEvaluation> EvaluateArrangeTask(ArrangeTaskSubmission submission)
        {
            var arrangeTask = _learningObjectRepository.GetArrangeTask(submission.ArrangeTaskId);
            var evaluations = arrangeTask.EvaluateSubmission(submission.Containers);
            if (evaluations == null) throw new InvalidOperationException("Invalid submission of arrange task.");

            if (evaluations.Select(e => e.SubmissionWasCorrect).All(c => c)) submission.MarkCorrect();
            _submissionRepository.SaveArrangeTaskSubmission(submission);

            return evaluations;
        }
    }
}