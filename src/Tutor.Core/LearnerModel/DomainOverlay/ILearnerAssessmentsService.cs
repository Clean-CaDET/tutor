﻿using FluentResults;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.KnowledgeComponentEvents;

namespace Tutor.Core.LearnerModel.DomainOverlay
{
    public interface ILearnerAssessmentsService
    {
        Result<Evaluation> EvaluateAndSaveSubmission(Submission submission);
        Result<double> GetMaxSubmissionCorrectness(int aiId, int learnerId);
        Result SeekChallengeHints(int learnerId, int assessmentItemId);
        Result SeekChallengeSolution(int learnerId, int assessmentItemId);
        Result SaveInstructorMessage(string message, int kcId, int learnerId);
    }
}