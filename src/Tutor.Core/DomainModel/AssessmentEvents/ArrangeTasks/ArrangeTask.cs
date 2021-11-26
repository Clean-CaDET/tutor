using System;
using System.Collections.Generic;
using System.Linq;

namespace Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks
{
    public class ArrangeTask : AssessmentEvent
    {
        public string Text { get; private set; }
        public List<ArrangeTaskContainer> Containers { get; private set; }

        public override Evaluation EvaluateSubmission(Submission submission)
        {
            if (submission is ArrangeTaskSubmission atSubmission) return EvaluateAT(atSubmission);
            throw new ArgumentException("Incorrect submission supplied to Arrange Task with ID " + Id);
        }

        private Evaluation EvaluateAT(ArrangeTaskSubmission atSubmission)
        {
            var evaluations = EvaluateContainers(atSubmission.Containers);
            var correctness = (double) evaluations.Count(c => c.SubmissionWasCorrect) / evaluations.Count;

            return new ArrangeTaskEvaluation(Id, correctness, evaluations);
        }

        private List<ArrangeTaskContainerEvaluation> EvaluateContainers(List<ArrangeTaskContainerSubmission> containers)
        {
            var evaluations = new List<ArrangeTaskContainerEvaluation>();
            foreach (var container in Containers)
            {
                var submittedContainer = containers.Find(c => c.Id == container.Id);
                if (submittedContainer == null) throw new ArgumentException("No ArrangeTaskContainer found with ID " + container.Id);

                evaluations.Add(new ArrangeTaskContainerEvaluation(container,
                    container.IsCorrectSubmission(submittedContainer.ElementIds)));
            }

            return evaluations;
        }
    }
}