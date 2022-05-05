using System;
using System.Collections.Generic;
using System.Linq;

namespace Tutor.Core.DomainModel.AssessmentItems.ArrangeTasks
{
    public class ArrangeTask : AssessmentItem
    {
        public string Text { get; private set; }
        public List<ArrangeTaskContainer> Containers { get; private set; }

        public override Evaluation Evaluate(Submission submission)
        {
            ValidateSubmission(submission);
            return EvaluateAt(submission as ArrangeTaskSubmission);
        }

        private void ValidateSubmission(Submission submission)
        {
            if (submission is not ArrangeTaskSubmission atSubmission)
                throw new ArgumentException("Incorrect submission type supplied to Arrange Task with ID " + Id);

            var submittedContainerIds = atSubmission.Containers.Select(c => c.ArrangeTaskContainerId).ToList();
            var actualContainerIds = Containers.Select(c => c.Id).ToList();
            if (!(submittedContainerIds.Count == actualContainerIds.Count && submittedContainerIds.Any(actualContainerIds.Contains)))
                throw new ArgumentException("Incorrect ArrangeTaskContainers supplied to Arrange Task with ID " + Id);

            var submittedElementIds = atSubmission.Containers.SelectMany(c => c.ElementIds).ToList();
            var actualElementIds = Containers.SelectMany(c => c.Elements).Select(e => e.Id).ToList();
            if (!(submittedElementIds.Count == actualElementIds.Count && submittedElementIds.Any(actualElementIds.Contains)))
                throw new ArgumentException("Incorrect Elements supplied to Arrange Task with ID " + Id);
        }

        private Evaluation EvaluateAt(ArrangeTaskSubmission atSubmission)
        {
            var evaluations = EvaluateContainers(atSubmission.Containers);
            var correctness = 1 - ((double) evaluations.Sum(c => c.IncorrectElementsCount) / Containers.Sum(c => c.Elements.Count));

            return new ArrangeTaskEvaluation(correctness, evaluations);
        }

        private List<ArrangeTaskContainerEvaluation> EvaluateContainers(List<ArrangeTaskContainerSubmission> containers)
        {
            var evaluations = new List<ArrangeTaskContainerEvaluation>();
            foreach (var container in Containers)
            {
                var submittedContainer = containers.Find(c => c.ArrangeTaskContainerId == container.Id);

                evaluations.Add(new ArrangeTaskContainerEvaluation(container,
                    container.CountIncorrectElements(submittedContainer?.ElementIds)));
            }

            return evaluations;
        }
    }
}