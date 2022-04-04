using FluentResults;
using System;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.KnowledgeComponentEvents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.SessionLifecycleEvents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.MoveOn;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries
{
    public class KnowledgeComponentMastery : EventSourcedAggregateRoot
    {
        private const double PassThreshold = 0.9;

        public double Mastery { get; private set; }
        public KnowledgeComponent KnowledgeComponent { get; private set; }
        public int LearnerId { get; private set; }
        public bool HasActiveSession { get; private set; }
        public bool IsPassed { get; private set; }
        public bool IsSatisfied { get; private set; }
        public bool IsCompleted
        {
            get
            {
                foreach (AssessmentItem assessmentItem in KnowledgeComponent.AssessmentItems)
                {
                    if (assessmentItem.Submissions.Count == 0)
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
        }

        public Result LaunchSession()
        {
            if (HasActiveSession)
                Causes(new SessionAbandoned()
                {
                    KnowledgeComponentId = KnowledgeComponent.Id,
                    LearnerId = LearnerId
                });

            Causes(new SessionLaunched()
            {
                KnowledgeComponentId = KnowledgeComponent.Id,
                LearnerId = LearnerId
            });
            return Result.Ok();
        }

        public Result TerminateSession()
        {
            if (!HasActiveSession)
                return Result.Fail("No active session to terminate.");

            Causes(new SessionTerminated()
            {
                KnowledgeComponentId = KnowledgeComponent.Id,
                LearnerId = LearnerId
            });
            return Result.Ok();
        }

        public Result<Evaluation> SubmitAssessmentItemAnswer(Submission submission)
        {
            if (!HasActiveSession)
                LaunchSession();

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
            var assessmentItem = KnowledgeComponent.GetAssessmentItem(submission.AssessmentItemId);
            if (assessmentItem == null)
                return Result.Fail("No assessment event with ID: " + submission.AssessmentItemId);

            Evaluation evaluation = null;
            try
            {
                evaluation = assessmentItem.EvaluateSubmission(submission);
            }
            catch (ArgumentException ex)
            {
                return Result.Fail(ex.Message);
            }
            if (evaluation.Correct) submission.MarkCorrect();
            submission.CorrectnessLevel = evaluation.CorrectnessLevel;

            Causes(new AssessmentItemAnswered()
            {
                Submission = submission,
                TimeStamp = submission.TimeStamp
            });

            return Result.Ok(evaluation);
        }

        public Result<AssessmentItem> SelectSuitableAssessmentItem(IAssessmentItemSelector assessmentItemSelector)
        {
            if (!HasActiveSession)
                LaunchSession();

            var ai = assessmentItemSelector.SelectSuitableAssessmentItem(KnowledgeComponent.AssessmentItems);
            if (ai == null) return Result.Fail("No assessment item found for knowledge component with ID " + KnowledgeComponent.Id);

            Causes(new AssessmentItemSelected()
            {
                LearnerId = LearnerId,
                KnowledgeComponentId = KnowledgeComponent.Id,
                AssessmentItemId = ai.Id
            });

            return Result.Ok(ai);
        }

        public Result RecordInstructionalItemSelection()
        {
            if (!HasActiveSession)
                LaunchSession();

            Causes(new InstructionalItemsSelected()
            {
                LearnerId = LearnerId,
                KnowledgeComponentId = KnowledgeComponent.Id
            });
            return Result.Ok();
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

        public Result SeekHelpForAssessmentItem(SoughtHelp helpEvent)
        {
            if (!HasActiveSession)
                LaunchSession();

            var assessmentItem = KnowledgeComponent.GetAssessmentItem(helpEvent.AssessmentItemId);
            if (assessmentItem == null)
                return Result.Fail("No assessment event with ID: " + helpEvent.AssessmentItemId);

            Causes(helpEvent);
            return Result.Ok();
        }

        protected override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
        }

        private void When(SessionLaunched @event)
        {
            HasActiveSession = true;
        }

        private void When(SessionTerminated @event)
        {
            HasActiveSession = false;
        }

        private void When(SessionAbandoned @event)
        {
            HasActiveSession = false;
        }

        private void When(AssessmentItemAnswered @event)
        {
            /* Probably refactor to move the GetMaximumSubmissionCorrectness from AE to KCMastery, or a 
             * child object (which would be created here if it doesn't exist yet). The Apply method
             * should never fail, silently or otherwise, and fetching the AE can fail.
             */
            var assessmentItem = KnowledgeComponent.GetAssessmentItem(@event.Submission.AssessmentItemId);
            if (assessmentItem == null)
                return;

            var currentCorrectnessLevel = assessmentItem.GetMaximumSubmissionCorrectness();

            assessmentItem.Submissions.Add(@event.Submission);

            if (currentCorrectnessLevel > @event.Submission.CorrectnessLevel) return;
            var kcMasteryIncrement = Math.Round(100.0 / KnowledgeComponent.AssessmentItems.Count
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

        private void When(AssessmentItemSelected @event)
        {
            /* 
             * Possibly save information that the AE has been selected somewhere in the 
             * model.
             */
        }

        private void When(InstructionalItemsSelected item)
        {
            // No action necessary for now.
        }

        private void When(SoughtHelp @event)
        {
            /*
             * Possibly record how many times help was sought somewhere?             
             */
        }
    }
}