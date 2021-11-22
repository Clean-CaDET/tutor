using System.Collections.Generic;
using Tutor.Core.ProgressModel.Submissions;

namespace Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks
{
    public class ArrangeTask : AssessmentEvent
    {
        public string Text { get; private set; }
        public List<ArrangeTaskContainer> Containers { get; private set; }

        private ArrangeTask() {}
        public ArrangeTask(int id, int knowledgeComponentId, string text, List<ArrangeTaskContainer> containers) : base(id, knowledgeComponentId)
        {
            Text = text;
            Containers = containers;
        }

        internal List<ArrangeTaskContainerEvaluation> EvaluateSubmission(List<ArrangeTaskContainerSubmission> containers)
        {
            var evaluations = new List<ArrangeTaskContainerEvaluation>();
            foreach (var container in Containers)
            {
                var submittedContainer = containers.Find(c => c.ContainerId == container.Id);
                //TODO: If null throw exception since it is an invalid submission and see what the controller should return following best practices.
                if (submittedContainer == null) return null;

                evaluations.Add(new ArrangeTaskContainerEvaluation(container,
                    container.IsCorrectSubmission(submittedContainer.ElementIds)));
            }

            return evaluations;
        }
    }
}