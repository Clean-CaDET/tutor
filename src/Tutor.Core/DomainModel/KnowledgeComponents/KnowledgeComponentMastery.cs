using FluentResults;
using System;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.KnowledgeComponents.AssessmentEventHelp;
using Tutor.Core.DomainModel.KnowledgeComponents.MoveOn;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class KnowledgeComponentMastery : EventSourcedAggregateRoot
    {
        public const double PassThreshold = 0.9;

        public double Mastery { get; private set; }
        public KnowledgeComponent KnowledgeComponent { get; private set; }
        public int LearnerId { get; private set; }
        public bool IsPassed { get; private set; }
        public bool IsSatisfied { get; private set; }
        public bool IsCompleted
        {
            get
            {
                foreach (AssessmentEvent assessmentEvent in KnowledgeComponent.AssessmentEvents)
                {
                    if (assessmentEvent.Submissions.Count == 0)
                        return false;
                }
                return true;
            }
        }

        public IMoveOnCriteria MoveOnCriteria { get; set; }

        private KnowledgeComponentMastery() { }

        public KnowledgeComponentMastery(KnowledgeComponent knowledgeComponent)
        {
            Mastery = 0.0;
            KnowledgeComponent = knowledgeComponent;
            IsPassed = false;
            IsSatisfied = false;
        }

        public Result<Evaluation> SubmitAssessmentEventAnswer(Submission submission)
        {
            bool IsCompletedBeforeSubmission = IsCompleted;
            Result<Evaluation> result = EvaluateAndSaveSubmission(submission);
            if (result.IsSuccess)
            {
                TryPass();
                TryComplete(IsCompletedBeforeSubmission);
            }

            return result;
        }

        private Result<Evaluation> EvaluateAndSaveSubmission(Submission submission)
        {
            var assessmentEvent = KnowledgeComponent.GetAssessmentEvent(submission.AssessmentEventId);
            if (assessmentEvent == null)
                return Result.Fail("No assessment event with ID: " + submission.AssessmentEventId);

            Evaluation evaluation = null;
            try
            {
                evaluation = assessmentEvent.EvaluateSubmission(submission);
            }
            catch (ArgumentException ex)
            {
                return Result.Fail(ex.Message);
            }
            if (evaluation.Correct) submission.MarkCorrect();
            submission.CorrectnessLevel = evaluation.CorrectnessLevel;

            Causes(new AssessmentEventAnswered()
            {
                Submission = submission,
                Timestamp = submission.TimeStamp
            });

            return Result.Ok(evaluation);
        }

        public Result<AssessmentEvent> SelectSuitableAssessmentEvent(IAssessmentEventSelector assessmentEventSelector)
        {
            var result = assessmentEventSelector.SelectSuitableAssessmentEvent(KnowledgeComponent.Id, LearnerId);
            if (result.IsSuccess)
                Causes(new AssessmentEventSelected()
                {
                    LearnerId = LearnerId,
                    KnowledgeComponentId = KnowledgeComponent.Id,
                    AssessmentEventId = result.Value.Id
                });

            return result;
        }

        private void TryPass()
        {
            if (IsPassed)
                return;

            if (Mastery >= PassThreshold)
            {
                Causes(new KnowledgeComponentPassed()
                {
                    KnowledgeComponentId = KnowledgeComponent.Id,
                    LearnerId = LearnerId
                });
                TrySatisfy();
            }
        }

        private void TryComplete(bool isCompletedBeforeSubmission)
        {
            if (isCompletedBeforeSubmission)
                return;

            if (IsCompleted)
            {
                Causes(new KnowledgeComponentCompleted()
                {
                    KnowledgeComponentId = KnowledgeComponent.Id,
                    LearnerId = LearnerId
                });
                TrySatisfy();
            }
        }

        private void TrySatisfy()
        {
            if (IsSatisfied)
                return;

            if (MoveOnCriteria.IsSatisfied(IsCompleted, IsPassed))
                Causes(new KnowledgeComponentSatisfied()
                {
                    KnowledgeComponentId = KnowledgeComponent.Id,
                    LearnerId = LearnerId
                });
        }

        public Result SeekHelpForAssessmentEvent(SoughtHelp helpEvent)
        {
            var assessmentEvent = KnowledgeComponent.GetAssessmentEvent(helpEvent.AssessmentEventId);
            if (assessmentEvent == null)
                return Result.Fail("No assessment event with ID: " + helpEvent.AssessmentEventId);

            Causes(helpEvent);
            return Result.Ok();
        }

        protected override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
        }

        private void When(AssessmentEventAnswered @event)
        {
            /* TODO: refactor to move the GetMaximumSubmissionCorrectness from AE to KCMastery, or a 
             * child object (which would be created here if it doesn't exist yet). The Apply method
             * should never fail, silently or otherwise, and fetching the AE can fail.
             */
            var assessmentEvent = KnowledgeComponent.GetAssessmentEvent(@event.Submission.AssessmentEventId);
            if (assessmentEvent == null)
                return;

            var currentCorrectnessLevel = assessmentEvent.GetMaximumSubmissionCorrectness();

            assessmentEvent.Submissions.Add(@event.Submission);

            if (currentCorrectnessLevel > @event.Submission.CorrectnessLevel) return;
            var kcMasteryIncrement = Math.Round(100.0 / KnowledgeComponent.AssessmentEvents.Count
                * (@event.Submission.CorrectnessLevel - currentCorrectnessLevel) / 100.0, 2);
            Mastery += kcMasteryIncrement;
        }

        private void When(KnowledgeComponentPassed @event)
        {
            IsPassed = true;
        }

        private void When(KnowledgeComponentCompleted @event)
        {
            // No action necessary since IsCompleted is calculated.
        }

        private void When(KnowledgeComponentSatisfied @event)
        {
            IsSatisfied = true;
        }

        private void When(AssessmentEventSelected @event)
        {
            /* 
             * TODO: save information that the AE has been selected somewhere in the 
             * model, probably in AeMastery when it's added.
             */
        }

        private void When(SoughtHelp @event)
        {
            /*
             * Possibly record how many times help was sought in AeMastery?             
             */
        }
    }
}